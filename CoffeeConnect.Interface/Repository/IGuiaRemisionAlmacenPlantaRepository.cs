using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IGuiaRemisionAlmacenPlantaRepository
    {
        //int ActualizarGuiaRemisionAlmacenPlanta(GuiaRemisionAlmacenPlanta GuiaRemisionAlmacenPlanta);
        int ActualizarGuiaRemisionAlmacenPlantaDetalle(List<GuiaRemisionAlmacenPlantaDetalleTipo> guiaRemisionAlmacenPlantaDetalle);
        ConsultaGuiaRemisionAlmacenPlanta ConsultaGuiaRemisionAlmacenPlantaPorNotaSalidaAlmacenPlantaId(int notaSalidaAlmacenPlantaId);
        IEnumerable<ConsultaGuiaRemisionAlmacenPlantaDetalle> ConsultaGuiaRemisionAlmacenPlantaDetallePorGuiaRemisionAlmacenPlantaId(int guiaRemisionAlmacenPlantaId);

        int Insertar(GuiaRemisionAlmacenPlanta guiaRemisionAlmacenPlanta);
        int Actualizar(GuiaRemisionAlmacenPlanta guiaRemisionAlmacenPlanta);

        //int ActualizarDatosCalidad(GuiaRemisionAlmacenPlanta GuiaRemisionAlmacenPlanta);

        ConsultaGuiaRemisionAlmacenPlanta ConsultaGuiaRemisionAlmacenPlantaPorId(int guiaRemisionAlmacenPlantaId);

    }
}