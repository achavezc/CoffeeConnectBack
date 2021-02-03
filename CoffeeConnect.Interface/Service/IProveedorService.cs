using CoffeeConnect.DTO;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IProveedorService
    {
        List<ConsultaProveedoresBE> ConsultarProveedores(ConsultaProveedoresRequestDTO consultaProveedoresRequestDTO);

    }
}
