using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using Core.Common.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeConnect.Service
{
    public partial class EmpresaService : IEmpresaService
    {
       
        private IEmpresaRepository _IEmpresaRepository;
       
        public EmpresaService(IEmpresaRepository empresaRepository)
        {
            _IEmpresaRepository = empresaRepository;          
        }
        public List<EmpresaBE> ConsultarEmpresa(int empresaId)       
        {            
            var lista = _IEmpresaRepository.ConsultarEmpresa(empresaId);
            
            return lista.ToList();
        }
    }
}
