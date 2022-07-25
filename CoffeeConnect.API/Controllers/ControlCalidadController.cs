using AspNetCore.Reporting;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Service;
using Core.Common;
using Core.Common.Domain.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeConnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControlCalidadController : ControllerBase
    {
        private IControlCalidadPlantaService _ControlCalidadPlantaService;
        private Core.Common.Logger.ILog _log;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ControlCalidadController(IControlCalidadPlantaService  ControlCalidadPlantaService, Core.Common.Logger.ILog log, IWebHostEnvironment webHostEnvironment)
        {
            _ControlCalidadPlantaService = ControlCalidadPlantaService;
            _log = log;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("version")]
        public IActionResult Version()
        {
            return Ok("ControlCalidadPlanta Service. version: 1.20.01.03");
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("Consultar")]
        [HttpPost]
        public IActionResult Consultar([FromBody] ConsultaControlCalidadPlantaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaControlCalidadPlantaResponseDTO response = new ConsultaControlCalidadPlantaResponseDTO();
            try
            {
                response.Result.Data = _ControlCalidadPlantaService.ConsultarControlCalidadPlanta(request);
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

        [Route("AnularControlCalidad")]
        [HttpPost]
        public IActionResult Anular([FromBody] AnularControlCalidadPlantaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            AnularControlCalidadPlantaResponseDTO response = new AnularControlCalidadPlantaResponseDTO();
            try
            {
                response.Result.Data = _ControlCalidadPlantaService.AnularControlCalidadPlanta(request);

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


        [Route("ConsultarPorId")]
        [HttpPost]
        public IActionResult ConsultarPorId([FromBody] ConsultaControlCalidadPlantaPorIdRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaControlCalidadPlantaPorIdResponseDTO response = new ConsultaControlCalidadPlantaPorIdResponseDTO();
            try
            {
                response.Result.Data = _ControlCalidadPlantaService.ConsultaControlCalidadPlantaPorId(request);

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
        public IActionResult RegistrarPesadoControlCalidadPlanta([FromBody] RegistrarActualizarPesadoControlCalidadPlantaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            RegistrarActualizarPesadoControlCalidadPlantaResponseDTO response = new RegistrarActualizarPesadoControlCalidadPlantaResponseDTO();
            try
            {
                response.Result.Data = _ControlCalidadPlantaService.RegistrarPesadoControlCalidadPlanta(request);

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
        public IActionResult ActualizarPesadoControlCalidadPlanta([FromBody] RegistrarActualizarPesadoControlCalidadPlantaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            RegistrarActualizarPesadoControlCalidadPlantaResponseDTO response = new RegistrarActualizarPesadoControlCalidadPlantaResponseDTO();
            try
            {
                response.Result.Data = _ControlCalidadPlantaService.ActualizarPesadoControlCalidadPlanta(request);

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
        public IActionResult ActualizarAnalisisCalidad([FromBody] ActualizarControlCalidadPlantaAnalisisCalidadRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ActualizarControlCalidadPlantaAnalisisCalidadResponseDTO response = new ActualizarControlCalidadPlantaAnalisisCalidadResponseDTO();
            try
            {
                response.Result.Data = _ControlCalidadPlantaService.ActualizarControlCalidadPlantaAnalisisCalidad(request);

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

        [Route("GenerarPDFNotaIngreso")]
        [HttpGet]
        public IActionResult GenerarPDFNotaIngreso(int id, int empresaId)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(id)}");

            GenerarPDFGuiaRemisionResponseDTO response = _ControlCalidadPlantaService.GenerarPDFGuiaRemisionPorNotaIngreso(id, empresaId);

            try
            {
                GenerarPDFGuiaRemisionRequestDTO request = new GenerarPDFGuiaRemisionRequestDTO { LoteId = id };
                string mimetype = "";
                int extension = 1;
                var path = $"{_webHostEnvironment.ContentRootPath}\\Reportes\\rptNotaIngreso.rdlc";

                LocalReport lr = new LocalReport(path);
                Dictionary<string, string> parameters = new Dictionary<string, string>();

                lr.AddDataSource("dsGRCabecera", Util.ToDataTable(response.Cabecera));
                lr.AddDataSource("dsGRListaDetalle", Util.ToDataTable(response.listaDetalleGM));
                lr.AddDataSource("dsGRDetalle", Util.ToDataTable(response.detalleGM));
                var result = lr.Execute(RenderType.Pdf, extension, parameters, mimetype);

                return File(result.MainStream, "application/pdf");
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



        [Route("ProcesarControlCalidad")]
        [HttpPost]
        public IActionResult ActualizarProcesarControlCalidadPlanta([FromBody] RegistrarActualizarEstadoControlCalidadPlantaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            RegistrarActualizarEstadoControlCalidadPlantaResponseDTO response = new RegistrarActualizarEstadoControlCalidadPlantaResponseDTO();
            try
            {
                response.Result.Data = _ControlCalidadPlantaService.ControlCalidadPlantaActualizarProcesar(request);

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




        [Route("RechazarConrolCalidad")]
        [HttpPost]
        public IActionResult ControlCalidadPlantaEstadoRechazado([FromBody] RegistrarActualizarEstadoControlCalidadPlantaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            RegistrarActualizarEstadoControlCalidadPlantaResponseDTO response = new RegistrarActualizarEstadoControlCalidadPlantaResponseDTO();
            try
            {
                response.Result.Data = _ControlCalidadPlantaService.ControlCalidadPlantaActualizarEstadoRechazado(request);

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
