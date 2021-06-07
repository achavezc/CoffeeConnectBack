using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Service;
using Core.Common.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Integracion.Deuda.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransporteController : ControllerBase
    {
        private ITransporteService _TransporteService;
        private Core.Common.Logger.ILog _log;
        public TransporteController(ITransporteService TransporteService, Core.Common.Logger.ILog log)
        {
            _TransporteService = TransporteService;
            _log = log;
        }

        [HttpGet("version")]
        public IActionResult Version()
        {
            return Ok("Maestro Service. version: 1.20.01.03");
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("Consultar")]
        [HttpPost]
        public IActionResult ConsultarTransporte([FromBody] ConsultaTransporteRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaTransporteResponseDTO response = new ConsultaTransporteResponseDTO();
            try
            {
                List<ConsultaTransportePorEmpresaTransporteId> lista = _TransporteService.ConsultarTransportePorEmpresaTransporteId(request);

                response.Result.Data = lista;

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
        //public IActionResult Registrar([FromBody] RegistrarActualizarTransporteRequestDTO request)
        public IActionResult Registrar(RegistrarActualizarTransporteRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            RegistrarActualizarTransporteResponseDTO response = new RegistrarActualizarTransporteResponseDTO();

            try
            {
                response.Result.Data = _TransporteService.RegistrarTransporte(request);
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
        public IActionResult Actualizar(RegistrarActualizarTransporteRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            RegistrarActualizarTransporteResponseDTO response = new RegistrarActualizarTransporteResponseDTO();
            try
            {
              
                response.Result.Data = _TransporteService.ActualizarTransporte(request);
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
        public IActionResult ConsultarPorId([FromBody] ConsultaTransportePorIdRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            ConsultaTransportePorIdResponseDTO response = new ConsultaTransportePorIdResponseDTO();
            try
            {
                response.Result.Data = _TransporteService.ConsultarTransportePorId(request);
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
