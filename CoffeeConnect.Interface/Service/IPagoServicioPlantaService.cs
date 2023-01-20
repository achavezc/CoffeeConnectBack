using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adjunto;
 
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IPagoServicioPlantaService
    {
        List<ConsultaPagoServicioPlantaBE> ConsultarPagoServicioPlanta(ConsultaPagoServicioPlantaRequestDTO request);

        int RegistrarPagoServicioPlanta(RegistrarActualizarPagoServicioPlantaRequestDTO request);

        int ActualizarPagoServicioPlanta(RegistrarActualizarPagoServicioPlantaRequestDTO request);

        int AnularPagoServicioPlanta(PagoServicioPlantaAnularRequestDTO request);

        ConsultaPagoServicioPlantaPorIdBE ConsultarPagoServicioPlantaPorId(ConsultaPagoServicioPlantaPorIdRequestDTO request);
    }
}
