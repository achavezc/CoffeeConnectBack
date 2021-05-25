using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface ILoteRepository
    {
        int Insertar(Lote lote);
        int InsertarLoteDetalle(List<LoteDetalle> request);

        LoteDetalle ConsultarLoteDetallePorId(int loteDetalleId);
        int ActualizarEstadoPorIds(List<TablaIdsTipo> ids, DateTime fecha, string usuario, string estadoId);
        int EliminarLoteDetalle(List<TablaIdsTipo> request);
        IEnumerable<ConsultaLoteBE> ConsultarLote(ConsultaLoteRequestDTO request);

        int ActualizarEstado(int loteId, DateTime fecha, string usuario, string estadoId);


        int Actualizar(int loteId, DateTime fecha, string usuario, string almacenId, int cantidad, decimal totalKilosNetosPesado, decimal totalKilosBrutosPesado, int? contratoId);

        IEnumerable<LoteDetalle> ConsultarLoteDetallePorLoteId(int loteId);

        

        IEnumerable<LoteDetalleConsulta> ConsultarBandejaLoteDetallePorId(int loteId);
        ConsultaLoteBandejaBE ConsultarLotePorId(int loteId);


        IEnumerable<ConsultaImpresionLotePorIdBE> ConsultarImpresionLotePorId(int loteId);

       
        IEnumerable<LoteAnalisisFisicoColorDetalle> ConsultarLoteAnalisisFisicoColorDetallePorId(int LoteId);
        IEnumerable<LoteAnalisisFisicoOlorDetalle> ConsultarLoteAnalisisFisicoOlorDetallePorId(int LoteId);

        IEnumerable<LoteAnalisisFisicoDefectoPrimarioDetalle> ConsultarLoteAnalisisFisicoDefectoPrimarioDetallePorId(int LoteId);
        IEnumerable<LoteAnalisisFisicoDefectoSecundarioDetalle> ConsultarLoteAnalisisFisicoDefectoSecundarioDetallePorId(int LoteId);
        IEnumerable<LoteAnalisisSensorialAtributoDetalle> ConsultarLoteAnalisisSensorialAtributoDetallePorId(int LoteId);
        IEnumerable<LoteAnalisisSensorialDefectoDetalle> ConsultarLoteAnalisisSensorialDefectoDetallePorId(int LoteId);
        IEnumerable<LoteRegistroTostadoIndicadorDetalle> ConsultarLoteRegistroTostadoIndicadorDetallePorId(int LoteId);

        int ActualizarLoteAnalisisFisicoColorDetalle(List<LoteAnalisisFisicoColorDetalleTipo> request, int LoteId);
        int ActualizarLoteAnalisisFisicoDefectoPrimarioDetalle(List<LoteAnalisisFisicoDefectoPrimarioDetalleTipo> request, int LoteId);
        int ActualizarLoteAnalisisFisicoDefectoSecundarioDetalle(List<LoteAnalisisFisicoDefectoSecundarioDetalleTipo> request, int LoteId);
        int ActualizarLoteAnalisisFisicoOlorDetalle(List<LoteAnalisisFisicoOlorDetalleTipo> request, int LoteId);
        int ActualizarLoteAnalisisSensorialAtributoDetalle(List<LoteAnalisisSensorialAtributoDetalleTipo> request, int LoteId);
        int ActualizarLoteAnalisisSensorialDefectoDetalle(List<LoteAnalisisSensorialDefectoDetalleTipo> request, int LoteId);
        int ActualizarLoteRegistroTostadoIndicadorDetalle(List<LoteRegistroTostadoIndicadorDetalleTipo> request, int LoteId);

        int ActualizarLoteAnalisisCalidad(Lote Lote);

    }
}