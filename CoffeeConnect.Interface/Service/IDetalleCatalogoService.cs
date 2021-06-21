using CoffeeConnect.DTO;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IDetalleCatalogoService
    {

        int RegistrarDetalleCatalogo(RegistrarActualizarDetalleCatalogoRequestDTO request);
        int ActualizarDetalleCatalogo(RegistrarActualizarDetalleCatalogoRequestDTO request);


        List<ConsultaDetalleCatalogoBE> ConsultarDetalleCatalogo(ConsultaDetalleCatalogoRequestDTO request);
        ConsultaDetalleCatalogoPorIdBE ConsultarDetalleCatalogoPorId(ConsultaDetalleCatalogoPorIdRequestDTO request);

        List<ConsultaCatalogoTablasBE> ConsultarCatalogoTablas(ConsultaCatalogoTablasRequestDTO request);


    }
}
