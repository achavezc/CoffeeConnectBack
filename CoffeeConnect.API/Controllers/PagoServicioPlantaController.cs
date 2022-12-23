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
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace CoffeeConnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoServicioPlantaController : ControllerBase
    {
        private IPagoServicioPlantaService PagoServicioPlantaService;
        private Core.Common.Logger.ILog _log;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IMaestroService _maestroService;
        public PagoServicioPlantaController(IMaestroService maestroService, IPagoServicioPlantaService PagoServicioPlantaService, Core.Common.Logger.ILog log, IWebHostEnvironment webHostEnvironment)
        {
            _log = log;
            _maestroService = maestroService;
            this.PagoServicioPlantaService = PagoServicioPlantaService;
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("Consultar")]
        [HttpPost]
        public IActionResult Consultar([FromBody] ConsultaPagoServicioPlantaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            ConsultaPagoServicioPlantaResponseDTO response = new ConsultaPagoServicioPlantaResponseDTO();
            try
            {
                response.Result.Data = PagoServicioPlantaService.ConsultarPagoServicioPlanta(request);
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
        //public IActionResult Registrar( IFormFile file,  [FromForm] string request)
        
        ////public IActionResult Registrar( [FromBody] RegistrarActualizarPagoServicioPlantaRequestDTO request)
        //{
        //    Guid guid = Guid.NewGuid();
        //    _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

        //    RegistrarActualizarPagoServicioPlantaResponseDTO response = new RegistrarActualizarPagoServicioPlantaResponseDTO();
        //    try
        //    {
        //        var myJsonObject = JsonConvert.DeserializeObject<RegistrarActualizarPagoServicioPlantaRequestDTO>(request);
        //        response.Result.Data = PagoServicioPlantaService.RegistrarPagoServicioPlanta(myJsonObject, file);
        //        //response.Result.Data = PagoServicioPlantaService.RegistrarPagoServicioPlanta(request);
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

        ////[Route("Registrar")]
        ////[HttpPost]
        ////public IActionResult Registrar(RegistrarActualizarPagoServicioPlantaRequestDTO request)
        ////{
        ////    Guid guid = Guid.NewGuid();
        ////    _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

        ////    RegistrarActualizarPagoServicioPlantaResponseDTO response = new RegistrarActualizarPagoServicioPlantaResponseDTO();
        ////    try
        ////    {
        ////        var myJsonObject = JsonConvert.DeserializeObject<RegistrarActualizarPagoServicioPlantaRequestDTO>(request);
        ////        response.Result.Data = PagoServicioPlantaService.RegistrarPagoServicioPlanta(request, null);
        ////        response.Result.Success = true;
        ////    }
        ////    catch (ResultException ex)
        ////    {
        ////        response.Result = new Result() { Success = true, ErrCode = ex.Result.ErrCode, Message = ex.Result.Message };
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        response.Result = new Result() { Success = false, Message = "Ocurrio un problema en el servicio, intentelo nuevamente." };
        ////        _log.RegistrarEvento(ex, guid.ToString());
        ////    }

        ////    _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(response)}");
        ////    return Ok(response);
        ////}

        //[Route("Actualizar")]
        //[HttpPost]
        //public IActionResult Actualizar(IFormFile file, [FromForm] string request)
        //{
        //    Guid guid = Guid.NewGuid();
        //    _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

        //    RegistrarActualizarPagoServicioPlantaResponseDTO response = new RegistrarActualizarPagoServicioPlantaResponseDTO();
        //    try
        //    {
        //        var myJsonObject = JsonConvert.DeserializeObject<RegistrarActualizarPagoServicioPlantaRequestDTO>(request);
        //        response.Result.Data = PagoServicioPlantaService.ActualizarPagoServicioPlanta(myJsonObject, file);
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

        ////[Route("Actualizar")]
        ////[HttpPost]
        ////public IActionResult Actualizar(RegistrarActualizarPagoServicioPlantaRequestDTO request)
        ////{
        ////    Guid guid = Guid.NewGuid();
        ////   // _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

        ////    RegistrarActualizarPagoServicioPlantaResponseDTO response = new RegistrarActualizarPagoServicioPlantaResponseDTO();
        ////    try
        ////    {
        ////        //var myJsonObject = JsonConvert.DeserializeObject<RegistrarActualizarPagoServicioPlantaRequestDTO>(request);
        ////        response.Result.Data = PagoServicioPlantaService.ActualizarPagoServicioPlanta(request, null);
        ////        response.Result.Success = true;
        ////    }
        ////    catch (ResultException ex)
        ////    {
        ////        response.Result = new Result() { Success = true, ErrCode = ex.Result.ErrCode, Message = ex.Result.Message };
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        response.Result = new Result() { Success = false, Message = "Ocurrio un problema en el servicio, intentelo nuevamente." };
        ////        _log.RegistrarEvento(ex, guid.ToString());
        ////    }

        ////    _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(response)}");

        ////    return Ok(response);
        ////}



        //[Route("ConsultarPorId")]
        //[HttpPost]
        //public IActionResult ConsultarPorId([FromBody] ConsultaPagoServicioPlantaPorIdRequestDTO request)
        //{
        //    Guid guid = Guid.NewGuid();
        //    _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

        //    ConsultaPagoServicioPlantaPorIdResponseDTO response = new ConsultaPagoServicioPlantaPorIdResponseDTO();
        //    try
        //    {
        //        response.Result.Data = PagoServicioPlantaService.ConsultarPagoServicioPlantaPorId(request);
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
        //public IActionResult ConsultarDetallePorId([FromBody] ConsultaPagoServicioPlantaPorIdRequestDTO request)
        //{
        //    Guid guid = Guid.NewGuid();
        //    _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

        //    ConsultaPagoServicioPlantaPorIdResponseDTO response = new ConsultaPagoServicioPlantaPorIdResponseDTO();
        //    try
        //    {
        //        response.Result.Data = PagoServicioPlantaService.ConsultarPagoServicioPlantaDetallePorId(request);
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

        ////[Route("Anular")]
        ////[HttpPost]
        ////public IActionResult Anular([FromBody] AnularPagoServicioPlantaRequestDTO request)
        ////{
        ////    Guid guid = Guid.NewGuid();
        ////    _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

        ////    AnularPagoServicioPlantaResponseDTO response = new AnularPagoServicioPlantaResponseDTO();
        ////    try
        ////    {
        ////        response.Result.Data = PagoServicioPlantaService.AnularPagoServicioPlanta(request);
        ////        response.Result.Success = true;
        ////    }
        ////    catch (ResultException ex)
        ////    {
        ////        response.Result = new Result() { Success = true, ErrCode = ex.Result.ErrCode, Message = ex.Result.Message };
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        response.Result = new Result() { Success = false, Message = "Ocurrio un problema en el servicio, intentelo nuevamente." };
        ////        _log.RegistrarEvento(ex, guid.ToString());
        ////    }

        ////    _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(response)}");
        ////    return Ok(response);
        ////}

        ////[Route("Imprimir")]
        ////[HttpGet]
        ////public IActionResult Imprimir(int id)
        ////{
        ////    return this.generar(id);
        ////}

        ////private IActionResult generar(int id)
        ////{
        ////    Guid guid = Guid.NewGuid();
        ////    _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(id)}");

        ////    ImpresionPagoServicioPlantaResponseDTO response = new ImpresionPagoServicioPlantaResponseDTO();
        ////    try
        ////    {
        ////        ConsultarImpresionPagoServicioPlantaRequestDTO request = new ConsultarImpresionPagoServicioPlantaRequestDTO { PagoServicioPlantaId = id };
        ////        ConsultarImpresionPagoServicioPlantaResponseDTO resImpresion = PagoServicioPlantaService.ConsultarImpresionPagoServicioPlanta(request);

        ////        var path = $"{this._webHostEnvironment.ContentRootPath}\\Reportes\\rptPagoServicioPlanta.rdlc";

        ////        LocalReport lr = new LocalReport(path);
        ////        Dictionary<string, string> parameters = new Dictionary<string, string>();

        ////        //TODO: impresionListaProductores
        ////        lr.AddDataSource("dsPagoServicioPlanta", resImpresion.listPagoServicioPlanta.ToList());
        ////        lr.AddDataSource("dsDetallePagoServicioPlanta", resImpresion.listDetallePagoServicioPlanta.ToList());
        ////        var result = lr.Execute(RenderType.Pdf, 1, parameters, "");

        ////        return File(result.MainStream, "application/pdf");
        ////    }
        ////    catch (ResultException ex)
        ////    {
        ////        response.Result = new Result() { Success = true, ErrCode = ex.Result.ErrCode, Message = ex.Result.Message };
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        response.Result = new Result() { Success = false, Message = "Ocurrio un problema en el servicio, intentelo nuevamente." };
        ////        _log.RegistrarEvento(ex, guid.ToString());
        ////    }

        ////    _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(response)}");

        ////    return Ok(response);
        ////}

        //[Route("DescargarArchivo")]
        ////[HttpPost]
        //[HttpGet()]
        //public IActionResult DescargarArchivo([FromQuery(Name = "path")] string path, [FromQuery(Name = "name")] string name)
        //{
        //    DescargarArchivoRequestDTO response = new DescargarArchivoRequestDTO();
        //    RequestDescargarArchivoDTO request = new RequestDescargarArchivoDTO();
        //    request.PathFile = path;
        //    request.ArchivoVisual = name;
        //    try
        //    {
        //        response.Result.Data = PagoServicioPlantaService.DescargarArchivo(request);
        //        response.Result.Success = true;

        //        string extension = Path.GetExtension(request.PathFile);

        //        Response.Clear();
        //        switch (extension)
        //        {
        //            case ".docx":
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


        //[Route("GenerarPDFOrdenProceso")]
        //[HttpGet]
        //public IActionResult GenerarPDFOrdenProceso(int id, int empresaId)
        
        //{
        //    Guid guid = Guid.NewGuid();
        //    _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(id)}");

        //    //ES MOMENTANEO SE DEBE ELIMINAR
        //    GenerarPDFLiquidacionProcesoResponseDTO response = new GenerarPDFLiquidacionProcesoResponseDTO(); ;

        //    try
        //    {
        //        List<ConsultaPagoServicioPlantaPorIdBE> listaLiquidacionProcesoPlanta = new List<ConsultaPagoServicioPlantaPorIdBE>();

        //        ConsultaPagoServicioPlantaPorIdRequestDTO consultaPagoServicioPlantaPorIdRequestDTO = new ConsultaPagoServicioPlantaPorIdRequestDTO();
        //        consultaPagoServicioPlantaPorIdRequestDTO.PagoServicioPlantaId = id;

        //        ConsultaPagoServicioPlantaPorIdBE consultaPagoServicioPlantaPorIdBE = PagoServicioPlantaService.ConsultarPagoServicioPlantaPorId(consultaPagoServicioPlantaPorIdRequestDTO);


               
        //            string[] certificacionesIds = consultaPagoServicioPlantaPorIdBE.CertificacionId.Split('|');

        //            string certificacionLabel = string.Empty;
        //            string tipoContratoLabel = string.Empty;


        //        List<ConsultaDetalleTablaBE> tablaTablas = _maestroService.ConsultarDetalleTablaDeTablas(empresaId, "ES");

        //        List<ConsultaDetalleTablaBE> tiposCafeProcesado = tablaTablas.Where(a => a.CodigoTabla.Trim().Equals("TiposCafeProcesado")).ToList();

        //        if (certificacionesIds.Length > 0)
        //        {

        //            List<ConsultaDetalleTablaBE> certificaciones = tablaTablas.Where(a => a.CodigoTabla.Trim().Equals("TipoCertificacionPlanta")).ToList();

        //            foreach (string certificacionId in certificacionesIds)
        //            {

        //                ConsultaDetalleTablaBE certificacion = certificaciones.Where(a => a.Codigo == certificacionId).FirstOrDefault();

        //                if (certificacion != null)
        //                {
        //                    certificacionLabel = certificacionLabel + certificacion.Label + " ";
        //                }
        //            }

        //        }

        //        consultaPagoServicioPlantaPorIdBE.Certificacion = certificacionLabel;


        //        if (consultaPagoServicioPlantaPorIdBE != null)
        //        {
        //            listaLiquidacionProcesoPlanta.Add(consultaPagoServicioPlantaPorIdBE);
        //        }

        //        string mimetype = "";
        //        int extension = 1;
        //        var path = $"{_webHostEnvironment.ContentRootPath}\\Reportes\\rptPagoServicioPlanta.rdlc";

        //        LocalReport lr = new LocalReport(path);
        //        Dictionary<string, string> parameters = new Dictionary<string, string>();

        //        DataTable dsLiquidacionProceso = Util.ToDataTable(listaLiquidacionProcesoPlanta, true);
        //        DataTable dsLiquidProcesoDetalle = Util.ToDataTable(consultaPagoServicioPlantaPorIdBE.detalle, true);
        //        //DataTable dsLiquidProcesoResultado = Util.ToDataTable(response.data.Resultado, true);
                


        //        DataTable dsLiquidProcesoResultado = Util.ToDataTable(tiposCafeProcesado, true);




        //        if (listaLiquidacionProcesoPlanta.Count > 0)
        //        {
        //            lr.AddDataSource("dsOrdenProceso", dsLiquidacionProceso);
        //            lr.AddDataSource("dsOrdenProcesoDetalle", dsLiquidProcesoDetalle);
        //            lr.AddDataSource("dsOrdenProcesoResultado", dsLiquidProcesoResultado);


        //        }
        //        if (listaLiquidacionProcesoPlanta.Count >0 && consultaPagoServicioPlantaPorIdBE.detalle != null)
        //        {
        //        }
        //        //if (response != null && response.data.Resultado != null)
        //        //{
        //        //}
        //        var result = lr.Execute(RenderType.Pdf, extension, parameters, mimetype);

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
    }
}
