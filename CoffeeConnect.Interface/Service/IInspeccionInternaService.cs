using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adjunto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IInspeccionInternaService
    {
        int RegistrarInspeccionInterna(RegistrarActualizarInspeccionInternaRequestDTO request, IFormFile file);
        int ActualizarInspeccionInterna(RegistrarActualizarInspeccionInternaRequestDTO request, IFormFile file);
        List<ConsultaInspeccionInternaBE> ConsultarInspeccionInterna(ConsultaInspeccionInternaRequestDTO request);
        ConsultaInspeccionInternaPorIdBE ConsultarInspeccionInternaPorId(ConsultaInspeccionInternaPorIdRequestDTO request);
        ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request);
    }
}
