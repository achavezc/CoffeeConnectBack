using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeConnect.Service
{
    public partial class OrganizacionService : IOrganizacionService
    {

        private IOrganizacionRepository _IOrganizacionRepository;

        public OrganizacionService(IOrganizacionRepository OrganizacionRepository)
        {
            _IOrganizacionRepository = OrganizacionRepository;
        }


        public List<ConsultaOrganizacionBE> ConsultarOrganizacion(ConsultaOrganizacionRequestDTO request)
        {
            var lista = _IOrganizacionRepository.ConsultarOrganizacion(request);

            return lista.ToList();
        }

    }
}
