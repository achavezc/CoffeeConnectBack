using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IEmpresaRepository
    {
       

        IEnumerable<Empresa> ObtenerEmpresaPorId(int empresaId);
        IEnumerable<EmpresaBE> ConsultarEmpresa(int empresaId);
    }
}
