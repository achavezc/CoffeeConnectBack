using CoffeeConnect.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface INotaSalidaAlmacenService
    {
        int RegistrarNotaCompra(RegistrarActualizarNotaCompraRequestDTO request);

        int ActualizarNotaCompra(RegistrarActualizarNotaCompraRequestDTO request);

        int AnularNotaCompra(AnularNotaCompraRequestDTO request);

        
        List<ConsultaNotaSalidaAlmacenBE> ConsultarNotaSalidaAlmacen(ConsultaNotaSalidaAlmacenRequestDTO request);

        ConsultaImpresionListaProductoresPorNotaSalidaAlmacenResponseDTO ConsultarImpresionListaProductoresPorNotaSalidaAlmacen(int notaSalidaAlmacenId);
        

    }
}
