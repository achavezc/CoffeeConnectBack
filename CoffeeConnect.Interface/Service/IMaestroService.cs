using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IMaestroService
    {
        List<ConsultaDetalleTablaBE> ConsultarDetalleTablaDeTablas(int empresaId, string idioma);
        List<ConsultaUbigeoBE> ConsultaUbibeo();
        List<Zona> ConsultarZona(string codigoDistrito);

        List<ConsultaPaisBE> ConsultarPais();

        List<ConsultaProductoPrecioDiaBE> ConsultarProductoPrecioDiaPorSubProductoIdPorEmpresaId(string subProductoId, int empresaId);

        List<ConsultaPrecioDiaRendimientoDetalleBE> ConsultarPrecioDiaRendimiento(ConsultaPrecioDiaRendimientoRequestDTO request);


     

    }
}
