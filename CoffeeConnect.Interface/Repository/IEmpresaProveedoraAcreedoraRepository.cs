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

        IEnumerable<ConsultaEmpresaProveedoraAcreedoraCertificacionPorIdBE> ConsultarEmpresaProveedoraAcreedoraCertificacionPorId(int empresaProveedoraAcreedoraId);
        IEnumerable<ConsultaEmpresaProveedoraAcreedoraBE> ValidarEmpresaProveedoraAcreedora(string ruc, int empresaId);

        int ActualizarEmpresaProveedoraAcreedoraCertificacion(List<EmpresaProveedoraAcreedoraCertificacionTipo> request, int empresaProveedoraAcreedoraCertificacionId);

    }
}
