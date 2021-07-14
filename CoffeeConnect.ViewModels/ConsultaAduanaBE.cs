using System;

namespace CoffeeConnect.DTO
{
    public class ConsultaAduanaBE
    {
        #region Properties
        /// <summary>
        /// Gets or sets the ProductorId value.
        /// </summary>
        public int AduanaId
        { get; set; }

        public int ContratoId
        { get; set; }

        public int ClienteId
        { get; set; }

        /// <summary>
        /// Gets or sets the Numero value.
        /// </summary>
        public string Numero
        { get; set; }

        public string NumeroContrato
        { get; set; }

        public string RazonSocialCliente
        { get; set; }
        


        /// <summary>
        /// Gets or sets the TipoDocumentoId value.
        /// </summary>
        public int  EmpresaExportadoraId
        { get; set; }


        public string RucEmpresaExportadora
        { get; set; }

        /// <summary>
        /// Gets or sets the NombreRazonSocial value.
        /// </summary>
        public string RazonSocialEmpresaExportadora
        { get; set; }

        public string RucEmpresaProductora
        { get; set; }

        public string RazonSocialEmpresaProductora
        { get; set; }


        public DateTime? FechaEmbarque
        { get; set; }


      
        /// <summary>
        /// Gets or sets the Activo value.
        /// </summary>
        public string EstadoId
        { get; set; }

        public string Estado
        { get; set; }


        #endregion
    }
}
