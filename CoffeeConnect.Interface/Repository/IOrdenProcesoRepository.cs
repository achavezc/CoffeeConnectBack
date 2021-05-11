using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Interface.Repository
{
    public interface IOrdenProcesoRepository
    {
        IEnumerable<ConsultaOrdenProcesoBE> ConsultarOrdenProceso(ConsultaOrdenProcesoRequestDTO request);
        int Insertar(OrdenProceso ordenProceso);
        int Actualizar(OrdenProceso ordenProceso);
    }
}
