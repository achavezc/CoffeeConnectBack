using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adjunto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IAduanaService
    {
        int RegistrarAduana(RegistrarActualizarAduanaRequestDTO request, IFormFile file);
        int ActualizarAduana(RegistrarActualizarAduanaRequestDTO request, IFormFile file);
        List<ConsultaAduanaBE> ConsultarAduana(ConsultaAduanaRequestDTO request);
        ConsultaAduanaPorIdBE ConsultarAduanaPorId(ConsultaAduanaPorIdRequestDTO request);
        ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request);

        int AnularAduana(AnularAduanaRequestDTO request);
    }
}
