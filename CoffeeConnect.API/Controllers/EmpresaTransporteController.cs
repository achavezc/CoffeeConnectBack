﻿using System;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Service;
using Core.Common.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace Integracion.Deuda.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaTransporteController : ControllerBase
    {
        private IEmpresaTransporteService _empresaTransporteService;
        private Core.Common.Logger.ILog _log;
        public EmpresaTransporteController(IEmpresaTransporteService empresaTransporteService, Core.Common.Logger.ILog log)
        {
            _empresaTransporteService = empresaTransporteService;
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
        public IActionResult ConsultarEmpresaTransporte([FromBody] ConsultaEmpresaTransporteRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaEmpresaTransporteResponseDTO response = new ConsultaEmpresaTransporteResponseDTO();
            try
            {                
                List<EmpresaTransporteBE> lista = _empresaTransporteService.ConsultarEmpresaTransporte(request.EmpresaId);

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

            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }
        
    }
}