using CoffeeConnect.DTO;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IMaestroService
    {
        List<ConsultaDetalleTablaBE> ConsultarDetalleTablaDeTablas(int empresaId);

    }
}
