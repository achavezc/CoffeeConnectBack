
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Service;
using Core.Common;
using Core.Common.Domain.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
using System;
using System.Collections.Generic;
using System.IO;

namespace Integracion.Deuda.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaSalidaAlmacenPlantaController : ControllerBase
    {
        private INotaSalidaAlmacenPlantaService _NotaSalidaAlmacenPlantaService;
        private IGuiaRemisionAlmacenPlantaService _guiaRemisionAlmacenService;

        private Core.Common.Logger.ILog _log;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public NotaSalidaAlmacenPlantaController(INotaSalidaAlmacenPlantaService NotaSalidaAlmacenPlantaService, IGuiaRemisionAlmacenPlantaService guiaRemisionAlmacenService, Core.Common.Logger.ILog log, IWebHostEnvironment webHostEnvironment)
        {
            _NotaSalidaAlmacenPlantaService = NotaSalidaAlmacenPlantaService;
            _guiaRemisionAlmacenService = guiaRemisionAlmacenService;

            _log = log;
            _webHostEnvironment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [HttpGet("version")]
        public IActionResult Version()
        {
            return Ok("NotaSalidaAlmacenPlanta Service. version: 1.20.01.03");
        }

        [Route("Registrar")]
        [HttpPost]
        public IActionResult Registrar([FromBody] RegistrarNotaSalidaAlmacenPlantaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            RegistrarNotaCompraResponseDTO response = new RegistrarNotaCompraResponseDTO();
            try
            {
                response.Result.Data = _NotaSalidaAlmacenPlantaService.RegistrarNotaSalidaAlmacenPlanta(request);

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

            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }

        [Route("Actualizar")]
        [HttpPost]
        public IActionResult Actualizar([FromBody] RegistrarNotaSalidaAlmacenPlantaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            RegistrarNotaCompraResponseDTO response = new RegistrarNotaCompraResponseDTO();
            try
            {
                response.Result.Data = _NotaSalidaAlmacenPlantaService.ActualizarNotaSalidaAlmacenPlanta(request);

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

            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }

        [Route("Anular")]
        [HttpPost]
        public IActionResult Anular([FromBody] AnularNotaSalidaAlmacenPlantaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            AnularNotaSalidaAlmacenPlantaResponseDTO response = new AnularNotaSalidaAlmacenPlantaResponseDTO();
            try
            {
                response.Result.Data = _NotaSalidaAlmacenPlantaService.AnularNotaSalidaAlmacenPlanta(request);

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

            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("Consultar")]
        [HttpPost]
        public IActionResult Consultar([FromBody] ConsultaNotaSalidaAlmacenPlantaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaNotaSalidaAlmacenPlantaResponseDTO response = new ConsultaNotaSalidaAlmacenPlantaResponseDTO();
            try
            {
                response.Result.Data = _NotaSalidaAlmacenPlantaService.ConsultarNotaSalidaAlmacenPlanta(request);

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

            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }


        [Route("ConsultarPorId")]
        [HttpPost]
        public IActionResult ConsultarPorId([FromBody] ConsultaNotaSalidaAlmacenPlantaPorIdRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaNotaSalidaAlmacenPlantaPorIdResponseDTO response = new ConsultaNotaSalidaAlmacenPlantaPorIdResponseDTO();
            try
            {
                response.Result.Data = _NotaSalidaAlmacenPlantaService.ConsultarNotaSalidaAlmacenPlantaPorId(request);

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

            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }

        [Route("GenerarPDFNotaSalida")]
        [HttpGet]
        public IActionResult GenerarPDFNotaSalida(int id, int empresaId)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(id)}");

            GenerarPDFNotaSalidaAlmacenPlantaResponseDTO response = _NotaSalidaAlmacenPlantaService.GenerarPDFNotaSalidaAlmacenPlanta(id, empresaId);

            try
            {
               
                var path = $"{_webHostEnvironment.ContentRootPath}\\Reportes\\rptNotaSalida.rdlc";
                /*
                string mimetype = "";
                int extension = 1;
                LocalReport lr = new LocalReport(path);
                Dictionary<string, string> parameters = new Dictionary<string, string>();

                lr.AddDataSource("dsGRCabecera", Util.ToDataTable(response.Cabecera));
                lr.AddDataSource("dsGRListaDetalle", Util.ToDataTable(response.listaDetalleGM));
                lr.AddDataSource("dsGRDetalle", Util.ToDataTable(response.detalleGM));
                var result = lr.Execute(RenderType.Pdf, extension, parameters, mimetype);

                return File(result.MainStream, "application/pdf");
                */
                using (var fs = System.IO.File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    LocalReport report = new LocalReport();
                    report.LoadReportDefinition(fs);
                    report.DataSources.Add(new ReportDataSource("dsGRCabecera", Util.ToDataTable(response.Cabecera)));
                    report.DataSources.Add(new ReportDataSource("dsGRListaDetalle", Util.ToDataTable(response.listaDetalleGM)));
                    report.DataSources.Add(new ReportDataSource("dsGRDetalle", Util.ToDataTable(response.detalleGM)));
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

            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }

        [Route("GenerarPDFGuiaRemision")]
        [HttpGet]
        public IActionResult GenerarPDFGuiaRemisionPlanta(int id)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(id)}");

            GenerarPDFGuiaRemisionResponseDTO response = _guiaRemisionAlmacenService.GenerarPDFGuiaRemisionPlantaPorNotaSalidaAlmacenId(id);

            try
            {
                GenerarPDFGuiaRemisionRequestDTO request = new GenerarPDFGuiaRemisionRequestDTO { LoteId = id };
               
                var path = $"{_webHostEnvironment.ContentRootPath}\\Reportes\\rptGuiaRemision.rdlc";
                /*
                string mimetype = "";
                int extension = 1;
                LocalReport lr = new LocalReport(path);
                Dictionary<string, string> parameters = new Dictionary<string, string>();

                lr.AddDataSource("dsGRCabecera", Util.ToDataTable(response.Cabecera));
                lr.AddDataSource("dsGRListaDetalle", Util.ToDataTable(response.listaDetalleGM));
                lr.AddDataSource("dsGRDetalle", Util.ToDataTable(response.detalleGM));
                var result = lr.Execute(RenderType.Pdf, extension, parameters, mimetype);

                return File(result.MainStream, "application/pdf");
                */
                using (var fs = System.IO.File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    LocalReport report = new LocalReport();
                    report.LoadReportDefinition(fs);
                    report.DataSources.Add(new ReportDataSource("dsGRCabecera", Util.ToDataTable(response.Cabecera)));
                    report.DataSources.Add(new ReportDataSource("dsGRListaDetalle", Util.ToDataTable(response.listaDetalleGM)));
                    report.DataSources.Add(new ReportDataSource("dsGRDetalle", Util.ToDataTable(response.detalleGM)));
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

            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }



    }
}
