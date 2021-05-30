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
    public class EmpresaProveedoraAcreedoraController : ControllerBase
    {
        private IEmpresaProveedoraAcreedoraService _empresaProveedoraAcreedoraService;
        private Core.Common.Logger.ILog _log;
        public EmpresaProveedoraAcreedoraController(IEmpresaProveedoraAcreedoraService empresaProveedoraAcreedoraService, Core.Common.Logger.ILog log)
        {
            _empresaProveedoraAcreedoraService = empresaProveedoraAcreedoraService;
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
        public IActionResult ConsultarEmpresaProveedoraAcreedora([FromBody] ConsultaEmpresaProveedoraAcreedoraRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaEmpresaProveedoraAcreedoraResponseDTO response = new ConsultaEmpresaProveedoraAcreedoraResponseDTO();
            try
            {
                List<ConsultaEmpresaProveedoraAcreedoraBE> lista = _empresaProveedoraAcreedoraService.ConsultarEmpresaProveedoraAcreedora(request);

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
        //public IActionResult Registrar([FromBody] RegistrarActualizarEmpresaProveedoraAcreedoraRequestDTO request)
        public IActionResult Registrar(RegistrarActualizarEmpresaProveedoraAcreedoraRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            RegistrarActualizarEmpresaProveedoraAcreedoraResponseDTO response = new RegistrarActualizarEmpresaProveedoraAcreedoraResponseDTO();

            try
            {
                response.Result.Data = _empresaProveedoraAcreedoraService.RegistrarEmpresaProveedoraAcreedora(request);
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
        public IActionResult Actualizar(RegistrarActualizarEmpresaProveedoraAcreedoraRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            RegistrarActualizarEmpresaProveedoraAcreedoraResponseDTO response = new RegistrarActualizarEmpresaProveedoraAcreedoraResponseDTO();
            try
            {

                response.Result.Data = _empresaProveedoraAcreedoraService.ActualizarEmpresaProveedoraAcreedora(request);
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
        public IActionResult ConsultarPorId([FromBody] ConsultaEmpresaProveedoraAcreedoraPorIdRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            ConsultaEmpresaProveedoraAcreedoraPorIdResponseDTO response = new ConsultaEmpresaProveedoraAcreedoraPorIdResponseDTO();
            try
            {
                response.Result.Data = _empresaProveedoraAcreedoraService.ConsultarEmpresaProveedoraAcreedoraPorId(request);
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
