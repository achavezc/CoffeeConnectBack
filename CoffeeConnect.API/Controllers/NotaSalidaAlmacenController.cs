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
    public class NotaSalidaAlmacenController : ControllerBase
    {
        private INotaSalidaAlmacenService _notaSalidaAlmacenService;
        private Core.Common.Logger.ILog _log;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public NotaSalidaAlmacenController(INotaSalidaAlmacenService notaSalidaAlmacenService, Core.Common.Logger.ILog log, IWebHostEnvironment webHostEnvironment)
        {
            _notaSalidaAlmacenService = notaSalidaAlmacenService;
            _log = log;
            _webHostEnvironment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [HttpGet("version")]
        public IActionResult Version()
        {
            return Ok("NotaSalidaAlmacen Service. version: 1.20.01.03");
        }

        [Route("Registrar")]
        [HttpPost]
        public IActionResult Registrar([FromBody] RegistrarNotaSalidaAlmacenRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            RegistrarNotaCompraResponseDTO response = new RegistrarNotaCompraResponseDTO();
            try
            {
                response.Result.Data = _notaSalidaAlmacenService.RegistrarNotaSalidaAlmacen(request);

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
        public IActionResult Actualizar([FromBody] RegistrarNotaSalidaAlmacenRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            RegistrarNotaCompraResponseDTO response = new RegistrarNotaCompraResponseDTO();
            try
            {
                response.Result.Data = _notaSalidaAlmacenService.ActualizarNotaSalidaAlmacen(request);

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
        public IActionResult Anular([FromBody] AnularNotaSalidaAlmacenRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            AnularNotaSalidaAlmacenResponseDTO response = new AnularNotaSalidaAlmacenResponseDTO();
            try
            {
                response.Result.Data = _notaSalidaAlmacenService.AnularNotaSalidaAlmacen(request);

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
        [Route("Consultar")]
        [HttpPost]
        public IActionResult Consultar([FromBody] ConsultaNotaSalidaAlmacenRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaNotaSalidaAlmacenResponseDTO response = new ConsultaNotaSalidaAlmacenResponseDTO();
            try
            {
                response.Result.Data = _notaSalidaAlmacenService.ConsultarNotaSalidaAlmacen(request);

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

        [Route("GenerarPDFListaProductores")]
        [HttpGet]
        public IActionResult GenerarPDFListaProductores(int id)
        {
            return this.generar(id);
        }

        [Route("GenerarPDFListaProductoresPost")]
        [HttpPost]
        public IActionResult GenerarPDFListaProductoresPost([FromBody] ConsultaNotaSalidaAlmacenPorIdRequestDTO request)
        {
            return this.generar(request.NotaSalidaAlmacenId);
        }

        private IActionResult generar(int id)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(id)}");

            ConsultaNotaCompraPorGuiaRecepcionMateriaPrimaIdResponseDTO response = new ConsultaNotaCompraPorGuiaRecepcionMateriaPrimaIdResponseDTO();
            try
            {
                ConsultaNotaCompraPorGuiaRecepcionMateriaPrimaIdRequestDTO request = new ConsultaNotaCompraPorGuiaRecepcionMateriaPrimaIdRequestDTO();
                request.GuiaRecepcionMateriaPrimaId = id;


                ConsultaImpresionListaProductoresPorNotaSalidaAlmacenResponseDTO impresionListaProductores = _notaSalidaAlmacenService.ConsultarImpresionListaProductoresPorNotaSalidaAlmacen(id);

                impresionListaProductores.FechaImpresion = DateTime.Now;
                List<ConsultaImpresionListaProductoresPorNotaSalidaAlmacenResponseDTO> reportCabecera = new List<ConsultaImpresionListaProductoresPorNotaSalidaAlmacenResponseDTO>();
                reportCabecera.Add(impresionListaProductores);

                string mimetype = "";
                int extension = 1;
                var path = $"{this._webHostEnvironment.ContentRootPath}\\Reportes\\ListaProductoresPorNotaSalidaAlmacen.rdlc";

                LocalReport lr = new LocalReport(path);
                Dictionary<string, string> parameters = new Dictionary<string, string>();

                //TODO: impresionListaProductores
                lr.AddDataSource("dsCabeceraLP", reportCabecera);
                lr.AddDataSource("dsDetalleLP", Util.ToDataTable(impresionListaProductores.ListaProductores));
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

        [Route("ConsultarPorId")]
        [HttpPost]
        public IActionResult ConsultarPorId([FromBody] ConsultaNotaSalidaAlmacenPorIdRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaNotaSalidaAlmacenPorIdResponseDTO response = new ConsultaNotaSalidaAlmacenPorIdResponseDTO();
            try
            {
                response.Result.Data = _notaSalidaAlmacenService.ConsultarNotaSalidaAlmacenPorId(request);

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

        //[Route("ActualizarDetalle")]
        //[HttpPost]
        //public IActionResult ActualizarDetalle([FromBody] RegistrarNotaSalidaAlmacenDetalleRequestDTO request)
        //{
        //    Guid guid = Guid.NewGuid();
        //    _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

        //    RegistrarNotaCompraResponseDTO response = new RegistrarNotaCompraResponseDTO();
        //    try
        //    {
        //        response.Result.Data = _notaSalidaAlmacenService.ActualizarNotaSalidaAlmacenDetalle(request);

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


        [Route("ActualizarAnalisisCalidad")]
        [HttpPost]
        public IActionResult ActualizarAnalisisCalidad([FromBody] ActualizarNotaSalidaAnalisisCalidadRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ActualizarGuiaRecepcionMateriaPrimaAnalisisCalidadResponseDTO response = new ActualizarGuiaRecepcionMateriaPrimaAnalisisCalidadResponseDTO();
            try
            {
                response.Result.Data = _notaSalidaAlmacenService.ActualizarNotaSalidaAlmacenAnalisisCalidad(request);

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
