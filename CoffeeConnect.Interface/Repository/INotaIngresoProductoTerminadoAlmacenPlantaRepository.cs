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


        public int Actualizar(int NotaIngresoProductoTerminadoAlmacenPlantaId,string almacenId,DateTime fecha, string usuario);

        int ActualizarCantidadSalidaAlmacenEstado(int notaIngresoProductoTerminadoAlmacenPlantaId, decimal cantidadSalidaAlmacen, decimal kilosNetosSalidaAlmacen, DateTime fecha, string usuario, string estadoId);

        int ActualizarCantidadOrdenProcesoEstado(int notaIngresoProductoTerminadoAlmacenPlantaId, decimal cantidadOrdenProceso, decimal kilosNetosOrdenProceso, DateTime fecha, string usuario, string estadoId);

        //int ActualizarCantidadOrdenProcesoEstado(int NotaIngresoProductoTerminadoAlmacenPlantaId, decimal cantidadOrdenProceso, decimal kilosNetosOrdenProceso, DateTime fecha, string usuario, string estadoId);

        IEnumerable<ResumenNotaIngresoProductoTerminadoAlmacenPlantaBE> ResumenNotaIngresoProductoTerminadoAlmacenPlanta(ResumenNotaIngresoProductoTerminadoAlmacenPlantaRequestDTO request);

    }
}