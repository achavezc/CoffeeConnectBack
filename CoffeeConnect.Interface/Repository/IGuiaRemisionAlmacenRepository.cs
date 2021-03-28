using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IGuiaRemisionAlmacenRepository
    {
        //int ActualizarGuiaRemisionAlmacen(GuiaRemisionAlmacen guiaRemisionAlmacen);
        int ActualizarGuiaRemisionAlmacenDetalle(List<GuiaRemisionAlmacenDetalleTipo> guiaRemisionAlmacenDetalle);
        ConsultaGuiaRemisionAlmacen ConsultaGuiaRemisionAlmacenPorNotaSalidaAlmacenId(int notaSalidaAlmacenId);
        IEnumerable<ConsultaGuiaRemisionAlmacenDetalle> ConsultaGuiaRemisionAlmacenDetallePorGuiaRemisionAlmacenId(int guiaRemisionAlmacenId);

        int Insertar(GuiaRemisionAlmacen guiaRemisionAlmacen);
        int Actualizar(GuiaRemisionAlmacen guiaRemisionAlmacen);
    }
}