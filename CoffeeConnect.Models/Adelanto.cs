using System;

namespace CoffeeConnect.Models
{
	public class Adelanto
	{
		#region Properties
		/// <summary>
		/// Gets or sets the AdelantoId value.
		/// </summary>
		public int AdelantoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the SocioId value.
		/// </summary>
		public int SocioId
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaId value.
		/// </summary>
		public int EmpresaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Numero value.
		/// </summary>
		public string Numero
		{ get; set; }

		/// <summary>
		/// Gets or sets the TipoDocumentoId value.
		/// </summary>
		public string TipoDocumentoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the NumeroDocumento value.
		/// </summary>
		public string NumeroDocumento
		{ get; set; }

		/// <summary>
		/// Gets or sets the NombreRazonSocial value.
		/// </summary>
		public string NombreRazonSocial
		{ get; set; }

		/// <summary>
		/// Gets or sets the MonedaId value.
		/// </summary>
		public string MonedaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Monto value.
		/// </summary>
		public decimal Monto
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaPago value.
		/// </summary>
		public DateTime FechaPago
		{ get; set; }

		/// <summary>
		/// Gets or sets the Motivo value.
		/// </summary>
		public string Motivo
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaEntregaProducto value.
		/// </summary>
		public DateTime FechaEntregaProducto
		{ get; set; }

		/// <summary>
		/// Gets or sets the NotaCompraId value.
		/// </summary>
		public int? NotaCompraId
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

		/// <summary>
		/// Gets or sets the Activo value.
		/// </summary>
		public bool Activo
		{ get; set; }

		#endregion
	}
}
