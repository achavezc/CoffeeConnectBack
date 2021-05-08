using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeConnect.Service
{
    public partial class EmpresaProveedoraAcreedoraService : IEmpresaProveedoraAcreedoraService
    {

        private IEmpresaProveedoraAcreedoraRepository _IEmpresaProveedoraAcreedoraRepository;

        public EmpresaProveedoraAcreedoraService(IEmpresaProveedoraAcreedoraRepository empresaProveedoraAcreedoraRepository)
        {
            _IEmpresaProveedoraAcreedoraRepository = empresaProveedoraAcreedoraRepository;
        }


        public List<ConsultaEmpresaProveedoraAcreedoraBE> ConsultarEmpresaProveedoraAcreedora(ConsultaEmpresaProveedoraAcreedoraRequestDTO request)
        {
            var lista = _IEmpresaProveedoraAcreedoraRepository.ConsultarEmpresaProveedoraAcreedora(request);

            return lista.ToList();
        }

    }
}
