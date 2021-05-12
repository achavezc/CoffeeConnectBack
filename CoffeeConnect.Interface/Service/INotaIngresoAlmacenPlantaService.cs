using CoffeeConnect.DTO;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface INotaIngresoAlmacenPlantaService
    {
       
        int Registrar(EnviarAlmacenNotaIngresoPlantaRequestDTO request);

        //List<ConsultaNotaIngresoAlmacenPlantaBE> ConsultarNotaIngresoAlmacenPlanta(ConsultaNotaIngresoAlmacenPlantaRequestDTO request);

        //int AnularNotaIngresoAlmacenPlanta(AnularNotaIngresoAlmacenPlantaRequestDTO request);

        int ActualizarNotaIngresoAlmacenPlanta(ActualizarNotaIngresoAlmacenPlantaRequestDTO request);

        //ConsultaNotaIngresoAlmacenPlantaPorIdBE ConsultarNotaIngresoAlmacenPlantaPorId(ConsultaNotaIngresoAlmacenPlantaPorIdRequestDTO request);
    }
}
