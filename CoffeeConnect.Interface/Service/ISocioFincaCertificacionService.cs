using CoffeeConnect.DTO;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface ISocioFincaCertificacionService
    {

        int RegistrarSocioFincaCertificacion(RegistrarActualizarSocioFincaCertificacionRequestDTO request);
        int ActualizarSocioFincaCertificacion(RegistrarActualizarSocioFincaCertificacionRequestDTO request);

        IEnumerable<ConsultaSocioFincaCertificacionPorSocioFincaId> ConsultarSocioFincaCertificacionPorSocioFincaId(ConsultaSocioFincaCertificacionPorSocioFincaIdRequestDTO request);

        ConsultaSocioFincaCertificacionPorId ConsultarSocioFincaCertificacionPorId(ConsultaSocioFincaCertificacionPorIdRequestDTO request);
    }
}
