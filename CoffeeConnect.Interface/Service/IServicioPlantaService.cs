﻿using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adjunto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IServicioPlantaService
    {
        int RegistrarServicioPlanta(RegistrarActualizarServicioPlantaRequestDTO request);
       

        List<ConsultaServicioPlantaBE> ConsultarServicioPlanta(ConsultaServicioPlantaRequestDTO request);

        ConsultaServicioPlantaPorIdBE ConsultarServicioPlantaPorId(ConsultaServicioPlantaPorIdRequestDTO request);

        int ActualizarServicioPlanta(RegistrarActualizarServicioPlantaRequestDTO request);

        int AnularServicioPlanta(ServicioPlantaAnularRequestDTO request);
    }
}
