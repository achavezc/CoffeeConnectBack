
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
    public partial class FincaFotoGeoreferenciadaService : IFincaFotoGeoreferenciadaService
    {
        private readonly IMapper _Mapper;


        private IFincaFotoGeoreferenciadaRepository _IFincaFotoGeoreferenciadaRepository;


        public IOptions<FileServerSettings> _fileServerSettings;

        public FincaFotoGeoreferenciadaService(IFincaFotoGeoreferenciadaRepository FincaFotoGeoreferenciadaRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings)
        {
            _IFincaFotoGeoreferenciadaRepository = FincaFotoGeoreferenciadaRepository;
            _fileServerSettings = fileServerSettings;
            _Mapper = mapper;



        }
        private String getRutaFisica(string pathFile)
        {
            return _fileServerSettings.Value.RutaPrincipal + pathFile;
        }

        public int RegistrarFincaFotoGeoreferenciada(RegistrarActualizarFincaFotoGeoreferenciadaRequestDTO request, IFormFile file)
        {
            FincaFotoGeoreferenciada socioFinca = _Mapper.Map<FincaFotoGeoreferenciada>(request);
            socioFinca.FechaRegistro = DateTime.Now;
            socioFinca.UsuarioRegistro = request.Usuario;

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

                    socioFinca.Nombre = file.FileName;
                    ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
                    {
                        filtros = new AdjuntarArchivosDTO()
                        {
                            archivoStream = fileBytes,
                            filename = file.FileName,
                        },
                        pathFile = _fileServerSettings.Value.FincasFotoGeoreferenciada

                    });
                    socioFinca.Path = _fileServerSettings.Value.FincasFotoGeoreferenciada + "\\" + response.ficheroReal;
                }
            }



            //if (file != null)
            //{
            //    if (file.Length > 0)
            //    {
            //        //Adjuntos
            //        socioFinca.Nombre = file.FileName;
            //        ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
            //        {
            //            filtros = new AdjuntarArchivosDTO()
            //            {
            //                archivoStream = fileBytes,
            //                filename = file.FileName,
            //            },
            //            pathFile = _fileServerSettings.Value.FincasCertificacion

            //        });
            //        socioFinca.Path = _fileServerSettings.Value.FincasCertificacion + "\\" + response.ficheroReal;
            //    }
            //}

            int affected = _IFincaFotoGeoreferenciadaRepository.Insertar(socioFinca);

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

        public int ActualizarFincaFotoGeoreferenciada(RegistrarActualizarFincaFotoGeoreferenciadaRequestDTO request, IFormFile file)
        {
            FincaFotoGeoreferenciada socioFinca = _Mapper.Map<FincaFotoGeoreferenciada>(request);
            //socioFinca.Nombre = request.Nombre;
            //socioFinca.Path = request.Path;
            socioFinca.FechaUltimaActualizacion = DateTime.Now;
            socioFinca.UsuarioUltimaActualizacion = request.Usuario;

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

                    socioFinca.Nombre = file.FileName;
                    ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
                    {
                        filtros = new AdjuntarArchivosDTO()
                        {
                            archivoStream = fileBytes,
                            filename = file.FileName,
                        },
                        pathFile = _fileServerSettings.Value.FincasFotoGeoreferenciada

                    });

                    socioFinca.Path = _fileServerSettings.Value.FincasFotoGeoreferenciada + "\\" + response.ficheroReal;
                }
            }


            ////Adjuntos
            //if (file != null)
            //{
            //    if (file.Length > 0)
            //    {
            //        socioFinca.Nombre = file.FileName;
            //        ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
            //        {
            //            filtros = new AdjuntarArchivosDTO()
            //            {
            //                archivoStream = fileBytes,
            //                filename = file.FileName,
            //            },
            //            pathFile = _fileServerSettings.Value.FincasCertificacion

            //        });

            //        socioFinca.Path = _fileServerSettings.Value.FincasCertificacion + "\\" + response.ficheroReal;
            //    }
            //}

            int affected = _IFincaFotoGeoreferenciadaRepository.Actualizar(socioFinca);

            return affected;
        }

        public IEnumerable<ConsultaFincaFotoGeoreferenciadaPorId> ConsultarFincaFotoGeoreferenciadaPorFincaId(ConsultaFincaFotoGeoreferenciadaPorFincaIdRequestDTO request)
        {
            return _IFincaFotoGeoreferenciadaRepository.ConsultarFincaFotoGeoreferenciadaPorFincaId(request.FincaId);
        }

        public ConsultaFincaFotoGeoreferenciadaPorId ConsultarFincaFotoGeoreferenciadaPorId(ConsultaFincaFotoGeoreferenciadaPorIdRequestDTO request)
        {
            return _IFincaFotoGeoreferenciadaRepository.ConsultarFincaFotoGeoreferenciadaPorId(request.FincaFotoGeoreferenciadaId);
        }

        public int EliminarFincaFotoGeoreferenciada(RegistrarActualizarFincaFotoGeoreferenciadaRequestDTO request)
        {
            ConsultaFincaFotoGeoreferenciadaPorId fincaFotoGeoreferenciada = _IFincaFotoGeoreferenciadaRepository.ConsultarFincaFotoGeoreferenciadaPorId(request.FincaFotoGeoreferenciadaId);

            var AdjuntoBl = new AdjuntarArchivosBL(_fileServerSettings);

            int affected = _IFincaFotoGeoreferenciadaRepository.Eliminar(request.FincaFotoGeoreferenciadaId);

            EliminarArchivoAdjuntoDTO adjunto = new EliminarArchivoAdjuntoDTO();
            adjunto.pathFile = fincaFotoGeoreferenciada.Path;

            if (!string.IsNullOrEmpty(adjunto.pathFile))
            {
                AdjuntoBl.EliminarArchivo(adjunto);
            }



            return affected;
        }


    }
}
