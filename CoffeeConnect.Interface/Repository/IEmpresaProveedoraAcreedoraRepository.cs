using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IEmpresaProveedoraAcreedoraRepository
    {   
        IEnumerable<ConsultaEmpresaProveedoraAcreedoraBE> ConsultarEmpresaProveedoraAcreedora(ConsultaEmpresaProveedoraAcreedoraRequestDTO request);

        ConsultaEmpresaProveedoraAcreedoraPorIdBE ConsultarEmpresaProveedoraAcreedoraPorId(int EmpresaProveedoraAcreedoraId);
        int Actualizar(EmpresaProveedoraAcreedora EmpresaProveedoraAcreedora);
        int Insertar(EmpresaProveedoraAcreedora EmpresaProveedoraAcreedora);
    }
}
