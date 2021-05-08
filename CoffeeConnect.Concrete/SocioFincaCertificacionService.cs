
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
    public partial class SocioFincaCertificacionService : ISocioFincaCertificacionService
    {
        private readonly IMapper _Mapper;


        private ISocioFincaCertificacionRepository _ISocioFincaRepository;


        public IOptions<FileServerSettings> _fileServerSettings;

        public SocioFincaCertificacionService(ISocioFincaCertificacionRepository socioFincaRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings)
        {
            _ISocioFincaRepository = socioFincaRepository;
            _fileServerSettings = fileServerSettings;
            _Mapper = mapper;



        }
        private String getRutaFisica(string pathFile)
        {
            return _fileServerSettings.Value.RutaPrincipal + pathFile;
        }

        public int RegistrarSocioFincaCertificacion(RegistrarActualizarSocioFincaCertificacionRequestDTO request, IFormFile file)
        {
            var AdjuntoBl = new AdjuntarArchivosBL(_fileServerSettings);
            byte[] fileBytes = null;

            SocioFincaCertificacion socioFinca = _Mapper.Map<SocioFincaCertificacion>(request);
            socioFinca.FechaRegistro = DateTime.Now;
            socioFinca.UsuarioRegistro = request.Usuario;

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

                    //Adjuntos
                    socioFinca.NombreArchivo = file.FileName;
                    ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
                    {
                        filtros = new AdjuntarArchivosDTO()
                        {
                            archivoStream = fileBytes,
                            filename = file.FileName,
                        },
                        pathFile = _fileServerSettings.Value.FincasCertificacion

                    });
                    socioFinca.PathArchivo = _fileServerSettings.Value.FincasCertificacion + "\\" + response.ficheroReal;
                }
            }



            //if (file != null)
            //{
            //    if (file.Length > 0)
            //    {
            //        //Adjuntos
            //        socioFinca.NombreArchivo = file.FileName;
            //        ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
            //        {
            //            filtros = new AdjuntarArchivosDTO()
            //            {
            //                archivoStream = fileBytes,
            //                filename = file.FileName,
            //            },
            //            pathFile = _fileServerSettings.Value.FincasCertificacion

            //        });
            //        socioFinca.PathArchivo = _fileServerSettings.Value.FincasCertificacion + "\\" + response.ficheroReal;
            //    }
            //}

            int affected = _ISocioFincaRepository.Insertar(socioFinca);

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

        public int ActualizarSocioFincaCertificacion(RegistrarActualizarSocioFincaCertificacionRequestDTO request, IFormFile file)
        {
            var AdjuntoBl = new AdjuntarArchivosBL(_fileServerSettings);

            SocioFincaCertificacion socioFinca = _Mapper.Map<SocioFincaCertificacion>(request);
            //socioFinca.NombreArchivo = request.NombreArchivo;
            //socioFinca.PathArchivo = request.PathArchivo;
            socioFinca.FechaUltimaActualizacion = DateTime.Now;
            socioFinca.UsuarioUltimaActualizacion = request.Usuario;


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

                    socioFinca.NombreArchivo = file.FileName;
                    ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
                    {
                        filtros = new AdjuntarArchivosDTO()
                        {
                            archivoStream = fileBytes,
                            filename = file.FileName,
                        },
                        pathFile = _fileServerSettings.Value.FincasCertificacion

                    });

                    socioFinca.PathArchivo = _fileServerSettings.Value.FincasCertificacion + "\\" + response.ficheroReal;
                }
            }


            //Adjuntos
            //if (file != null)
            //{
            //    if (file.Length > 0)
            //    {
            //        socioFinca.NombreArchivo = file.FileName;
            //        ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
            //        {
            //            filtros = new AdjuntarArchivosDTO()
            //            {
            //                archivoStream = fileBytes,
            //                filename = file.FileName,
            //            },
            //            pathFile = _fileServerSettings.Value.FincasCertificacion

            //        });

            //        socioFinca.PathArchivo = _fileServerSettings.Value.FincasCertificacion + "\\" + response.ficheroReal;
            //    }
            //}

            int affected = _ISocioFincaRepository.Actualizar(socioFinca);

            return affected;
        }

        public IEnumerable<ConsultaSocioFincaCertificacionPorSocioFincaId> ConsultarSocioFincaCertificacionPorSocioFincaId(ConsultaSocioFincaCertificacionPorSocioFincaIdRequestDTO request)
        {
            return _ISocioFincaRepository.ConsultarSocioFincaCertificacionPorSocioFincaId(request.SocioFincaId);
        }

        public ConsultaSocioFincaCertificacionPorId ConsultarSocioFincaCertificacionPorId(ConsultaSocioFincaCertificacionPorIdRequestDTO request)
        {
            return _ISocioFincaRepository.ConsultarSocioFincaCertificacionPorId(request.SocioFincaCertificacionId);
        }

    }
}
