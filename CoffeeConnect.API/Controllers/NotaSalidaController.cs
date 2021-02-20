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
    public class NotaSalidaController : ControllerBase
    {
        private INotaSalidaService _notaSalidaService;
        private Core.Common.Logger.ILog _log;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public NotaSalidaController(INotaSalidaService notaSalidaService, Core.Common.Logger.ILog log, IWebHostEnvironment webHostEnvironment)
        {
            _notaSalidaService = notaSalidaService;
            _log = log;
            _webHostEnvironment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [HttpGet("version")]
        public IActionResult Version()
        {
            return Ok("NotaSalida Service. version: 1.20.01.03");
        }

        //[Route("Registrar")]
        //[HttpPost]
        //public IActionResult Registrar([FromBody] RegistrarActualizarNotaCompraRequestDTO request)
        //{
        //    Guid guid = Guid.NewGuid();
        //    _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

        //    RegistrarNotaCompraResponseDTO response = new RegistrarNotaCompraResponseDTO();
        //    try
        //    {
        //        response.Result.Data = _notaSalidaService.RegistrarNotaCompra(request);

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

        //[Route("Actualizar")]
        //[HttpPost]
        //public IActionResult Actualizar([FromBody] RegistrarActualizarNotaCompraRequestDTO request)
        //{
        //    Guid guid = Guid.NewGuid();
        //    _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

        //    RegistrarNotaCompraResponseDTO response = new RegistrarNotaCompraResponseDTO();
        //    try
        //    {
        //        response.Result.Data = _notaSalidaService.ActualizarNotaCompra(request);

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

        //[Route("Anular")]
        //[HttpPost]
        //public IActionResult Anular([FromBody] AnularNotaCompraRequestDTO request)
        //{
        //    Guid guid = Guid.NewGuid();
        //    _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

        //    AnularGuiaRecepcionMateriaPrimaResponseDTO response = new AnularGuiaRecepcionMateriaPrimaResponseDTO();
        //    try
        //    {
        //        response.Result.Data = _notaSalidaService.AnularNotaCompra(request);

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

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("Consultar")]
        [HttpPost]
        public IActionResult Consultar([FromBody] ConsultaNotaSalidaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaNotaSalidaResponseDTO response = new ConsultaNotaSalidaResponseDTO();
            try
            {
                response.Result.Data = _notaSalidaService.ConsultarNotaSalida(request);

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
