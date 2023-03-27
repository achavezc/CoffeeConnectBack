using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IContratoCompraRepository
    {
        int Insertar(ContratoCompra ContratoCompra);

        int Actualizar(ContratoCompra ContratoCompra);

        IEnumerable<ConsultaContratoCompraBE> ConsultarContratoCompra(ConsultaContratoCompraRequestDTO request);

        ConsultaContratoCompraPorIdBE ConsultarContratoCompraPorId(int ContratoCompraId);

        int ActualizarEstado(int ContratoCompraId, DateTime fecha, string usuario, string estadoId);

        int ValidadContratoCompraExistente(int empresaId, string numero);

        int AsignarContratoCompra(int contratoVentaId, int contratoCompraId, DateTime fecha, string usuario, string estadoId, string contratoVentaEstadoId);

        int DesasignarContratoCompra(int contratoVentaId, int contratoCompraId, DateTime fecha, string usuario, string estadoId, string contratoVentaEstadoId);


        int ActualizarTotalSacosContratoVenta(int contratoCompraId, decimal totalSacosContratoVenta, decimal kilosNetosQQContratoVenta, DateTime fecha, string usuario, string estadoId);

        ConsultaContratoCompraPorIdBE ConsultarContratoCompraPorContratoVentaId(int ContratoVentaId);

    }
}