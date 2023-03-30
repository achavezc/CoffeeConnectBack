using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adjunto;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using CoffeeConnect.Service.Adjunto;
using Core.Common.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CoffeeConnect.Service
{
    public partial class OrdenProcesoPlantaService : IOrdenProcesoPlantaService
    {
        private readonly IMapper _Mapper;
        private IOrdenProcesoPlantaRepository _IOrdenProcesoPlantaRepository;
        public IOptions<FileServerSettings> _fileServerSettings;
        private ICorrelativoRepository _ICorrelativoRepository;
        private IMaestroRepository _IMaestroRepository;
        private INotaIngresoAlmacenPlantaRepository _INotaIngresoAlmacenPlantaRepository;
        private INotaIngresoProductoTerminadoAlmacenPlantaRepository _INotaIngresoProductoTerminadoAlmacenPlantaRepository;




        public OrdenProcesoPlantaService(IOrdenProcesoPlantaRepository OrdenProcesoPlantaRepository, INotaIngresoAlmacenPlantaRepository NotaIngresoAlmacenPlantaRepository, INotaIngresoProductoTerminadoAlmacenPlantaRepository NotaIngresoProductoTerminadoAlmacenPlantaRepository, ICorrelativoRepository correlativoRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings, IMaestroRepository maestroRepository)
        {
            _IOrdenProcesoPlantaRepository = OrdenProcesoPlantaRepository;
            _INotaIngresoAlmacenPlantaRepository = NotaIngresoAlmacenPlantaRepository;
            _INotaIngresoProductoTerminadoAlmacenPlantaRepository = NotaIngresoProductoTerminadoAlmacenPlantaRepository;
            _Mapper = mapper;
            _fileServerSettings = fileServerSettings;
            _ICorrelativoRepository = correlativoRepository;
            _IMaestroRepository = maestroRepository;
        }

        public List<ConsultaOrdenProcesoPlantaBE> ConsultarOrdenProcesoPlanta(ConsultaOrdenProcesoPlantaRequestDTO request)
        {
            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Comercial.Contrato.ValidacionRangoFechaMayor2anios.Label" });

            var list = _IOrdenProcesoPlantaRepository.ConsultarOrdenProcesoPlanta(request);


            // obtener certificaciones
            List<ConsultaDetalleTablaBE> lista = _IMaestroRepository.ConsultarDetalleTablaDeTablas(request.EmpresaId, String.Empty).ToList();
            List<ConsultaDetalleTablaBE> certificaciones = lista.Where(a => a.CodigoTabla.Trim().Equals("TipoCertificacionPlanta")).ToList();

            foreach (ConsultaOrdenProcesoPlantaBE obj in list)
            {
                

                string[] certificacionesIds = obj.CertificacionId.Split('|');
                string certificacionLabel = string.Empty;
                if (certificacionesIds.Length > 0)
                {
                    foreach (string certificacionId in certificacionesIds)
                    {
                        ConsultaDetalleTablaBE certificacion = certificaciones.Where(a => a.Codigo == certificacionId).FirstOrDefault();
                        if (certificacion != null)
                        {
                            certificacionLabel = certificacionLabel + certificacion.Label + " ";
                        }
                    }
                }

                // obtener certificaciones
                obj.Certificacion = certificacionLabel;
            }

            return list.ToList();
        }

        public int RegistrarOrdenProcesoPlanta(RegistrarActualizarOrdenProcesoPlantaRequestDTO request, IFormFile file)

        //public int RegistrarOrdenProcesoPlanta(RegistrarActualizarOrdenProcesoPlantaRequestDTO request )
        {
            OrdenProcesoPlanta OrdenProcesoPlanta = _Mapper.Map<OrdenProcesoPlanta>(request);
            OrdenProcesoPlanta.FechaRegistro = DateTime.Now;
            OrdenProcesoPlanta.UsuarioRegistro = request.Usuario;
            OrdenProcesoPlanta.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.OrdenProcesoPlanta);

            var AdjuntoBl = new AdjuntarArchivosBL(_fileServerSettings);
           
            byte[] fileBytes = null;

            if (file != null)
            {
                if (file.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        fileBytes = ms.ToArray();
                        string s = Convert.ToBase64String(fileBytes);
                    }

                    OrdenProcesoPlanta.NombreArchivo = file.FileName;
                    //Adjuntos
                    ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
                    {
                        filtros = new AdjuntarArchivosDTO()
                        {
                            archivoStream = fileBytes,
                            filename = file.FileName,
                        },
                        pathFile = _fileServerSettings.Value.OrdenProcesoPlanta
                    });
                    OrdenProcesoPlanta.PathArchivo = _fileServerSettings.Value.OrdenProcesoPlanta + "\\" + response.ficheroReal;
                }
            }

            int OrdenProcesoPlantaId = _IOrdenProcesoPlantaRepository.Insertar(OrdenProcesoPlanta);

             
            foreach (OrdenProcesoPlantaDetalle detalle in request.OrdenProcesoPlantaDetalle)
            {
                decimal cantidadDisponible = 0;
                decimal kilosBrutos  = 0;               
                decimal cantidadOrdenProceso = 0;
                decimal kilosNetosOrdenProceso = 0;

                DateTime? fechaRegistro=null;

                if (OrdenProcesoPlanta.TipoProcesoId =="03" || OrdenProcesoPlanta.TipoProcesoId == "04") //Reproceso o Transformacion (Resultado Secado)
                {
                    ConsultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE consultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE =_INotaIngresoProductoTerminadoAlmacenPlantaRepository.ConsultarNotaIngresoProductoTerminadoAlmacenPlantaPorId(detalle.NotaIngresoAlmacenPlantaId);
                    cantidadOrdenProceso = consultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE.CantidadOrdenProceso;
                    cantidadDisponible = consultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE.Cantidad - cantidadOrdenProceso;
                    kilosBrutos = consultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE.KilosBrutos;
                    fechaRegistro = consultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE.FechaRegistro;
                    kilosNetosOrdenProceso = consultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE.KilosNetosOrdenProceso;

                    string estado = NotaIngresoProductoTerminadoAlmacenPlantaEstados.Ingresado;

                    if (detalle.Cantidad >= cantidadDisponible)
                    {
                        estado = NotaIngresoProductoTerminadoAlmacenPlantaEstados.Procesado;
                    }

                    _INotaIngresoProductoTerminadoAlmacenPlantaRepository.ActualizarCantidadOrdenProcesoEstado(detalle.NotaIngresoAlmacenPlantaId, cantidadOrdenProceso + detalle.Cantidad, kilosNetosOrdenProceso + detalle.KilosNetos, DateTime.Now, request.Usuario, estado);
                }
                else
                {
                    ConsultaNotaIngresoAlmacenPlantaPorIdBE consultaNotaIngresoAlmacenPlantaPorIdBE = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaPorId(detalle.NotaIngresoAlmacenPlantaId) ;
                    cantidadOrdenProceso = consultaNotaIngresoAlmacenPlantaPorIdBE.CantidadOrdenProceso.Value;
                    cantidadDisponible = consultaNotaIngresoAlmacenPlantaPorIdBE.Cantidad.Value - cantidadOrdenProceso;
                    kilosBrutos = consultaNotaIngresoAlmacenPlantaPorIdBE.PesoBruto.Value;
                    fechaRegistro= consultaNotaIngresoAlmacenPlantaPorIdBE.FechaRegistro;
                    kilosNetosOrdenProceso = consultaNotaIngresoAlmacenPlantaPorIdBE.KilosNetosOrdenProceso.Value;

                    string estado = NotaIngresoAlmacenPlantaEstados.Ingresado;

                    if (detalle.Cantidad >= cantidadDisponible)
                    {
                        estado = NotaIngresoAlmacenPlantaEstados.Procesado;
                    }

                    _INotaIngresoAlmacenPlantaRepository.ActualizarCantidadOrdenProcesoEstado(detalle.NotaIngresoAlmacenPlantaId, cantidadOrdenProceso + detalle.Cantidad, kilosNetosOrdenProceso + detalle.KilosNetos, DateTime.Now, request.Usuario, estado);
                }


                detalle.KilosBrutosNotaIngreso = kilosBrutos;


                
                
                detalle.FechaIngresoAlmacen = fechaRegistro.Value;

                detalle.OrdenProcesoPlantaId = OrdenProcesoPlantaId;

                _IOrdenProcesoPlantaRepository.InsertarProcesoPlantaDetalle(detalle);
            }
            return OrdenProcesoPlantaId;
        }

        public int ActualizarOrdenProcesoPlanta(RegistrarActualizarOrdenProcesoPlantaRequestDTO request, IFormFile file)
        {
            OrdenProcesoPlanta ordenProcesoPlanta = _Mapper.Map<OrdenProcesoPlanta>(request);

            var AdjuntoBl = new AdjuntarArchivosBL(_fileServerSettings);
            byte[] fileBytes = null;
            if (file != null)
            {
                if (file.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        fileBytes = ms.ToArray();
                        string s = Convert.ToBase64String(fileBytes);
                    }

                    ordenProcesoPlanta.NombreArchivo = file.FileName;
                    ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
                    {
                        filtros = new AdjuntarArchivosDTO()
                        {
                            archivoStream = fileBytes,
                            filename = file.FileName,
                        },
                        pathFile = _fileServerSettings.Value.OrdenProcesoPlanta

                    });

                    ordenProcesoPlanta.PathArchivo = _fileServerSettings.Value.OrdenProcesoPlanta + "\\" + response.ficheroReal;
                }
            }

            ordenProcesoPlanta.FechaUltimaActualizacion = DateTime.Now;
            ordenProcesoPlanta.UsuarioUltimaActualizacion = request.Usuario;
            int affected = _IOrdenProcesoPlantaRepository.Actualizar(ordenProcesoPlanta);

            List<OrdenProcesoPlantaDetalleBE> detalleOrdenProcesoPlanta =  _IOrdenProcesoPlantaRepository.ConsultarOrdenProcesoPlantaDetallePorId(request.OrdenProcesoPlantaId).ToList();


            foreach (OrdenProcesoPlantaDetalleBE detalle in detalleOrdenProcesoPlanta)
            {
                if (ordenProcesoPlanta.TipoProcesoId == "03" || ordenProcesoPlanta.TipoProcesoId == "04") //Reproceso o Transformacion (Resultado Secado)
                {
                    ConsultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE consultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE = _INotaIngresoProductoTerminadoAlmacenPlantaRepository.ConsultarNotaIngresoProductoTerminadoAlmacenPlantaPorId(detalle.NotaIngresoAlmacenPlantaId);

                    string estado = NotaIngresoAlmacenPlantaEstados.Procesado;

                    if (consultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE.EstadoId == NotaIngresoProductoTerminadoAlmacenPlantaEstados.Procesado)
                    {
                        estado = NotaIngresoAlmacenPlantaEstados.Ingresado;
                    }

                    _INotaIngresoProductoTerminadoAlmacenPlantaRepository.ActualizarCantidadOrdenProcesoEstado(detalle.NotaIngresoAlmacenPlantaId, consultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE.CantidadOrdenProceso - detalle.Cantidad, consultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE.KilosNetosOrdenProceso - detalle.KilosNetos, DateTime.Now, request.Usuario, estado);

                }
                else
                {
                    ConsultaNotaIngresoAlmacenPlantaPorIdBE consultaNotaIngresoAlmacenPlantaPorIdBE = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaPorId(detalle.NotaIngresoAlmacenPlantaId);

                    string estado = NotaIngresoAlmacenPlantaEstados.Procesado;

                    if (consultaNotaIngresoAlmacenPlantaPorIdBE.EstadoId == NotaIngresoAlmacenPlantaEstados.Procesado)
                    {
                        estado = NotaIngresoAlmacenPlantaEstados.Ingresado;
                    }

                    _INotaIngresoAlmacenPlantaRepository.ActualizarCantidadOrdenProcesoEstado(detalle.NotaIngresoAlmacenPlantaId, consultaNotaIngresoAlmacenPlantaPorIdBE.CantidadOrdenProceso.Value - detalle.Cantidad, consultaNotaIngresoAlmacenPlantaPorIdBE.KilosNetosOrdenProceso.Value - detalle.KilosNetos, DateTime.Now, request.Usuario, estado);


                    
                }
            }

            _IOrdenProcesoPlantaRepository.EliminarProcesoPlantaDetalle(ordenProcesoPlanta.OrdenProcesoPlantaId);


            foreach (OrdenProcesoPlantaDetalle detalle in request.OrdenProcesoPlantaDetalle)
            {
                decimal cantidadDisponible = 0;
                decimal kilosBrutos = 0;
                decimal cantidadOrdenProceso = 0;
                decimal kilosNetosOrdenProceso = 0;

                DateTime? fechaRegistro = null;

                if (ordenProcesoPlanta.TipoProcesoId == "03" || ordenProcesoPlanta.TipoProcesoId == "04") //Reproceso o Transformacion (Resultado Secado)
                {
                    ConsultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE consultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE = _INotaIngresoProductoTerminadoAlmacenPlantaRepository.ConsultarNotaIngresoProductoTerminadoAlmacenPlantaPorId(detalle.NotaIngresoAlmacenPlantaId);

                    cantidadOrdenProceso = consultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE.CantidadOrdenProceso;
                    cantidadDisponible = consultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE.Cantidad - cantidadOrdenProceso;
                    kilosBrutos = consultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE.KilosBrutos;
                    fechaRegistro = consultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE.FechaRegistro;
                    kilosNetosOrdenProceso = consultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE.KilosNetosOrdenProceso;

                    string estado = NotaIngresoProductoTerminadoAlmacenPlantaEstados.Ingresado;

                    if (detalle.Cantidad >= cantidadDisponible)
                    {
                        estado = NotaIngresoProductoTerminadoAlmacenPlantaEstados.Procesado;
                    }

                    _INotaIngresoProductoTerminadoAlmacenPlantaRepository.ActualizarCantidadOrdenProcesoEstado(detalle.NotaIngresoAlmacenPlantaId, cantidadOrdenProceso + detalle.Cantidad, kilosNetosOrdenProceso + detalle.KilosNetos, DateTime.Now, request.Usuario, estado);


                }
                else
                {
                    ConsultaNotaIngresoAlmacenPlantaPorIdBE consultaNotaIngresoAlmacenPlantaPorIdBE = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaPorId(detalle.NotaIngresoAlmacenPlantaId);
                    cantidadDisponible = consultaNotaIngresoAlmacenPlantaPorIdBE.Cantidad.Value - consultaNotaIngresoAlmacenPlantaPorIdBE.CantidadOrdenProceso.Value;
                    fechaRegistro = consultaNotaIngresoAlmacenPlantaPorIdBE.FechaRegistro;
                    string estado = NotaIngresoAlmacenPlantaEstados.Ingresado;

                    if (detalle.Cantidad >= cantidadDisponible)
                    {
                        estado = NotaIngresoAlmacenPlantaEstados.Procesado;
                    }

                    _INotaIngresoAlmacenPlantaRepository.ActualizarCantidadOrdenProcesoEstado(detalle.NotaIngresoAlmacenPlantaId, consultaNotaIngresoAlmacenPlantaPorIdBE.CantidadOrdenProceso.Value + detalle.Cantidad, consultaNotaIngresoAlmacenPlantaPorIdBE.KilosNetosOrdenProceso.Value + detalle.KilosNetos, DateTime.Now, request.Usuario, estado);
                }
                detalle.FechaIngresoAlmacen = fechaRegistro;

                detalle.OrdenProcesoPlantaId = request.OrdenProcesoPlantaId;

                _IOrdenProcesoPlantaRepository.InsertarProcesoPlantaDetalle(detalle);
            }


            return affected;
        }

        public ConsultaOrdenProcesoPlantaPorIdBE ConsultarOrdenProcesoPlantaPorId(ConsultaOrdenProcesoPlantaPorIdRequestDTO request)
        {
            ConsultaOrdenProcesoPlantaPorIdBE consultaOrdenProcesoPlantaPorIdBE = _IOrdenProcesoPlantaRepository.ConsultarOrdenProcesoPlantaPorId(request.OrdenProcesoPlantaId);

            if (consultaOrdenProcesoPlantaPorIdBE != null)
            {
                consultaOrdenProcesoPlantaPorIdBE.detalle = _IOrdenProcesoPlantaRepository.ConsultarOrdenProcesoPlantaDetallePorId(request.OrdenProcesoPlantaId).ToList();


                 


            }

            return consultaOrdenProcesoPlantaPorIdBE;
        }

        public ConsultaOrdenProcesoPlantaPorIdBE ConsultarOrdenProcesoPlantaDetallePorId(ConsultaOrdenProcesoPlantaPorIdRequestDTO request)
        {
            ConsultaOrdenProcesoPlantaPorIdBE consultaOrdenProcesoPlantaPorIdBE = new ConsultaOrdenProcesoPlantaPorIdBE();


            consultaOrdenProcesoPlantaPorIdBE.detalle = _IOrdenProcesoPlantaRepository.ConsultarOrdenProcesoPlantaDetallePorId(request.OrdenProcesoPlantaId).ToList();


            return consultaOrdenProcesoPlantaPorIdBE;
        }

        //public int AnularOrdenProcesoPlanta(AnularOrdenProcesoPlantaRequestDTO request)
        //{
        //    int result = 0;
        //    if(request.OrdenProcesoPlantaId > 0)
        //    {
        //        result = _IOrdenProcesoPlantaRepository.Anular(request.OrdenProcesoPlantaId, DateTime.Now, request.Usuario, OrdenProcesoPlantaEstados.Anulado);
        //    }
        //    return result;
        //}

        //public ConsultarImpresionOrdenProcesoPlantaResponseDTO ConsultarImpresionOrdenProcesoPlanta(ConsultarImpresionOrdenProcesoPlantaRequestDTO request)
        //{
        //    ConsultarImpresionOrdenProcesoPlantaResponseDTO response = new ConsultarImpresionOrdenProcesoPlantaResponseDTO();
        //    response.listOrdenProcesoPlanta = _IOrdenProcesoPlantaRepository.ConsultarImpresionOrdenProcesoPlanta(request.OrdenProcesoPlantaId);
        //    response.listDetalleOrdenProcesoPlanta = _IOrdenProcesoPlantaRepository.ConsultarOrdenProcesoPlantaDetallePorId(request.OrdenProcesoPlantaId);
        //    return response;
        //}

        private String getRutaFisica(string pathFile)
        {
            return _fileServerSettings.Value.RutaPrincipal + pathFile;
        }

        public ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request)
        {
            try
            {
                string rutaReal = Path.Combine(getRutaFisica(request.PathFile));

                if (File.Exists(rutaReal))
                {
                    byte[] archivoBytes = File.ReadAllBytes(rutaReal);
                    return new ResponseDescargarArchivoDTO()
                    {
                        archivoBytes = archivoBytes,
                        errores = new Dictionary<string, string>(),
                        ficheroVisual = request.ArchivoVisual
                    };
                }
                else
                {
                    var resp = new ResponseDescargarArchivoDTO()
                    {
                        archivoBytes = null,
                        errores = new Dictionary<string, string>(),
                        ficheroVisual = ""
                    };
                    resp.errores.Add("Error", "El Archivo solicitado no existe");
                    return resp;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
