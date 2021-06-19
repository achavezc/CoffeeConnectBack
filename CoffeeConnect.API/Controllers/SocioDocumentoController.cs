using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adjunto;
using CoffeeConnect.Interface.Service;
using Core.Common.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Integracion.Deuda.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocioDocumentoController : ControllerBase
    {
        private ISocioDocumentoService _SocioDocumentoService;
        private Core.Common.Logger.ILog _log;

        public SocioDocumentoController(ISocioDocumentoService socioDocumentoService, Core.Common.Logger.ILog log)
        {
            _SocioDocumentoService = socioDocumentoService;
            _log = log;
        }

        [HttpGet("version")]
        public IActionResult Version()
        {
            return Ok("Productor Finca Service. version: 1.20.01.03");
        }

        [Route("Registrar")]
        [HttpPost]
        public IActionResult Registrar(IFormFile file, [FromForm] string request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            RegistrarSocioDocumentoResponseDTO response = new RegistrarSocioDocumentoResponseDTO();
            try
            {
                var myJsonObject = JsonConvert.DeserializeObject<RegistrarSocioDocumentoRequestDTO>(request);
                response.Result.Data = _SocioDocumentoService.RegistrarSocioDocumento(myJsonObject, file);
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

        [Route("Actualizar")]
        [HttpPost]
        public IActionResult Actualizar(IFormFile file, [FromForm] string request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            RegistrarSocioDocumentoResponseDTO response = new RegistrarSocioDocumentoResponseDTO();
            try
            {
                var myJsonObject = JsonConvert.DeserializeObject<RegistrarSocioDocumentoRequestDTO>(request);
                response.Result.Data = _SocioDocumentoService.ActualizarSocioDocumento(myJsonObject, file);
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
        [HttpGet()]
        public IActionResult DescargarArchivo([FromQuery(Name = "path")] string path, [FromQuery(Name = "name")] string name)
        {
            DescargarArchivoRequestDTO response = new DescargarArchivoRequestDTO();
            RequestDescargarArchivoDTO request = new RequestDescargarArchivoDTO();
            request.PathFile = path;
            request.ArchivoVisual = name;
            try
            {
                response.Result.Data = _SocioDocumentoService.DescargarArchivo(request);
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

        [Route("ConsultarPorSocioId")]
        [HttpPost]
        public IActionResult ConsultarPorSocioId([FromBody] ConsultarSocioDocumentoPorSocioIdRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            ConsultarSocioDocumentoPorSocioIdResponseDTO response = new ConsultarSocioDocumentoPorSocioIdResponseDTO();
            try
            {
                response.Result.Data = _SocioDocumentoService.ConsultarSocioDocumentoPorSocioId(request);
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

        [Route("Eliminar")]
        [HttpPost]
        public IActionResult Eliminar(RegistrarSocioDocumentoRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            RegistrarSocioDocumentoResponseDTO response = new RegistrarSocioDocumentoResponseDTO();
            try
            {

                response.Result.Data = _SocioDocumentoService.EliminarSocioDocumento(request);
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
