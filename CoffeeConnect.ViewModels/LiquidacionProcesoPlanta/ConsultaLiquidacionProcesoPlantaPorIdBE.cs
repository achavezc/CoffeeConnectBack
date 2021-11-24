using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
    public class ConsultaLiquidacionProcesoPlantaPorIdBE
    {
        #region Properties
        /// <summary>
        /// Gets or sets the LiquidacionProcesoPlantaId value.
        /// </summary>
        public int LiquidacionProcesoPlantaId { get; set; }

        /// <summary>
        /// Gets or sets the OrdenProcesoPlantaId value.
        /// </summary>
        public int OrdenProcesoPlantaId { get; set; }

        public decimal? NumeroDefectos { get; set; }

        /// <summary>
        /// Gets or sets the Numero value.
        /// </summary>
        public string Numero
        { get; set; }

        /// <summary>
        /// Gets or sets the EmpresaId value.
        /// </summary>
        public int EmpresaId
        { get; set; }

        /// <summary>
        /// Gets or sets the Observacion value.
        /// </summary>
        public string Observacion
        { get; set; }

        /// <summary>
        /// Gets or sets the EnvasesProductos value.
        /// </summary>
        public string EnvasesProductos
        { get; set; }

        /// <summary>
        /// Gets or sets the TrabajosRealizados value.
        /// </summary>
        public string TrabajosRealizados
        { get; set; }

        /// <summary>
        /// Gets or sets the EstadoId value.
        /// </summary>
        public string EstadoId
        { get; set; }

        public string Estado
        { get; set; }

        public string TipoProcesoId
        { get; set; }

        /// <summary>
        /// Gets or sets the TipoProceso value.
        /// </summary>
        public string TipoProceso
        { get; set; }

        /// <summary>
        /// Gets or sets the TipoProduccionId value.
        /// </summary>
        public string TipoProduccionId
        { get; set; }

        /// <summary>
        /// Gets or sets the TipoProduccion value.
        /// </summary>
        public string TipoProduccion
        { get; set; }

        public string TipoCertificacionId
        { get; set; }

        public string TipoCertificacion
        { get; set; }

        /// <summary>
        /// Gets or sets the EntidadCertificadoraId value.
        /// </summary>
        public string EntidadCertificadoraId
        { get; set; }

        /// <summary>
        /// Gets or sets the EntidadCertificadora value.
        /// </summary>
        public string EntidadCertificadora
        { get; set; }


        /// <summary>
        /// Gets or sets the ProductoId value.
        /// </summary>
        public string ProductoId
        { get; set; }

        /// <summary>
        /// Gets or sets the Producto value.
        /// </summary>
        public string Producto
        { get; set; }

        /// <summary>
        /// Gets or sets the SubProductoId value.
        /// </summary>
        public string SubProductoId
        { get; set; }

        /// <summary>
        /// Gets or sets the SubProducto value.
        /// </summary>
        public string SubProducto
        { get; set; }

        /// <summary>
        /// Gets or sets the FechaRegistro value.
        /// </summary>
        public DateTime FechaRegistro
        { get; set; }
        public string FechaRegistroString { get; set; }

        public string FechaInicioProcesoString { get; set; }

        public string FechaFinProcesoString { get; set; }
        /// <summary>
        /// Gets or sets the UsuarioRegistro value.
        /// </summary>
        public string UsuarioRegistro
        { get; set; }

        /// <summary>
        /// Gets or sets the RazonSocial value.
        /// </summary>
        public string RazonSocial
        { get; set; }

        /// <summary>
        /// Gets or sets the Ruc value.
        /// </summary>
        public string Ruc { get; set; }

        /// <summary>
        /// Gets or sets the Logo value.
        /// </summary>
        public string Logo { get; set; }

        public string RucOrganizacion { get; set; }

        public string RazonSocialOrganizacion { get; set; }

        public string NumeroOrdenProcesoPlanta { get; set; }

        public string ProductoTerminado { get; set; }

        public string SubProductoTerminado { get; set; }

        public string Calidad { get; set; }

        public string Preparacion { get; set; }

        public IEnumerable<ConsultaLiquidacionProcesoPlantaDetalleBE> Detalle { get; set; }

        public IEnumerable<ConsultaLiquidacionProcesoPlantaResultadoBE> Resultado { get; set; }

        #endregion
    }
}
