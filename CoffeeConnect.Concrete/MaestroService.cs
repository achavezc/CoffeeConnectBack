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
            List<ConsultaPrecioDiaRendimientoBE> resultados = _IMaestroRepository.ConsultarPrecioDiaRendimientoPorEmpresa(request.EmpresaId).ToList();

            return resultados;
            //List<ConsultaPrecioDiaRendimientoBE> precios = new List<ConsultaPrecioDiaRendimientoBE>();

            //ConsultaPrecioDiaRendimientoBE precio1 = new ConsultaPrecioDiaRendimientoBE();
            //precio1.MonedaId = "01";
            //precio1.TipoCambio = 3.86;
            //precio1.PrecioPromedioContrato = 170.25;
            //precio1.RendimientoInicio = 64;
            //precio1.RendimientoFin = 65.99;
            //precio1.Valor1 = 9.80;
            //precio1.Valor2 = 9.60;
            //precio1.Valor3 = 9.40;

            //ConsultaPrecioDiaRendimientoBE precio2 = new ConsultaPrecioDiaRendimientoBE();
            //precio2.MonedaId = "01";
            //precio2.TipoCambio = 3.86;
            //precio2.PrecioPromedioContrato = 170.25;
            //precio2.RendimientoInicio = 66;
            //precio2.RendimientoFin = 67.99;
            ////precio2.Valor1 = 10;
            ////precio2.Valor2 = 9.80;
            ////precio2.Valor3 = 9.60;

            //ConsultaPrecioDiaRendimientoBE precio3 = new ConsultaPrecioDiaRendimientoBE();
            //precio3.MonedaId = "01";
            //precio3.TipoCambio = 3.86;
            //precio3.PrecioPromedioContrato = 170.25;
            //precio3.RendimientoInicio = 68;
            //precio3.RendimientoFin = 69.99;
            ////precio3.Valor1 = 10.20;
            ////precio3.Valor2 = 10;
            ////precio3.Valor3 = 9.80;

            //ConsultaPrecioDiaRendimientoBE precio4 = new ConsultaPrecioDiaRendimientoBE();
            //precio4.MonedaId = "01";
            //precio4.TipoCambio = 3.86;
            //precio4.PrecioPromedioContrato = 170.25;
            //precio4.RendimientoInicio = 70;
            //precio4.RendimientoFin = 71.99;

            //ConsultaPrecioDiaRendimientoBE precio5 = new ConsultaPrecioDiaRendimientoBE();
            //precio5.MonedaId = "01";
            //precio5.TipoCambio = 3.86;
            //precio5.PrecioPromedioContrato = 170.25;
            //precio5.RendimientoInicio = 72;
            //precio5.RendimientoFin = 73.99;

            //ConsultaPrecioDiaRendimientoBE precio6 = new ConsultaPrecioDiaRendimientoBE();
            //precio6.MonedaId = "01";
            //precio6.TipoCambio = 3.86;
            //precio6.PrecioPromedioContrato = 170.25;
            //precio6.RendimientoInicio = 74;
            //precio6.RendimientoFin = 75.99;

            //ConsultaPrecioDiaRendimientoBE precio7 = new ConsultaPrecioDiaRendimientoBE();
            //precio7.MonedaId = "01";
            //precio7.TipoCambio = 3.86;
            //precio7.PrecioPromedioContrato = 170.25;
            //precio7.RendimientoInicio = 76;
            //precio7.RendimientoFin = 77.99;

            //ConsultaPrecioDiaRendimientoBE precio8 = new ConsultaPrecioDiaRendimientoBE();
            //precio8.MonedaId = "01";
            //precio8.TipoCambio = 3.86;
            //precio8.PrecioPromedioContrato = 170.25;
            //precio8.RendimientoInicio = 78;
            //precio8.RendimientoFin = 79.99;

            //ConsultaPrecioDiaRendimientoBE precio9 = new ConsultaPrecioDiaRendimientoBE();
            //precio9.MonedaId = "01";
            //precio9.TipoCambio = 3.86;
            //precio9.PrecioPromedioContrato = 170.25;
            //precio9.RendimientoInicio = 80;
            //precio9.RendimientoFin = 80;

            //precios.Add(precio1);
            //precios.Add(precio2);
            //precios.Add(precio3);
            //precios.Add(precio4);
            //precios.Add(precio5);
            //precios.Add(precio6);
            //precios.Add(precio7);
            //precios.Add(precio8);
            //precios.Add(precio9);

            //return precios;
        }

    }
}
