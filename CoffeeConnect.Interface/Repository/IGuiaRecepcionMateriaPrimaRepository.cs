using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IGuiaRecepcionMateriaPrimaRepository
    {
        IEnumerable<ConsultaGuiaRecepcionMateriaPrimaBE> ConsultarGuiaRecepcionMateriaPrima(ConsultaGuiaRecepcionMateriaPrimaRequestDTO request);
        int AnularGuiaRecepcionMateriaPrima(int guiaRecepcionMateriaPrimaId, DateTime fecha, string usuario, string estadoId);
        ConsultaGuiaRecepcionMateriaPrimaPorIdBE ConsultarGuiaRecepcionMateriaPrimaPorId(int guiaRecepcionMateriaPrimaId);
        int Insert(GuiaRecepcionMateriaPrima guiaRecepcionMateriaPrima);
        int ActualizarAnalisisCalidad(GuiaRecepcionMateriaPrima guiaRecepcionMateriaPrima);
       
        IEnumerable<GuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalle> ConsultarGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetallePorId(int guiaRecepcionMateriaPrimaId);
        
        IEnumerable<GuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalle> ConsultarGuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetallePorId(int guiaRecepcionMateriaPrimaId);

        IEnumerable<GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetalle> ConsultarGuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetallePorId(int guiaRecepcionMateriaPrimaId);

        IEnumerable<GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetalle> ConsultarGuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetallePorId(int guiaRecepcionMateriaPrimaId);
        
        IEnumerable<GuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalle> ConsultarGuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetallePorId(int guiaRecepcionMateriaPrimaId);
        
        IEnumerable<GuiaRecepcionMateriaPrimaAnalisisSensorialDefectoDetalle> ConsultarGuiaRecepcionMateriaPrimaAnalisisSensorialDefectoDetallePorId(int guiaRecepcionMateriaPrimaId);

        IEnumerable<GuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetalle> ConsultarGuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetallePorId(int guiaRecepcionMateriaPrimaId);
        

    }
}