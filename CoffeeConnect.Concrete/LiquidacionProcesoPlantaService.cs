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
    public partial class LiquidacionProcesoPlantaService : ILiquidacionProcesoPlantaService
    {
        private readonly IMapper _Mapper;
        private ILiquidacionProcesoPlantaRepository _ILiquidacionProcesoPlantaRepository;
        public IOptions<FileServerSettings> _fileServerSettings;
        private ICorrelativoRepository _ICorrelativoRepository;

        public LiquidacionProcesoPlantaService(ILiquidacionProcesoPlantaRepository LiquidacionProcesoPlantaRepository, ICorrelativoRepository correlativoRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings)
        {
            _ILiquidacionProcesoPlantaRepository = LiquidacionProcesoPlantaRepository;
            _Mapper = mapper;
            _fileServerSettings = fileServerSettings;
            _ICorrelativoRepository = correlativoRepository;
        }

        public List<ConsultaLiquidacionProcesoPlantaBE> ConsultarLiquidacionProcesoPlanta(ConsultaLiquidacionProcesoPlantaRequestDTO request)
        {
            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Comercial.Contrato.ValidacionRangoFechaMayor2anios.Label" });

            var list = _ILiquidacionProcesoPlantaRepository.ConsultarLiquidacionProcesoPlanta(request);
            return list.ToList();
        }

        //public int RegistrarLiquidacionProcesoPlanta(RegistrarActualizarLiquidacionProcesoPlantaRequestDTO request, IFormFile file)
        //{
        //    LiquidacionProcesoPlanta LiquidacionProcesoPlanta = _Mapper.Map<LiquidacionProcesoPlanta>(request);
        //    LiquidacionProcesoPlanta.FechaRegistro = DateTime.Now;
        //    LiquidacionProcesoPlanta.UsuarioRegistro = request.Usuario;
        //    LiquidacionProcesoPlanta.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.LiquidacionProcesoPlanta);

        //    var AdjuntoBl = new AdjuntarArchivosBL(_fileServerSettings);
        //    byte[] fileBytes = null;

        //    if (file != null)
        //    {
        //        if (file.Length > 0)
        //        {
        //            using (var ms = new MemoryStream())
        //            {
        //                file.CopyTo(ms);
        //                fileBytes = ms.ToArray();
        //                string s = Convert.ToBase64String(fileBytes);
        //            }

        //            LiquidacionProcesoPlanta.NombreArchivo = file.FileName;
        //            //Adjuntos
        //            ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
        //            {
        //                filtros = new AdjuntarArchivosDTO()
        //                {
        //                    archivoStream = fileBytes,
        //                    filename = file.FileName,
        //                },
        //                pathFile = _fileServerSettings.Value.LiquidacionProcesoPlanta
        //            });
        //            LiquidacionProcesoPlanta.PathArchivo = _fileServerSettings.Value.LiquidacionProcesoPlanta + "\\" + response.ficheroReal;
        //        }
        //    }

        //    int LiquidacionProcesoPlantaId = _ILiquidacionProcesoPlantaRepository.Insertar(LiquidacionProcesoPlanta);

        //    foreach (LiquidacionProcesoPlantaDetalle detalle in request.LiquidacionProcesoPlantaDetalle)
        //    {
        //        detalle.LiquidacionProcesoPlantaId = LiquidacionProcesoPlantaId;
        //        _ILiquidacionProcesoPlantaRepository.InsertarProcesoPlantaDetalle(detalle);
        //    }
        //    return LiquidacionProcesoPlantaId;
        //}

        //public int ActualizarLiquidacionProcesoPlanta(RegistrarActualizarLiquidacionProcesoPlantaRequestDTO request, IFormFile file)
        //{
        //    LiquidacionProcesoPlanta LiquidacionProcesoPlanta = _Mapper.Map<LiquidacionProcesoPlanta>(request);

        //    var AdjuntoBl = new AdjuntarArchivosBL(_fileServerSettings);
        //    byte[] fileBytes = null;
        //    if (file != null)
        //    {
        //        if (file.Length > 0)
        //        {
        //            using (var ms = new MemoryStream())
        //            {
        //                file.CopyTo(ms);
        //                fileBytes = ms.ToArray();
        //                string s = Convert.ToBase64String(fileBytes);
        //            }

        //            LiquidacionProcesoPlanta.NombreArchivo = file.FileName;
        //            ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
        //            {
        //                filtros = new AdjuntarArchivosDTO()
        //                {
        //                    archivoStream = fileBytes,
        //                    filename = file.FileName,
        //                },
        //                pathFile = _fileServerSettings.Value.LiquidacionProcesoPlanta

        //            });

        //            LiquidacionProcesoPlanta.PathArchivo = _fileServerSettings.Value.LiquidacionProcesoPlanta + "\\" + response.ficheroReal;
        //        }
        //    }

        //    LiquidacionProcesoPlanta.FechaUltimaActualizacion = DateTime.Now;
        //    LiquidacionProcesoPlanta.UsuarioUltimaActualizacion = request.Usuario;
        //    int affected = _ILiquidacionProcesoPlantaRepository.Actualizar(LiquidacionProcesoPlanta);

        //    _ILiquidacionProcesoPlantaRepository.EliminarProcesoPlantaDetalle(LiquidacionProcesoPlanta.LiquidacionProcesoPlantaId);

            
        //    foreach (LiquidacionProcesoPlantaDetalle detalle in request.LiquidacionProcesoPlantaDetalle)
        //    {
        //        detalle.LiquidacionProcesoPlantaId = request.LiquidacionProcesoPlantaId;
        //        _ILiquidacionProcesoPlantaRepository.InsertarProcesoPlantaDetalle(detalle);
        //    }


        //    return affected;
        //}

        //public ConsultaLiquidacionProcesoPlantaPorIdBE ConsultarLiquidacionProcesoPlantaPorId(ConsultaLiquidacionProcesoPlantaPorIdRequestDTO request)
        //{
        //    ConsultaLiquidacionProcesoPlantaPorIdBE consultaLiquidacionProcesoPlantaPorIdBE = _ILiquidacionProcesoPlantaRepository.ConsultarLiquidacionProcesoPlantaPorId(request.LiquidacionProcesoPlantaId);

        //    if (consultaLiquidacionProcesoPlantaPorIdBE != null)
        //    {
        //        consultaLiquidacionProcesoPlantaPorIdBE.detalle = _ILiquidacionProcesoPlantaRepository.ConsultarLiquidacionProcesoPlantaDetallePorId(request.LiquidacionProcesoPlantaId).ToList();
        //    }

        //    return consultaLiquidacionProcesoPlantaPorIdBE;
        //}

        //public ConsultaLiquidacionProcesoPlantaPorIdBE ConsultarLiquidacionProcesoPlantaDetallePorId(ConsultaLiquidacionProcesoPlantaPorIdRequestDTO request)
        //{
        //    ConsultaLiquidacionProcesoPlantaPorIdBE consultaLiquidacionProcesoPlantaPorIdBE = new ConsultaLiquidacionProcesoPlantaPorIdBE();

            
        //     consultaLiquidacionProcesoPlantaPorIdBE.detalle = _ILiquidacionProcesoPlantaRepository.ConsultarLiquidacionProcesoPlantaDetallePorId(request.LiquidacionProcesoPlantaId).ToList();
            

        //    return consultaLiquidacionProcesoPlantaPorIdBE;
        //}

        ////public int AnularLiquidacionProcesoPlanta(AnularLiquidacionProcesoPlantaRequestDTO request)
        ////{
        ////    int result = 0;
        ////    if(request.LiquidacionProcesoPlantaId > 0)
        ////    {
        ////        result = _ILiquidacionProcesoPlantaRepository.Anular(request.LiquidacionProcesoPlantaId, DateTime.Now, request.Usuario, LiquidacionProcesoPlantaEstados.Anulado);
        ////    }
        ////    return result;
        ////}

        ////public ConsultarImpresionLiquidacionProcesoPlantaResponseDTO ConsultarImpresionLiquidacionProcesoPlanta(ConsultarImpresionLiquidacionProcesoPlantaRequestDTO request)
        ////{
        ////    ConsultarImpresionLiquidacionProcesoPlantaResponseDTO response = new ConsultarImpresionLiquidacionProcesoPlantaResponseDTO();
        ////    response.listLiquidacionProcesoPlanta = _ILiquidacionProcesoPlantaRepository.ConsultarImpresionLiquidacionProcesoPlanta(request.LiquidacionProcesoPlantaId);
        ////    response.listDetalleLiquidacionProcesoPlanta = _ILiquidacionProcesoPlantaRepository.ConsultarLiquidacionProcesoPlantaDetallePorId(request.LiquidacionProcesoPlantaId);
        ////    return response;
        ////}

        //private String getRutaFisica(string pathFile)
        //{
        //    return _fileServerSettings.Value.RutaPrincipal + pathFile;
        //}

        //public ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request)
        //{
        //    try
        //    {
        //        string rutaReal = Path.Combine(getRutaFisica(request.PathFile));

        //        if (File.Exists(rutaReal))
        //        {
        //            byte[] archivoBytes = File.ReadAllBytes(rutaReal);
        //            return new ResponseDescargarArchivoDTO()
        //            {
        //                archivoBytes = archivoBytes,
        //                errores = new Dictionary<string, string>(),
        //                ficheroVisual = request.ArchivoVisual
        //            };
        //        }
        //        else
        //        {
        //            var resp = new ResponseDescargarArchivoDTO()
        //            {
        //                archivoBytes = null,
        //                errores = new Dictionary<string, string>(),
        //                ficheroVisual = ""
        //            };
        //            resp.errores.Add("Error", "El Archivo solicitado no existe");
        //            return resp;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
