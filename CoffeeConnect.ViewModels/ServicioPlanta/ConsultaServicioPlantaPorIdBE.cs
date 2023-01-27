using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class ConsultaServicioPlantaPorIdBE
    {
        public ConsultaServicioPlantaPorIdBE()
        {
            
        }

        public int ServicioPlantaId { get; set; }

        public int EmpresaId { get; set; }

        public int EmpresaClienteId { get; set; }

        public decimal? TotalImporteProcesado { get; set; }

        public string RazonSocialEmpresaCliente { get; set; }

        public string RucEmpresaCliente { get; set; }

        public string Numero { get; set; }

        public string MonedaId { get; set; }

        public string TipoComprobanteId { get; set; }

        public decimal? Saldo { get; set; }


        public string TipoServicioId { get; set; }

        public string TipoServicio { get; set; }

        public string TipoComprobante { get; set; }

        public string SerieComprobante { get; set; }

        public string NumeroComprobante { get; set; }

        public string SerieDocumento { get; set; }

        public string UnidadMedidaId { get; set; }

        public string NumeroDocumento { get; set; }

        public DateTime FechaDocumento { get; set; }

        public DateTime FechaComprobante { get; set; }

        public string UnidadMedida { get; set; }


        public int? LiquidacionProcesoPlantaId
        { get; set; }


        public string NumeroLiquidacionProcesoPlanta
        { get; set; }

        public DateTime? FechaInicioLiquidacionProcesoPlanta
        { get; set; }

        public DateTime? FechaFinLiquidacionProcesoPlanta
        { get; set; }

        



        public decimal? Cantidad
        { get; set; }

        public decimal? PrecioUnitario
        { get; set; }

        public decimal? Importe
        { get; set; }

        public decimal? PorcentajeTIRB
        { get; set; }

        public decimal? TotalImporte
        { get; set; }

        public string Observaciones { get; set; }

        public string EstadoId { get; set; }

        public string Estado { get; set; }
        public string CodigoCampania { get; set; }

        public DateTime FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaUltimaActualizacion { get; set; }       

        public string UsuarioUltimaActualizacion { get; set; }


    }
}
