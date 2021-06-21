using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adjunto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IDiagnosticoService
    {
        int RegistrarDiagnostico(RegistrarActualizarDiagnosticoRequestDTO request, IFormFile file);
        int ActualizarDiagnostico(RegistrarActualizarDiagnosticoRequestDTO request, IFormFile file);
        List<ConsultaDiagnosticoBE> ConsultarDiagnostico(ConsultaDiagnosticoRequestDTO request);
        ConsultaDiagnosticoPorIdBE ConsultarDiagnosticoPorId(ConsultaDiagnosticoPorIdRequestDTO request);
        ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request);
    }
}
