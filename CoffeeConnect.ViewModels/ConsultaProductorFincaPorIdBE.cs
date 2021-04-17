using System;

namespace CoffeeConnect.DTO
{
    public class ConsultaProductorFincaPorIdBE
    {
        #region Properties
        /// <summary>
        /// Gets or sets the GuiaRecepcionMateriaPrimaId value.
        /// </summary>
        public int ProductorFincaId
        { get; set; }

        public int ProductorId
        { get; set; }

        /// <summary>
        /// Gets or sets the Numero value.
        /// </summary>
        public string Nombre
        { get; set; }

        /// <summary>
        /// Gets or sets the NumeroReferencia value.
        /// </summary>
        public string DepartamentoId
        { get; set; }

        /// <summary>
        /// Gets or sets the ProductoId value.
        /// </summary>
        public string Direccion
        { get; set; }

        /// <summary>
        /// Gets or sets the Producto value.
        /// </summary>
        public string ProvinciaId
        { get; set; }

        /// <summary>
        /// Gets or sets the SubProductoId value.
        /// </summary>
        public string DistritoId
        { get; set; }

        public int ZonaId
        { get; set; }


        /// <summary>
        /// Gets or sets the SubProducto value.
        /// </summary>
        public decimal? Latitud
        { get; set; }

        public decimal? Longuitud
        { get; set; }

        public decimal? LatitudDms
        { get; set; }

        public decimal? LonguitudDms
        { get; set; }

        public decimal? Altitud
        { get; set; }

        public string FuenteEnergiaId
        { get; set; }

        public string FuenteAguaId
        { get; set; }

        public string InternetId
        { get; set; }

        public string SenialTelefonicaId
        { get; set; }

        public string EstablecimientoSaludId
        { get; set; }

        public string CentroEducativoId
        { get; set; }

        public string CentroEducativoNivel
        { get; set; }

        public decimal? TiempoTotalEstablecimientoSalud
        { get; set; }


        public int? CantidadAnimalesMenores
        { get; set; }

        public string MaterialVivienda
        { get; set; }

        public string Suelo
        { get; set; }



        /// <summary>
        /// Gets or sets the EstadoId value.
        /// </summary>
        public string EstadoId
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





        #endregion
    }
}
