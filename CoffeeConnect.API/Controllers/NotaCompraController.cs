using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adelanto;
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
    public class NotaCompraController : ControllerBase
    {
        private INotaCompraService _notaCompraService;
        private Core.Common.Logger.ILog _log;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public NotaCompraController(INotaCompraService notaCompraService, Core.Common.Logger.ILog log, IWebHostEnvironment webHostEnvironment)
        {
            _notaCompraService = notaCompraService;
            _log = log;
            _webHostEnvironment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [HttpGet("version")]
        public IActionResult Version()
        {
            return Ok("NotaCompra Service. version: 1.20.01.03");
        }

        [Route("Registrar")]
        [HttpPost]
        public IActionResult Registrar([FromBody] RegistrarActualizarNotaCompraRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            RegistrarNotaCompraResponseDTO response = new RegistrarNotaCompraResponseDTO();
            try
            {
                response.Result.Data = _notaCompraService.RegistrarNotaCompra(request);

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
        public IActionResult Actualizar([FromBody] RegistrarActualizarNotaCompraRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            RegistrarNotaCompraResponseDTO response = new RegistrarNotaCompraResponseDTO();
            try
            {
                response.Result.Data = _notaCompraService.ActualizarNotaCompra(request);

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
        public IActionResult Anular([FromBody] AnularNotaCompraRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            AnularGuiaRecepcionMateriaPrimaResponseDTO response = new AnularGuiaRecepcionMateriaPrimaResponseDTO();
            try
            {
                response.Result.Data = _notaCompraService.AnularNotaCompra(request);

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

        [Route("Liquidar")]
        [HttpPost]
        public IActionResult Liquidar([FromBody] LiquidarNotaCompraRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            LiquidarNotaCompraResponseDTO response = new LiquidarNotaCompraResponseDTO();
            try
            {
                response.Result.Data = _notaCompraService.LiquidarNotaCompra(request);

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
        public IActionResult Consultar([FromBody] ConsultaNotaCompraRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaNotaCompraResponseDTO response = new ConsultaNotaCompraResponseDTO();
            try
            {
                response.Result.Data = _notaCompraService.ConsultarNotaCompra(request);

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

        [Route("ConsultarPorGuiaRecepcionMateriaPrimaId")]
        [HttpPost]
        public IActionResult ConsultarPorGuiaRecepcionMateriaPrimaId([FromBody] ConsultaNotaCompraPorGuiaRecepcionMateriaPrimaIdRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaNotaCompraPorGuiaRecepcionMateriaPrimaIdResponseDTO response = new ConsultaNotaCompraPorGuiaRecepcionMateriaPrimaIdResponseDTO();
            try
            {
                response.Result.Data = _notaCompraService.ConsultarNotaCompraPorGuiaRecepcionMateriaPrimaId(request);

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
        public IActionResult ConsultarPorId([FromBody] ConsultaNotaCompraPorIdRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaNotaCompraPorIdResponseDTO response = new ConsultaNotaCompraPorIdResponseDTO();
            try
            {
                response.Result.Data = _notaCompraService.ConsultarNotaCompraPorId(request);

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

        private IActionResult generar(int id)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(id)}");

            ConsultaNotaCompraPorGuiaRecepcionMateriaPrimaIdResponseDTO response = new ConsultaNotaCompraPorGuiaRecepcionMateriaPrimaIdResponseDTO();
            try
            {
                ConsultaNotaCompraPorGuiaRecepcionMateriaPrimaIdRequestDTO request = new ConsultaNotaCompraPorGuiaRecepcionMateriaPrimaIdRequestDTO();
                request.GuiaRecepcionMateriaPrimaId = id;

                ConsultaImpresionNotaCompraPorGuiaRecepcionMateriaPrimaIdBE item = _notaCompraService.ConsultarImpresionNotaCompraPorGuiaRecepcionMateriaPrimaId(request);

                List< ConsultaImpresionAdelantoBE> adelantos = _notaCompraService.ConsultarImpresionNotaCompraAdelantosPorGuiaRecepcionMateriaPrimaId(item.NotaCompraId);



                List<ConsultaImpresionNotaCompraPorGuiaRecepcionMateriaPrimaIdBE> lista = new List<ConsultaImpresionNotaCompraPorGuiaRecepcionMateriaPrimaIdBE>();
                lista.Add(item);

                
                var path = $"{this._webHostEnvironment.ContentRootPath}\\Reportes\\NotaCompra.rdlc";
                /*
                string mimetype = "";
                int extension = 1;
                LocalReport lr = new LocalReport(path);
                Dictionary<string, string> parameters = new Dictionary<string, string>();

                lr.AddDataSource("dsNotaCompra", Util.ToDataTable(lista));
                lr.AddDataSource("dsAdelanto", Util.ToDataTable(adelantos));

                var result = lr.Execute(RenderType.Pdf, extension, parameters, mimetype);

                return File(result.MainStream, "application/pdf");
                */
                using (var fs = System.IO.File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    LocalReport report = new LocalReport();
                    report.LoadReportDefinition(fs);
                    report.DataSources.Add(new ReportDataSource("dsNotaCompra", Util.ToDataTable(lista)));
                    report.DataSources.Add(new ReportDataSource("dsAdelanto", Util.ToDataTable(adelantos)));
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

        [Route("GenerarPDF")]
        [HttpGet]
        public IActionResult GenerarPDF(int id)
        {
            return this.generar(id);
        }

        [Route("GenerarPDFPost")]
        [HttpPost]
        public IActionResult GenerarPDFPost([FromBody] ConsultaNotaCompraPorGuiaRecepcionMateriaPrimaIdRequestDTO request)
        {
            return this.generar(request.GuiaRecepcionMateriaPrimaId);
        }

    }
}
