using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface INotaIngresoAlmacenPlantaRepository
    {       
        int Insertar(NotaIngresoAlmacenPlanta NotaIngresoAlmacenPlanta);

        IEnumerable<ConsultaNotaIngresoAlmacenPlantaBE> ConsultarNotaIngresoAlmacenPlanta(ConsultaNotaIngresoAlmacenPlantaRequestDTO request);

        //IEnumerable<NotaIngresoAlmacenPlanta> ConsultarNotaIngresoPorIds(List<TablaIdsTipo> request);

      
     

        int ActualizarEstado(int NotaIngresoAlmacenPlantaId, DateTime fecha, string usuario, string estadoId);

        ConsultaNotaIngresoAlmacenPlantaPorIdBE ConsultarNotaIngresoAlmacenPlantaPorId(int NotaIngresoAlmacenPlantaId);

        int Actualizar(int NotaIngresoAlmacenPlantaId, DateTime fecha, string usuario, string almacenId);

        int ActualizarEstadoPorIds(List<TablaIdsTipo> ids, DateTime fecha, string usuario, string estadoId);
    }
}