using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Service;
using Core.Common.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeConnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrecioDiaRendimientoController : ControllerBase
    {
        private IPrecioDiaRendimientoService _PrecioDiaRendimientoService;
        private Core.Common.Logger.ILog _log;

        public PrecioDiaRendimientoController(IPrecioDiaRendimientoService PrecioDiaRendimientoService, Core.Common.Logger.ILog log)
        {
            _PrecioDiaRendimientoService = PrecioDiaRendimientoService;
            _log = log;
        }

        [Route("Consultar")]
        [HttpPost]
        public IActionResult Consultar([FromBody] ConsultarPrecioDiaRendimientoRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultarPrecioDiaRendimientoResponseDTO response = new ConsultarPrecioDiaRendimientoResponseDTO();

            try
            {
                response.Result.Data = _PrecioDiaRendimientoService.ConsultaPrecioDiaRendimiento(request);
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

            _log.RegistrarEvento($"{guid}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }

        [Route("CalcularPrecioDiaRendimiento")]
        [HttpPost]
        public IActionResult ConsultarPorId([FromBody] CalcularPrecioDiaRendimientoRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            CalculoPrecioDiaRendimientoResponseDTO response = new CalculoPrecioDiaRendimientoResponseDTO();
            try
            {
                response.Result.Data = _PrecioDiaRendimientoService.CalcularPrecioDiaRendimiento(request);

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
        public IActionResult Registrar(RegistrarActualizarPrecioDiaRendimientoRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            RegistrarActualizarPrecioDiaRendimientoResponseDTO response = new RegistrarActualizarPrecioDiaRendimientoResponseDTO();
            try
            {
                response.Result.Data = _PrecioDiaRendimientoService.RegistrarPrecioDiaRendimiento(request);
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

            _log.RegistrarEvento($"{guid}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }

        [Route("Anular")]
        [HttpPost]
        public IActionResult Anular([FromBody] AnularPrecioDiaRendimientoRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            AnularPrecioDiaRendimientoResponseDTO response = new AnularPrecioDiaRendimientoResponseDTO();
            try
            {
                response.Result.Data = _PrecioDiaRendimientoService.AnularPrecioDiaRendimiento(request);

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

        [Route("ConsultarPorcentajeRendimiento")]
        [HttpPost]
        public IActionResult ConsultarPorcentajeRendimiento([FromBody] CalcularPrecioDiaRendimientoRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            CalculoPrecioDiaRendimientoResponseDTO response = new CalculoPrecioDiaRendimientoResponseDTO();
            try
            {
                response.Result.Data = _PrecioDiaRendimientoService.ConsultarPorcentajeRendimiento(request);

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
