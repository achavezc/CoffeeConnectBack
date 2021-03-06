using System;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Service;
using Core.Common.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Integracion.Deuda.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductorFincaController : ControllerBase
    {
        private IProductorFincaService _productorService;

        private Core.Common.Logger.ILog _log;
        public ProductorFincaController(IProductorFincaService productorService, Core.Common.Logger.ILog log)
        {
            _productorService = productorService;
            _log = log;
        }

        [HttpGet("version")]
        public IActionResult Version()
        {
            return Ok("Productor Finca Service. version: 1.20.01.03");
        }

        

      

        [Route("Registrar")]
        [HttpPost]
        public IActionResult Registrar([FromBody] RegistrarActualizarProductorFincaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            RegistrarActualizarProductorFincaResponseDTO response = new RegistrarActualizarProductorFincaResponseDTO();
            try
            {
                response.Result.Data = _productorService.RegistrarProductorFinca(request);

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
        public IActionResult Actualizar([FromBody] RegistrarActualizarProductorFincaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            RegistrarActualizarProductorFincaResponseDTO response = new RegistrarActualizarProductorFincaResponseDTO();
            try
            {
                response.Result.Data = _productorService.ActualizarProductorFinca(request);

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

        [Route("ConsultarPorProductorId")]
        [HttpPost]
        public IActionResult ConsultarPorProductorId([FromBody] ConsultaProductorFincaProductorIdRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaProductorPorIdResponseDTO response = new ConsultaProductorPorIdResponseDTO();
            try
            {
                response.Result.Data = _productorService.ConsultarProductorFincaPorProductorId(request);

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
