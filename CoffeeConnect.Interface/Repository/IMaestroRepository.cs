using CoffeeConnect.DTO;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Repository
{
    public interface IMaestroRepository
    {
        IEnumerable<ConsultaDetalleTablaBE> ConsultarDetalleTablaDeTablas(int empresaId);
    }
}