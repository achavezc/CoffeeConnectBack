
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
    public partial class FincaDocumentoAdjuntoService : IFincaDocumentoAdjuntoService
    {
        private readonly IMapper _Mapper;
       

        private IFincaDocumentoAdjuntoRepository _IFincaDocumentoAdjuntoRepository;


        public IOptions<FileServerSettings> _fileServerSettings;
     
        public FincaDocumentoAdjuntoService(IFincaDocumentoAdjuntoRepository FincaDocumentoAdjuntoRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings)
        {
            _IFincaDocumentoAdjuntoRepository = FincaDocumentoAdjuntoRepository;
            _fileServerSettings = fileServerSettings;
            _Mapper = mapper;



        }
        private String getRutaFisica(string pathFile)
        {
            return _fileServerSettings.Value.RutaPrincipal + pathFile;
        }

        public int RegistrarFincaDocumentoAdjunto(RegistrarActualizarFincaDocumentoAdjuntoRequestDTO request, IFormFile file)
        {
            FincaDocumentoAdjunto socioFinca = _Mapper.Map<FincaDocumentoAdjunto>(request);
            socioFinca.FechaRegistro = DateTime.Now;
            socioFinca.UsuarioRegistro = request.Usuario;

            var AdjuntoBl = new AdjuntarArchivosBL(_fileServerSettings);
            byte[] fileBytes = null ;
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
                        pathFile = _fileServerSettings.Value.FincasDocumentoAdjunto

                    });
                    socioFinca.Path = _fileServerSettings.Value.FincasCertificacion + "\\" + response.ficheroReal;
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

            int affected = _IFincaDocumentoAdjuntoRepository.Insertar(socioFinca);

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

        public int ActualizarFincaDocumentoAdjunto(RegistrarActualizarFincaDocumentoAdjuntoRequestDTO request, IFormFile file)
        {
            FincaDocumentoAdjunto socioFinca = _Mapper.Map<FincaDocumentoAdjunto>(request);
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
                        pathFile = _fileServerSettings.Value.FincasDocumentoAdjunto

                    });

                    socioFinca.Path = _fileServerSettings.Value.FincasCertificacion + "\\" + response.ficheroReal;
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

            int affected = _IFincaDocumentoAdjuntoRepository.Actualizar(socioFinca);

            return affected;
        }

        public IEnumerable<ConsultaFincaDocumentoAdjuntoPorId> ConsultarFincaDocumentoAdjuntoPorFincaId(ConsultaFincaDocumentoAdjuntoPorFincaIdRequestDTO request)
        {
            return _IFincaDocumentoAdjuntoRepository.ConsultarFincaDocumentoAdjuntoPorFincaId(request.FincaId);
        }

        public ConsultaFincaDocumentoAdjuntoPorId ConsultarFincaDocumentoAdjuntoPorId(ConsultaFincaDocumentoAdjuntoPorIdRequestDTO request)
        {
            return _IFincaDocumentoAdjuntoRepository.ConsultarFincaDocumentoAdjuntoPorId(request.FincaDocumentoAdjuntoId);
        }

    }
}
