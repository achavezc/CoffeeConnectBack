
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
    public partial class AduanaDocumentoAdjuntoService : IAduanaDocumentoAdjuntoService
    {
        private readonly IMapper _Mapper;


        private IAduanaDocumentoAdjuntoRepository _IAduanaDocumentoAdjuntoRepository;


        public IOptions<FileServerSettings> _fileServerSettings;

        public AduanaDocumentoAdjuntoService(IAduanaDocumentoAdjuntoRepository AduanaDocumentoAdjuntoRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings)
        {
            _IAduanaDocumentoAdjuntoRepository = AduanaDocumentoAdjuntoRepository;
            _fileServerSettings = fileServerSettings;
            _Mapper = mapper;



        }
        private String getRutaFisica(string pathFile)
        {
            return _fileServerSettings.Value.RutaPrincipal + pathFile;
        }

        public int RegistrarAduanaDocumentoAdjunto(RegistrarActualizarAduanaDocumentoAdjuntoRequestDTO request, IFormFile file)
        {
            AduanaDocumentoAdjunto socioAduana = _Mapper.Map<AduanaDocumentoAdjunto>(request);
            socioAduana.FechaRegistro = DateTime.Now;
            socioAduana.UsuarioRegistro = request.Usuario;

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

                    socioAduana.Nombre = file.FileName;
                    ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
                    {
                        filtros = new AdjuntarArchivosDTO()
                        {
                            archivoStream = fileBytes,
                            filename = file.FileName,
                        },
                        pathFile = _fileServerSettings.Value.AduanasDocumentoAdjunto
                    });
                    socioAduana.Path = _fileServerSettings.Value.AduanasDocumentoAdjunto + "\\" + response.ficheroReal;
                }
            }



            //if (file != null)
            //{
            //    if (file.Length > 0)
            //    {
            //        //Adjuntos
            //        socioAduana.Nombre = file.FileName;
            //        ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
            //        {
            //            filtros = new AdjuntarArchivosDTO()
            //            {
            //                archivoStream = fileBytes,
            //                filename = file.FileName,
            //            },
            //            pathFile = _fileServerSettings.Value.AduanasCertificacion

            //        });
            //        socioAduana.Path = _fileServerSettings.Value.AduanasCertificacion + "\\" + response.ficheroReal;
            //    }
            //}

            int affected = _IAduanaDocumentoAdjuntoRepository.Insertar(socioAduana);

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

        public int ActualizarAduanaDocumentoAdjunto(RegistrarActualizarAduanaDocumentoAdjuntoRequestDTO request, IFormFile file)
        {
            AduanaDocumentoAdjunto socioAduana = _Mapper.Map<AduanaDocumentoAdjunto>(request);
            //socioAduana.Nombre = request.Nombre;
            //socioAduana.Path = request.Path;
            socioAduana.FechaUltimaActualizacion = DateTime.Now;
            socioAduana.UsuarioUltimaActualizacion = request.Usuario;

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

                    socioAduana.Nombre = file.FileName;
                    ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
                    {
                        filtros = new AdjuntarArchivosDTO()
                        {
                            archivoStream = fileBytes,
                            filename = file.FileName,
                        },
                        pathFile = _fileServerSettings.Value.AduanasDocumentoAdjunto

                    });

                    socioAduana.Path = _fileServerSettings.Value.AduanasDocumentoAdjunto + "\\" + response.ficheroReal;
                }
            }


            ////Adjuntos
            //if (file != null)
            //{
            //    if (file.Length > 0)
            //    {
            //        socioAduana.Nombre = file.FileName;
            //        ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
            //        {
            //            filtros = new AdjuntarArchivosDTO()
            //            {
            //                archivoStream = fileBytes,
            //                filename = file.FileName,
            //            },
            //            pathFile = _fileServerSettings.Value.AduanasCertificacion

            //        });

            //        socioAduana.Path = _fileServerSettings.Value.AduanasCertificacion + "\\" + response.ficheroReal;
            //    }
            //}

            int affected = _IAduanaDocumentoAdjuntoRepository.Actualizar(socioAduana);

            return affected;
        }

        public IEnumerable<ConsultaAduanaDocumentoAdjuntoPorId> ConsultarAduanaDocumentoAdjuntoPorAduanaId(ConsultaAduanaDocumentoAdjuntoPorAduanaIdRequestDTO request)
        {
            return _IAduanaDocumentoAdjuntoRepository.ConsultarAduanaDocumentoAdjuntoPorAduanaId(request.AduanaId);
        }

        public ConsultaAduanaDocumentoAdjuntoPorId ConsultarAduanaDocumentoAdjuntoPorId(ConsultaAduanaDocumentoAdjuntoPorIdRequestDTO request)
        {
            return _IAduanaDocumentoAdjuntoRepository.ConsultarAduanaDocumentoAdjuntoPorId(request.AduanaDocumentoAdjuntoId);
        }

        public int EliminarAduanaDocumentoAdjunto(RegistrarActualizarAduanaDocumentoAdjuntoRequestDTO request)
        {
            ConsultaAduanaDocumentoAdjuntoPorId AduanaAduanaDocumentoAdjunto = _IAduanaDocumentoAdjuntoRepository.ConsultarAduanaDocumentoAdjuntoPorId(request.AduanaDocumentoAdjuntoId);

            var AdjuntoBl = new AdjuntarArchivosBL(_fileServerSettings);

            int affected = _IAduanaDocumentoAdjuntoRepository.Eliminar(request.AduanaDocumentoAdjuntoId);

            EliminarArchivoAdjuntoDTO adjunto = new EliminarArchivoAdjuntoDTO();
            adjunto.pathFile = AduanaAduanaDocumentoAdjunto.Path;

            if(!string.IsNullOrEmpty(AduanaAduanaDocumentoAdjunto.Path))
            {
                AdjuntoBl.EliminarArchivo(adjunto);
            }
            



            return affected;
        }

    }
}
