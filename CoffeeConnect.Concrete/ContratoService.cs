﻿
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
        private ICorrelativoRepository _ICorrelativoRepository;
        public IOptions<FileServerSettings> _fileServerSettings;
        private IMaestroRepository _IMaestroRepository;


        public ContratoService(IContratoRepository contratoRepository, ICorrelativoRepository correlativoRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings, IMaestroRepository maestroRepository)
        {
            _IContratoRepository = contratoRepository;
            _fileServerSettings = fileServerSettings;
            _ICorrelativoRepository = correlativoRepository;
            _Mapper = mapper;
            _IMaestroRepository = maestroRepository;
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

            List<ConsultaDetalleTablaBE> lista = _IMaestroRepository.ConsultarDetalleTablaDeTablas(request.EmpresaId).ToList();


            foreach (ConsultaContratoBE contrato in list)
            {
                string[] certificacionesIds = contrato.TipoCertificacionId.Split('|');

                string certificacionLabel = string.Empty;

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
                    contrato.PathArchivo = _fileServerSettings.Value.FincasCertificacion + "\\" + response.ficheroReal;
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
                        pathFile = _fileServerSettings.Value.FincasCertificacion
                    });

                    contrato.PathArchivo = _fileServerSettings.Value.FincasCertificacion + "\\" + response.ficheroReal;
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
            int affected = _IContratoRepository.Actualizar(contrato);

            return affected;
        }

        public ConsultaContratoPorIdBE ConsultarContratoPorId(ConsultaContratoPorIdRequestDTO request)
        {
            return _IContratoRepository.ConsultarContratoPorId(request.ContratoId);
        }

        public int AnularContrato(AnularContratoRequestDTO request)
        {
            int result = 0;
            if (request.ContratoId > 0)
            {
                result = _IContratoRepository.Anular(request.ContratoId, DateTime.Now, request.Usuario, ContratoEstados.Anulado);
            }
            return result;
        }

        public ConsultarTrackingContratoPorContratoIdBE ConsultarTrackingContratoPorContratoId(ConsultaTrackingContratoPorContratoIdRequestDTO request)
        {
            return _IContratoRepository.ConsultarTrackingContratoPorContratoId(request.ContratoId,request.Idioma);
        }

        public List<ConsultarTrackingContratoPorContratoIdBE> ConsultarTrackingContrato(ConsultaTrackingContratoRequestDTO request)
        {
           
            var list = _IContratoRepository.ConsultarTrackingContrato(request);

            



            return list.ToList();
        }


    }
}
