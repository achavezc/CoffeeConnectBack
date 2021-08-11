using AspNetCore.Reporting;
using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adelanto;
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
using System.Net.Mime;

namespace Integracion.Deuda.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdelantoController : ControllerBase
    {
        private IAdelantoService _AdelantoService;
        private Core.Common.Logger.ILog _log;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdelantoController(IAdelantoService AdelantoService, Core.Common.Logger.ILog log, IWebHostEnvironment webHostEnvironment)
        {
            _AdelantoService = AdelantoService;
            _log = log;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("version")]
        public IActionResult Version()
        {
            return Ok("Adelanto Service. version: 1.20.01.03");
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("Consultar")]
        [HttpPost]
        public IActionResult Consultar([FromBody] ConsultaAdelantoRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaAdelantoResponseDTO response = new ConsultaAdelantoResponseDTO();
            try
            {
                response.Result.Data = _AdelantoService.ConsultarAdelanto(request);

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

        [Route("Registrar")]
        [HttpPost]
        //public IActionResult Registrar([FromBody] RegistrarActualizarAduanaRequestDTO request)
        public IActionResult Registrar(RegistrarActualizarAdelantoRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            RegistrarActualizarAdelantoResponseDTO response = new RegistrarActualizarAdelantoResponseDTO();
            try
            {
                //var myJsonObject = JsonConvert.DeserializeObject<RegistrarActualizarAduanaRequestDTO>(request);
                response.Result.Data = _AdelantoService.RegistrarAdelanto(request);
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
        public IActionResult Actualizar(RegistrarActualizarAdelantoRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            RegistrarActualizarAdelantoResponseDTO response = new RegistrarActualizarAdelantoResponseDTO();
            try
            {
                //var myJsonObject = JsonConvert.DeserializeObject<RegistrarActualizarAduanaRequestDTO>(request);
                response.Result.Data = _AdelantoService.ActualizarAdelanto(request);
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

        [Route("ConsultarPorId")]
        [HttpPost]
        public IActionResult ConsultarPorId([FromBody] ConsultaAdelantoPorIdRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            ConsultaAdelantoPorIdResponseDTO response = new ConsultaAdelantoPorIdResponseDTO();
            try
            {
                response.Result.Data = _AdelantoService.ConsultarAdelantoPorId(request);
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



        

        [Route("GenerarPDFAdelanto")]
        [HttpGet]
        public IActionResult GenerarPDFAdelanto(int id)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(id)}");

            //ES MOMENTANEO SE DEBE ELIMINAR
            GenerarPDFAdelantoResponseDTO response = _AdelantoService.GenerarPDF(id);

            try
            {
                string mimetype = "";
                int extension = 1;
                var path = $"{_webHostEnvironment.ContentRootPath}\\Reportes\\rptAdelanto.rdlc";

                LocalReport lr = new LocalReport(path);
                Dictionary<string, string> parameters = new Dictionary<string, string>();

                lr.AddDataSource("dsAdelanto", Util.ToDataTable(response.resultado));
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
