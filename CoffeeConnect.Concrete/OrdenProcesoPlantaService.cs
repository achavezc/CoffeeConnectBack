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

        public OrdenProcesoPlantaService(IOrdenProcesoPlantaRepository OrdenProcesoPlantaRepository, ICorrelativoRepository correlativoRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings)
        {
            _IOrdenProcesoPlantaRepository = OrdenProcesoPlantaRepository;
            _Mapper = mapper;
            _fileServerSettings = fileServerSettings;
            _ICorrelativoRepository = correlativoRepository;
        }

        public List<ConsultaOrdenProcesoPlantaBE> ConsultarOrdenProcesoPlanta(ConsultaOrdenProcesoPlantaRequestDTO request)
        {
            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Comercial.Contrato.ValidacionRangoFechaMayor2anios.Label" });

            var list = _IOrdenProcesoPlantaRepository.ConsultarOrdenProcesoPlanta(request);
            return list.ToList();
        }

        public int RegistrarOrdenProcesoPlanta(RegistrarActualizarOrdenProcesoPlantaRequestDTO request, IFormFile file)
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

            //foreach (OrdenProcesoPlantaDetalle detalle in request.OrdenProcesoPlantaDetalle)
            //{
            //    detalle.OrdenProcesoPlantaId = OrdenProcesoPlantaId;
            //    _IOrdenProcesoPlantaRepository.InsertarProcesoDetalle(detalle);
            //}
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

            //_IOrdenProcesoPlantaRepository.EliminarProcesoDetalle(ordenProcesoPlanta.OrdenProcesoPlantaId);

            //foreach (OrdenProcesoPlantaDetalle detalle in request.OrdenProcesoPlantaDetalle)
            //{
            //    detalle.OrdenProcesoPlantaId = OrdenProcesoPlanta.OrdenProcesoPlantaId;
            //    _IOrdenProcesoPlantaRepository.InsertarProcesoDetalle(detalle);
            //}


            return affected;
        }

        //public ConsultaOrdenProcesoPlantaPorIdBE ConsultarOrdenProcesoPlantaPorId(ConsultaOrdenProcesoPlantaPorIdRequestDTO request)
        //{
        //    ConsultaOrdenProcesoPlantaPorIdBE consultaOrdenProcesoPlantaPorIdBE = _IOrdenProcesoPlantaRepository.ConsultarOrdenProcesoPlantaPorId(request.OrdenProcesoPlantaId);

        //    consultaOrdenProcesoPlantaPorIdBE.detalle = _IOrdenProcesoPlantaRepository.ConsultarOrdenProcesoPlantaDetallePorId(request.OrdenProcesoPlantaId).ToList();


        //    return consultaOrdenProcesoPlantaPorIdBE;
        //}

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
