using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface ISocioRepository
    {
        int Insertar(Socio socio);

        int Actualizar(Socio socio);

        IEnumerable<ConsultaSocioBE> ConsultarSocio(ConsultaSocioRequestDTO request);

        ConsultaSocioPorIdBE ConsultarSocioPorId(int socioId);

        ConsultaProductorIdBE ConsultarSocioProductorPorSocioFincaId(int socioFincaId);

    }
}