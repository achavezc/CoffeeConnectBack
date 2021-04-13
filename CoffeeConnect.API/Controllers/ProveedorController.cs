using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Service;
using Core.Common.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Integracion.Deuda.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private IProveedorService _proveedorService;
        private Core.Common.Logger.ILog _log;
        public ProveedorController(IProveedorService proveedorService, Core.Common.Logger.ILog log)
        {
            _proveedorService = proveedorService;
            _log = log;
        }

        [HttpGet("version")]
        public IActionResult Version()
        {
            return Ok("Proveedor Service. version: 1.20.01.03");
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("Consultar")]
        [HttpPost]
        public IActionResult Consultar([FromBody] ConsultaProveedoresRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaProveedoresResponseDTO response = new ConsultaProveedoresResponseDTO();
            try
            {
                response.Result.Data = _proveedorService.ConsultarProveedores(request);

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
