using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IEmpresaProveedoraAcreedoraService
    {
        List<ConsultaEmpresaProveedoraAcreedoraBE> ConsultarEmpresaProveedoraAcreedora(ConsultaEmpresaProveedoraAcreedoraRequestDTO request);

    }
}
