using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adjunto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IAduanaService
    {
        int RegistrarAduana(RegistrarActualizarAduanaRequestDTO request);
        int ActualizarAduana(RegistrarActualizarAduanaRequestDTO request);
        List<ConsultaAduanaBE> ConsultarAduana(ConsultaAduanaRequestDTO request);
        ConsultaAduanaPorIdBE ConsultarAduanaPorId(ConsultaAduanaPorIdRequestDTO request);
        ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request);

        int AnularAduana(AnularAduanaRequestDTO request);
    }
}
