using CoffeeConnect.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Interface.Repository
{
   public interface IControlCalidadPlantaRepository
    {
        IEnumerable<ConsultaControlCalidadPlantaBE> ConsultarControlCalidadPlanta(ConsultaControlCalidadPlantaRequestDTO request);
        int AnularControlCalidadPlanta(int NotaIngresoPlantaId, DateTime fecha, string usuario, string estadoId);
        ConsultaControlCalidadPlantaPorIdBE ConsultaControlCalidadPlantaPorId(int ControlCalidadPlantaId);
        int InsertarPesadoControlCalidadPlanta(ControlCalidadPlanta NotaIngresoPlanta);

        int ActualizarPesadoControlCalidadPlanta(ControlCalidadPlanta NotaIngresoPlanta);

        int ActualizarAnalisisCalidad(ControlCalidadPlanta NotaIngresoPlanta);
        public int ControlCalidadPlantaActualizarProcesar(ControlCalidadPlanta ControlCalidadPlanta);

        IEnumerable<ControlCalidadPlantaAnalisisFisicoColorDetalle> ConsultarControlCalidadPlantaAnalisisFisicoColorDetallePorId(int NotaIngresoPlantaId);

        IEnumerable<ControlCalidadPlantaAnalisisFisicoOlorDetalle> ConsultarControlCalidadPlantaAnalisisFisicoOlorDetallePorId(int NotaIngresoPlantaId);

        IEnumerable<ControlCalidadPlantaAnalisisFisicoDefectoPrimarioDetalle> ConsultarControlCalidadPlantaAnalisisFisicoDefectoPrimarioDetallePorId(int NotaIngresoPlantaId);

        IEnumerable<ControlCalidadPlantaAnalisisFisicoDefectoSecundarioDetalle> ConsultarControlCalidadPlantaAnalisisFisicoDefectoSecundarioDetallePorId(int NotaIngresoPlantaId);
        IEnumerable<ControlCalidadPlantaAnalisisSensorialAtributoDetalle> ConsultarControlCalidadPlantaAnalisisSensorialAtributoDetallePorId(int NotaIngresoPlantaId);
        IEnumerable<ControlCalidadPlantaAnalisisSensorialDefectoDetalle> ConsultarControlCalidadPlantaAnalisisSensorialDefectoDetallePorId(int NotaIngresoPlantaId);
        IEnumerable<ControlCalidadPlantaRegistroTostadoIndicadorDetalle> ConsultarControlCalidadPlantaRegistroTostadoIndicadorDetallePorId(int NotaIngresoPlantaId);

        int ActualizarControlCalidadPlantaAnalisisFisicoColorDetalle(List<ControlCalidadPlantaAnalisisFisicoColorDetalleTipo> request, int NotaIngresoPlantaId);
        int ActualizarControlCalidadPlantaAnalisisFisicoDefectoPrimarioDetalle(List<ControlCalidadPlantaAnalisisFisicoDefectoPrimarioDetalleTipo> request, int NotaIngresoPlantaId);
        int ActualizarControlCalidadPlantaAnalisisFisicoDefectoSecundarioDetalle(List<ControlCalidadPlantaAnalisisFisicoDefectoSecundarioDetalleTipo> request, int NotaIngresoPlantaId);
        int ActualizarControlCalidadPlantaAnalisisFisicoOlorDetalle(List<ControlCalidadPlantaAnalisisFisicoOlorDetalleTipo> request, int NotaIngresoPlantaId);
        int ActualizarControlCalidadPlantaAnalisisSensorialAtributoDetalle(List<ControlCalidadPlantaAnalisisSensorialAtributoDetalleTipo> request, int NotaIngresoPlantaId);
        int ActualizarControlCalidadPlantaAnalisisSensorialDefectoDetalle(List<ControlCalidadPlantaAnalisisSensorialDefectoDetalleTipo> request, int NotaIngresoPlantaId);
        int ActualizarControlCalidadPlantaRegistroTostadoIndicadorDetalle(List<ControlCalidadPlantaRegistroTostadoIndicadorDetalleTipo> request, int NotaIngresoPlantaId);


        int ActualizarEstadoControlCalidad(int NotaIngresoPlantaId, DateTime fecha, string usuario, string estadoId);
    }
}
