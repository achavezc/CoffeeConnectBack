
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
using System.Text;

namespace CoffeeConnect.Service
{
    public partial class DiagnosticoService : IDiagnosticoService
    {
        private readonly IMapper _Mapper;
        private IDiagnosticoRepository _IDiagnosticoRepository;
        private ICorrelativoRepository _ICorrelativoRepository;
        public IOptions<FileServerSettings> _fileServerSettings;

        public DiagnosticoService(IDiagnosticoRepository DiagnosticoRepository, ICorrelativoRepository correlativoRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings)
        {
            _IDiagnosticoRepository = DiagnosticoRepository;
            _ICorrelativoRepository = correlativoRepository;
            _Mapper = mapper;
            _fileServerSettings = fileServerSettings;
        }

        private string getRutaFisica(string pathFile)
        {
            return _fileServerSettings.Value.RutaPrincipal + pathFile;
        }

        public int ActualizarDiagnostico(RegistrarActualizarDiagnosticoRequestDTO request, IFormFile file)
        {
            Diagnostico Diagnostico = _Mapper.Map<Diagnostico>(request);
            Diagnostico.FechaUltimaActualizacion = DateTime.Now;
            Diagnostico.UsuarioUltimaActualizacion = request.Usuario;

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

                    Diagnostico.NombreArchivo = file.FileName;
                    ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
                    {
                        filtros = new AdjuntarArchivosDTO()
                        {
                            archivoStream = fileBytes,
                            filename = file.FileName,
                        },
                        pathFile = _fileServerSettings.Value.Diagnostico
                    });

                    Diagnostico.PathArchivo = _fileServerSettings.Value.Diagnostico + "\\" + response.ficheroReal;
                }
            }

            int affected = _IDiagnosticoRepository.Actualizar(Diagnostico);

            if (request.DiagnosticoCostoProduccionList.FirstOrDefault() != null)
            {
                request.DiagnosticoCostoProduccionList.ForEach(z =>
                {
                    z.DiagnosticoId = request.DiagnosticoId;
                });

                _IDiagnosticoRepository.ActualizarDiagnosticoCostoProduccion(request.DiagnosticoCostoProduccionList, request.DiagnosticoId);
            }

            if (request.DiagnosticoDatosCampoList.FirstOrDefault() != null)
            {
                request.DiagnosticoDatosCampoList.ForEach(z =>
                {
                    z.DiagnosticoId = request.DiagnosticoId;
                });

                _IDiagnosticoRepository.ActualizarDiagnosticoDatosCampo(request.DiagnosticoDatosCampoList, request.DiagnosticoId);
            }

            if (request.DiagnosticoInfraestructuraList.FirstOrDefault() != null)
            {
                request.DiagnosticoInfraestructuraList.ForEach(z =>
                {
                    z.DiagnosticoId = request.DiagnosticoId;
                });

                _IDiagnosticoRepository.ActualizarDiagnosticoInfraestructura(request.DiagnosticoInfraestructuraList, request.DiagnosticoId);
            }

            return affected;
        }

        public int RegistrarDiagnostico(RegistrarActualizarDiagnosticoRequestDTO request, IFormFile file)
        {
            Diagnostico Diagnostico = _Mapper.Map<Diagnostico>(request);
            Diagnostico.FechaRegistro = DateTime.Now;
            Diagnostico.UsuarioRegistro = request.Usuario;
            Diagnostico.Numero = _ICorrelativoRepository.Obtener(null, Documentos.Diagnostico);

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

                    Diagnostico.NombreArchivo = file.FileName;
                    //Adjuntos
                    ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
                    {
                        filtros = new AdjuntarArchivosDTO()
                        {
                            archivoStream = fileBytes,
                            filename = file.FileName,
                        },
                        pathFile = _fileServerSettings.Value.Diagnostico
                    });
                    Diagnostico.PathArchivo = _fileServerSettings.Value.Diagnostico + "\\" + response.ficheroReal;
                }
            }

            int DiagnosticoId = _IDiagnosticoRepository.Insertar(Diagnostico);

            if (request.DiagnosticoCostoProduccionList.FirstOrDefault() != null)
            {
                request.DiagnosticoCostoProduccionList.ForEach(z =>
                {
                    z.DiagnosticoId = DiagnosticoId;
                });

                _IDiagnosticoRepository.ActualizarDiagnosticoCostoProduccion(request.DiagnosticoCostoProduccionList, DiagnosticoId);
            }

            if (request.DiagnosticoDatosCampoList.FirstOrDefault() != null)
            {
                request.DiagnosticoDatosCampoList.ForEach(z =>
                {
                    z.DiagnosticoId = DiagnosticoId;
                });

                _IDiagnosticoRepository.ActualizarDiagnosticoDatosCampo(request.DiagnosticoDatosCampoList, DiagnosticoId);
            }

            if (request.DiagnosticoInfraestructuraList.FirstOrDefault() != null)
            {
                request.DiagnosticoInfraestructuraList.ForEach(z =>
                {
                    z.DiagnosticoId = DiagnosticoId;
                });

                _IDiagnosticoRepository.ActualizarDiagnosticoInfraestructura(request.DiagnosticoInfraestructuraList, DiagnosticoId);
            }

            return DiagnosticoId;
        }

        public List<ConsultaDiagnosticoBE> ConsultarDiagnostico(ConsultaDiagnosticoRequestDTO request)
        {
            //if (string.IsNullOrEmpty(request.Numero) && string.IsNullOrEmpty(request.Ruc) && string.IsNullOrEmpty(request.RazonSocial))
            //    throw new ResultException(new Result { ErrCode = "01", Message = "Comercial.Diagnostico.ValidacionSeleccioneMinimoUnFiltro.Label" });


            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Comercial.Diagnostico.ValidacionRangoFechaMayor2anios.Label" });



            var list = _IDiagnosticoRepository.ConsultarDiagnostico(request);

            return list.ToList();
        }

        public ConsultaDiagnosticoPorIdBE ConsultarDiagnosticoPorId(ConsultaDiagnosticoPorIdRequestDTO request)
        {
            ConsultaDiagnosticoPorIdBE consultaDiagnosticoPorIdBE = _IDiagnosticoRepository.ConsultarDiagnosticoPorId(request.DiagnosticoId);

            if (consultaDiagnosticoPorIdBE != null)
            {
                consultaDiagnosticoPorIdBE.DiagnosticoInfraestructura = _IDiagnosticoRepository.ConsultarDiagnosticoInfraestructuraPorId(request.DiagnosticoId).ToList();
                consultaDiagnosticoPorIdBE.DiagnosticoDatosCampo = _IDiagnosticoRepository.ConsultarDiagnosticoDatosCampoPorId(request.DiagnosticoId).ToList();
                consultaDiagnosticoPorIdBE.DiagnosticoCostoProduccion = _IDiagnosticoRepository.ConsultarDiagnosticoCostoProduccionPorId(request.DiagnosticoId).ToList();
            }
            return consultaDiagnosticoPorIdBE;
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
