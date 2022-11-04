using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface INotaIngresoProductoTerminadoAlmacenPlantaService
    {

        int RegistrarNotaIngresoProductoTerminadoAlmacenPlanta(RegistrarActualizarNotaIngresoProductoTerminadoAlmacenPlantaRequestDTO request);

        List<ConsultaNotaIngresoProductoTerminadoAlmacenPlantaBE> ConsultarNotaIngresoProductoTerminadoAlmacenPlanta(ConsultaNotaIngresoProductoTerminadoAlmacenPlantaRequestDTO request);

        int AnularNotaIngresoProductoTerminadoAlmacenPlanta(AnularNotaIngresoProductoTerminadoAlmacenPlantaRequestDTO request);

        int ActualizarNotaIngresoProductoTerminadoAlmacenPlanta(RegistrarActualizarNotaIngresoProductoTerminadoAlmacenPlantaRequestDTO request);

        ConsultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE ConsultarNotaIngresoProductoTerminadoAlmacenPlantaPorId(ConsultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdRequestDTO request);
    }
}
