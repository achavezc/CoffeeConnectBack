using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IDetalleCatalogoRepository
    {
        int Insertar(DetalleCatalogo DetalleCatalogo);

        int Actualizar(DetalleCatalogo DetalleCatalogo);

        IEnumerable<ConsultaDetalleCatalogoBE> ConsultarDetalleCatalogo(ConsultaDetalleCatalogoRequestDTO request);

        ConsultaDetalleCatalogoPorIdBE ConsultarDetalleCatalogoPorId(int DetalleCatalogoId);

        IEnumerable<ConsultaCatalogoTablasBE> ConsultarCatalogoTablas();
    }
}