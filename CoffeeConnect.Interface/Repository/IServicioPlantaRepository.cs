using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IServicioPlantaRepository
    {   

        IEnumerable<ConsultaServicioPlantaBE> ConsultarServicioPlanta(ConsultaServicioPlantaRequestDTO request);
         
        ConsultaServicioPlantaPorIdBE ConsultarServicioPlantaPorId(int ServicioPlantaId);

        ConsultaServicioPlantaPorIdBE ConsultarServicioPlantaPorNotaIngresoPlantaId(int NotaIngresoPlantaId);

        int InsertarServicioPlanta(ServicioPlanta ServicioPlanta);
        int Actualizar(ServicioPlanta ServicioPlanta);
        int ServicioActualizarTotalImporteProcesado(ServicioActualizarTotalImporteProcesado ServicioPlanta2);

        

        int ActualizarServicioPlantaEstado(int ServicioPlantaId, DateTime fecha, string usuario, string estadoId);

        int ActualizarServicioPlantaEstadoMontos(int ServicioPlantaId, DateTime fecha, string usuario, string estadoId, decimal importe);

    }
}