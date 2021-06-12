using CoffeeConnect.DTO;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface INotaSalidaAlmacenPlantaService
    {
        int RegistrarNotaSalidaAlmacenPlanta(RegistrarNotaSalidaAlmacenPlantaRequestDTO request);
        int ActualizarNotaSalidaAlmacenPlanta(RegistrarNotaSalidaAlmacenPlantaRequestDTO request);
        int AnularNotaSalidaAlmacenPlanta(AnularNotaSalidaAlmacenPlantaRequestDTO request);
        List<ConsultaNotaSalidaAlmacenPlantaBE> ConsultarNotaSalidaAlmacenPlanta(ConsultaNotaSalidaAlmacenPlantaRequestDTO request);
        ConsultaNotaSalidaAlmacenPlantaPorIdBE ConsultarNotaSalidaAlmacenPlantaPorId(ConsultaNotaSalidaAlmacenPlantaPorIdRequestDTO request);

        
    }
}
