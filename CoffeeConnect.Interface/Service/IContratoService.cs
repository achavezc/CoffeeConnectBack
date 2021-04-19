using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adjunto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IContratoService
    {
        int RegistrarContrato(RegistrarActualizarContratoRequestDTO request, IFormFile file);
        int ActualizarContrato(RegistrarActualizarContratoRequestDTO request, IFormFile file);
        List<ConsultaContratoBE> ConsultarContrato(ConsultaContratoRequestDTO request);
        ConsultaContratoPorIdBE ConsultarContratoPorId(ConsultaContratoPorIdRequestDTO request);

        ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request);


    }
}
