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
    public class OrdenProcesoPlantaController : ControllerBase
    {
        private IOrdenProcesoPlantaService OrdenProcesoPlantaService;
        private Core.Common.Logger.ILog _log;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IMaestroService _maestroService;
        public OrdenProcesoPlantaController(IMaestroService maestroService, IOrdenProcesoPlantaService OrdenProcesoPlantaService, Core.Common.Logger.ILog log, IWebHostEnvironment webHostEnvironment)
        {
            _log = log;
            _maestroService = maestroService;
            this.OrdenProcesoPlantaService = OrdenProcesoPlantaService;
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("Consultar")]
        [HttpPost]
        public IActionResult Consultar([FromBody] ConsultaOrdenProcesoPlantaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            ConsultaOrdenProcesoPlantaResponseDTO response = new ConsultaOrdenProcesoPlantaResponseDTO();
            try
            {
                response.Result.Data = OrdenProcesoPlantaService.ConsultarOrdenProcesoPlanta(request);
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

        [Route("Registrar")]
        [HttpPost]
        public IActionResult Registrar( IFormFile file,  [FromForm] string request)
        
        //public IActionResult Registrar( [FromBody] RegistrarActualizarOrdenProcesoPlantaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            RegistrarActualizarOrdenProcesoPlantaResponseDTO response = new RegistrarActualizarOrdenProcesoPlantaResponseDTO();
            try
            {
                var myJsonObject = JsonConvert.DeserializeObject<RegistrarActualizarOrdenProcesoPlantaRequestDTO>(request);
                response.Result.Data = OrdenProcesoPlantaService.RegistrarOrdenProcesoPlanta(myJsonObject, file);
                //response.Result.Data = OrdenProcesoPlantaService.RegistrarOrdenProcesoPlanta(request);
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
        //public IActionResult Registrar(RegistrarActualizarOrdenProcesoPlantaRequestDTO request)
        //{
        //    Guid guid = Guid.NewGuid();
        //    _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

        //    RegistrarActualizarOrdenProcesoPlantaResponseDTO response = new RegistrarActualizarOrdenProcesoPlantaResponseDTO();
        //    try
        //    {
        //        var myJsonObject = JsonConvert.DeserializeObject<RegistrarActualizarOrdenProcesoPlantaRequestDTO>(request);
        //        response.Result.Data = OrdenProcesoPlantaService.RegistrarOrdenProcesoPlanta(request, null);
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

        [Route("Actualizar")]
        [HttpPost]
        public IActionResult Actualizar(IFormFile file, [FromForm] string request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            RegistrarActualizarOrdenProcesoPlantaResponseDTO response = new RegistrarActualizarOrdenProcesoPlantaResponseDTO();
            try
            {
                var myJsonObject = JsonConvert.DeserializeObject<RegistrarActualizarOrdenProcesoPlantaRequestDTO>(request);
                response.Result.Data = OrdenProcesoPlantaService.ActualizarOrdenProcesoPlanta(myJsonObject, file);
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

        //[Route("Actualizar")]
        //[HttpPost]
        //public IActionResult Actualizar(RegistrarActualizarOrdenProcesoPlantaRequestDTO request)
        //{
        //    Guid guid = Guid.NewGuid();
        //   // _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

        //    RegistrarActualizarOrdenProcesoPlantaResponseDTO response = new RegistrarActualizarOrdenProcesoPlantaResponseDTO();
        //    try
        //    {
        //        //var myJsonObject = JsonConvert.DeserializeObject<RegistrarActualizarOrdenProcesoPlantaRequestDTO>(request);
        //        response.Result.Data = OrdenProcesoPlantaService.ActualizarOrdenProcesoPlanta(request, null);
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



        [Route("ConsultarPorId")]
        [HttpPost]
        public IActionResult ConsultarPorId([FromBody] ConsultaOrdenProcesoPlantaPorIdRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            ConsultaOrdenProcesoPlantaPorIdResponseDTO response = new ConsultaOrdenProcesoPlantaPorIdResponseDTO();
            try
            {
                response.Result.Data = OrdenProcesoPlantaService.ConsultarOrdenProcesoPlantaPorId(request);
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

        [Route("ConsultarDetallePorId")]
        [HttpPost]
        public IActionResult ConsultarDetallePorId([FromBody] ConsultaOrdenProcesoPlantaPorIdRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            ConsultaOrdenProcesoPlantaPorIdResponseDTO response = new ConsultaOrdenProcesoPlantaPorIdResponseDTO();
            try
            {
                response.Result.Data = OrdenProcesoPlantaService.ConsultarOrdenProcesoPlantaDetallePorId(request);
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

        //[Route("Anular")]
        //[HttpPost]
        //public IActionResult Anular([FromBody] AnularOrdenProcesoPlantaRequestDTO request)
        //{
        //    Guid guid = Guid.NewGuid();
        //    _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

        //    AnularOrdenProcesoPlantaResponseDTO response = new AnularOrdenProcesoPlantaResponseDTO();
        //    try
        //    {
        //        response.Result.Data = OrdenProcesoPlantaService.AnularOrdenProcesoPlanta(request);
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

        //    ImpresionOrdenProcesoPlantaResponseDTO response = new ImpresionOrdenProcesoPlantaResponseDTO();
        //    try
        //    {
        //        ConsultarImpresionOrdenProcesoPlantaRequestDTO request = new ConsultarImpresionOrdenProcesoPlantaRequestDTO { OrdenProcesoPlantaId = id };
        //        ConsultarImpresionOrdenProcesoPlantaResponseDTO resImpresion = OrdenProcesoPlantaService.ConsultarImpresionOrdenProcesoPlanta(request);

        //        var path = $"{this._webHostEnvironment.ContentRootPath}\\Reportes\\rptOrdenProcesoPlanta.rdlc";

        //        LocalReport lr = new LocalReport(path);
        //        Dictionary<string, string> parameters = new Dictionary<string, string>();

        //        //TODO: impresionListaProductores
        //        lr.AddDataSource("dsOrdenProcesoPlanta", resImpresion.listOrdenProcesoPlanta.ToList());
        //        lr.AddDataSource("dsDetalleOrdenProcesoPlanta", resImpresion.listDetalleOrdenProcesoPlanta.ToList());
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

        [Route("DescargarArchivo")]
        //[HttpPost]
        [HttpGet()]
        public IActionResult DescargarArchivo([FromQuery(Name = "path")] string path, [FromQuery(Name = "name")] string name)
        {
            DescargarArchivoRequestDTO response = new DescargarArchivoRequestDTO();
            RequestDescargarArchivoDTO request = new RequestDescargarArchivoDTO();
            request.PathFile = path;
            request.ArchivoVisual = name;
            try
            {
                response.Result.Data = OrdenProcesoPlantaService.DescargarArchivo(request);
                response.Result.Success = true;

                string extension = Path.GetExtension(request.PathFile);

                Response.Clear();
                switch (extension)
                {
                    case ".docx":
                        Response.Headers.Add("Content-type", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
                        break;
                    case ".jpg":
                        Response.Headers.Add("Content-type", "image/jpeg");
                        break;
                    case ".png":
                        Response.Headers.Add("Content-type", "image/png");
                        break;
                    case ".pdf":
                        Response.Headers.Add("Content-type", "application/pdf");
                        break;
                    case ".xls":
                        Response.Headers.Add("Content-type", "application/vnd.ms-excel");
                        break;
                    case ".xlsx":
                        Response.Headers.Add("Content-type", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                        break;
                    case ".doc":
                        Response.Headers.Add("Content-type", "application/msword");
                        break;
                }

                var contentDispositionHeader = new ContentDisposition()
                {
                    FileName = request.ArchivoVisual,
                    DispositionType = "attachment"
                };

                Response.Headers.Add("Content-Length", response.Result.Data.archivoBytes.Length.ToString());
                Response.Headers.Add("Content-Disposition", contentDispositionHeader.ToString());
                Response.Body.WriteAsync(response.Result.Data.archivoBytes);
            }
            catch (ResultException ex)
            {
                response.Result = new Result() { Success = true, ErrCode = ex.Result.ErrCode, Message = ex.Result.Message };
            }
            catch (Exception ex)
            {
                response.Result = new Result() { Success = false, Message = "Ocurrio un problema en el servicio, intentelo nuevamente." };
            }
            return null;
        }


        [Route("GenerarPDFOrdenProceso")]
        [HttpGet]
        public IActionResult GenerarPDFOrdenProceso(int id, int empresaId)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(id)}");

            //ES MOMENTANEO SE DEBE ELIMINAR
            GenerarPDFLiquidacionProcesoResponseDTO response = new GenerarPDFLiquidacionProcesoResponseDTO(); ;

            try
            {
                List<ConsultaOrdenProcesoPlantaPorIdBE> listaLiquidacionProcesoPlanta = new List<ConsultaOrdenProcesoPlantaPorIdBE>();

                ConsultaOrdenProcesoPlantaPorIdRequestDTO consultaOrdenProcesoPlantaPorIdRequestDTO = new ConsultaOrdenProcesoPlantaPorIdRequestDTO();
                consultaOrdenProcesoPlantaPorIdRequestDTO.OrdenProcesoPlantaId = id;

                ConsultaOrdenProcesoPlantaPorIdBE consultaOrdenProcesoPlantaPorIdBE = OrdenProcesoPlantaService.ConsultarOrdenProcesoPlantaPorId(consultaOrdenProcesoPlantaPorIdRequestDTO);


                if (consultaOrdenProcesoPlantaPorIdBE != null)
                {
                    listaLiquidacionProcesoPlanta.Add(consultaOrdenProcesoPlantaPorIdBE);
                }

                string mimetype = "";
                int extension = 1;
                var path = $"{_webHostEnvironment.ContentRootPath}\\Reportes\\rptOrdenProcesoPlanta.rdlc";

                LocalReport lr = new LocalReport(path);
                Dictionary<string, string> parameters = new Dictionary<string, string>();

                DataTable dsLiquidacionProceso = Util.ToDataTable(listaLiquidacionProcesoPlanta, true);
                DataTable dsLiquidProcesoDetalle = Util.ToDataTable(consultaOrdenProcesoPlantaPorIdBE.detalle, true);
                //DataTable dsLiquidProcesoResultado = Util.ToDataTable(response.data.Resultado, true);
                List<ConsultaDetalleTablaBE> tablaTablas = _maestroService.ConsultarDetalleTablaDeTablas(empresaId, "ES");

                List<ConsultaDetalleTablaBE> tiposCafeProcesado = tablaTablas.Where(a => a.CodigoTabla.Trim().Equals("TiposCafeProcesado")).ToList();

                DataTable dsLiquidProcesoResultado = Util.ToDataTable(tiposCafeProcesado, true);




                if (listaLiquidacionProcesoPlanta.Count > 0)
                {
                    lr.AddDataSource("dsOrdenProceso", dsLiquidacionProceso);
                    lr.AddDataSource("dsOrdenProcesoDetalle", dsLiquidProcesoDetalle);
                    lr.AddDataSource("dsOrdenProcesoResultado", dsLiquidProcesoResultado);


                }
                if (listaLiquidacionProcesoPlanta.Count >0 && consultaOrdenProcesoPlantaPorIdBE.detalle != null)
                {
                }
                //if (response != null && response.data.Resultado != null)
                //{
                //}
                var result = lr.Execute(RenderType.Pdf, extension, parameters, mimetype);

                return File(result.MainStream, "application/pdf");
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
    }
}
