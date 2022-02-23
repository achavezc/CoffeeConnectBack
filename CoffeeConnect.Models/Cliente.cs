using System;

namespace CoffeeConnect.Models
{
    public class Cliente
    {
        #region Properties
        /// <summary>
        /// Gets or sets the ClienteId value.
        /// </summary>
        public int ClienteId
        { get; set; }

        /// <summary>
        /// Gets or sets the Numero value.
        /// </summary>
        public string Numero
        { get; set; }

        /// <summary>
        /// Gets or sets the TipoClienteId value.
        /// </summary>
        public string TipoClienteId
        { get; set; }

        /// <summary>
        /// Gets or sets the Ruc value.
        /// </summary>
        public string Ruc
        { get; set; }

        public string CodigoInterno
        { get; set; }
        


        public string FloId
        { get; set; }

        public int EmpresaId { get; set; }


        /// <summary>
        /// Gets or sets the RazonSocial value.
        /// </summary>
        public string RazonSocial
        { get; set; }

        /// <summary>
        /// Gets or sets the Direccion value.
        /// </summary>
        public string Direccion
        { get; set; }

        /// <summary>
        /// Gets or sets the PaisId value.
        /// </summary>
        public string PaisId
        { get; set; }

        /// <summary>
        /// Gets or sets the DepartamentoId value.
        /// </summary>
        public string DepartamentoId
        { get; set; }

        /// <summary>
        /// Gets or sets the ProvinciaId value.
        /// </summary>
        public string ProvinciaId
        { get; set; }

        /// <summary>
        /// Gets or sets the DistritoId value.
        /// </summary>
        public string DistritoId
        { get; set; }

        /// <summary>
        /// Gets or sets the NumeroTelefono value.
        /// </summary>
        public string NumeroTelefono
        { get; set; }

        /// <summary>
        /// Gets or sets the CorreoElectronico value.
        /// </summary>
        public string CorreoElectronico
        { get; set; }

        /// <summary>
        /// Gets or sets the GerenteGeneral value.
        /// </summary>
        public string GerenteGeneral
        { get; set; }

        /// <summary>
        /// Gets or sets the GerenteGeneralNumero value.
        /// </summary>
        public string GerenteGeneralNumero
        { get; set; }

        /// <summary>
        /// Gets or sets the Presidente value.
        /// </summary>
        public string Presidente
        { get; set; }

        /// <summary>
        /// Gets or sets the PresidenteNumero value.
        /// </summary>
        public string PresidenteNumero
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
        /// Gets or sets the EstadoId value.
        /// </summary>
        public string EstadoId
        { get; set; }

        /// <summary>
        /// Gets or sets the Activo value.
        /// </summary>
        public bool Activo
        { get; set; }

        #endregion
    }
}
