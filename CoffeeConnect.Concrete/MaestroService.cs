using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeConnect.Service
{
    public partial class MaestroService : IMaestroService
    {

        private IMaestroRepository _IMaestroRepository;

        public MaestroService(IMaestroRepository maestroRepository)
        {
            _IMaestroRepository = maestroRepository;
        }
        public List<ConsultaDetalleTablaBE> ConsultarDetalleTablaDeTablas(int empresaId)
        {
            var lista = _IMaestroRepository.ConsultarDetalleTablaDeTablas(empresaId);

            return lista.ToList();
        }
        public List<ConsultaUbigeoBE> ConsultaUbibeo()
        {
            var lista = _IMaestroRepository.ConsultaUbibeo();

            return lista.ToList();
        }

        public List<Zona> ConsultarZona(string codigoDistrito)
        {
            var lista = _IMaestroRepository.ConsultarZona(codigoDistrito);

            return lista.ToList();
        }

        public List<ConsultaPaisBE> ConsultarPais()
        {
            var lista = _IMaestroRepository.ConsultarPais();

            return lista.ToList();
        }

    }
}
