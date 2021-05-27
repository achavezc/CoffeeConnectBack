using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adjunto;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using CoffeeConnect.Service.Adjunto;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;

namespace CoffeeConnect.Service
{
    public partial class SocioDocumentoService : ISocioDocumentoService
    {
        private readonly IMapper _Mapper;
        private IOptions<FileServerSettings> _fileServerSettings;
        private ISocioDocumentoRepository _SocioDocumentoRepository;

        public SocioDocumentoService(IMapper mapper, IOptions<FileServerSettings> fileServerSettings, ISocioDocumentoRepository socioDocumentoService)
        {
            _fileServerSettings = fileServerSettings;
            _Mapper = mapper;
            _SocioDocumentoRepository = socioDocumentoService;
        }

        public int ActualizarSocioDocumento(RegistrarSocioDocumentoRequestDTO request, IFormFile file)
        {
            SocioDocumento socioDocumento = _Mapper.Map<SocioDocumento>(request);
            socioDocumento.FechaUltimaActualizacion = DateTime.Now;
            socioDocumento.UsuarioUltimaActualizacion = request.Usuario;

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

                    socioDocumento.Nombre = file.FileName;
                    ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
                    {
                        filtros = new AdjuntarArchivosDTO()
                        {
                            archivoStream = fileBytes,
                            filename = file.FileName,
                        },
                        pathFile = _fileServerSettings.Value.SocioDocumento

                    });

                    socioDocumento.Path = _fileServerSettings.Value.SocioDocumento + "\\" + response.ficheroReal;
                }
            }

            int affected = _SocioDocumentoRepository.Actualizar(socioDocumento);

            return affected;
        }



        



        public IEnumerable<ConsultarSocioDocumentoPorSocioId> ConsultarSocioDocumentoPorSocioId(ConsultarSocioDocumentoPorSocioIdRequestDTO request)
        {
            return _SocioDocumentoRepository.ConsultarSocioDocumentoPorSocioId(request.SocioId);
        }

        public ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request)
        {
            try
            {
                string rutaReal = Path.Combine(getRutaFisica(request.PathFile));

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
                        ficheroVisual = string.Empty
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

        public int RegistrarSocioDocumento(RegistrarSocioDocumentoRequestDTO request, IFormFile file)
        {
            SocioDocumento socioDocumento = _Mapper.Map<SocioDocumento>(request);
            socioDocumento.FechaRegistro = DateTime.Now;
            socioDocumento.UsuarioRegistro = request.Usuario;

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

                    socioDocumento.Nombre = file.FileName;
                    ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
                    {
                        filtros = new AdjuntarArchivosDTO()
                        {
                            archivoStream = fileBytes,
                            filename = file.FileName,
                        },
                        pathFile = _fileServerSettings.Value.SocioDocumento
                    });
                    socioDocumento.Path = _fileServerSettings.Value.SocioDocumento + "\\" + response.ficheroReal;
                }
            }

            int affected = _SocioDocumentoRepository.Insertar(socioDocumento);

            return affected;
        }

        private String getRutaFisica(string pathFile)
        {
            return _fileServerSettings.Value.RutaPrincipal + pathFile;
        }

        public int EliminarSocioDocumento(RegistrarSocioDocumentoRequestDTO request)
        {
            SocioDocumento socioDocumento = _SocioDocumentoRepository.ConsultarSocioDocumentoPorId(request.SocioDocumentoId);

            var AdjuntoBl = new AdjuntarArchivosBL(_fileServerSettings);

            int affected = _SocioDocumentoRepository.Eliminar(request.SocioDocumentoId);

            EliminarArchivoAdjuntoDTO adjunto = new EliminarArchivoAdjuntoDTO();
            adjunto.pathFile = socioDocumento.Path;

            if (!string.IsNullOrEmpty(adjunto.pathFile))
            {
                AdjuntoBl.EliminarArchivo(adjunto);
            }



            return affected;
        }
    }
}
