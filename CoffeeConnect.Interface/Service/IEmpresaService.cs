using CoffeeConnect.DTO;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IEmpresaService
    {
        List<EmpresaBE> ConsultarEmpresa(int empresaId);

    }
}
