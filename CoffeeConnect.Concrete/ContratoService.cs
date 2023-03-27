
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
    public partial class ContratoService : IContratoService
    {
        private readonly IMapper _Mapper;
        private IContratoRepository _IContratoRepository;
        private IAduanaRepository _IAduanaRepository;
        private ICorrelativoRepository _ICorrelativoRepository;
        public IOptions<FileServerSettings> _fileServerSettings;
        private IMaestroRepository _IMaestroRepository;
        private IEmpresaRepository _IEmpresaRepository;
        private IContratoCompraRepository _IContratoCompraRepository;
        

        public ContratoService(IAduanaRepository AduanaRepository, IContratoRepository contratoRepository, IContratoCompraRepository contratoCompraRepository, ICorrelativoRepository correlativoRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings, IMaestroRepository maestroRepository, IEmpresaRepository empresaRepository)
        {
            _IContratoRepository = contratoRepository;
            _IAduanaRepository = AduanaRepository;
            _fileServerSettings = fileServerSettings;
            _ICorrelativoRepository = correlativoRepository;
            _Mapper = mapper;
            _IMaestroRepository = maestroRepository;
            _IEmpresaRepository = empresaRepository;
            _IContratoCompraRepository = contratoCompraRepository;
        }

        private String getRutaFisica(string pathFile)
        {
            return _fileServerSettings.Value.RutaPrincipal + pathFile;
        }

        public List<ConsultaContratoBE> ConsultarContrato(ConsultaContratoRequestDTO request)
        {
            if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFin == null || request.FechaFin == DateTime.MinValue || string.IsNullOrEmpty(request.EstadoId))
                throw new ResultException(new Result { ErrCode = "01", Message = "Comercial.Cliente.ValidacionSeleccioneMinimoUnFiltro.Label" });

            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Comercial.Contrato.ValidacionRangoFechaMayor2anios.Label" });

            var list = _IContratoRepository.ConsultarContrato(request);

            List<ConsultaDetalleTablaBE> lista = _IMaestroRepository.ConsultarDetalleTablaDeTablas(request.EmpresaId,String.Empty).ToList();


            foreach (ConsultaContratoBE contrato in list)
            {
                string[] certificacionesIds = contrato.TipoCertificacionId.Split('|');

                string certificacionLabel = string.Empty;
                string tipoContratoLabel = string.Empty;


                if (certificacionesIds.Length > 0)
                {

                    List<ConsultaDetalleTablaBE> certificaciones = lista.Where(a => a.CodigoTabla.Trim().Equals("TipoCertificacion")).ToList();
                    
                    foreach (string certificacionId in certificacionesIds)
                    {

                        ConsultaDetalleTablaBE certificacion = certificaciones.Where(a => a.Codigo == certificacionId).FirstOrDefault();

                        if (certificacion != null)
                        {
                            certificacionLabel = certificacionLabel + certificacion.Label + " ";
                        }
                    }

                }
                List<ConsultaDetalleTablaBE> tipoContratos = lista.Where(a => a.CodigoTabla.Trim().Equals("TipoContrato")).ToList();
                ConsultaDetalleTablaBE tipoContrato = tipoContratos.Where(a => a.Codigo == contrato.TipoContratoId).FirstOrDefault();
                if (tipoContrato != null)
                {
                    tipoContratoLabel = tipoContratoLabel + tipoContrato.Label + " ";
                }

                contrato.TipoContrato = tipoContratoLabel;
                contrato.TipoCertificacion = certificacionLabel;
            }

            


            return list.ToList();
        }

        public int RegistrarContrato(RegistrarActualizarContratoRequestDTO request, IFormFile file)
        {
            Contrato contrato = _Mapper.Map<Contrato>(request);
            contrato.FechaRegistro = DateTime.Now;
            //contrato.NombreArchivo = file.FileName;
            contrato.UsuarioRegistro = request.Usuario;
            //contrato.Numero = _ICorrelativoRepository.Obtener(null, Documentos.Contrato);


            

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
                        // act on the Base64 data
                    }

                    contrato.NombreArchivo = file.FileName;
                    //Adjuntos
                    ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
                    {
                        filtros = new AdjuntarArchivosDTO()
                        {
                            archivoStream = fileBytes,
                            filename = file.FileName,
                        },
                        pathFile = _fileServerSettings.Value.Contrato
                    });
                    contrato.PathArchivo = _fileServerSettings.Value.Contrato + "\\" + response.ficheroReal;
                }

            }

            //if (file != null)
            //{
            //    if (file.Length > 0)
            //    {
            //        //Adjuntos
            //        ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
            //        {
            //            filtros = new AdjuntarArchivosDTO()
            //            {
            //                archivoStream = fileBytes,
            //                filename = file.FileName,
            //            },
            //            pathFile = _fileServerSettings.Value.FincasCertificacion
            //        });
            //        contrato.PathArchivo = _fileServerSettings.Value.FincasCertificacion + "\\" + response.ficheroReal;
            //    }
            //}

            Empresa empresa = _IEmpresaRepository.ObtenerEmpresaPorId(request.EmpresaId);

            //if(empresa.TipoEmpresaid != "01")
            //{
            //    contrato.EstadoId = ContratoEstados.Asignado;
            //}

            int cantidadContratosExistentes = _IContratoRepository.ValidadContratoExistente(request.EmpresaId, request.Numero);
            
            if (cantidadContratosExistentes > 0) 
            {
                throw new ResultException(new Result { ErrCode = "02", Message = "Comercial.Contrato.ValidacionContratoExistente.Label" });

            }

            

            int affected = _IContratoRepository.Insertar(contrato);

            return affected;
        }

        public ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request)
        {
            try
            {
                String rutaReal = Path.Combine(getRutaFisica(request.PathFile));

                if (File.Exists(rutaReal))
                {

                    Byte[] archivoBytes = System.IO.File.ReadAllBytes(rutaReal);
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

        public int ActualizarContrato(RegistrarActualizarContratoRequestDTO request, IFormFile file)
        {
            Contrato contrato = _Mapper.Map<Contrato>(request);
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
                        // act on the Base64 data
                    }

                    contrato.NombreArchivo = file.FileName;
                    ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
                    {
                        filtros = new AdjuntarArchivosDTO()
                        {
                            archivoStream = fileBytes,
                            filename = file.FileName,
                        },
                        pathFile = _fileServerSettings.Value.Contrato
                    });

                    contrato.PathArchivo = _fileServerSettings.Value.Contrato + "\\" + response.ficheroReal;



                }
            }

            contrato.FechaUltimaActualizacion = DateTime.Now;
            contrato.UsuarioUltimaActualizacion = request.Usuario;
            ////Adjuntos
            //if (file != null)
            //{
            //    if (file.Length > 0)
            //    {
            //        contrato.NombreArchivo = file.FileName;
            //        ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
            //        {
            //            filtros = new AdjuntarArchivosDTO()
            //            {
            //                archivoStream = fileBytes,
            //                filename = file.FileName,
            //            },
            //            pathFile = _fileServerSettings.Value.FincasCertificacion

            //        });

            //        contrato.PathArchivo = _fileServerSettings.Value.FincasCertificacion + "\\" + response.ficheroReal;
            //    }
            //}

            if (request.EmpresaId != 1)
            {
                List<ContratoDetalleBE> contratoDetalleActual = _IContratoRepository.ConsultarContratoDetallePorId(request.ContratoId).ToList();


                foreach (ContratoDetalleBE detalle in contratoDetalleActual)
                {
                    ConsultaContratoCompraPorIdBE consultaContratoCompraPorIdBE = _IContratoCompraRepository.ConsultarContratoCompraPorId(detalle.ContratoCompraId);

                    

                    string estado = ContratoCompraEstados.Asignado;

                    if (consultaContratoCompraPorIdBE.TotalSacosContratoVenta - detalle.Cantidad == 0)
                    {
                        estado = ContratoCompraEstados.Activo;
                    }

                    _IContratoCompraRepository.ActualizarTotalSacosContratoVenta(detalle.ContratoCompraId, consultaContratoCompraPorIdBE.TotalSacosContratoVenta - detalle.Cantidad, consultaContratoCompraPorIdBE.KilosNetosQQContratoVenta - detalle.KilosNetosQQ,DateTime.Now, request.Usuario, estado);

                   
                }



                _IContratoRepository.EliminarContratoDetalle(request.ContratoId);
                

                if (request.ContratoDetalle != null && request.ContratoDetalle.Count > 0)
                {
                    contrato.TotalContratosAsignados = request.ContratoDetalle.Count;

                    bool existePerdida = false;

                    decimal gananciaNeta = 0;

                    foreach (ContratoDetalle contratoDetalle in request.ContratoDetalle)
                    {
                        decimal totalSacosContratoVenta = 0;
                        decimal kilosNetosQQContratoVenta = 0;
                        decimal totalSacosDisponibles = 0;

                        gananciaNeta = gananciaNeta + contratoDetalle.GananciaNeta;

                        if (contratoDetalle.GananciaNeta < 0)
                        {
                            existePerdida = true;                            
                        }
                          

                        ConsultaContratoCompraPorIdBE consultaContratoCompraPorIdBE = _IContratoCompraRepository.ConsultarContratoCompraPorId(contratoDetalle.ContratoCompraId);
                        totalSacosContratoVenta = consultaContratoCompraPorIdBE.TotalSacosContratoVenta;
                        kilosNetosQQContratoVenta = consultaContratoCompraPorIdBE.KilosNetosQQContratoVenta;

                        totalSacosDisponibles = consultaContratoCompraPorIdBE.TotalSacos - totalSacosContratoVenta;
                        
                       

                        string estado = ContratoCompraEstados.Asignado;

                        if (contratoDetalle.Cantidad >= totalSacosDisponibles)
                        {
                            estado = ContratoCompraEstados.Completado;
                        }

                        _IContratoCompraRepository.ActualizarTotalSacosContratoVenta(contratoDetalle.ContratoCompraId, totalSacosContratoVenta + contratoDetalle.Cantidad, kilosNetosQQContratoVenta + contratoDetalle.KilosNetosQQ, DateTime.Now, request.Usuario, estado);


                    }
                    contrato.ExistePerdida = existePerdida;
                    contrato.GananciaNeta = gananciaNeta;

                    if (contrato.TotalSacos - contrato.TotalSacosAsignados == 0)
                    {
                        contrato.EstadoId = ContratoEstados.Completado;
                    }
                    else
                    {
                        contrato.EstadoId = ContratoEstados.Asignado;
                    }
                }
                else
                {
                    contrato.TotalContratosAsignados = 0;
                    contrato.ExistePerdida = false;
                    contrato.EstadoId = ContratoEstados.Activo;
                }

            }

            int affected = _IContratoRepository.Actualizar(contrato);

            

            if (request.EmpresaId != 1 && request.ContratoDetalle != null && request.ContratoDetalle.Count > 0)
            {
                foreach (ContratoDetalle contratoDetalle in request.ContratoDetalle)
                {
                    contratoDetalle.ContratoId = request.ContratoId;

                    _IContratoRepository.InsertarContratoDetalle(contratoDetalle);

                   // _IContratoCompraRepository.ActualizarEstado(contratoDetalle.ContratoCompraId, DateTime.Now, request.Usuario, ContratoCompraEstados.Asignado);
                }
            }

            return affected;
        }

        public ConsultaContratoPorIdBE ConsultarContratoPorId(ConsultaContratoPorIdRequestDTO request)
        {
            ConsultaContratoPorIdBE ConsultaContratoPorIdBE = _IContratoRepository.ConsultarContratoPorId(request.ContratoId);


            




            if (ConsultaContratoPorIdBE.EmpresaId != 1)
            {
                ConsultaContratoPorIdBE.Detalle = _IContratoRepository.ConsultarContratoDetallePorId(request.ContratoId).ToList();
            }

            return ConsultaContratoPorIdBE;
        }

        public int AnularContrato(AnularContratoRequestDTO request)
        {
            int result = 0;
            if (request.ContratoId > 0)
            {
                result = _IContratoRepository.ActualizarEstado(request.ContratoId, DateTime.Now, request.Usuario, ContratoEstados.Anulado);
            }
            return result;
        }

        public int AsignarAcopio(AsignarAcopioContratoRequestDTO request)
        {
            int cantidadContratosAsignados = _IContratoRepository.ValidadContratoAsignado(request.EmpresaId, ContratoEstados.Asignado);

            if(cantidadContratosAsignados>0)
            {
               throw new ResultException(new Result { ErrCode = "01", Message = "Comercial.Contrato.ValidacionContratoAsignado.Label" });

            }

            int result = 0;
            if (request.ContratoId > 0)
            {
                result = _IContratoRepository.AsignarAcopio(request.ContratoId, DateTime.Now, request.Usuario, ContratoEstados.Asignado, request.KGPergaminoAsignacion, request.PorcentajeRendimientoAsignacion, request.TotalKGPergaminoAsignacion);
            }
            return result;
        }


        public ConsultarTrackingContratoPorContratoIdBE ConsultarTrackingContratoPorContratoId(ConsultaTrackingContratoPorContratoIdRequestDTO request)
        {
            ConsultarTrackingContratoPorContratoIdBE consultarTrackingContratoPorContratoIdBE =  _IContratoRepository.ConsultarTrackingContratoPorContratoId(request.ContratoId,request.Idioma);

            string[] certificacionesIds = consultarTrackingContratoPorContratoIdBE.TipoCertificacionId.Split('|');

            string certificacionLabel = string.Empty;

            List<ConsultaDetalleTablaBE> lista = _IMaestroRepository.ConsultarDetalleTablaDeTablas(consultarTrackingContratoPorContratoIdBE.EmpresaId, String.Empty).ToList();

            if (certificacionesIds.Length > 0)
            {
                List<ConsultaDetalleTablaBE> certificaciones = lista.Where(a => a.CodigoTabla.Trim().Equals("TipoCertificacion")).ToList();

                foreach (string certificacionId in certificacionesIds)
                {

                    ConsultaDetalleTablaBE certificacion = certificaciones.Where(a => a.Codigo == certificacionId).FirstOrDefault();

                    if (certificacion != null)
                    {
                        certificacionLabel = certificacionLabel + certificacion.Label + " ";
                    }
                }

                consultarTrackingContratoPorContratoIdBE.TipoCertificacion = certificacionLabel;

            }

            consultarTrackingContratoPorContratoIdBE.Cargamentos = _IContratoRepository.ConsultarTrackingContratoCargamentoPorContratoId(request.ContratoId, request.Idioma).ToList();

            consultarTrackingContratoPorContratoIdBE.Certificaciones = _IContratoRepository.ConsultarTrackingContratoCertificacionPorContratoId(request.ContratoId, request.Idioma).ToList();


            return consultarTrackingContratoPorContratoIdBE;

        }

        public List<ConsultarTrackingContratoPorContratoIdBE> ConsultarTrackingContrato(ConsultaTrackingContratoRequestDTO request)
        {
           
            var list = _IContratoRepository.ConsultarTrackingContrato(request);

            



            return list.ToList();
        }


        public ConsultaContratoAsignado ConsultarContratoAsignado(ConsultaContratoAsignadoRequestDTO request)
        {
            return _IContratoRepository.ConsultarContratoAsignado(request.EmpresaId,ContratoEstados.Asignado);
        }

        public int DesasignarContrato(AsignarContratoCompraRequestDTO request)
        {
            int result = 0;
            if (request.ContratoVentaId > 0)
            {

                ConsultaContratoCompraPorIdBE contrato = _IContratoCompraRepository.ConsultarContratoCompraPorContratoVentaId(request.ContratoVentaId);

                result = _IContratoCompraRepository.DesasignarContratoCompra(request.ContratoVentaId, contrato.ContratoCompraId, DateTime.Now, request.Usuario, ContratoCompraEstados.Activo, ContratoEstados.Activo);


            }
            return result;
        }

    }
}
