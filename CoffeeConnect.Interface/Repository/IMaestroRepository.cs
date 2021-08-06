using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Repository
{
    public interface IMaestroRepository
    {
        IEnumerable<ConsultaDetalleTablaBE> ConsultarDetalleTablaDeTablas(int empresaId, string idioma);
        IEnumerable<ConsultaUbigeoBE> ConsultaUbibeo();
        IEnumerable<Zona> ConsultarZona(string codigoDistrito);
        IEnumerable<ConsultaPaisBE> ConsultarPais();
        IEnumerable<ConsultaPrecioDiaRendimientoBE> ConsultarPrecioDiaRendimientoPorEmpresa(int empresaId);
    }
}