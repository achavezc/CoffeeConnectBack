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
        int ActualizarGuiaRemisionAlmacenPlantaDetalle(List<GuiaRemisionAlmacenPlantaDetalleTipo> GuiaRemisionAlmacenPlantaDetalle);
        //ConsultaGuiaRemisionAlmacenPlanta ConsultaGuiaRemisionAlmacenPlantaPorNotaSalidaAlmacenId(int notaSalidaAlmacenId);
        //IEnumerable<ConsultaGuiaRemisionAlmacenPlantaDetalle> ConsultaGuiaRemisionAlmacenPlantaDetallePorGuiaRemisionAlmacenPlantaId(int GuiaRemisionAlmacenPlantaId);

        int Insertar(GuiaRemisionAlmacenPlanta GuiaRemisionAlmacenPlanta);
        int Actualizar(GuiaRemisionAlmacenPlanta GuiaRemisionAlmacenPlanta);

        //int ActualizarDatosCalidad(GuiaRemisionAlmacenPlanta GuiaRemisionAlmacenPlanta);

        //ConsultaGuiaRemisionAlmacenPlanta ConsultaGuiaRemisionAlmacenPlantaPorId(int GuiaRemisionAlmacenPlantaId);
    }
}