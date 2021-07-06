
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
    public partial class InspeccionInternaService : IInspeccionInternaService
    {
        private readonly IMapper _Mapper;
        private IInspeccionInternaRepository _IInspeccionInternaRepository;
        private ICorrelativoRepository _ICorrelativoRepository;
        public IOptions<FileServerSettings> _fileServerSettings;

        public InspeccionInternaService(IInspeccionInternaRepository inspeccionInternaRepository, ICorrelativoRepository correlativoRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings)
        {
            _IInspeccionInternaRepository = inspeccionInternaRepository;
            _ICorrelativoRepository = correlativoRepository;
            _Mapper = mapper;
            _fileServerSettings = fileServerSettings;
        }

        private String getRutaFisica(string pathFile)
        {
            return _fileServerSettings.Value.RutaPrincipal + pathFile;
        }

        public int ActualizarInspeccionInterna(RegistrarActualizarInspeccionInternaRequestDTO request, IFormFile file)
        {
            InspeccionInterna inspeccionInterna = _Mapper.Map<InspeccionInterna>(request);
            inspeccionInterna.FechaUltimaActualizacion = DateTime.Now;
            inspeccionInterna.UsuarioUltimaActualizacion = request.Usuario;

            AdjuntarArchivosBL AdjuntoBl = new AdjuntarArchivosBL(_fileServerSettings);
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

                    inspeccionInterna.NombreArchivo = file.FileName;
                    ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
                    {
                        filtros = new AdjuntarArchivosDTO()
                        {
                            archivoStream = fileBytes,
                            filename = file.FileName,
                        },
                        pathFile = _fileServerSettings.Value.InspeccionInterna
                    });

                    inspeccionInterna.PathArchivo = _fileServerSettings.Value.InspeccionInterna + "\\" + response.ficheroReal;
                }
            }

            int affected = _IInspeccionInternaRepository.Actualizar(inspeccionInterna);

            if (request.InspeccionInternaNormaList.FirstOrDefault() != null)
            {
                request.InspeccionInternaNormaList.ForEach(z =>
                {
                    z.InspeccionInternaId = request.InspeccionInternaId;
                });

                _IInspeccionInternaRepository.ActualizarInspeccionInternaNormas(request.InspeccionInternaNormaList, request.InspeccionInternaId);
            }

            if (request.InspeccionInternaParcelaList.FirstOrDefault() != null)
            {
                request.InspeccionInternaParcelaList.ForEach(z =>
                {
                    z.InspeccionInternaId = request.InspeccionInternaId;
                });

                _IInspeccionInternaRepository.ActualizarInspeccionInternaParcela(request.InspeccionInternaParcelaList, request.InspeccionInternaId);
            }

            if (request.InspeccionInternaLevantamientoNoConformidadList.FirstOrDefault() != null)
            {
                request.InspeccionInternaLevantamientoNoConformidadList.ForEach(z =>
                {
                    z.InspeccionInternaId = request.InspeccionInternaId;
                });

                _IInspeccionInternaRepository.ActualizarInspeccionInternaLevantamientoNoConformidad(request.InspeccionInternaLevantamientoNoConformidadList, request.InspeccionInternaId);
            }

            if (request.InspeccionInternaNoConformidadList.FirstOrDefault() != null)
            {
                request.InspeccionInternaNoConformidadList.ForEach(z =>
                {
                    z.InspeccionInternaId = request.InspeccionInternaId;
                });

                _IInspeccionInternaRepository.ActualizarInspeccionInternaNoConformidad(request.InspeccionInternaNoConformidadList, request.InspeccionInternaId);
            }

            return affected;
        }

        public int RegistrarInspeccionInterna(RegistrarActualizarInspeccionInternaRequestDTO request, IFormFile file)
        {
            InspeccionInterna inspeccionInterna = _Mapper.Map<InspeccionInterna>(request);
            inspeccionInterna.FechaRegistro = DateTime.Now;
            inspeccionInterna.UsuarioRegistro = request.Usuario;
            inspeccionInterna.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.InspeccionInterna);

            AdjuntarArchivosBL AdjuntoBl = new AdjuntarArchivosBL(_fileServerSettings);
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

                    inspeccionInterna.NombreArchivo = file.FileName;
                    //Adjuntos
                    ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
                    {
                        filtros = new AdjuntarArchivosDTO()
                        {
                            archivoStream = fileBytes,
                            filename = file.FileName,
                        },
                        pathFile = _fileServerSettings.Value.InspeccionInterna
                    });
                    inspeccionInterna.PathArchivo = _fileServerSettings.Value.InspeccionInterna + "\\" + response.ficheroReal;
                }
            }

            int inspeccionInternaId = _IInspeccionInternaRepository.Insertar(inspeccionInterna);

            if (request.InspeccionInternaNormaList.FirstOrDefault() != null)
            {
                request.InspeccionInternaNormaList.ForEach(z =>
                {
                    z.InspeccionInternaId = inspeccionInternaId;
                });

                _IInspeccionInternaRepository.ActualizarInspeccionInternaNormas(request.InspeccionInternaNormaList, inspeccionInternaId);
            }

            if (request.InspeccionInternaParcelaList.FirstOrDefault() != null)
            {
                request.InspeccionInternaParcelaList.ForEach(z =>
                {
                    z.InspeccionInternaId = inspeccionInternaId;
                });

                _IInspeccionInternaRepository.ActualizarInspeccionInternaParcela(request.InspeccionInternaParcelaList, inspeccionInternaId);
            }

            if (request.InspeccionInternaLevantamientoNoConformidadList.FirstOrDefault() != null)
            {
                request.InspeccionInternaLevantamientoNoConformidadList.ForEach(z =>
                {
                    z.InspeccionInternaId = inspeccionInternaId;
                });

                _IInspeccionInternaRepository.ActualizarInspeccionInternaLevantamientoNoConformidad(request.InspeccionInternaLevantamientoNoConformidadList, inspeccionInternaId);
            }

            if (request.InspeccionInternaNoConformidadList.FirstOrDefault() != null)
            {
                request.InspeccionInternaNoConformidadList.ForEach(z =>
                {
                    z.InspeccionInternaId = inspeccionInternaId;
                });

                _IInspeccionInternaRepository.ActualizarInspeccionInternaNoConformidad(request.InspeccionInternaNoConformidadList, inspeccionInternaId);
            }

            return inspeccionInternaId;
        }

        public List<ConsultaInspeccionInternaBE> ConsultarInspeccionInterna(ConsultaInspeccionInternaRequestDTO request)
        {
            //if (string.IsNullOrEmpty(request.Numero) && string.IsNullOrEmpty(request.Ruc) && string.IsNullOrEmpty(request.RazonSocial))
            //    throw new ResultException(new Result { ErrCode = "01", Message = "Comercial.InspeccionInterna.ValidacionSeleccioneMinimoUnFiltro.Label" });


            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Comercial.InspeccionInterna.ValidacionRangoFechaMayor2anios.Label" });



            var list = _IInspeccionInternaRepository.ConsultarInspeccionInterna(request);

            return list.ToList();
        }

        public ConsultaInspeccionInternaPorIdBE ConsultarInspeccionInternaPorId(ConsultaInspeccionInternaPorIdRequestDTO request)
        {
            ConsultaInspeccionInternaPorIdBE consultaInspeccionInternaPorIdBE = _IInspeccionInternaRepository.ConsultarInspeccionInternaPorId(request.InspeccionInternaId);

            if (consultaInspeccionInternaPorIdBE != null)
            {

                consultaInspeccionInternaPorIdBE.InspeccionInternaParcela = _IInspeccionInternaRepository.ConsultarInspeccionInternaParcelaPorId(request.InspeccionInternaId).ToList();
                consultaInspeccionInternaPorIdBE.InspeccionInternaNoConformidad = _IInspeccionInternaRepository.ConsultarInspeccionInternaNoConformidadPorId(request.InspeccionInternaId).ToList();
                consultaInspeccionInternaPorIdBE.InspeccionInternaLevantamientoNoConformidad = _IInspeccionInternaRepository.ConsultarInspeccionInternaLevantamientoNoConformidadPorId(request.InspeccionInternaId).ToList();
                consultaInspeccionInternaPorIdBE.InspeccionInternaNorma = _IInspeccionInternaRepository.ConsultarInspeccionInternaNormasPorId(request.InspeccionInternaId).ToList();
            }
            return consultaInspeccionInternaPorIdBE;
        }

        public ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request)
        {
            try
            {
                string rutaReal = Path.Combine(getRutaFisica(request.PathFile));

                if (File.Exists(rutaReal))
                {
                    Byte[] archivoBytes = File.ReadAllBytes(rutaReal);
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
