using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Repository
{
    public interface ILiquidacionProcesoPlantaRepository
    {
        IEnumerable<ConsultaLiquidacionProcesoPlantaBE> ConsultarLiquidacionProcesoPlanta(ConsultaLiquidacionProcesoPlantaRequestDTO request);


        int Insertar(LiquidacionProcesoPlanta liquidacionProcesoPlanta);
        int Actualizar(LiquidacionProcesoPlanta liquidacionProcesoPlanta);

        int InsertarLiquidacionProcesoPlantaDetalle(LiquidacionProcesoPlantaDetalle liquidacionProcesoPlantaDetalle);

        int InsertarLiquidacionProcesoPlantaResultado(LiquidacionProcesoPlantaResultado liquidacionProcesoPlantaResultado);

        int EliminarLiquidacionProcesoPlantaResultado(int liquidacionProcesoPlantaPlantaId);

        ////int Anular(int LiquidacionProcesoPlantaId, DateTime fecha, string usuario, string estadoId);
        ////IEnumerable<LiquidacionProcesoPlantaDetalle> ConsultarLiquidacionProcesoPlantaDetallePorId(int LiquidacionProcesoPlantaId);
        int EliminarLiquidacionProcesoPlantaDetalle(int liquidacionProcesoPlantaId);

        ConsultaLiquidacionProcesoPlantaPorIdBE ConsultarLiquidacionProcesoPlantaPorId(int liquidacionProcesoPlantaId);

        //IEnumerable<LiquidacionProcesoPlantaDetalleBE> ConsultarLiquidacionProcesoPlantaDetallePorId(int LiquidacionProcesoPlantaId);
        //ConsultaLiquidacionProcesoPlantaPorIdBE ConsultarLiquidacionProcesoPlantaPorId(int LiquidacionProcesoPlantaId);
        ////IEnumerable<LiquidacionProcesoPlantaDTO> ConsultarImpresionLiquidacionProcesoPlanta(int LiquidacionProcesoPlantaId);
    }
}
