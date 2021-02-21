using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IEmpresaTransporteRepository
    {
       

        IEnumerable<EmpresaTransporteBE> ConsultarEmpresaTransporte(int empresaId);
    }
}
