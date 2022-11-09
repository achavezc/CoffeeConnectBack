
using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using Core.Common;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface INotaSalidaAlmacenPlantaRepository
    {
        int Insertar(NotaSalidaAlmacenPlanta NotaSalidaAlmacenPlanta);

        int Actualizar(NotaSalidaAlmacenPlanta NotaSalidaAlmacenPlanta);

        int ActualizarEstado(int NotaSalidaAlmacenPlantaId, DateTime fecha, string usuario, string estadoId);

        int EliminarNotaSalidaAlmacenPlantaDetalle(int NotaSalidaAlmacenPlantaId);


        IEnumerable<ConsultaNotaSalidaAlmacenPlantaBE> ConsultarNotaSalidaAlmacenPlanta(ConsultaNotaSalidaAlmacenPlantaRequestDTO request);
       
        ConsultaNotaSalidaAlmacenPlantaPorIdBE ConsultarNotaSalidaAlmacenPlantaPorId(int NotaSalidaAlmacenPlantaId);


        IEnumerable<ConsultaNotaSalidaAlmacenPlantaDetallePorIdBE> ConsultarNotaSalidaAlmacenPlantaDetallePorIdBE(int notaSalidaAlmacenPlantaId);

        int ActualizarNotaSalidaAlmacenPlantaDetalle(List<NotaSalidaAlmacenPlantaDetalle> request, int? NotaSalidaAlmacenPlantaId);

        //int ActualizarEstadoPorIds(List<TablaIdsTipo> ids, DateTime fecha, string usuario, string estadoId);

        int InsertarNotaSalidaAlmacenPlantaDetalle(NotaSalidaAlmacenPlantaDetalle notaSalidaAlmacenPlantaDetalle);

    }
}