using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Repository
{
    public interface INotaIngresoPlantaRepository
    {
        IEnumerable<ConsultaNotaIngresoPlantaBE> ConsultarNotaIngresoPlanta(ConsultaNotaIngresoPlantaRequestDTO request);
        int AnularNotaIngresoPlanta(int NotaIngresoPlantaId, DateTime fecha, string usuario, string estadoId);
        ConsultaNotaIngresoPlantaPorIdBE ConsultarNotaIngresoPlantaPorId(int notaIngresoPlantaId);
        int InsertarPesado(NotaIngresoPlanta NotaIngresoPlanta);

        int ActualizarPesado(NotaIngresoPlanta NotaIngresoPlanta);

        int ActualizarAnalisisCalidad(NotaIngresoPlanta NotaIngresoPlanta);
       
        IEnumerable<NotaIngresoPlantaAnalisisFisicoColorDetalle> ConsultarNotaIngresoPlantaAnalisisFisicoColorDetallePorId(int NotaIngresoPlantaId);
        
        IEnumerable<NotaIngresoPlantaAnalisisFisicoOlorDetalle> ConsultarNotaIngresoPlantaAnalisisFisicoOlorDetallePorId(int NotaIngresoPlantaId);

        IEnumerable<NotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetalle> ConsultarNotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetallePorId(int NotaIngresoPlantaId);

        IEnumerable<NotaIngresoPlantaAnalisisFisicoDefectoSecundarioDetalle> ConsultarNotaIngresoPlantaAnalisisFisicoDefectoSecundarioDetallePorId(int NotaIngresoPlantaId);
        IEnumerable<NotaIngresoPlantaAnalisisSensorialAtributoDetalle> ConsultarNotaIngresoPlantaAnalisisSensorialAtributoDetallePorId(int NotaIngresoPlantaId);
        IEnumerable<NotaIngresoPlantaAnalisisSensorialDefectoDetalle> ConsultarNotaIngresoPlantaAnalisisSensorialDefectoDetallePorId(int NotaIngresoPlantaId);
        IEnumerable<NotaIngresoPlantaRegistroTostadoIndicadorDetalle> ConsultarNotaIngresoPlantaRegistroTostadoIndicadorDetallePorId(int NotaIngresoPlantaId);

        int ActualizarNotaIngresoPlantaAnalisisFisicoColorDetalle(List<NotaIngresoPlantaAnalisisFisicoColorDetalleTipo> request, int NotaIngresoPlantaId);
        int ActualizarNotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetalle(List<NotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetalleTipo> request, int NotaIngresoPlantaId);
        int ActualizarNotaIngresoPlantaAnalisisFisicoDefectoSecundarioDetalle(List<NotaIngresoPlantaAnalisisFisicoDefectoSecundarioDetalleTipo> request, int NotaIngresoPlantaId);
        int ActualizarNotaIngresoPlantaAnalisisFisicoOlorDetalle(List<NotaIngresoPlantaAnalisisFisicoOlorDetalleTipo> request, int NotaIngresoPlantaId);
        int ActualizarNotaIngresoPlantaAnalisisSensorialAtributoDetalle(List<NotaIngresoPlantaAnalisisSensorialAtributoDetalleTipo> request, int NotaIngresoPlantaId);
        int ActualizarNotaIngresoPlantaAnalisisSensorialDefectoDetalle(List<NotaIngresoPlantaAnalisisSensorialDefectoDetalleTipo> request, int NotaIngresoPlantaId);
        int ActualizarNotaIngresoPlantaRegistroTostadoIndicadorDetalle(List<NotaIngresoPlantaRegistroTostadoIndicadorDetalleTipo> request, int NotaIngresoPlantaId);


        int ActualizarEstado(int NotaIngresoPlantaId, DateTime fecha, string usuario, string estadoId);


        int InsertarNotaIngresoPlantaDetalle(NotaIngresoPlantaDetalle notaIngresoPlantaDetalle);


    }
}
