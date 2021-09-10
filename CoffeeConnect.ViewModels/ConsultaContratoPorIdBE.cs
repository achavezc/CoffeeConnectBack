
using System;

using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class ConsultaContratoPorIdBE
    {
        #region Properties

        public int ContratoId
        { get; set; }

        /// <summary>
        /// Gets or sets the Numero value.
        /// </summary>
        public string Numero
        { get; set; }

        /// <summary>
        /// Gets or sets the ClienteId value.
        /// </summary>
        public int ClienteId
        { get; set; }

        public string PeriodosCosecha
        { get; set; }


        /// <summary>
        /// Gets or sets the FloId value.
        /// </summary>
        public string FloId
        { get; set; }

      
        


        /// <summary>
        /// Gets or sets the CondicionEmbarqueId value.
        /// </summary>
        public string CondicionEmbarqueId
        { get; set; }

        /// <summary>
        /// Gets or sets the FechaEmbarque value.
        /// </summary>
        public DateTime? FechaEmbarque
        { get; set; }

        /// <summary>
        /// Gets or sets the FechaContrato value.
        /// </summary>
        public DateTime FechaContrato
        { get; set; }

        /// <summary>
        /// Gets or sets the FechaFacturacion value.
        /// </summary>
        public DateTime? FechaFacturacion
        { get; set; }

        /// <summary>
        /// Gets or sets the PaisDestinoId value.
        /// </summary>
        public string PaisDestinoId
        { get; set; }

        /// <summary>
        /// Gets or sets the DepartamentoDestinoId value.
        /// </summary>
        public string DepartamentoDestinoId
        { get; set; }

        /// <summary>
        /// Gets or sets the ProductoId value.
        /// </summary>
        public string ProductoId
        { get; set; }

        public string SubProductoId
        { get; set; }

        /// <summary>
        /// Gets or sets the TipoProduccionId value.
        /// </summary>
        public string TipoProduccionId
        { get; set; }

        /// <summary>
        /// Gets or sets the MonedadId value.
        /// </summary>
        public string MonedadId
        { get; set; }

        /// <summary>
        /// Gets or sets the Monto value.
        /// </summary>
        public decimal Monto
        { get; set; }

        /// <summary>
        /// Gets or sets the UnidadMedicionId value.
        /// </summary>
        public string UnidadMedicionId
        { get; set; }

        /// <summary>
        /// Gets or sets the UnidadMedidaId value.
        /// </summary>
        public int EmpresaId
        { get; set; }

        /// <summary>
        /// Gets or sets the EntidadCertificadoraId value.
        /// </summary>
        public string EntidadCertificadoraId
        { get; set; }

        /// <summary>
        /// Gets or sets the TipoCertificacionId value.
        /// </summary>
        public string TipoCertificacionId
        { get; set; }

        public string TipoContratoId
        { get; set; }


        /// <summary>
        /// Gets or sets the CalidadId value.
        /// </summary>
        public string CalidadId
        { get; set; }

        public string CalculoContratoId
        { get; set; }

        /// <summary>
        /// Gets or sets the GradoId value.
        /// </summary>
        public string GradoId
        { get; set; }

        /// <summary>
        /// Gets or sets the Cantidad value.
        /// </summary>
        public decimal TotalSacos
        { get; set; }

        /// <summary>
        /// Gets or sets the PesoPorSaco value.
        /// </summary>
        public decimal PesoPorSaco
        { get; set; }

        public decimal PesoKilos
        { get; set; }

        public decimal? PesoEnContrato
        { get; set; }



        /// <summary>
        /// Gets or sets the PreparacionCantidadDefectos value.
        /// </summary>
        public decimal PreparacionCantidadDefectos
        { get; set; }

        public string LaboratorioId
        { get; set; }

        /// <summary>
        /// Gets or sets the MuestraEnviadaCliente value.
        /// </summary>
        public string NumeroSeguimientoMuestra
        { get; set; }

        /// <summary>
        /// Gets or sets the MuestraEnviadaAnalisisGlifosato value.
        /// </summary>
        public string EstadoMuestraId { get; set; }
        public DateTime? FechaEnvioMuestra { get; set; }
        public DateTime? FechaRecepcionMuestra { get; set; }
        public string ObservacionMuestra { get; set; }
        public string NavieraId { get; set; }

        /// <summary>
        /// Gets or sets the NombreArchivo value.
        /// </summary>
        public string NombreArchivo { get; set; }
        public string DescripcionArchivo { get; set; }

        /// <summary>
        /// Gets or sets the PathArchivo value.
        /// </summary>
        public string PathArchivo
        { get; set; }

        /// <summary>
        /// Gets or sets the FechaRegistro value.
        /// </summary>
        public DateTime FechaRegistro
        { get; set; }

        /// <summary>
        /// Gets or sets the UsuarioRegistro value.
        /// </summary>
        public string UsuarioRegistro
        { get; set; }

        /// <summary>
        /// Gets or sets the FechaUltimaActualizacion value.
        /// </summary>
        public DateTime FechaUltimaActualizacion
        { get; set; }

        /// <summary>
        /// Gets or sets the UsuarioUltimaActualizacion value.
        /// </summary>
        public string UsuarioUltimaActualizacion
        { get; set; }

        /// <summary>
        /// Gets or sets the EstadoId value.
        /// </summary>
        public string EstadoId { get; set; }

        public string EstadoContrato { get; set; }

        


        public string NumeroCliente { get; set; }
        public string Cliente { get; set; }

        public string RazonSocial
        { get; set; }

        public string Ruc
        { get; set; }

        public string Logo
        { get; set; }

        public string Direccion
        { get; set; }
        public string EmpaqueId { get; set; }
        public string TipoId { get; set; }

        public string FacturarEnId { get; set; }
        public DateTime? FechaFijacionContrato { get; set; }
        public decimal? KilosNetosQQ { get; set; }
        public string EstadoFijacionId { get; set; }
        public decimal? KilosNetosLB { get; set; }
        public decimal? PrecioNivelFijacion { get; set; }
        public decimal? Diferencial { get; set; }
        public decimal? PUTotalA { get; set; }
        public decimal? PUTotalB { get; set; }
        public decimal? PUTotalC { get; set; }
        public decimal? NotaCreditoComision { get; set; }
        public decimal? GastosExpCostos { get; set; }
        public decimal? TotalFacturar1 { get; set; }
        public decimal? TotalFacturar2 { get; set; }
        public decimal? TotalFacturar3 { get; set; }

        public decimal? KGPergaminoAsignacion
        { get; set; }


        public decimal? PorcentajeRendimientoAsignacion
        { get; set; }


        public decimal? TotalKGPergaminoAsignacion
        { get; set; }

        public decimal? SaldoPendienteKGPergaminoAsignacion
        { get; set; }

        public string EstadoPagoFacturaId { get; set; }        

        public DateTime? FechaPagoFactura { get; set; }
       


        #endregion
    }
}
