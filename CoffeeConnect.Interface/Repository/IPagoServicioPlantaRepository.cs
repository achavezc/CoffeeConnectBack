using CoffeeConnect.DTO;
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

        int AnularPagoServicioPlanta(int PagoServicioPlantaId, DateTime fecha, string usuario, string estadoId,string Observacion);

        IEnumerable<ConsultaPagoServicioPlantaBE> ConsultarPagoServicioPlantaPorServicioPlantaId(int servicioPlantaId);

    }
}