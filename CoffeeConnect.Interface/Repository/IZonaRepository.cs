using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IZonaRepository
    {
        int Insertar(Zona Zona);

        int Actualizar(Zona Zona);

        IEnumerable<ConsultaZonaBE> ConsultarZona(ConsultaZonaRequestDTO request);

        ConsultaZonaPorIdBE ConsultarZonaPorId(int ZonaId);

       
    }
}