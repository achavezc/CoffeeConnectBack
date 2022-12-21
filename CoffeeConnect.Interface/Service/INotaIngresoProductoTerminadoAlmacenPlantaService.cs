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

        int ActualizarNotaIngresoProductoTerminadoAlmacenPlanta(ActualizarNotaIngresoProductoTerminadoAlmacenPlantaRequestDTO request);

        ConsultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE ConsultarNotaIngresoProductoTerminadoAlmacenPlantaPorId(ConsultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdRequestDTO request);

        List<ResumenNotaIngresoProductoTerminadoAlmacenPlantaBE> ResumenNotaIngresoProductoTerminadoAlmacenPlanta(ResumenNotaIngresoProductoTerminadoAlmacenPlantaRequestDTO request);

    }
}
