
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
    public partial class ContratoCompraService : IContratoCompraService
    {
        private readonly IMapper _Mapper;
        private IContratoCompraRepository _IContratoCompraRepository;

        private IAduanaRepository _IAduanaRepository;
        private ICorrelativoRepository _ICorrelativoRepository;
        public IOptions<FileServerSettings> _fileServerSettings;
        private IMaestroRepository _IMaestroRepository;
        private IEmpresaRepository _IEmpresaRepository;

        
        public ContratoCompraService(IAduanaRepository AduanaRepository, IContratoCompraRepository ContratoCompraRepository, ICorrelativoRepository correlativoRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings, IMaestroRepository maestroRepository, IEmpresaRepository empresaRepository)
        {
            _IContratoCompraRepository = ContratoCompraRepository;
            _IAduanaRepository = AduanaRepository;
            _fileServerSettings = fileServerSettings;
            _ICorrelativoRepository = correlativoRepository;
            _Mapper = mapper;
            _IMaestroRepository = maestroRepository;
            _IEmpresaRepository = empresaRepository;
        }

        private String getRutaFisica(string pathFile)
        {
            return _fileServerSettings.Value.RutaPrincipal + pathFile;
        }

        public List<ConsultaContratoCompraBE> ConsultarContratoCompra(ConsultaContratoCompraRequestDTO request)
        {
            if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFin == null || request.FechaFin == DateTime.MinValue || string.IsNullOrEmpty(request.EstadoId))
                throw new ResultException(new Result { ErrCode = "01", Message = "Comercial.Cliente.ValidacionSeleccioneMinimoUnFiltro.Label" });

            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Comercial.ContratoCompra.ValidacionRangoFechaMayor2anios.Label" });

            var list = _IContratoCompraRepository.ConsultarContratoCompra(request);

            List<ConsultaDetalleTablaBE> lista = _IMaestroRepository.ConsultarDetalleTablaDeTablas(request.EmpresaId,String.Empty).ToList();


            foreach (ConsultaContratoCompraBE ContratoCompra in list)
            {
                string[] certificacionesIds = ContratoCompra.TipoCertificacionId.Split('|');

                string certificacionLabel = string.Empty;
                string tipoContratoCompraLabel = string.Empty;


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
                List<ConsultaDetalleTablaBE> tipoContratoCompras = lista.Where(a => a.CodigoTabla.Trim().Equals("TipoContrato")).ToList();
                ConsultaDetalleTablaBE tipoContratoCompra = tipoContratoCompras.Where(a => a.Codigo == ContratoCompra.TipoContratoId).FirstOrDefault();
                if (tipoContratoCompra != null)
                {
                    tipoContratoCompraLabel = tipoContratoCompraLabel + tipoContratoCompra.Label + " ";
                }

                ContratoCompra.TipoContrato = tipoContratoCompraLabel;
                ContratoCompra.TipoCertificacion = certificacionLabel;
            }

            


            return list.ToList();
        }

        public int RegistrarContratoCompra(RegistrarActualizarContratoCompraRequestDTO request, IFormFile file)
        {
            ContratoCompra ContratoCompra = _Mapper.Map<ContratoCompra>(request);
            ContratoCompra.FechaRegistro = DateTime.Now;
            //ContratoCompra.NombreArchivo = file.FileName;
            ContratoCompra.UsuarioRegistro = request.Usuario;
            //ContratoCompra.Numero = _ICorrelativoRepository.Obtener(null, Documentos.ContratoCompra);

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

                    ContratoCompra.NombreArchivo = file.FileName;
                    //Adjuntos
                    ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
                    {
                        filtros = new AdjuntarArchivosDTO()
                        {
                            archivoStream = fileBytes,
                            filename = file.FileName,
                        },
                        pathFile = _fileServerSettings.Value.ContratoCompra
                    });
                    ContratoCompra.PathArchivo = _fileServerSettings.Value.ContratoCompra + "\\" + response.ficheroReal;
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
            //        ContratoCompra.PathArchivo = _fileServerSettings.Value.FincasCertificacion + "\\" + response.ficheroReal;
            //    }
            //}

            Empresa empresa = _IEmpresaRepository.ObtenerEmpresaPorId(request.EmpresaId);

            //if(empresa.TipoEmpresaid != "01")
            //{
            //    ContratoCompra.EstadoId = ContratoEstados.Completado;
            //}

            int cantidadContratoComprasExistentes = _IContratoCompraRepository.ValidadContratoCompraExistente(request.EmpresaId, request.Numero);
            
            if (cantidadContratoComprasExistentes > 0) 
            {
                throw new ResultException(new Result { ErrCode = "02", Message = "Comercial.ContratoCompra.ValidacionContratoCompraExistente.Label" });

            }

            int affected = _IContratoCompraRepository.Insertar(ContratoCompra);

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

        public int ActualizarContratoCompra(RegistrarActualizarContratoCompraRequestDTO request, IFormFile file)
        {
            ContratoCompra ContratoCompra = _Mapper.Map<ContratoCompra>(request);
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

                    ContratoCompra.NombreArchivo = file.FileName;
                    ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
                    {
                        filtros = new AdjuntarArchivosDTO()
                        {
                            archivoStream = fileBytes,
                            filename = file.FileName,
                        },
                        pathFile = _fileServerSettings.Value.ContratoCompra
                    });

                    ContratoCompra.PathArchivo = _fileServerSettings.Value.ContratoCompra + "\\" + response.ficheroReal;
                }
            }

            ContratoCompra.FechaUltimaActualizacion = DateTime.Now;
            ContratoCompra.UsuarioUltimaActualizacion = request.Usuario;
            ////Adjuntos
            //if (file != null)
            //{
            //    if (file.Length > 0)
            //    {
            //        ContratoCompra.NombreArchivo = file.FileName;
            //        ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
            //        {
            //            filtros = new AdjuntarArchivosDTO()
            //            {
            //                archivoStream = fileBytes,
            //                filename = file.FileName,
            //            },
            //            pathFile = _fileServerSettings.Value.FincasCertificacion

            //        });

            //        ContratoCompra.PathArchivo = _fileServerSettings.Value.FincasCertificacion + "\\" + response.ficheroReal;
            //    }
            //}
            int affected = _IContratoCompraRepository.Actualizar(ContratoCompra);

            return affected;
        }

        public ConsultaContratoCompraPorIdBE ConsultarContratoCompraPorId(ConsultaContratoCompraPorIdRequestDTO request)
        {
            return _IContratoCompraRepository.ConsultarContratoCompraPorId(request.ContratoCompraId);
        }

        public int AnularContratoCompra(AnularContratoCompraRequestDTO request)
        {
            int result = 0;
            if (request.ContratoCompraId > 0)
            {
                result = _IContratoCompraRepository.ActualizarEstado(request.ContratoCompraId, DateTime.Now, request.Usuario, ContratoCompraEstados.Anulado);
            }
            return result;
        }



        public int AsignarContratoCompra(AsignarContratoCompraRequestDTO request)
        { 
            int result = 0;
            if (request.ContratoVentaId > 0)
            {                
                result = _IContratoCompraRepository.AsignarContratoCompra(request.ContratoVentaId , request.ContratoCompraId, DateTime.Now, request.Usuario, ContratoCompraEstados.Asignado,ContratoEstados.Completado);
            
            
            }
            return result;
        }

        




    }
}
