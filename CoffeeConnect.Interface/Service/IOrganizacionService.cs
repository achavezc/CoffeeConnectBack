using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IOrganizacionService
    {
        List<ConsultaOrganizacionBE> ConsultarOrganizacion(ConsultaOrganizacionRequestDTO request);

    }
}
