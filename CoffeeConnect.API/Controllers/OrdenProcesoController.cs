using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Service;
using Core.Common.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeConnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenProcesoController : ControllerBase
    {
        private IOrdenProcesoService ordenProcesoService;
        private Core.Common.Logger.ILog _log;
        public OrdenProcesoController(IOrdenProcesoService ordenProcesoService, Core.Common.Logger.ILog log)
        {
            _log = log;
            this.ordenProcesoService = ordenProcesoService;
        }

        [Route("Consultar")]
        [HttpPost]
        public IActionResult Consultar([FromBody] ConsultaOrdenProcesoRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            ConsultaOrdenProcesoResponseDTO response = new ConsultaOrdenProcesoResponseDTO();
            try
            {
                response.Result.Data = ordenProcesoService.ConsultarOrdenProceso(request);
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
        public IActionResult Registrar(IFormFile file, [FromForm] string request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            RegistrarActualizarOrdenProcesoResponseDTO response = new RegistrarActualizarOrdenProcesoResponseDTO();
            try
            {
                var myJsonObject = JsonConvert.DeserializeObject<RegistrarActualizarOrdenProcesoRequestDTO>(request);
                response.Result.Data = ordenProcesoService.RegistrarOrdenProceso(myJsonObject, file);
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

        [Route("Actualizar")]
        [HttpPost]
        public IActionResult Actualizar(IFormFile file, [FromForm] string request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            RegistrarActualizarOrdenProcesoResponseDTO response = new RegistrarActualizarOrdenProcesoResponseDTO();
            try
            {
                var myJsonObject = JsonConvert.DeserializeObject<RegistrarActualizarOrdenProcesoRequestDTO>(request);
                response.Result.Data = ordenProcesoService.ActualizarOrdenProceso(myJsonObject, file);
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
    }
}
