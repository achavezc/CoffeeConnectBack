using System;

namespace CoffeeConnect.DTO
{
    public class ConsultaNotaIngresoAlmacenBE
    {
        #region Properties
        /// <summary>
        /// Gets or sets the GuiaRecepcionMateriaPrimaId value.
        /// </summary>
        public int GuiaRecepcionMateriaPrimaId
        { get; set; }

        /// <summary>
        /// Gets or sets the Numero value.
        /// </summary>
        public string Numero
        { get; set; }

        /// <summary>
        /// Gets or sets the TipoProvedorId value.
        /// </summary>
        public string TipoProvedorId
        { get; set; }

        /// <summary>
        /// Gets or sets the TipoProvedor value.
        /// </summary>
        public string TipoProvedor
        { get; set; }

        /// <summary>
        /// Gets or sets the ProveedorId value.
        /// </summary>
        public int ProveedorId
        { get; set; }

        /// <summary>
        /// Gets or sets the NombreRazonSocial value.
        /// </summary>
        public string NombreRazonSocial
        { get; set; }

        /// <summary>
        /// Gets or sets the CodigoSocio value.
        /// </summary>
        public string CodigoSocio
        { get; set; }

        /// <summary>
        /// Gets or sets the TipoDocumentoId value.
        /// </summary>
        public string TipoDocumentoId
        { get; set; }

        /// <summary>
        /// Gets or sets the TipoDocumento value.
        /// </summary>
        public string TipoDocumento
        { get; set; }

        /// <summary>
        /// Gets or sets the NumeroDocumento value.
        /// </summary>
        public string NumeroDocumento
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
        /// Gets or sets the AlmacenId value.
        /// </summary>
        public int? AlmacenId
        { get; set; }

        /// <summary>
        /// Gets or sets the Almacen value.
        /// </summary>
        public string Almacen
        { get; set; }

        /// <summary>
        /// Gets or sets the EstadoId value.
        /// </summary>
        public string EstadoId
        { get; set; }

        /// <summary>
        /// Gets or sets the Estado value.
        /// </summary>
        public string Estado
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
        public DateTime? FechaUltimaActualizacion
        { get; set; }

        /// <summary>
        /// Gets or sets the UsuarioUltimaActualizacion value.
        /// </summary>
        public string UsuarioUltimaActualizacion
        { get; set; }

        /// <summary>
        /// Gets or sets the Activo value.
        /// </summary>
        public bool Activo
        { get; set; }
        public int NotaIngresoAlmacenId { get; set; }

        public decimal? RendimientoPorcentaje
        { get; set; }

        public decimal? TotalAnalisisSensorial
        { get; set; }

        public string DefectosAnalisisSensorial
        { get; set; }

        public string TipoCertificacionId
        { get; set; }

        public string Certificacion
        { get; set; }

        public string UnidadMedida
        { get; set; }

        public decimal? CantidadPesado
        { get; set; }

        #endregion
    }


}
