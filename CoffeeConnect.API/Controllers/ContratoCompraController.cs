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
    public class ContratoCompraController : ControllerBase
    {
        private IContratoCompraService _ContratoCompraService;

        private Core.Common.Logger.ILog _log;
        public ContratoCompraController(IContratoCompraService ContratoCompraService, Core.Common.Logger.ILog log)
        {
            _ContratoCompraService = ContratoCompraService;
            _log = log;
        }

        [HttpGet("version")]
        public IActionResult Version()
        {
            return Ok("ContratoCompra Service. version: 1.20.01.03");
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("Consultar")]
        [HttpPost]
        public IActionResult Consultar([FromBody] ConsultaContratoCompraRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaContratoCompraResponseDTO response = new ConsultaContratoCompraResponseDTO();
            try
            {
                response.Result.Data = _ContratoCompraService.ConsultarContratoCompra(request);

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
        //public IActionResult Registrar([FromBody] RegistrarActualizarContratoCompraRequestDTO request)
        public IActionResult Registrar(IFormFile file, [FromForm] string request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            RegistrarActualizarContratoCompraResponseDTO response = new RegistrarActualizarContratoCompraResponseDTO();
            try
            {
                var myJsonObject = JsonConvert.DeserializeObject<RegistrarActualizarContratoCompraRequestDTO>(request);
                response.Result.Data = _ContratoCompraService.RegistrarContratoCompra(myJsonObject, file);
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

            RegistrarActualizarContratoCompraResponseDTO response = new RegistrarActualizarContratoCompraResponseDTO();
            try
            {
                var myJsonObject = JsonConvert.DeserializeObject<RegistrarActualizarContratoCompraRequestDTO>(request);
                response.Result.Data = _ContratoCompraService.ActualizarContratoCompra(myJsonObject, file);
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
        public IActionResult ConsultarPorId([FromBody] ConsultaContratoCompraPorIdRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            ConsultaContratoCompraPorIdResponseDTO response = new ConsultaContratoCompraPorIdResponseDTO();
            try
            {
                response.Result.Data = _ContratoCompraService.ConsultarContratoCompraPorId(request);
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
                response.Result.Data = _ContratoCompraService.DescargarArchivo(request);
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
        public IActionResult Anular([FromBody] AnularContratoCompraRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            AnularLoteResponseDTO response = new AnularLoteResponseDTO();
            try
            {
                response.Result.Data = _ContratoCompraService.AnularContratoCompra(request);

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


        [Route("AsignarContratoCompra")]
        [HttpPost]
        public IActionResult AsignarContratoCompra([FromBody] AsignarContratoCompraRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            AsignarContratoVentaResponseDTO response = new AsignarContratoVentaResponseDTO();
            try
            {
                response.Result.Data = _ContratoCompraService.AsignarContratoCompra(request);

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
