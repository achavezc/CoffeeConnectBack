using CoffeeConnect.DTO;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IOrdenServicioControlCalidadService
    {
       
       
        List<ConsultaOrdenServicioControlCalidadBE> ConsultarOrdenServicioControlCalidad(ConsultaOrdenServicioControlCalidadRequestDTO request);

        int AnularOrdenServicioControlCalidad(AnularOrdenServicioControlCalidadRequestDTO request);
    }
}
