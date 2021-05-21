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
    public partial class ProductorDocumentoService : IProductorDocumentoService
    {
        private readonly IMapper _Mapper;
        private IOptions<FileServerSettings> _fileServerSettings;
        private IProductorDocumentoRepository _ProductorDocumentoRepository;

        public ProductorDocumentoService(IMapper mapper, IOptions<FileServerSettings> fileServerSettings, IProductorDocumentoRepository ProductorDocumentoService)
        {
            _fileServerSettings = fileServerSettings;
            _Mapper = mapper;
            _ProductorDocumentoRepository = ProductorDocumentoService;
        }

        public int ActualizarProductorDocumento(RegistrarProductorDocumentoRequestDTO request, IFormFile file)
        {
            ProductorDocumento ProductorDocumento = _Mapper.Map<ProductorDocumento>(request);
            ProductorDocumento.FechaUltimaActualizacion = DateTime.Now;
            ProductorDocumento.UsuarioUltimaActualizacion = request.Usuario;

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

                    ProductorDocumento.Nombre = file.FileName;
                    ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
                    {
                        filtros = new AdjuntarArchivosDTO()
                        {
                            archivoStream = fileBytes,
                            filename = file.FileName,
                        },
                        pathFile = _fileServerSettings.Value.ProductorDocumento

                    });

                    ProductorDocumento.Path = _fileServerSettings.Value.ProductorDocumento + "\\" + response.ficheroReal;
                }
            }

            int affected = _ProductorDocumentoRepository.Actualizar(ProductorDocumento);

            return affected;
        }

        public IEnumerable<ConsultarProductorDocumentoPorProductorId> ConsultarProductorDocumentoPorProductorId(ConsultarProductorDocumentoPorProductorIdRequestDTO request)
        {
            return _ProductorDocumentoRepository.ConsultarProductorDocumentoPorProductorId(request.ProductorId);
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

        public int RegistrarProductorDocumento(RegistrarProductorDocumentoRequestDTO request, IFormFile file)
        {
            ProductorDocumento ProductorDocumento = _Mapper.Map<ProductorDocumento>(request);
            ProductorDocumento.FechaRegistro = DateTime.Now;
            ProductorDocumento.UsuarioRegistro = request.Usuario;

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

                    ProductorDocumento.Nombre = file.FileName;
                    ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
                    {
                        filtros = new AdjuntarArchivosDTO()
                        {
                            archivoStream = fileBytes,
                            filename = file.FileName,
                        },
                        pathFile = _fileServerSettings.Value.ProductorDocumento
                    });
                    ProductorDocumento.Path = _fileServerSettings.Value.ProductorDocumento + "\\" + response.ficheroReal;
                }
            }

            int affected = _ProductorDocumentoRepository.Insertar(ProductorDocumento);

            return affected;
        }

        private String getRutaFisica(string pathFile)
        {
            return _fileServerSettings.Value.RutaPrincipal + pathFile;
        }
    }
}
