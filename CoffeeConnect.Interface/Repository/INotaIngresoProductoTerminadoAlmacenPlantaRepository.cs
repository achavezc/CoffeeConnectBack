using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface INotaIngresoProductoTerminadoAlmacenPlantaRepository
    {       
        int Insertar(NotaIngresoProductoTerminadoAlmacenPlanta NotaIngresoProductoTerminadoAlmacenPlanta);

        IEnumerable<ConsultaNotaIngresoProductoTerminadoAlmacenPlantaBE> ConsultarNotaIngresoProductoTerminadoAlmacenPlanta(ConsultaNotaIngresoProductoTerminadoAlmacenPlantaRequestDTO request);


        ConsultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE ConsultarNotaIngresoProductoTerminadoAlmacenPlantaPorId(int NotaIngresoProductoTerminadoAlmacenPlantaId);
        

        int ActualizarEstado(int NotaIngresoProductoTerminadoAlmacenPlantaId, DateTime fecha, string usuario, string estadoId);


        public int Actualizar(NotaIngresoProductoTerminadoAlmacenPlanta NotaIngresoProductoTerminadoAlmacenPlanta);

        //int ActualizarCantidadOrdenProcesoEstado(int NotaIngresoProductoTerminadoAlmacenPlantaId, decimal cantidadOrdenProceso, decimal kilosNetosOrdenProceso, DateTime fecha, string usuario, string estadoId);
    }
}