using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adjunto;
using CoffeeConnect.Interface.Service;
using Core.Common.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Mime;

namespace Integracion.Deuda.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private IContratoService _contratoService;

        private Core.Common.Logger.ILog _log;
        public ContratoController(IContratoService contratoService, Core.Common.Logger.ILog log)
        {
            _contratoService = contratoService;
            _log = log;
        }

        [HttpGet("version")]
        public IActionResult Version()
        {
            return Ok("Contrato Service. version: 1.20.01.03");
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("Consultar")]
        [HttpPost]
        public IActionResult Consultar([FromBody] ConsultaContratoRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaContratoResponseDTO response = new ConsultaContratoResponseDTO();
            try
            {
                response.Result.Data = _contratoService.ConsultarContrato(request);

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
        //public IActionResult Registrar([FromBody] RegistrarActualizarContratoRequestDTO request)
        public IActionResult Registrar(IFormFile file, [FromForm] string request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            RegistrarActualizarContratoResponseDTO response = new RegistrarActualizarContratoResponseDTO();
            try
            {
                var myJsonObject = JsonConvert.DeserializeObject<RegistrarActualizarContratoRequestDTO>(request);
                response.Result.Data = _contratoService.RegistrarContrato(myJsonObject, file);
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
        public IActionResult Actualizar(IFormFile file, [FromForm] string request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            RegistrarActualizarContratoResponseDTO response = new RegistrarActualizarContratoResponseDTO();
            try
            {
                var myJsonObject = JsonConvert.DeserializeObject<RegistrarActualizarContratoRequestDTO>(request);
                response.Result.Data = _contratoService.ActualizarContrato(myJsonObject, file);
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
        public IActionResult ConsultarPorId([FromBody] ConsultaContratoPorIdRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            ConsultaContratoPorIdResponseDTO response = new ConsultaContratoPorIdResponseDTO();
            try
            {
                response.Result.Data = _contratoService.ConsultarContratoPorId(request);
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

        [Route("DescargarArchivo")]
        //[HttpPost]
        [HttpGet()]
        //public IActionResult DescargarArchivo([FromBody] RequestDescargarArchivoDTO request)
        public IActionResult DescargarArchivo([FromQuery(Name = "path")] string path, [FromQuery(Name = "name")] string name)
        {


            DescargarArchivoRequestDTO response = new DescargarArchivoRequestDTO();
            RequestDescargarArchivoDTO request = new RequestDescargarArchivoDTO();
            request.PathFile = path;
            request.ArchivoVisual = name;
            try
            {
                response.Result.Data = _contratoService.DescargarArchivo(request);
                response.Result.Success = true;

                string extension = Path.GetExtension(request.PathFile);

                Response.Clear();
                switch (extension)
                {
                    case ".docx":
                        Response.Headers.Add("Content-type", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
                        break;
                    case ".jpg":
                        Response.Headers.Add("Content-type", "image/jpeg");
                        break;
                    case ".png":
                        Response.Headers.Add("Content-type", "image/png");
                        break;
                    case ".pdf":
                        Response.Headers.Add("Content-type", "application/pdf");
                        break;
                    case ".xls":
                        Response.Headers.Add("Content-type", "application/vnd.ms-excel");
                        break;
                    case ".xlsx":
                        Response.Headers.Add("Content-type", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                        break;
                    case ".doc":
                        Response.Headers.Add("Content-type", "application/msword");
                        break;
                }

                //context.Response.ContentType = "Application/octet-stream";
                //string  content = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("attachment; filename=\"{0}\"", request.ArchivoVisual)));

                var contentDispositionHeader = new ContentDisposition()
                {
                    FileName = request.ArchivoVisual,
                    DispositionType = "attachment"
                };

                Response.Headers.Add("Content-Length", response.Result.Data.archivoBytes.Length.ToString());
                Response.Headers.Add("Content-Disposition", contentDispositionHeader.ToString());
                Response.Body.WriteAsync(response.Result.Data.archivoBytes);



            }
            catch (ResultException ex)
            {
                response.Result = new Result() { Success = true, ErrCode = ex.Result.ErrCode, Message = ex.Result.Message };
            }
            catch (Exception ex)
            {
                response.Result = new Result() { Success = false, Message = "Ocurrio un problema en el servicio, intentelo nuevamente." };
            }


            return null;
        }

        [Route("Anular")]
        [HttpPost]
        public IActionResult Anular([FromBody] AnularContratoRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            AnularLoteResponseDTO response = new AnularLoteResponseDTO();
            try
            {
                response.Result.Data = _contratoService.AnularContrato(request);

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



        [Route("ConsultarTrackingContratoPorContratoId")]
        [HttpPost]
        public IActionResult ConsultarTrackingContratoPorContratoId([FromBody] ConsultaTrackingContratoPorContratoIdRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            ConsultaTrackingContratoPorContratoIdResponseDTO response = new ConsultaTrackingContratoPorContratoIdResponseDTO();
            try
            {
                response.Result.Data = _contratoService.ConsultarTrackingContratoPorContratoId(request);
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

        [Route("ConsultarTrackingContrato")]
        [HttpPost]
        public IActionResult ConsultarTrackingContrato([FromBody] ConsultaTrackingContratoRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            ConsultaTrackingContratoResponseDTO response = new ConsultaTrackingContratoResponseDTO();
            try
            {
                response.Result.Data = _contratoService.ConsultarTrackingContrato(request);
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
