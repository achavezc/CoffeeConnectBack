//using AspNetCore.Reporting;
using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adjunto;
using CoffeeConnect.Interface.Service;
using Core.Common;
using Core.Common.Domain.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tmds.Utils;

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
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
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

        [Route("Registrar")]
        [HttpPost]
        public IActionResult Registrar(RegistrarActualizarLiquidacionProcesoPlantaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            RegistrarActualizarLiquidacionProcesoPlantaResponseDTO response = new RegistrarActualizarLiquidacionProcesoPlantaResponseDTO();
            try
            {

                response.Result.Data = LiquidacionProcesoPlantaService.RegistrarLiquidacionProcesoPlanta(request);
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

        [Route("Actualizar")]
        [HttpPost]
        public IActionResult Actualizar(RegistrarActualizarLiquidacionProcesoPlantaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            RegistrarActualizarLiquidacionProcesoPlantaResponseDTO response = new RegistrarActualizarLiquidacionProcesoPlantaResponseDTO();
            try
            {

                response.Result.Data = LiquidacionProcesoPlantaService.ActualizarLiquidacionProcesoPlanta(request);
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

        [Route("ConsultarPorId")]
        [HttpPost]
        public IActionResult ConsultarPorId([FromBody] ConsultaLiquidacionProcesoPlantaPorIdRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            ConsultaLiquidacionProcesoPlantaPorIdResponseDTO response = new ConsultaLiquidacionProcesoPlantaPorIdResponseDTO();
            try
            {
                response.Result.Data = LiquidacionProcesoPlantaService.ConsultarLiquidacionProcesoPlantaPorId(request);
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

        //[Route("GenerarPDFLiquidacionProceso")]
        //[HttpGet]
        //public IActionResult GenerarPDFLiquidacionProceso(int id, int empresaId)
        //{
        //    Guid guid = Guid.NewGuid();
        //    _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(id)}");

        //    //ES MOMENTANEO SE DEBE ELIMINAR
        //    GenerarPDFLiquidacionProcesoResponseDTO response = new GenerarPDFLiquidacionProcesoResponseDTO(); ;

        //    try
        //    {
        //        List<ConsultaLiquidacionProcesoPlantaPorIdBE> listaLiquidacionProcesoPlanta = new List<ConsultaLiquidacionProcesoPlantaPorIdBE>();

        //        response.data = LiquidacionProcesoPlantaService.ConsultarLiquidacionProcesoPlantaPorId(new ConsultaLiquidacionProcesoPlantaPorIdRequestDTO
        //        {
        //            LiquidacionProcesoPlantaId = id,
        //            EmpresaId = empresaId
        //        });

        //        var path = "";

        //        DataTable dsLiquidacionProceso = Util.ToDataTable(listaLiquidacionProcesoPlanta, true);

        //        DataTable dsLiquidProcesoResultado = Util.ToDataTable(response.data.Resultado, true);



        //        if (response != null && response.data != null)
        //        {
        //            if(response.data.TipoProcesoId!= "02") //Transformacion)
        //            {
        //                path = $"{_webHostEnvironment.ContentRootPath}\\Reportes\\rptLiquidacionProceso.rdlc";
        //            }
        //            else
        //            {
        //                //List<ConsultaLiquidacionProcesoPlantaDetalleBE> detalle = response.data.Detalle.ToList();

        //                //if (detalle.Count > 0)
        //                //{
        //                //    decimal kilosNetos = 0;
        //                //    decimal kilosBrutos = 0;
        //                //    decimal cantidad = 0;
        //                //    decimal h2o = 0;


        //                //    List<ConsultaLiquidacionProcesoPlantaDetalleBE> detalle2 = new List<ConsultaLiquidacionProcesoPlantaDetalleBE>();
        //                //    detalle2.Add(detalle[0]);

        //                //    foreach (ConsultaLiquidacionProcesoPlantaDetalleBE detalleItem in detalle2)
        //                //    {
        //                //        kilosNetos = kilosNetos + detalleItem.KilosNetos;
        //                //        kilosBrutos = kilosBrutos + detalleItem.KilosBrutos;
        //                //        cantidad = kilosNetos + detalleItem.Cantidad;
        //                //        h2o = h2o + detalleItem.PorcentajeHumedad;
        //                //    }

        //                //    detalle2[0].KilosNetos = kilosNetos;
        //                //    detalle2[0].KilosBrutos = kilosBrutos;
        //                //    detalle2[0].Cantidad = cantidad;
        //                //    detalle2[0].PorcentajeHumedad = h2o / detalle2.Count;

        //                //    response.data.Detalle = detalle2;
        //                //}



        //                path = $"{_webHostEnvironment.ContentRootPath}\\Reportes\\rptLiquidacionSecado.rdlc";
        //            }
        //                listaLiquidacionProcesoPlanta.Add(response.data);
        //        }

        //        DataTable dsLiquidProcesoDetalle = Util.ToDataTable(response.data.Detalle, true);

        //        string mimetype = "";
        //        int extension = 1;


        //        LocalReport lr = new LocalReport(path);
        //        Dictionary<string, string> parameters = new Dictionary<string, string>();



        //        if (listaLiquidacionProcesoPlanta.Count > 0)
        //        {
        //            lr.AddDataSource("dsLiquidacionProceso", dsLiquidacionProceso);
        //        }
        //        if (response != null && response.data.Detalle != null)
        //        {
        //            lr.AddDataSource("dsLiquidProcesoDetalle", dsLiquidProcesoDetalle);
        //        }
        //        if (response != null && response.data.Resultado != null)
        //        {
        //            lr.AddDataSource("dsLiquidProcesoResultado", dsLiquidProcesoResultado);
        //        }
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

        [Route("GenerarPDFLiquidacionProceso")]
        [HttpGet]
        public IActionResult GenerarPDFLiquidacionProceso(int id, int empresaId)
        {
            /*
            LifetimeServices.LeaseTime = TimeSpan.FromSeconds(5);
            LifetimeServices.LeaseManagerPollTime = TimeSpan.FromSeconds(5);
            LifetimeServices.RenewOnCallTime = TimeSpan.FromSeconds(1);
            LifetimeServices.SponsorshipTimeout = TimeSpan.FromSeconds(5);
            */
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(id)}");

            //ES MOMENTANEO SE DEBE ELIMINAR
            GenerarPDFLiquidacionProcesoResponseDTO response = new GenerarPDFLiquidacionProcesoResponseDTO(); ;

            try
            {
                List<ConsultaLiquidacionProcesoPlantaPorIdBE> listaLiquidacionProcesoPlanta = new List<ConsultaLiquidacionProcesoPlantaPorIdBE>();

                response.data = LiquidacionProcesoPlantaService.ConsultarLiquidacionProcesoPlantaPorId(new ConsultaLiquidacionProcesoPlantaPorIdRequestDTO
                {
                    LiquidacionProcesoPlantaId = id,
                    EmpresaId = empresaId
                });

                var path = "";

               

               

                DataTable dsLiquidProcesoDetalle = null;

                if (response != null && response.data != null)
                {

                    if (response.data.TipoProcesoId == "01") //Transformacion)
                    {
                        dsLiquidProcesoDetalle = Util.ToDataTable(response.data.Detalle, true);
                        path = $"{_webHostEnvironment.ContentRootPath}\\Reportes\\rptLiquidacionProceso.rdlc";
                    }
                    else
                    {
                        path = $"{_webHostEnvironment.ContentRootPath}\\Reportes\\rptLiquidacionSecado.rdlc";

                        List<ConsultaLiquidacionProcesoPlantaDetalleBE> detalle = response.data.Detalle.ToList();

                        if (detalle.Count > 0)
                        {
                            decimal kilosNetos = 0;
                            decimal kilosBrutos = 0;
                            decimal cantidad = 0;
                            decimal h2o = 0;


                            List<ConsultaLiquidacionProcesoPlantaDetalleBE> detalle2 = new List<ConsultaLiquidacionProcesoPlantaDetalleBE>();
                            detalle2.Add(detalle[0]);

                            foreach (ConsultaLiquidacionProcesoPlantaDetalleBE detalleItem in detalle)
                            {
                                kilosNetos = kilosNetos + detalleItem.KilosNetos;
                                kilosBrutos = kilosBrutos + detalleItem.KilosBrutos;
                                cantidad = cantidad + detalleItem.Cantidad;
                                h2o = h2o + detalleItem.PorcentajeHumedad;
                            }

                            detalle2[0].KilosNetos = kilosNetos;
                            detalle2[0].KilosBrutos = kilosBrutos;
                            detalle2[0].Cantidad = cantidad;
                            detalle2[0].PorcentajeHumedad = h2o / detalle2.Count;

                            dsLiquidProcesoDetalle = Util.ToDataTable(detalle2, true);

                             
                        }
                    }



                    listaLiquidacionProcesoPlanta.Add(response.data);

                    
                }
                DataTable dsLiquidacionProceso = Util.ToDataTable(listaLiquidacionProcesoPlanta, true);

                DataTable dsLiquidProcesoResultado = Util.ToDataTable(response.data.Resultado, true);

                
                //LocalReport lr = new LocalReport(path);
                
                Dictionary<string, string> parameters = new Dictionary<string, string>();

                string mimetype = "";
                int extension = 1;

                if (listaLiquidacionProcesoPlanta.Count > 0)
                {
                   // lr.AddDataSource("dsLiquidacionProceso", dsLiquidacionProceso);
                }
                if (response != null && response.data.Detalle != null)
                {
                    //lr.AddDataSource("dsLiquidProcesoDetalle", dsLiquidProcesoDetalle);
                }
                if (response != null && response.data.Resultado != null)
                {
                   // lr.AddDataSource("dsLiquidProcesoResultado", dsLiquidProcesoResultado);
                }

                //var result = lr.Execute(RenderType.Pdf, extension, parameters, mimetype);
                //return File(result.MainStream, "application/pdf");
                

               // using var fs = new FileStream(path, FileMode.Open);
                
                using (var fs = System.IO.File.Open(path,FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    LocalReport report = new LocalReport();
                    report.LoadReportDefinition(fs);
                    report.DataSources.Add(new ReportDataSource("dsLiquidacionProceso", dsLiquidacionProceso));
                    report.DataSources.Add(new ReportDataSource("dsLiquidProcesoDetalle", dsLiquidProcesoDetalle));
                    report.DataSources.Add(new ReportDataSource("dsLiquidProcesoResultado", dsLiquidProcesoResultado));
                    byte[] bytes = report.Render("PDF");

                    fs.Close();
                    return File(bytes, "application/pdf");
                }
               
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
