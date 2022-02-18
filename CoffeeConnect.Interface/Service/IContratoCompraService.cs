using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adjunto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IContratoCompraService
    {
        int RegistrarContratoCompra(RegistrarActualizarContratoCompraRequestDTO request, IFormFile file);
        int ActualizarContratoCompra(RegistrarActualizarContratoCompraRequestDTO request, IFormFile file);
        List<ConsultaContratoCompraBE> ConsultarContratoCompra(ConsultaContratoCompraRequestDTO request);
        ConsultaContratoCompraPorIdBE ConsultarContratoCompraPorId(ConsultaContratoCompraPorIdRequestDTO request);
        ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request);
        int AnularContratoCompra(AnularContratoCompraRequestDTO request);

        int AsignarContratoVenta(AsignarContratoVentaRequestDTO request);

    }
}
