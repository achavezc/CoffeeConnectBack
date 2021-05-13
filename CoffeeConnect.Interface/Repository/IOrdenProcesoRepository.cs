using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Repository
{
    public interface IOrdenProcesoRepository
    {
        IEnumerable<ConsultaOrdenProcesoBE> ConsultarOrdenProceso(ConsultaOrdenProcesoRequestDTO request);
        int Insertar(OrdenProceso ordenProceso);
        int Actualizar(OrdenProceso ordenProceso);
        int Anular(int ordenProcesoId, DateTime fecha, string usuario, string estadoId);
    }
}
