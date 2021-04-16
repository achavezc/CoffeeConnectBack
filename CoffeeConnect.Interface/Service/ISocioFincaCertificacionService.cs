using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adjunto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface ISocioFincaCertificacionService
    {

        int RegistrarSocioFincaCertificacion(RegistrarActualizarSocioFincaCertificacionRequestDTO request, IFormFile file);
        int ActualizarSocioFincaCertificacion(RegistrarActualizarSocioFincaCertificacionRequestDTO request, IFormFile file);

        IEnumerable<ConsultaSocioFincaCertificacionPorSocioFincaId> ConsultarSocioFincaCertificacionPorSocioFincaId(ConsultaSocioFincaCertificacionPorSocioFincaIdRequestDTO request);

        ConsultaSocioFincaCertificacionPorId ConsultarSocioFincaCertificacionPorId(ConsultaSocioFincaCertificacionPorIdRequestDTO request);
        ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request);
    }
}
