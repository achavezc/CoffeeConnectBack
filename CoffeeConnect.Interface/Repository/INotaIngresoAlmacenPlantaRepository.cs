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



        public int Actualizar(NotaIngresoAlmacenPlanta NotaIngresoAlmacenPlanta);

        int ActualizarEstadoPorIds(List<TablaIdsTipo> ids, DateTime fecha, string usuario, string estadoId);


        int ActualizarNotaIngresoAlmacenPlantaAnalisisFisicoColorDetalle(List<NotaIngresoAlmacenPlantaAnalisisFisicoColorDetalleTipo> request, int NotaIngresoAlmacenPlantaId);
        int ActualizarNotaIngresoAlmacenPlantaAnalisisFisicoDefectoPrimarioDetalle(List<NotaIngresoAlmacenPlantaAnalisisFisicoDefectoPrimarioDetalleTipo> request, int NotaIngresoAlmacenPlantaId);
        int ActualizarNotaIngresoAlmacenPlantaAnalisisFisicoDefectoSecundarioDetalle(List<NotaIngresoAlmacenPlantaAnalisisFisicoDefectoSecundarioDetalleTipo> request, int NotaIngresoAlmacenPlantaId);
        int ActualizarNotaIngresoAlmacenPlantaAnalisisFisicoOlorDetalle(List<NotaIngresoAlmacenPlantaAnalisisFisicoOlorDetalleTipo> request, int NotaIngresoAlmacenPlantaId);
        int ActualizarNotaIngresoAlmacenPlantaAnalisisSensorialAtributoDetalle(List<NotaIngresoAlmacenPlantaAnalisisSensorialAtributoDetalleTipo> request, int NotaIngresoAlmacenPlantaId);
        int ActualizarNotaIngresoAlmacenPlantaAnalisisSensorialDefectoDetalle(List<NotaIngresoAlmacenPlantaAnalisisSensorialDefectoDetalleTipo> request, int NotaIngresoAlmacenPlantaId);
        int ActualizarNotaIngresoAlmacenPlantaRegistroTostadoIndicadorDetalle(List<NotaIngresoAlmacenPlantaRegistroTostadoIndicadorDetalleTipo> request, int NotaIngresoAlmacenPlantaId);


        int ActualizarCantidadOrdenProcesoEstado(int notaIngresoAlmacenPlantaId, decimal cantidadOrdenProceso, decimal kilosNetosOrdenProceso, DateTime fecha, string usuario, string estadoId);
    }
}