using AspNetCore.Reporting;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Service;
using Core.Common;
using Core.Common.Domain.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Integracion.Deuda.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaIngresoPlantaController : ControllerBase
    {
        private INotaIngresoPlantaService _NotaIngresoPlantaService;
        private Core.Common.Logger.ILog _log;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public NotaIngresoPlantaController(INotaIngresoPlantaService NotaIngresoPlantaService, Core.Common.Logger.ILog log, IWebHostEnvironment webHostEnvironment)
        {
            _NotaIngresoPlantaService = NotaIngresoPlantaService;
            _log = log;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("version")]
        public IActionResult Version()
        {
            return Ok("NotaIngresoPlanta Service. version: 1.20.01.03");
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("Consultar")]
        [HttpPost]
        public IActionResult Consultar([FromBody] ConsultaNotaIngresoPlantaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaNotaIngresoPlantaResponseDTO response = new ConsultaNotaIngresoPlantaResponseDTO();
            try
            {
                response.Result.Data = _NotaIngresoPlantaService.ConsultarNotaIngresoPlanta(request);
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
        public IActionResult Anular([FromBody] AnularNotaIngresoPlantaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            AnularNotaIngresoPlantaResponseDTO response = new AnularNotaIngresoPlantaResponseDTO();
            try
            {
                response.Result.Data = _NotaIngresoPlantaService.AnularNotaIngresoPlanta(request);

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
        public IActionResult ConsultarPorId([FromBody] ConsultaNotaIngresoPlantaPorIdRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaNotaIngresoPlantaPorIdResponseDTO response = new ConsultaNotaIngresoPlantaPorIdResponseDTO();
            try
            {
                response.Result.Data = _NotaIngresoPlantaService.ConsultarNotaIngresoPlantaPorId(request);

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

        [Route("RegistrarPesado")]
        [HttpPost]
        public IActionResult RegistrarPesado([FromBody] RegistrarActualizarPesadoNotaIngresoPlantaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            RegistrarActualizarPesadoNotaIngresoPlantaResponseDTO response = new RegistrarActualizarPesadoNotaIngresoPlantaResponseDTO();
            try
            {
                response.Result.Data = _NotaIngresoPlantaService.RegistrarPesadoNotaIngresoPlanta(request);

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

        [Route("ActualizarPesado")]
        [HttpPost]
        public IActionResult ActualizarPesado([FromBody] RegistrarActualizarPesadoNotaIngresoPlantaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            RegistrarActualizarPesadoNotaIngresoPlantaResponseDTO response = new RegistrarActualizarPesadoNotaIngresoPlantaResponseDTO();
            try
            {
                response.Result.Data = _NotaIngresoPlantaService.ActualizarPesadoNotaIngresoPlanta(request);

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

        [Route("ActualizarAnalisisCalidad")]
        [HttpPost]
        public IActionResult ActualizarAnalisisCalidad([FromBody] ActualizarNotaIngresoPlantaAnalisisCalidadRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ActualizarNotaIngresoPlantaAnalisisCalidadResponseDTO response = new ActualizarNotaIngresoPlantaAnalisisCalidadResponseDTO();
            try
            {
                response.Result.Data = _NotaIngresoPlantaService.ActualizarNotaIngresoPlantaAnalisisCalidad(request);

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

        [Route("GenerarPDFNotaIngreso")]
        [HttpGet]
        public IActionResult GenerarPDFNotaIngreso(int id, int empresaId)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(id)}");

            GenerarPDFGuiaRemisionResponseDTO response = _NotaIngresoPlantaService.GenerarPDFGuiaRemisionPorNotaIngreso(id, empresaId);

            try
            {
                
                string mimetype = "";
                int extension = 1;
                var path = $"{_webHostEnvironment.ContentRootPath}\\Reportes\\rptNotaIngreso.rdlc";

                LocalReport lr = new LocalReport(path);
                Dictionary<string, string> parameters = new Dictionary<string, string>();

                lr.AddDataSource("dsGRCabecera", Util.ToDataTable(response.Cabecera));
                lr.AddDataSource("dsGRListaDetalle", Util.ToDataTable(response.listaDetalleGM));
                lr.AddDataSource("dsGRDetalle", Util.ToDataTable(response.detalleGM));
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

            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }


        [Route("EnviarAlmacen")]
        [HttpPost]
        public IActionResult EnviarAlmacen([FromBody] EnviarAlmacenNotaIngresoPlantaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            EnviarAlmacenNotaIngresoPlantaResponseDTO response = new EnviarAlmacenNotaIngresoPlantaResponseDTO();
            try
            {
                response.Result.Data = _NotaIngresoPlantaService.EnviarAlmacen(request);

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


    }
}
