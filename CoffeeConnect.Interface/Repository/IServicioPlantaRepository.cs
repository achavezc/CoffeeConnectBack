using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IServicioPlantaRepository
    {   

        IEnumerable<ConsultaServicioPlantaBE> ConsultarServicioPlanta(ConsultaServicioPlantaRequestDTO request);

        int InsertarServicioPlanta(ServicioPlanta ServicioPlanta);

    }
}