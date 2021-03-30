using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface ISocioFincaCertificacionRepository
    {
        int Insertar(SocioFincaCertificacion socioFincaCertificacion);

        int Actualizar(SocioFincaCertificacion socioFincaCertificacion);

        IEnumerable<ConsultaSocioFincaCertificacionPorSocioFincaId> ConsultarSocioFincaCertificacionPorSocioFincaId(int socioFincaId);

        ConsultaSocioFincaCertificacionPorId ConsultarSocioFincaCertificacionPorId(int socioFincaId);
    }
}