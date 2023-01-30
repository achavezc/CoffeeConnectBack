using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adjunto;
 
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IDevolucionPrestamoPlantaService
    {
        List<ConsultaDevolucionPrestamoPlantaBE> ConsultarDevolucionPrestamoPlanta(ConsultaDevolucionPrestamoPlantaRequestDTO request);

        int RegistrarDevolucionPrestamoPlanta(RegistrarActualizarDevolucionPrestamoPlantaRequestDTO request);

        int ActualizarDevolucionPrestamoPlanta(RegistrarActualizarDevolucionPrestamoPlantaRequestDTO request);

        int AnularDevolucionPrestamoPlanta(DevolucionPrestamoPlantaAnularRequestDTO request);

        ConsultaDevolucionPrestamoPlantaPorIdBE ConsultarDevolucionPrestamoPlantaPorId(ConsultaDevolucionPrestamoPlantaPorIdRequestDTO request);
    }
}
