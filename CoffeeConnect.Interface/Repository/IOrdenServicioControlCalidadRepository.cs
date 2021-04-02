using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IOrdenServicioControlCalidadRepository
    {
        IEnumerable<ConsultaOrdenServicioControlCalidadBE> ConsultarOrdenServicioControlCalidad(ConsultaOrdenServicioControlCalidadRequestDTO request);
        int ActualizarEstado(int ordenServicioControlCalidadId, DateTime fecha, string usuario, string estadoId);
        int Insertar(OrdenServicioControlCalidad OrdenServicioControlCalidad);
        int Actualizar(OrdenServicioControlCalidad OrdenServicioControlCalidad);

        int ActualizarAnalisisCalidad(OrdenServicioControlCalidad OrdenServicioControlCalidad);

        ConsultaOrdenServicioControlCalidadPorIdBE ConsultarOrdenServicioControlCalidadPorId(int OrdenServicioControlCalidadId);
        IEnumerable<OrdenServicioControlCalidadAnalisisFisicoColorDetalle> ConsultarOrdenServicioControlCalidadAnalisisFisicoColorDetallePorId(int OrdenServicioControlCalidadId);
        IEnumerable<OrdenServicioControlCalidadAnalisisFisicoOlorDetalle> ConsultarOrdenServicioControlCalidadAnalisisFisicoOlorDetallePorId(int OrdenServicioControlCalidadId);
        IEnumerable<OrdenServicioControlCalidadAnalisisFisicoDefectoPrimarioDetalle> ConsultarOrdenServicioControlCalidadAnalisisFisicoDefectoPrimarioDetallePorId(int OrdenServicioControlCalidadId);
        IEnumerable<OrdenServicioControlCalidadAnalisisFisicoDefectoSecundarioDetalle> ConsultarOrdenServicioControlCalidadAnalisisFisicoDefectoSecundarioDetallePorId(int OrdenServicioControlCalidadId);
        IEnumerable<OrdenServicioControlCalidadAnalisisSensorialAtributoDetalle> ConsultarOrdenServicioControlCalidadAnalisisSensorialAtributoDetallePorId(int OrdenServicioControlCalidadId);
        IEnumerable<OrdenServicioControlCalidadAnalisisSensorialDefectoDetalle> ConsultarOrdenServicioControlCalidadAnalisisSensorialDefectoDetallePorId(int OrdenServicioControlCalidadId);
        IEnumerable<OrdenServicioControlCalidadRegistroTostadoIndicadorDetalle> ConsultarOrdenServicioControlCalidadRegistroTostadoIndicadorDetallePorId(int OrdenServicioControlCalidadId);
        int ActualizarOrdenServicioControlCalidadAnalisisFisicoColorDetalle(List<OrdenServicioControlCalidadAnalisisFisicoColorDetalleTipo> request, int OrdenServicioControlCalidadId);
        int ActualizarOrdenServicioControlCalidadAnalisisFisicoDefectoPrimarioDetalle(List<OrdenServicioControlCalidadAnalisisFisicoDefectoPrimarioDetalleTipo> request, int OrdenServicioControlCalidadId);
        int ActualizarOrdenServicioControlCalidadAnalisisFisicoDefectoSecundarioDetalle(List<OrdenServicioControlCalidadAnalisisFisicoDefectoSecundarioDetalleTipo> request, int OrdenServicioControlCalidadId);
        int ActualizarOrdenServicioControlCalidadAnalisisFisicoOlorDetalle(List<OrdenServicioControlCalidadAnalisisFisicoOlorDetalleTipo> request, int OrdenServicioControlCalidadId);
        int ActualizarOrdenServicioControlCalidadAnalisisSensorialAtributoDetalle(List<OrdenServicioControlCalidadAnalisisSensorialAtributoDetalleTipo> request, int OrdenServicioControlCalidadId);
        int ActualizarOrdenServicioControlCalidadAnalisisSensorialDefectoDetalle(List<OrdenServicioControlCalidadAnalisisSensorialDefectoDetalleTipo> request, int OrdenServicioControlCalidadId);
        int ActualizarOrdenServicioControlCalidadRegistroTostadoIndicadorDetalle(List<OrdenServicioControlCalidadRegistroTostadoIndicadorDetalleTipo> request, int OrdenServicioControlCalidadId);






    }
}