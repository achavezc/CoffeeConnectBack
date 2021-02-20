using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface INotaSalidaAlmacenRepository
    {
        int Insertar(NotaCompra notaCompra);

        int Actualizar(NotaCompra notaCompra);

        int Anular(int notaCompraId, DateTime fecha, string usuario, string estadoId);

        IEnumerable<ConsultaNotaSalidaAlmacenBE> ConsultarNotaSalidaAlmacen(ConsultaNotaSalidaAlmacenRequestDTO request);
        IEnumerable<ConsultaImpresionListaProductoresPorNotaSalidaAlmacenIdBE> ConsultarImpresionListaProductoresPorNotaSalida(int notaSalidaAlmacenId);

        ConsultaNotaSalidaAlmacenPorIdBE ConsultarNotaSalidaAlmacenPorId(int notaSalidaAlmacenId);
    }
}