using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models.Kardex;
using Core.Common.Domain.Model;
using Core.Common.Logger;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeConnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KardexController : ControllerBase
    {
        private IKardexService _kardexService;
        private ILog _log;

        public KardexController(IKardexService kardexService, ILog log)
        {
            _kardexService = kardexService;
            _log = log;
        }

        [Route("GenerarKardex")]
        [HttpGet]
        public IActionResult GenerarKardex([FromQuery(Name = "fechaInicio")] string fechaInicio, [FromQuery(Name = "fechaFin")] string fechaFin, [FromQuery(Name = "empresaId")] int empresaId)
        {
            Guid guid = Guid.NewGuid();
            KardexPergaminoIngresoConsultaRequest request = new KardexPergaminoIngresoConsultaRequest();
            request.FechaInicio = Convert.ToDateTime(fechaInicio);
            request.FechaFin = Convert.ToDateTime(fechaFin);
            request.EmpresaId = empresaId;
            ExportarKardexResponseDTO response = new ExportarKardexResponseDTO();
            try
            {
                response = _kardexService.ExportarKardex(request);
                return File(response.content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", string.Format("Kardex-{0}_{1}.xlsx", DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("HHmmss")));
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
