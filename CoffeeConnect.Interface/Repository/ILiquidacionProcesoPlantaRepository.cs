using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Repository
{
    public interface ILiquidacionProcesoPlantaRepository
    {
        IEnumerable<ConsultaLiquidacionProcesoPlantaBE> ConsultarLiquidacionProcesoPlanta(ConsultaLiquidacionProcesoPlantaRequestDTO request);


        //int Insertar(LiquidacionProcesoPlanta LiquidacionProcesoPlanta);
        //int Actualizar(LiquidacionProcesoPlanta LiquidacionProcesoPlanta);

        //int InsertarProcesoPlantaDetalle(LiquidacionProcesoPlantaDetalle LiquidacionProcesoPlantaDetalle);

        ////int Anular(int LiquidacionProcesoPlantaId, DateTime fecha, string usuario, string estadoId);
        ////IEnumerable<LiquidacionProcesoPlantaDetalle> ConsultarLiquidacionProcesoPlantaDetallePorId(int LiquidacionProcesoPlantaId);
        //int EliminarProcesoPlantaDetalle(int LiquidacionProcesoPlantaId);

        //IEnumerable<LiquidacionProcesoPlantaDetalleBE> ConsultarLiquidacionProcesoPlantaDetallePorId(int LiquidacionProcesoPlantaId);
        //ConsultaLiquidacionProcesoPlantaPorIdBE ConsultarLiquidacionProcesoPlantaPorId(int LiquidacionProcesoPlantaId);
        ////IEnumerable<LiquidacionProcesoPlantaDTO> ConsultarImpresionLiquidacionProcesoPlanta(int LiquidacionProcesoPlantaId);
    }
}
