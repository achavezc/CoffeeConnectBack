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

        private IProductoPrecioDiaRepository _IProductoPrecioDiaRepository;

        public MaestroService(IMaestroRepository maestroRepository, IProductoPrecioDiaRepository productoPrecioDiaRepository)
        {
            _IMaestroRepository = maestroRepository;
            _IProductoPrecioDiaRepository = productoPrecioDiaRepository;
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

        public List<ConsultaProductoPrecioDiaBE> ConsultarProductoPrecioDiaPorSubProductoIdPorEmpresaId(string subProductoId, int empresaId)
        {
            List<ConsultaProductoPrecioDiaBE> precios = _IProductoPrecioDiaRepository.ConsultarProductoPrecioDiaPorSubProductoIdPorEmpresaId(empresaId,subProductoId ).ToList();


            return precios;
        }

        public List<ConsultaPrecioDiaRendimientoBE> ConsultarPrecioDiaRendimiento(ConsultaPrecioDiaRendimientoRequestDTO request)
        {
            List<ConsultaPrecioDiaRendimientoBE> precios = new List<ConsultaPrecioDiaRendimientoBE>();

            ConsultaPrecioDiaRendimientoBE precio1 = new ConsultaPrecioDiaRendimientoBE();
            precio1.MonedaId = "01";
            precio1.RendimientoInicio = 64;
            precio1.RendimientoFin = 65.99;
            precio1.Valor1 = 9.80;
            precio1.Valor2 = 9.60;
            precio1.Valor3 = 9.40;

            ConsultaPrecioDiaRendimientoBE precio2 = new ConsultaPrecioDiaRendimientoBE();
            precio2.MonedaId = "01";
            precio2.RendimientoInicio = 66;
            precio2.RendimientoFin = 67.99;
            precio2.Valor1 = 10;
            precio2.Valor2 = 9.80;
            precio2.Valor3 = 9.60;

            ConsultaPrecioDiaRendimientoBE precio3 = new ConsultaPrecioDiaRendimientoBE();
            precio3.MonedaId = "01";
            precio3.RendimientoInicio = 68;
            precio3.RendimientoFin = 69.99;
            precio3.Valor1 = 10.20;
            precio3.Valor2 = 10;
            precio3.Valor3 = 9.80;

            precios.Add(precio1);
            precios.Add(precio2);
            precios.Add(precio3);

            return precios;
        }

    }
}
