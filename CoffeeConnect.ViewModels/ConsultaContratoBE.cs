using System;

namespace CoffeeConnect.DTO
{
    public class ConsultaContratoBE
    {
        #region Properties
        /// <summary>
        /// Gets or sets the ProductorId value.
        /// </summary>
        public int ContratoId
        { get; set; }

        /// <summary>
        /// Gets or sets the Numero value.
        /// </summary>
        public string Numero
        { get; set; }

        public int ClienteId
        { get; set; }

        /// <summary>
        /// Gets or sets the TipoDocumentoId value.
        /// </summary>
        public string NumeroCliente
        { get; set; }

        /// <summary>
        /// Gets or sets the NombreRazonSocial value.
        /// </summary>
        public string Cliente { get; set; }

        public decimal? CantidadContenedores
        { get; set; }

        public DateTime FechaEmbarque { get; set; }
        public string ProductoId { get; set; }
        public string SubProductoId { get; set; }
        public string Producto { get; set; }
        public string TipoProduccionId { get; set; }
        public string TipoProduccion { get; set; }
        public string CalidadId { get; set; }
        public string Calidad { get; set; }

        /// <summary>
        /// Gets or sets the Activo value.
        /// </summary>
        /// 
        public decimal TotalSacos { get; set; }
        public decimal PesoKilos { get; set; }
     
        public string EstadoId { get; set; }
        public string Estado { get; set; }
        public string TipoCertificacionId { get; set; }
        public string TipoCertificacion { get; set; }
        public decimal PesoPorSaco { get; set; }
        public string Grado { get; set; }

        public string FloId { get; set; }
        public string Empaque { get; set; }
        public string TipoEmpaque { get; set; }
        public string SubProducto { get; set; }
        public decimal PreparacionCantidadDefectos { get; set; }

        public DateTime FechaContrato { get; set; }

        public int EmpresaId { get; set; }
        public string TipoContratoId { get; set; }
        public string TipoContrato { get; set; }

        public string EstadoPagoFacturaId { get; set; }
        public string EstadoPagoFactura { get; set; }

        public DateTime? FechaPagoFactura { get; set; }

        public string CondicionEmbarqueId { get; set; }

        public string CondicionEmbarque { get; set; }

        public decimal? KilosNetosLB { get; set; }

        public decimal? KilosNetosQQ { get; set; }


        public DateTime? FechaFijacionContrato { get; set; }

        public string EstadoFijacionId { get; set; }

        public string EstadoFijacion { get; set; }

        public decimal? PrecioNivelFijacion { get; set; }

        public decimal? Diferencial { get; set; }

        public decimal? PUTotalA { get; set; }

        public decimal? TotalFacturar1 { get; set; }

        public decimal? NotaCreditoComision { get; set; }

        public decimal? PUTotalB { get; set; }

        public decimal? TotalFacturar2 { get; set; }


        public decimal? GastosExpCostos { get; set; }

        public decimal? TotalFacturar3 { get; set; }



        #endregion
    }
}
