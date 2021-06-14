using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Repository
{
    public interface IOrdenProcesoPlantaRepository
    {
        IEnumerable<ConsultaOrdenProcesoPlantaBE> ConsultarOrdenProcesoPlanta(ConsultaOrdenProcesoPlantaRequestDTO request);
        int Insertar(OrdenProcesoPlanta ordenProcesoPlanta);
        int Actualizar(OrdenProcesoPlanta ordenProcesoPlanta);

        int InsertarProcesoPlantaDetalle(OrdenProcesoPlantaDetalle ordenProcesoPlantaDetalle);

        //int Anular(int OrdenProcesoPlantaId, DateTime fecha, string usuario, string estadoId);
        //IEnumerable<OrdenProcesoPlantaDetalle> ConsultarOrdenProcesoPlantaDetallePorId(int OrdenProcesoPlantaId);
        int EliminarProcesoPlantaDetalle(int ordenProcesoPlantaId);

        IEnumerable<OrdenProcesoPlantaDetalleBE> ConsultarOrdenProcesoPlantaDetallePorId(int OrdenProcesoPlantaId);
        ConsultaOrdenProcesoPlantaPorIdBE ConsultarOrdenProcesoPlantaPorId(int ordenProcesoPlantaId);
        //IEnumerable<OrdenProcesoPlantaDTO> ConsultarImpresionOrdenProcesoPlanta(int OrdenProcesoPlantaId);
    }
}
