using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adjunto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IPrestamoPlantaService
    {
        int RegistrarPrestamoPlanta(RegistrarActualizarPrestamoPlantaRequestDTO request);
       

        List<ConsultaPrestamoPlantaBE> ConsultarPrestamoPlanta(ConsultaPrestamoPlantaRequestDTO request);

        ConsultaPrestamoPlantaPorIdBE ConsultarPrestamoPlantaPorId(ConsultaPrestamoPlantaPorIdRequestDTO request);

        int ActualizarPrestamoPlanta(RegistrarActualizarPrestamoPlantaRequestDTO request);

        int AnularPrestamoPlanta(PrestamoPlantaAnularRequestDTO request);
    }
}
