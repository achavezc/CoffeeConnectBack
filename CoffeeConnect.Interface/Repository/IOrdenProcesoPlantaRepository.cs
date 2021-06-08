using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Repository
{
    public interface IOrdenProcesoPlantaRepository
    {
        IEnumerable<ConsultaOrdenProcesoPlantaBE> ConsultarOrdenProcesoPlanta(ConsultaOrdenProcesoPlantaRequestDTO request);
        int Insertar(OrdenProcesoPlanta OrdenProcesoPlanta);
        int Actualizar(OrdenProcesoPlanta OrdenProcesoPlanta);
        //int Anular(int OrdenProcesoPlantaId, DateTime fecha, string usuario, string estadoId);
        //IEnumerable<OrdenProcesoPlantaDetalle> ConsultarOrdenProcesoPlantaDetallePorId(int OrdenProcesoPlantaId);
        //int EliminarProcesoDetalle(int OrdenProcesoPlantaId);
        //int InsertarProcesoDetalle(OrdenProcesoPlantaDetalle OrdenProcesoPlantaDetalle);
        //ConsultaOrdenProcesoPlantaPorIdBE ConsultarOrdenProcesoPlantaPorId(int OrdenProcesoPlantaId);
        //IEnumerable<OrdenProcesoPlantaDTO> ConsultarImpresionOrdenProcesoPlanta(int OrdenProcesoPlantaId);
    }
}
