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
    public partial class OrdenProcesoService : IOrdenProcesoService
    {
        private readonly IMapper _Mapper;
        private IOrdenProcesoRepository _IOrdenProcesoRepository;
        public IOptions<FileServerSettings> _fileServerSettings;
        private ICorrelativoRepository _ICorrelativoRepository;

        public OrdenProcesoService(IOrdenProcesoRepository ordenProcesoRepository, ICorrelativoRepository correlativoRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings)
        {
            _IOrdenProcesoRepository = ordenProcesoRepository;
            _Mapper = mapper;
            _fileServerSettings = fileServerSettings;
            _ICorrelativoRepository = correlativoRepository;
        }

        public List<ConsultaOrdenProcesoBE> ConsultarOrdenProceso(ConsultaOrdenProcesoRequestDTO request)
        {
            var timeSpan = request.FechaFinal - request.FechaInicio;

            if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Comercial.Contrato.ValidacionRangoFechaMayor2anios.Label" });

            var list = _IOrdenProcesoRepository.ConsultarOrdenProceso(request);
            return list.ToList();
        }

        public int RegistrarOrdenProceso(RegistrarActualizarOrdenProcesoRequestDTO request, IFormFile file)
        {
            OrdenProceso ordenProceso = _Mapper.Map<OrdenProceso>(request);
            ordenProceso.FechaRegistro = DateTime.Now;
            ordenProceso.UsuarioRegistro = request.UsuarioRegistro;
            ordenProceso.Numero = _ICorrelativoRepository.Obtener(null, Documentos.OrdenProceso);

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
                    }

                    ordenProceso.NombreArchivo = file.FileName;
                    //Adjuntos
                    ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
                    {
                        filtros = new AdjuntarArchivosDTO()
                        {
                            archivoStream = fileBytes,
                            filename = file.FileName,
                        },
                        pathFile = _fileServerSettings.Value.OrdenProceso
                    });
                    ordenProceso.PathArchivo = _fileServerSettings.Value.OrdenProceso + "\\" + response.ficheroReal;
                }
            }

            int affected = _IOrdenProcesoRepository.Insertar(ordenProceso);
            return affected;
        }

        public int ActualizarOrdenProceso(RegistrarActualizarOrdenProcesoRequestDTO request, IFormFile file)
        {
            OrdenProceso ordenProceso = _Mapper.Map<OrdenProceso>(request);

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
                    }

                    ordenProceso.NombreArchivo = file.FileName;
                    ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
                    {
                        filtros = new AdjuntarArchivosDTO()
                        {
                            archivoStream = fileBytes,
                            filename = file.FileName,
                        },
                        pathFile = _fileServerSettings.Value.OrdenProceso

                    });

                    ordenProceso.PathArchivo = _fileServerSettings.Value.OrdenProceso + "\\" + response.ficheroReal;
                }
            }

            ordenProceso.FechaUltimaActualizacion = DateTime.Now;
            ordenProceso.UsuarioUltimaActualizacion = request.UsuarioRegistro;
            int affected = _IOrdenProcesoRepository.Actualizar(ordenProceso);
            return affected;
        }
    }
}
