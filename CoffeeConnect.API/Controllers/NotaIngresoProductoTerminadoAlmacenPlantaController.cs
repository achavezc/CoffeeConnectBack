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
    public class NotaIngresoProductoTerminadoAlmacenPlantaController : ControllerBase
    {
        private INotaIngresoProductoTerminadoAlmacenPlantaService _NotaIngresoProductoTerminadoAlmacenPlantaService;
        private Core.Common.Logger.ILog _log;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public NotaIngresoProductoTerminadoAlmacenPlantaController(INotaIngresoProductoTerminadoAlmacenPlantaService NotaIngresoProductoTerminadoAlmacenPlantaService, Core.Common.Logger.ILog log, IWebHostEnvironment webHostEnvironment)
        {
            _NotaIngresoProductoTerminadoAlmacenPlantaService = NotaIngresoProductoTerminadoAlmacenPlantaService;
            _log = log;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("version")]
        public IActionResult Version()
        {
            return Ok("NotaIngresoProductoTerminadoAlmacenPlanta Service. version: 1.20.01.03");
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("Consultar")]
        [HttpPost]
        public IActionResult Consultar([FromBody] ConsultaNotaIngresoProductoTerminadoAlmacenPlantaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaNotaIngresoProductoTerminadoAlmacenPlantaResponseDTO response = new ConsultaNotaIngresoProductoTerminadoAlmacenPlantaResponseDTO();
            try
            {
                response.Result.Data = _NotaIngresoProductoTerminadoAlmacenPlantaService.ConsultarNotaIngresoProductoTerminadoAlmacenPlanta(request);
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
        public IActionResult Anular([FromBody] AnularNotaIngresoProductoTerminadoAlmacenPlantaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            AnularNotaIngresoProductoTerminadoAlmacenPlantaResponseDTO response = new AnularNotaIngresoProductoTerminadoAlmacenPlantaResponseDTO();
            try
            {
                response.Result.Data = _NotaIngresoProductoTerminadoAlmacenPlantaService.AnularNotaIngresoProductoTerminadoAlmacenPlanta(request);

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
        public IActionResult ConsultarPorId([FromBody] ConsultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdResponseDTO response = new ConsultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdResponseDTO();
            try
            {
                response.Result.Data = _NotaIngresoProductoTerminadoAlmacenPlantaService.ConsultarNotaIngresoProductoTerminadoAlmacenPlantaPorId(request);

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
        public IActionResult Registrar([FromBody] RegistrarActualizarNotaIngresoProductoTerminadoAlmacenPlantaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            RegistrarActualizarNotaIngresoProductoTerminadoAlmacenPlantaResponseDTO response = new RegistrarActualizarNotaIngresoProductoTerminadoAlmacenPlantaResponseDTO();
            try
            {
                response.Result.Data = _NotaIngresoProductoTerminadoAlmacenPlantaService.RegistrarNotaIngresoProductoTerminadoAlmacenPlanta(request);

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
        public IActionResult Actualizar([FromBody] RegistrarActualizarNotaIngresoProductoTerminadoAlmacenPlantaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            RegistrarActualizarNotaIngresoProductoTerminadoAlmacenPlantaResponseDTO response = new RegistrarActualizarNotaIngresoProductoTerminadoAlmacenPlantaResponseDTO();
            try
            {
                response.Result.Data = _NotaIngresoProductoTerminadoAlmacenPlantaService.ActualizarNotaIngresoProductoTerminadoAlmacenPlanta(request);

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
