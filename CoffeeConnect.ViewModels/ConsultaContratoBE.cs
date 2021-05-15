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
        public string Cliente
        { get; set; }

        public DateTime FechaEmbarque
        { get; set; }

        public string ProductoId
        { get; set; }

        public string SubProductoId
        { get; set; }

        public string Producto
        { get; set; }

        public string TipoProduccionId
        { get; set; }

        public string TipoProduccion
        { get; set; }


        public string CalidadId
        { get; set; }

        public string Calidad
        { get; set; }

        /// <summary>
        /// Gets or sets the Activo value.
        /// </summary>
        /// 
        public decimal TotalSacos
        { get; set; }

        public decimal Peso
        { get; set; }




        public string UnidadMedida
        { get; set; }


        public string EstadoId
        { get; set; }

        public string Estado
        { get; set; }
        public string TipoCertificacionId { get; set; }
        public decimal PesoPorSaco { get; set; }


        public string Grado { get; set; }
        #endregion
    }
}
