using CoffeeConnect.DTO;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Repository
{
    public interface IProveedorRepository
    {
        IEnumerable<ConsultaProveedoresBE> ConsultarProveedores(ConsultaProveedoresRequestDTO request);
    }
}