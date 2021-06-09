using AspNetCore.Reporting;
using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adjunto;
using CoffeeConnect.Interface.Service;
using Core.Common;
using Core.Common.Domain.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace CoffeeConnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiquidacionProcesoPlantaController : ControllerBase
    {
        private ILiquidacionProcesoPlantaService LiquidacionProcesoPlantaService;
        private Core.Common.Logger.ILog _log;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LiquidacionProcesoPlantaController(ILiquidacionProcesoPlantaService LiquidacionProcesoPlantaService, Core.Common.Logger.ILog log, IWebHostEnvironment webHostEnvironment)
        {
            _log = log;
            this.LiquidacionProcesoPlantaService = LiquidacionProcesoPlantaService;
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("Consultar")]
        [HttpPost]
        public IActionResult Consultar([FromBody] ConsultaLiquidacionProcesoPlantaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            ConsultaLiquidacionProcesoPlantaResponseDTO response = new ConsultaLiquidacionProcesoPlantaResponseDTO();
            try
            {
                response.Result.Data = LiquidacionProcesoPlantaService.ConsultarLiquidacionProcesoPlanta(request);
                response.Result.Success = true;
            }
            catch (ResultException ex)
            {
                response.Result = new Result() { Success = true, ErrCode = ex.Result.ErrCode, Message = ex.Result.Message };
            }
            catch (Exception ex)
            {
                response.Result = new Result() { Success = false, Message = "Ocurrio un problema en el servicio, intentelo nuevamente." };
                _log.RegistrarEvento(ex, guid.ToString());
            }

            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(response)}");
            return Ok(response);
        }

        //[Route("Registrar")]
        //[HttpPost]
        //public IActionResult Registrar(IFormFile file, [FromForm] string request)
        //{
        //    Guid guid = Guid.NewGuid();
        //    _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

        //    RegistrarActualizarLiquidacionProcesoPlantaResponseDTO response = new RegistrarActualizarLiquidacionProcesoPlantaResponseDTO();
        //    try
        //    {
        //        var myJsonObject = JsonConvert.DeserializeObject<RegistrarActualizarLiquidacionProcesoPlantaRequestDTO>(request);
        //        response.Result.Data = LiquidacionProcesoPlantaService.RegistrarLiquidacionProcesoPlanta(myJsonObject, file);
        //        response.Result.Success = true;
        //    }
        //    catch (ResultException ex)
        //    {
        //        response.Result = new Result() { Success = true, ErrCode = ex.Result.ErrCode, Message = ex.Result.Message };
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Result = new Result() { Success = false, Message = "Ocurrio un problema en el servicio, intentelo nuevamente." };
        //        _log.RegistrarEvento(ex, guid.ToString());
        //    }

        //    _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(response)}");
        //    return Ok(response);
        //}

        //[Route("Registrar")]
        //[HttpPost]
        //public IActionResult Registrar(RegistrarActualizarLiquidacionProcesoPlantaRequestDTO request)
        //{
        //    Guid guid = Guid.NewGuid();
        //    _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

        //    RegistrarActualizarLiquidacionProcesoPlantaResponseDTO response = new RegistrarActualizarLiquidacionProcesoPlantaResponseDTO();
        //    try
        //    {
        //        var myJsonObject = JsonConvert.DeserializeObject<RegistrarActualizarLiquidacionProcesoPlantaRequestDTO>(request);
        //        response.Result.Data = LiquidacionProcesoPlantaService.RegistrarLiquidacionProcesoPlanta(request, null);
        //        response.Result.Success = true;
        //    }
        //    catch (ResultException ex)
        //    {
        //        response.Result = new Result() { Success = true, ErrCode = ex.Result.ErrCode, Message = ex.Result.Message };
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Result = new Result() { Success = false, Message = "Ocurrio un problema en el servicio, intentelo nuevamente." };
        //        _log.RegistrarEvento(ex, guid.ToString());
        //    }

        //    _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(response)}");
        //    return Ok(response);
        //}

        //[Route("Actualizar")]
        //[HttpPost]
        //public IActionResult Actualizar(IFormFile file, [FromForm] string request)
        //{
        //    Guid guid = Guid.NewGuid();
        //    _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

        //    RegistrarActualizarLiquidacionProcesoPlantaResponseDTO response = new RegistrarActualizarLiquidacionProcesoPlantaResponseDTO();
        //    try
        //    {
        //        var myJsonObject = JsonConvert.DeserializeObject<RegistrarActualizarLiquidacionProcesoPlantaRequestDTO>(request);
        //        response.Result.Data = LiquidacionProcesoPlantaService.ActualizarLiquidacionProcesoPlanta(myJsonObject, file);
        //        response.Result.Success = true;
        //    }
        //    catch (ResultException ex)
        //    {
        //        response.Result = new Result() { Success = true, ErrCode = ex.Result.ErrCode, Message = ex.Result.Message };
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Result = new Result() { Success = false, Message = "Ocurrio un problema en el servicio, intentelo nuevamente." };
        //        _log.RegistrarEvento(ex, guid.ToString());
        //    }

        //    _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(response)}");

        //    return Ok(response);
        //}

        //[Route("Actualizar")]
        //[HttpPost]
        //public IActionResult Actualizar(RegistrarActualizarLiquidacionProcesoPlantaRequestDTO request)
        //{
        //    Guid guid = Guid.NewGuid();
        //   // _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

        //    RegistrarActualizarLiquidacionProcesoPlantaResponseDTO response = new RegistrarActualizarLiquidacionProcesoPlantaResponseDTO();
        //    try
        //    {
        //        //var myJsonObject = JsonConvert.DeserializeObject<RegistrarActualizarLiquidacionProcesoPlantaRequestDTO>(request);
        //        response.Result.Data = LiquidacionProcesoPlantaService.ActualizarLiquidacionProcesoPlanta(request, null);
        //        response.Result.Success = true;
        //    }
        //    catch (ResultException ex)
        //    {
        //        response.Result = new Result() { Success = true, ErrCode = ex.Result.ErrCode, Message = ex.Result.Message };
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Result = new Result() { Success = false, Message = "Ocurrio un problema en el servicio, intentelo nuevamente." };
        //        _log.RegistrarEvento(ex, guid.ToString());
        //    }

        //    _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(response)}");

        //    return Ok(response);
        //}



        //[Route("ConsultarPorId")]
        //[HttpPost]
        //public IActionResult ConsultarPorId([FromBody] ConsultaLiquidacionProcesoPlantaPorIdRequestDTO request)
        //{
        //    Guid guid = Guid.NewGuid();
        //    _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

        //    ConsultaLiquidacionProcesoPlantaPorIdResponseDTO response = new ConsultaLiquidacionProcesoPlantaPorIdResponseDTO();
        //    try
        //    {
        //        response.Result.Data = LiquidacionProcesoPlantaService.ConsultarLiquidacionProcesoPlantaPorId(request);
        //        response.Result.Success = true;
        //    }
        //    catch (ResultException ex)
        //    {
        //        response.Result = new Result() { Success = true, ErrCode = ex.Result.ErrCode, Message = ex.Result.Message };
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Result = new Result() { Success = false, Message = "Ocurrio un problema en el servicio, intentelo nuevamente." };
        //        _log.RegistrarEvento(ex, guid.ToString());
        //    }

        //    _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(response)}");
        //    return Ok(response);
        //}

        //[Route("ConsultarDetallePorId")]
        //[HttpPost]
        //public IActionResult ConsultarDetallePorId([FromBody] ConsultaLiquidacionProcesoPlantaPorIdRequestDTO request)
        //{
        //    Guid guid = Guid.NewGuid();
        //    _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

        //    ConsultaLiquidacionProcesoPlantaPorIdResponseDTO response = new ConsultaLiquidacionProcesoPlantaPorIdResponseDTO();
        //    try
        //    {
        //        response.Result.Data = LiquidacionProcesoPlantaService.ConsultarLiquidacionProcesoPlantaDetallePorId(request);
        //        response.Result.Success = true;
        //    }
        //    catch (ResultException ex)
        //    {
        //        response.Result = new Result() { Success = true, ErrCode = ex.Result.ErrCode, Message = ex.Result.Message };
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Result = new Result() { Success = false, Message = "Ocurrio un problema en el servicio, intentelo nuevamente." };
        //        _log.RegistrarEvento(ex, guid.ToString());
        //    }

        //    _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(response)}");
        //    return Ok(response);
        //}

        //[Route("Anular")]
        //[HttpPost]
        //public IActionResult Anular([FromBody] AnularLiquidacionProcesoPlantaRequestDTO request)
        //{
        //    Guid guid = Guid.NewGuid();
        //    _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

        //    AnularLiquidacionProcesoPlantaResponseDTO response = new AnularLiquidacionProcesoPlantaResponseDTO();
        //    try
        //    {
        //        response.Result.Data = LiquidacionProcesoPlantaService.AnularLiquidacionProcesoPlanta(request);
        //        response.Result.Success = true;
        //    }
        //    catch (ResultException ex)
        //    {
        //        response.Result = new Result() { Success = true, ErrCode = ex.Result.ErrCode, Message = ex.Result.Message };
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Result = new Result() { Success = false, Message = "Ocurrio un problema en el servicio, intentelo nuevamente." };
        //        _log.RegistrarEvento(ex, guid.ToString());
        //    }

        //    _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(response)}");
        //    return Ok(response);
        //}

        //[Route("Imprimir")]
        //[HttpGet]
        //public IActionResult Imprimir(int id)
        //{
        //    return this.generar(id);
        //}

        //private IActionResult generar(int id)
        //{
        //    Guid guid = Guid.NewGuid();
        //    _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(id)}");

        //    ImpresionLiquidacionProcesoPlantaResponseDTO response = new ImpresionLiquidacionProcesoPlantaResponseDTO();
        //    try
        //    {
        //        ConsultarImpresionLiquidacionProcesoPlantaRequestDTO request = new ConsultarImpresionLiquidacionProcesoPlantaRequestDTO { LiquidacionProcesoPlantaId = id };
        //        ConsultarImpresionLiquidacionProcesoPlantaResponseDTO resImpresion = LiquidacionProcesoPlantaService.ConsultarImpresionLiquidacionProcesoPlanta(request);

        //        var path = $"{this._webHostEnvironment.ContentRootPath}\\Reportes\\rptLiquidacionProcesoPlanta.rdlc";

        //        LocalReport lr = new LocalReport(path);
        //        Dictionary<string, string> parameters = new Dictionary<string, string>();

        //        //TODO: impresionListaProductores
        //        lr.AddDataSource("dsLiquidacionProcesoPlanta", resImpresion.listLiquidacionProcesoPlanta.ToList());
        //        lr.AddDataSource("dsDetalleLiquidacionProcesoPlanta", resImpresion.listDetalleLiquidacionProcesoPlanta.ToList());
        //        var result = lr.Execute(RenderType.Pdf, 1, parameters, "");

        //        return File(result.MainStream, "application/pdf");
        //    }
        //    catch (ResultException ex)
        //    {
        //        response.Result = new Result() { Success = true, ErrCode = ex.Result.ErrCode, Message = ex.Result.Message };
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Result = new Result() { Success = false, Message = "Ocurrio un problema en el servicio, intentelo nuevamente." };
        //        _log.RegistrarEvento(ex, guid.ToString());
        //    }

        //    _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(response)}");

        //    return Ok(response);
        //}

        //[Route("DescargarArchivo")]
        //[HttpPost]
        //[HttpGet()]
        //public IActionResult DescargarArchivo([FromQuery(Name = "path")] string path, [FromQuery(Name = "name")] string name)
        //{
        //    DescargarArchivoRequestDTO response = new DescargarArchivoRequestDTO();
        //    RequestDescargarArchivoDTO request = new RequestDescargarArchivoDTO();
        //    request.PathFile = path;
        //    request.ArchivoVisual = name;
        //    try
        //    {
        //        response.Result.Data = LiquidacionProcesoPlantaService.DescargarArchivo(request);
        //        response.Result.Success = true;

        //        string extension = Path.GetExtension(request.PathFile);

        //        Response.Clear();
        //        switch (extension)
        //        {
        //            case ".doxc":
        //                Response.Headers.Add("Content-type", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        //                break;
        //            case ".jpg":
        //                Response.Headers.Add("Content-type", "image/jpeg");
        //                break;
        //            case ".png":
        //                Response.Headers.Add("Content-type", "image/png");
        //                break;
        //            case ".pdf":
        //                Response.Headers.Add("Content-type", "application/pdf");
        //                break;
        //            case ".xls":
        //                Response.Headers.Add("Content-type", "application/vnd.ms-excel");
        //                break;
        //            case ".xlsx":
        //                Response.Headers.Add("Content-type", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        //                break;
        //            case ".doc":
        //                Response.Headers.Add("Content-type", "application/msword");
        //                break;
        //        }

        //        var contentDispositionHeader = new ContentDisposition()
        //        {
        //            FileName = request.ArchivoVisual,
        //            DispositionType = "attachment"
        //        };

        //        Response.Headers.Add("Content-Length", response.Result.Data.archivoBytes.Length.ToString());
        //        Response.Headers.Add("Content-Disposition", contentDispositionHeader.ToString());
        //        Response.Body.WriteAsync(response.Result.Data.archivoBytes);
        //    }
        //    catch (ResultException ex)
        //    {
        //        response.Result = new Result() { Success = true, ErrCode = ex.Result.ErrCode, Message = ex.Result.Message };
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Result = new Result() { Success = false, Message = "Ocurrio un problema en el servicio, intentelo nuevamente." };
        //    }
        //    return null;
        //}
    }
}
