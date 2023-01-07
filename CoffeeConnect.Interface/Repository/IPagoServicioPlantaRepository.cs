﻿using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IPagoServicioPlantaRepository
    {
        IEnumerable<ConsultaPagoServicioPlantaBE> ConsultarPagoServicioPlanta(ConsultaPagoServicioPlantaRequestDTO request);
        int Insertar(PagoServicioPlanta PagoServicioPlanta);
        ConsultaPagoServicioPlantaPorIdBE ConsultarPagoServicioPlantaPorId(int PagoServicioPlantaId);
        int Actualizar(PagoServicioPlanta PagoServicioPlanta);
    }
}