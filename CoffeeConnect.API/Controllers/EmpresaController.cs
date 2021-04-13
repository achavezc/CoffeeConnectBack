using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Service;
using Core.Common.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Integracion.Deuda.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private IEmpresaService _empresaService;
        private IEmpresaProveedoraAcreedoraService _empresaProveedoraAcreedoraService;

        private Core.Common.Logger.ILog _log;
        public EmpresaController(IEmpresaService empresaService, IEmpresaProveedoraAcreedoraService empresaProveedoraAcreedoraService, Core.Common.Logger.ILog log)
        {
            _empresaService = empresaService;
            _empresaProveedoraAcreedoraService = empresaProveedoraAcreedoraService;
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
        public IActionResult ConsultarEmpresa([FromBody] ConsultaEmpresaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            //ConsultaEmpresaResponseDTO response = new ConsultaEmpresaResponseDTO();

            ConsultaEmpresaProveedoraAcreedoraResponseDTO response = new ConsultaEmpresaProveedoraAcreedoraResponseDTO();

            try
            {
                ConsultaEmpresaProveedoraAcreedoraRequestDTO consultaEmpresaProveedoraAcreedoraRequestDTO = new ConsultaEmpresaProveedoraAcreedoraRequestDTO();
                consultaEmpresaProveedoraAcreedoraRequestDTO.EmpresaId = request.EmpresaId;
                consultaEmpresaProveedoraAcreedoraRequestDTO.EstadoId = MaestroEstados.Activo;

                //List<EmpresaBE> lista = _empresaService.ConsultarEmpresa(request.EmpresaId);
                List<ConsultaEmpresaProveedoraAcreedoraBE> lista = _empresaProveedoraAcreedoraService.ConsultarEmpresaProveedoraAcreedora(consultaEmpresaProveedoraAcreedoraRequestDTO);

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
