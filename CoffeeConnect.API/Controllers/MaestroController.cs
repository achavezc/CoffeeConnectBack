using System;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Service;
using Core.Common.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using CoffeeConnect.Models;

namespace Integracion.Deuda.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaestroController : ControllerBase
    {
        private IMaestroService _maestroService;
        private Core.Common.Logger.ILog _log;
        public MaestroController(IMaestroService maestroService, Core.Common.Logger.ILog log)
        {
            _maestroService = maestroService;
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
        public IActionResult ConsultarTablaDeTablas([FromBody] ConsultaTablaDeTablasRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaTablaDeTablasResponseDTO response = new ConsultaTablaDeTablasResponseDTO();
            try
            {                
                List<ConsultaDetalleTablaBE> lista = _maestroService.ConsultarDetalleTablaDeTablas(request.EmpresaId);

                response.Result.Data = lista.Where(a => a.CodigoTabla == request.CodigoTabla).ToList();

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
        [Route("ConsultarDepartamento")]
        [HttpPost]
        public IActionResult ConsultarDepartamento([FromBody] ConsultaDepartamentoRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaTablaDeTablasResponseDTO response = new ConsultaTablaDeTablasResponseDTO();
            try
            {
                List<ConsultaUbigeoBE> lista = _maestroService.ConsultaUbibeo();

                response.Result.Data = lista.Where(a => a.CodigoPais == request.CodigoPais && a.Codigo.EndsWith("0000"))
                                        .ToList();

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

            //_log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("ConsultarProvincia")]
        [HttpPost]
        public IActionResult ConsultarProvincia([FromBody] ConsultaProvinciaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaTablaDeTablasResponseDTO response = new ConsultaTablaDeTablasResponseDTO();
            try
            {
                List<ConsultaUbigeoBE> lista = _maestroService.ConsultaUbibeo();
                string prefijoDepartamento = !String.IsNullOrEmpty(request.CodigoDepartamento.ToString()) 
                                                && request.CodigoDepartamento.Length >= 2 ? request.CodigoDepartamento.Substring(0, 2) : "-";

                response.Result.Data = lista.Where(a => a.CodigoPais == request.CodigoPais && a.Codigo.EndsWith("00") 
                                                && a.Codigo.StartsWith(prefijoDepartamento)
                                                && !a.Codigo.EndsWith("0000"))
                                        .ToList();

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

            //_log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("ConsultarDistrito")]
        [HttpPost]
        public IActionResult ConsultarDistrito([FromBody] ConsultaDistritoRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaTablaDeTablasResponseDTO response = new ConsultaTablaDeTablasResponseDTO();
            try
            {
                List<ConsultaUbigeoBE> lista = _maestroService.ConsultaUbibeo();
                string prefijoDepartamento = !String.IsNullOrEmpty(request.CodigoDepartamento.ToString())
                                                && request.CodigoDepartamento.Length >= 2 ? request.CodigoDepartamento.Substring(0, 2) : "-";

                string prefijoProvincia = !String.IsNullOrEmpty(request.CodigoProvincia.ToString())
                                                && request.CodigoProvincia.Length >= 4 ? request.CodigoProvincia.Substring(0, 4) : "-";

                response.Result.Data = lista.Where(a => a.CodigoPais == request.CodigoPais 
                                                        && !a.Codigo.EndsWith("00") 
                                                        && a.Codigo.StartsWith(prefijoProvincia))
                                        .ToList();

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

            //_log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }


        [Route("ConsultarZona")]
        [HttpPost]
        public IActionResult ConsultarZona([FromBody] ConsultaZonaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaTablaDeTablasResponseDTO response = new ConsultaTablaDeTablasResponseDTO();
            try
            {
                List<Zona> lista = _maestroService.ConsultarZona(request.CodigoDistrito);

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

            //_log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }
    }
}
