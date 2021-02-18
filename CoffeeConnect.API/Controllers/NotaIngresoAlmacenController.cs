using System;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Service;
using Core.Common.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Integracion.Deuda.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaIngresoAlmacenController : ControllerBase
    {
        private INotaIngresoAlmacenService _notaIngresoAlmacenService;

        private Core.Common.Logger.ILog _log;
        public NotaIngresoAlmacenController(INotaIngresoAlmacenService notaIngresoAlmacenService, Core.Common.Logger.ILog log)
        {
            _notaIngresoAlmacenService = notaIngresoAlmacenService;
            _log = log;
        }

        [HttpGet("version")]
        public IActionResult Version()
        {
            return Ok("NotaIngresoAlmacen Service. version: 1.20.01.03");
        }

        

        [Route("Registrar")]
        [HttpPost]
        public IActionResult Registrar([FromBody] EnviarAlmacenGuiaRecepcionMateriaPrimaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            EnviarAlmacenGuiaRecepcionMateriaPrimaResponseDTO response = new EnviarAlmacenGuiaRecepcionMateriaPrimaResponseDTO();
            try
            {
                response.Result.Data = _notaIngresoAlmacenService.Registrar(request);

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
        public IActionResult Consultar([FromBody] ConsultaNotaIngresoAlmacenRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaNotaIngresoAlmacenResponseDTO response = new ConsultaNotaIngresoAlmacenResponseDTO();
            try
            {
                response.Result.Data = _notaIngresoAlmacenService.ConsultarNotaIngresoAlmacen(request);

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
        public IActionResult Anular([FromBody] AnularNotaIngresoAlmacenRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            AnularNotaIngresoAlmacenResponseDTO response = new AnularNotaIngresoAlmacenResponseDTO();
            try
            {
                response.Result.Data = _notaIngresoAlmacenService.AnularNotaIngresoAlmacen(request);

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
