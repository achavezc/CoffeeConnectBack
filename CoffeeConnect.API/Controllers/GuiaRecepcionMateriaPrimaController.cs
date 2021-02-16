using System;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Service;
using Core.Common.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Integracion.Deuda.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuiaRecepcionMateriaPrimaController : ControllerBase
    {
        private IGuiaRecepcionMateriaPrimaService _guiaRecepcionMateriaPrimaService;
        private Core.Common.Logger.ILog _log;
        public GuiaRecepcionMateriaPrimaController(IGuiaRecepcionMateriaPrimaService guiaRecepcionMateriaPrimaService, Core.Common.Logger.ILog log)
        {
            _guiaRecepcionMateriaPrimaService = guiaRecepcionMateriaPrimaService;
            _log = log;
        }

        [HttpGet("version")]
        public IActionResult Version()
        {
            return Ok("GuiaRecepcionMateriaPrima Service. version: 1.20.01.03");
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("Consultar")]
        [HttpPost]
        public IActionResult Consultar([FromBody] ConsultaGuiaRecepcionMateriaPrimaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaGuiaRecepcionMateriaPrimaResponseDTO response = new ConsultaGuiaRecepcionMateriaPrimaResponseDTO();
            try
            {                
                response.Result.Data = _guiaRecepcionMateriaPrimaService.ConsultarGuiaRecepcionMateriaPrima(request);

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
        public IActionResult Anular([FromBody] AnularGuiaRecepcionMateriaPrimaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            AnularGuiaRecepcionMateriaPrimaResponseDTO response = new AnularGuiaRecepcionMateriaPrimaResponseDTO();
            try
            {
                response.Result.Data = _guiaRecepcionMateriaPrimaService.AnularGuiaRecepcionMateriaPrima(request);

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

        //[Route("EnviarGuardiola")]
        //[HttpPost]
        //public IActionResult EnviarGuardiola([FromBody] EnviarGuardiolaGuiaRecepcionMateriaPrimaRequestDTO request)
        //{
        //    Guid guid = Guid.NewGuid();
        //    _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

        //    EnviarGuardiolaGuiaRecepcionMateriaPrimaResponseDTO response = new EnviarGuardiolaGuiaRecepcionMateriaPrimaResponseDTO();
        //    try
        //    {
        //        response.Result.Data = _guiaRecepcionMateriaPrimaService.EnviarGuardiolaGuiaRecepcionMateriaPrima(request);

        //        response.Result.Success = true;

        //    }
        //    catch (ResultException ex)
        //    {
        //        response.Result = new Result() { Success = true, ErrCode = ex.Result.ErrCode, Message = ex.Result.Message };
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Result = new Result() { Success = false, Message = "Ocurrio un problema en el servicio, intentelo nuevamente." };
        //        _log.RegistrarEvento(ex, guid.ToString());
        //    }

        //    _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

        //    return Ok(response);
        //}


        [Route("ConsultarPorId")]
        [HttpPost]
        public IActionResult ConsultarPorId([FromBody] ConsultaGuiaRecepcionMateriaPrimaPorIdRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaGuiaRecepcionMateriaPrimaPorIdResponseDTO response = new ConsultaGuiaRecepcionMateriaPrimaPorIdResponseDTO();
            try
            {
                response.Result.Data = _guiaRecepcionMateriaPrimaService.ConsultarGuiaRecepcionMateriaPrimaPorId(request);

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

        [Route("RegistrarPesado")]
        [HttpPost]
        public IActionResult RegistrarPesado([FromBody] RegistrarActualizarPesadoGuiaRecepcionMateriaPrimaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            RegistrarActualizarPesadoGuiaRecepcionMateriaPrimaResponseDTO response = new RegistrarActualizarPesadoGuiaRecepcionMateriaPrimaResponseDTO();
            try
            {
                response.Result.Data = _guiaRecepcionMateriaPrimaService.RegistrarPesadoGuiaRecepcionMateriaPrima(request);

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

        [Route("ActualizarPesado")]
        [HttpPost]
        public IActionResult ActualizarPesado([FromBody] RegistrarActualizarPesadoGuiaRecepcionMateriaPrimaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            RegistrarActualizarPesadoGuiaRecepcionMateriaPrimaResponseDTO response = new RegistrarActualizarPesadoGuiaRecepcionMateriaPrimaResponseDTO();
            try
            {
                response.Result.Data = _guiaRecepcionMateriaPrimaService.ActualizarPesadoGuiaRecepcionMateriaPrima(request);

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


        [Route("ActualizarAnalisisCalidad")]
        [HttpPost]
        public IActionResult ActualizarAnalisisCalidad([FromBody] ActualizarGuiaRecepcionMateriaPrimaAnalisisCalidadRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ActualizarGuiaRecepcionMateriaPrimaAnalisisCalidadResponseDTO response = new ActualizarGuiaRecepcionMateriaPrimaAnalisisCalidadResponseDTO();
            try
            {
                response.Result.Data = _guiaRecepcionMateriaPrimaService.ActualizarGuiaRecepcionMateriaPrimaAnalisisCalidad(request);

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
