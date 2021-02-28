using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IMaestroService
    {
        List<ConsultaDetalleTablaBE> ConsultarDetalleTablaDeTablas(int empresaId);
        List<ConsultaUbigeoBE> ConsultaUbibeo();
        List<Zona> ConsultarZona(string codigoDistrito);


    }
}
