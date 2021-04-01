using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Service;
using Core.Common.Domain.Model;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Integracion.Deuda.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoteController : ControllerBase
    {
        private ILoteService _loteService;
        private Core.Common.Logger.ILog _log;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IConverter _converter;

        public LoteController(ILoteService loteService, Core.Common.Logger.ILog log, IWebHostEnvironment webHostEnvironment, IConverter converter)
        {
            _loteService = loteService;
            _log = log;
            _webHostEnvironment = webHostEnvironment;
            _converter = converter;
        }

        [HttpGet("version")]
        public IActionResult Version()
        {
            return Ok("Lote Service. version: 1.20.01.03");
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("Generar")]
        [HttpPost]
        public IActionResult Generar([FromBody] GenerarLoteRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            GenerarLoteResponseDTO response = new GenerarLoteResponseDTO();
            try
            {
                response.Result.Data = _loteService.GenerarLote(request);

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
        public IActionResult Consultar([FromBody] ConsultaLoteRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaLoteResponseDTO response = new ConsultaLoteResponseDTO();
            try
            {
                response.Result.Data = _loteService.ConsultarLote(request);

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
        public IActionResult Anular([FromBody] AnularLoteRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            AnularLoteResponseDTO response = new AnularLoteResponseDTO();
            try
            {
                response.Result.Data = _loteService.AnularLote(request);

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
        public IActionResult Actualizar([FromBody] ActualizarLoteRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ActualizarLoteResponseDTO response = new ActualizarLoteResponseDTO();
            try
            {
                response.Result.Data = _loteService.ActualizarLote(request);

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

        [Route("ConsultarDetallePorId")]
        [HttpPost]
        public IActionResult ConsultarDetallePorId([FromBody] ConsultaLoteDetallePorLoteIdRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaLoteDetallePorLoteIdResponseDTO response = new ConsultaLoteDetallePorLoteIdResponseDTO();
            try
            {
                var resultado = _loteService.ConsultarLotePorId(request);
                response.Result.Data = resultado.listaDetalle;
                response.LoteId = resultado.LoteId;
                response.Numero = resultado.Numero;
                response.EmpresaId = resultado.EmpresaId;
                response.RazonSocial = resultado.RazonSocial;
                response.Ruc = resultado.Ruc;
                response.Direccion = resultado.Direccion;
                response.Logo = resultado.Logo;
                response.DepartamentoId = resultado.DepartamentoId;
                response.Departamento = resultado.Departamento;
                response.ProvinciaId = resultado.ProvinciaId;
                response.Provincia = resultado.Provincia;
                response.DistritoId = resultado.DistritoId;
                response.Distrito = resultado.Distrito;
                response.EstadoId = resultado.EstadoId;
                response.Estado = resultado.Estado;
                response.AlmacenId = resultado.AlmacenId;
                response.Almacen = resultado.Almacen;
                response.UnidadMedidaId = resultado.UnidadMedidaId;
                response.UnidadMedida = resultado.UnidadMedida;
                response.Cantidad = resultado.Cantidad;
                response.TotalKilosNetosPesado = resultado.TotalKilosNetosPesado;
                response.TotalKilosBrutosPesado = resultado.TotalKilosBrutosPesado;
                response.PromedioRendimientoPorcentaje = resultado.PromedioRendimientoPorcentaje;
                response.PromedioRendimientoPorcentaje = resultado.PromedioRendimientoPorcentaje;
                response.PromedioHumedadPorcentaje = resultado.PromedioHumedadPorcentaje;
                response.PromedioTotalAnalisisSensorial = resultado.PromedioTotalAnalisisSensorial;

                response.FechaRegistro = resultado.FechaRegistro;
                response.UsuarioRegistro = resultado.UsuarioRegistro;
                response.FechaUltimaActualizacion = resultado.FechaUltimaActualizacion;
                response.UsuarioUltimaActualizacion = resultado.UsuarioUltimaActualizacion;
                response.Activo = resultado.Activo;
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

        [Route("ConsultarLoteDetallePorLoteId")]
        [HttpPost]
        public IActionResult ConsultarLoteDetalle([FromBody] ConsultaLoteDetalleBusquedaPorLoteIdRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaLoteDetalleBusquedaPorLoteIdResponseDTO response = new ConsultaLoteDetalleBusquedaPorLoteIdResponseDTO();
            try
            {
                response.Result.Data = _loteService.ConsultaLoteDetalleBusquedaPorLoteId(request);

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

        [Route("ConsultarEtiquetasLote")]
        [HttpPost]
        public IActionResult ConsultarEtiquetasLote([FromBody] ConsultarEtiquetasLoteRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultarEtiquetasLoteResponseDTO response = new ConsultarEtiquetasLoteResponseDTO();
            try
            {
                response.Result.Data = _loteService.ConsultarImpresionLotePorId(request.LoteId);

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

        [Route("GenerarPDFEtiquetasLote")]
        [HttpGet]
        public IActionResult GenerarPDFEtiquetasLote(int id)
        {
            return GenerarPDF(id);
        }

        IActionResult GenerarPDF(int id)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(id)}");

            GenerarPDFEtiquetasLoteResponseDTO response = new GenerarPDFEtiquetasLoteResponseDTO();
            try
            {
                GenerarPDFEtiquetasLoteRequestDTO request = new GenerarPDFEtiquetasLoteRequestDTO { LoteId = id };
                response.Result.Data = _loteService.ConsultarImpresionLotePorId(request.LoteId);
                string html = _loteService.ObtenerHTMLReporteEtiquetasLotes(response.Result.Data);

                var globalSettings = new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings { Top = 10 },
                    DocumentTitle = "Etiquetas Lotes"
                };
                var objectSettings = new ObjectSettings
                {
                    PagesCount = true,
                    HtmlContent = html,
                    WebSettings = { DefaultEncoding = "utf-8" },
                    HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Página [page] de [toPage]" }
                };
                var pdf = new HtmlToPdfDocument()
                {
                    GlobalSettings = globalSettings,
                    Objects = { objectSettings }
                };
                var file = _converter.Convert(pdf);

                return File(file, "application/pdf");
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

            _log.RegistrarEvento($"{guid}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }
    }
}
