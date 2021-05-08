using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeConnect.Service
{
    public partial class EmpresaTransporteService : IEmpresaTransporteService
    {

        private IEmpresaTransporteRepository _IEmpresaTransporteRepository;

        public EmpresaTransporteService(IEmpresaTransporteRepository empresaTransporteRepository)
        {
            _IEmpresaTransporteRepository = empresaTransporteRepository;
        }
        public List<EmpresaTransporteBE> ConsultarEmpresaTransporte(int empresaId)
        {
            var lista = _IEmpresaTransporteRepository.ConsultarEmpresaTransporte(empresaId);

            return lista.ToList();
        }

        public List<ConsultaTransportistaBE> ConsultarTransportista(ConsultaTransportistaRequestDTO request)
        {
            var lista = _IEmpresaTransporteRepository.ConsultarTransportista(request);

            return lista.ToList();
        }

    }
}
