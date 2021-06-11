
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
    public partial class NotaIngresoPlantaDocumentoAdjuntoService : INotaIngresoPlantaDocumentoAdjuntoService
    {
        private readonly IMapper _Mapper;


        private INotaIngresoPlantaDocumentoAdjuntoRepository _INotaIngresoPlantaDocumentoAdjuntoRepository;


        public IOptions<FileServerSettings> _fileServerSettings;

        public NotaIngresoPlantaDocumentoAdjuntoService(INotaIngresoPlantaDocumentoAdjuntoRepository NotaIngresoPlantaDocumentoAdjuntoRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings)
        {
            _INotaIngresoPlantaDocumentoAdjuntoRepository = NotaIngresoPlantaDocumentoAdjuntoRepository;
            _fileServerSettings = fileServerSettings;
            _Mapper = mapper;



        }
        private String getRutaFisica(string pathFile)
        {
            return _fileServerSettings.Value.RutaPrincipal + pathFile;
        }

        public int RegistrarNotaIngresoPlantaDocumentoAdjunto(RegistrarActualizarNotaIngresoPlantaDocumentoAdjuntoRequestDTO request, IFormFile file)
        {
            NotaIngresoPlantaDocumentoAdjunto socioNotaIngresoPlanta = _Mapper.Map<NotaIngresoPlantaDocumentoAdjunto>(request);
            socioNotaIngresoPlanta.FechaRegistro = DateTime.Now;
            socioNotaIngresoPlanta.UsuarioRegistro = request.Usuario;

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

                    socioNotaIngresoPlanta.Nombre = file.FileName;
                    ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
                    {
                        filtros = new AdjuntarArchivosDTO()
                        {
                            archivoStream = fileBytes,
                            filename = file.FileName,
                        },
                        pathFile = _fileServerSettings.Value.NotaIngresoPlantasDocumentoAdjunto
                    });
                    socioNotaIngresoPlanta.Path = _fileServerSettings.Value.NotaIngresoPlantasDocumentoAdjunto + "\\" + response.ficheroReal;
                }
            }



            //if (file != null)
            //{
            //    if (file.Length > 0)
            //    {
            //        //Adjuntos
            //        socioNotaIngresoPlanta.Nombre = file.FileName;
            //        ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
            //        {
            //            filtros = new AdjuntarArchivosDTO()
            //            {
            //                archivoStream = fileBytes,
            //                filename = file.FileName,
            //            },
            //            pathFile = _fileServerSettings.Value.NotaIngresoPlantasCertificacion

            //        });
            //        socioNotaIngresoPlanta.Path = _fileServerSettings.Value.NotaIngresoPlantasCertificacion + "\\" + response.ficheroReal;
            //    }
            //}

            int affected = _INotaIngresoPlantaDocumentoAdjuntoRepository.Insertar(socioNotaIngresoPlanta);

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

        public int ActualizarNotaIngresoPlantaDocumentoAdjunto(RegistrarActualizarNotaIngresoPlantaDocumentoAdjuntoRequestDTO request, IFormFile file)
        {
            NotaIngresoPlantaDocumentoAdjunto socioNotaIngresoPlanta = _Mapper.Map<NotaIngresoPlantaDocumentoAdjunto>(request);
            //socioNotaIngresoPlanta.Nombre = request.Nombre;
            //socioNotaIngresoPlanta.Path = request.Path;
            socioNotaIngresoPlanta.FechaUltimaActualizacion = DateTime.Now;
            socioNotaIngresoPlanta.UsuarioUltimaActualizacion = request.Usuario;

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

                    socioNotaIngresoPlanta.Nombre = file.FileName;
                    ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
                    {
                        filtros = new AdjuntarArchivosDTO()
                        {
                            archivoStream = fileBytes,
                            filename = file.FileName,
                        },
                        pathFile = _fileServerSettings.Value.NotaIngresoPlantasDocumentoAdjunto

                    });

                    socioNotaIngresoPlanta.Path = _fileServerSettings.Value.NotaIngresoPlantasDocumentoAdjunto + "\\" + response.ficheroReal;
                }
            }


            ////Adjuntos
            //if (file != null)
            //{
            //    if (file.Length > 0)
            //    {
            //        socioNotaIngresoPlanta.Nombre = file.FileName;
            //        ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
            //        {
            //            filtros = new AdjuntarArchivosDTO()
            //            {
            //                archivoStream = fileBytes,
            //                filename = file.FileName,
            //            },
            //            pathFile = _fileServerSettings.Value.NotaIngresoPlantasCertificacion

            //        });

            //        socioNotaIngresoPlanta.Path = _fileServerSettings.Value.NotaIngresoPlantasCertificacion + "\\" + response.ficheroReal;
            //    }
            //}

            int affected = _INotaIngresoPlantaDocumentoAdjuntoRepository.Actualizar(socioNotaIngresoPlanta);

            return affected;
        }

        public IEnumerable<ConsultaNotaIngresoPlantaDocumentoAdjuntoPorId> ConsultarNotaIngresoPlantaDocumentoAdjuntoPorNotaIngresoPlantaId(ConsultaNotaIngresoPlantaDocumentoAdjuntoPorNotaIngresoPlantaIdRequestDTO request)
        {
            return _INotaIngresoPlantaDocumentoAdjuntoRepository.ConsultarNotaIngresoPlantaDocumentoAdjuntoPorNotaIngresoPlantaId(request.NotaIngresoPlantaId);
        }

        public ConsultaNotaIngresoPlantaDocumentoAdjuntoPorId ConsultarNotaIngresoPlantaDocumentoAdjuntoPorId(ConsultaNotaIngresoPlantaDocumentoAdjuntoPorIdRequestDTO request)
        {
            return _INotaIngresoPlantaDocumentoAdjuntoRepository.ConsultarNotaIngresoPlantaDocumentoAdjuntoPorId(request.NotaIngresoPlantaDocumentoAdjuntoId);
        }

        public int EliminarNotaIngresoPlantaDocumentoAdjunto(RegistrarActualizarNotaIngresoPlantaDocumentoAdjuntoRequestDTO request)
        {
            ConsultaNotaIngresoPlantaDocumentoAdjuntoPorId NotaIngresoPlantaNotaIngresoPlantaDocumentoAdjunto = _INotaIngresoPlantaDocumentoAdjuntoRepository.ConsultarNotaIngresoPlantaDocumentoAdjuntoPorId(request.NotaIngresoPlantaDocumentoAdjuntoId);

            var AdjuntoBl = new AdjuntarArchivosBL(_fileServerSettings);

            int affected = _INotaIngresoPlantaDocumentoAdjuntoRepository.Eliminar(request.NotaIngresoPlantaDocumentoAdjuntoId);

            EliminarArchivoAdjuntoDTO adjunto = new EliminarArchivoAdjuntoDTO();
            adjunto.pathFile = NotaIngresoPlantaNotaIngresoPlantaDocumentoAdjunto.Path;

            if(!string.IsNullOrEmpty(NotaIngresoPlantaNotaIngresoPlantaDocumentoAdjunto.Path))
            {
                AdjuntoBl.EliminarArchivo(adjunto);
            }
            



            return affected;
        }

    }
}
