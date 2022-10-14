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

        ConsultaNotaIngresoAlmacenPlantaPorIdBE ConsultarNotaIngresoAlmacenPlantaPorId(int NotaIngresoAlmacenPlantaId);
        
        IEnumerable<NotaIngresoAlmacenPlantaAnalisisFisicoColorDetalle> ConsultarNotaIngresoAlmacenPlantaAnalisisFisicoColorDetallePorId(int NotaIngresoAlmacenPlantaId);


        IEnumerable<NotaIngresoAlmacenPlantaAnalisisFisicoOlorDetalle> ConsultarNotaIngresoAlmacenPlantaAnalisisFisicoOlorDetallePorId(int NotaIngresoAlmacenPlantaId);

        IEnumerable<NotaIngresoAlmacenPlantaAnalisisFisicoDefectoPrimarioDetalle> ConsultarNotaIngresoAlmacenPlantaAnalisisFisicoDefectoPrimarioDetallePorId(int NotaIngresoAlmacenPlantaId);

        IEnumerable<NotaIngresoAlmacenPlantaAnalisisFisicoDefectoSecundarioDetalle> ConsultarNotaIngresoAlmacenPlantaAnalisisFisicoDefectoSecundarioDetallePorId(int NotaIngresoAlmacenPlantaId);

        IEnumerable<NotaIngresoAlmacenPlantaAnalisisSensorialAtributoDetalle> ConsultarNotaIngresoAlmacenPlantaAnalisisSensorialAtributoDetallePorId(int NotaIngresoAlmacenPlantaId);

        IEnumerable<NotaIngresoAlmacenPlantaAnalisisSensorialDefectoDetalle> ConsultarNotaIngresoAlmacenPlantaAnalisisSensorialDefectoDetallePorId(int NotaIngresoAlmacenPlantaId);

        IEnumerable<NotaIngresoAlmacenPlantaRegistroTostadoIndicadorDetalle> ConsultarNotaIngresoAlmacenPlantaRegistroTostadoIndicadorDetallePorId(int NotaIngresoAlmacenPlantaId);





        int ActualizarEstado(int NotaIngresoAlmacenPlantaId, DateTime fecha, string usuario, string estadoId);

 

        int Actualizar(int NotaIngresoAlmacenPlantaId, DateTime fecha, string usuario, string almacenId);

        int ActualizarEstadoPorIds(List<TablaIdsTipo> ids, DateTime fecha, string usuario, string estadoId);
    }
}