using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Interface.Repository
{
   public interface IControlCalidadPlantaRepository
    {
        IEnumerable<ConsultaControlCalidadPlantaBE> ConsultarControlCalidadPlanta(ConsultaControlCalidadPlantaRequestDTO request);
        int AnularControlCalidadPlanta(int ControlCalidadPlantaId,int NotaIngresoPlantaId,string estadoNotaIngresoId, DateTime fecha, string usuario, string estadoId);
        ConsultaControlCalidadPlantaPorIdBE ConsultaControlCalidadPlantaPorId(int ControlCalidadPlantaId);
        int InsertarPesadoControlCalidadPlanta(ControlCalidadPlanta NotaIngresoPlanta);

        int ActualizarPesadoControlCalidadPlanta(ControlCalidadPlanta NotaIngresoPlanta);

        int ActualizarAnalisisCalidad(ControlCalidadPlanta NotaIngresoPlanta);
        public int ControlCalidadPlantaActualizarProcesar(ControlCalidadPlanta ControlCalidadPlanta);
        public int ControlCalidadPlantaActualizarEstadoRechazado(ControlCalidadPlanta ControlCalidadPlanta);

        IEnumerable<ControlCalidadPlantaAnalisisFisicoColorDetalle> ConsultarControlCalidadPlantaAnalisisFisicoColorDetallePorId(int ControlCalidadPlantaId);

        IEnumerable<ControlCalidadPlantaAnalisisFisicoOlorDetalle> ConsultarControlCalidadPlantaAnalisisFisicoOlorDetallePorId(int ControlCalidadPlantaId);

        IEnumerable<ControlCalidadPlantaAnalisisFisicoDefectoPrimarioDetalle> ConsultarControlCalidadPlantaAnalisisFisicoDefectoPrimarioDetallePorId(int ControlCalidadPlantaId);

        IEnumerable<ControlCalidadPlantaAnalisisFisicoDefectoSecundarioDetalle> ConsultarControlCalidadPlantaAnalisisFisicoDefectoSecundarioDetallePorId(int ControlCalidadPlantaId);
        IEnumerable<ControlCalidadPlantaAnalisisSensorialAtributoDetalle> ConsultarControlCalidadPlantaAnalisisSensorialAtributoDetallePorId(int ControlCalidadPlantaId);
        IEnumerable<ControlCalidadPlantaAnalisisSensorialDefectoDetalle> ConsultarControlCalidadPlantaAnalisisSensorialDefectoDetallePorId(int ControlCalidadlantaId);
        IEnumerable<ControlCalidadPlantaRegistroTostadoIndicadorDetalle> ConsultarControlCalidadPlantaRegistroTostadoIndicadorDetallePorId(int ControlCalidadPlantaId);

        int ActualizarControlCalidadPlantaAnalisisFisicoColorDetalle(List<ControlCalidadPlantaAnalisisFisicoColorDetalleTipo> request, int ControlCalidadPlantaId);
        int ActualizarControlCalidadPlantaAnalisisFisicoDefectoPrimarioDetalle(List<ControlCalidadPlantaAnalisisFisicoDefectoPrimarioDetalleTipo> request, int ControlCalidadPlantaId);
        int ActualizarControlCalidadPlantaAnalisisFisicoDefectoSecundarioDetalle(List<ControlCalidadPlantaAnalisisFisicoDefectoSecundarioDetalleTipo> request, int ControlCalidadPlantaId);
        int ActualizarControlCalidadPlantaAnalisisFisicoOlorDetalle(List<ControlCalidadPlantaAnalisisFisicoOlorDetalleTipo> request, int ControlCalidadPlantaId);
        int ActualizarControlCalidadPlantaAnalisisSensorialAtributoDetalle(List<ControlCalidadPlantaAnalisisSensorialAtributoDetalleTipo> request, int ControlCalidadPlantaId);
        int ActualizarControlCalidadPlantaAnalisisSensorialDefectoDetalle(List<ControlCalidadPlantaAnalisisSensorialDefectoDetalleTipo> request, int ControlCalidadPlantaId);
        int ActualizarControlCalidadPlantaRegistroTostadoIndicadorDetalle(List<ControlCalidadPlantaRegistroTostadoIndicadorDetalleTipo> request, int ControlCalidadPlantaId);


        int ActualizarEstadoControlCalidad(int ControlCalidadPlantaId, DateTime fecha, string usuario, string estadoId);

        int ActualizarCantidadProcesadaEstado(int controlCalidadPlantaId, decimal cantidadProcesada, decimal kilosNetosProcesado, DateTime fecha, string usuario, string estadoId);



        int ActualizarControlCalidad(ControlCalidadPlanta ControlCalidadPlanta);
    }
}
