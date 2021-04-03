using System;

namespace CoffeeConnect.DTO
{
	public class ConsultaClienteBE
	{
		#region Properties
		/// <summary>
		/// Gets or sets the ProductorId value.
		/// </summary>
		public int ClienteId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Numero value.
		/// </summary>
		public string Numero
		{ get; set; }

		/// <summary>
		/// Gets or sets the TipoDocumentoId value.
		/// </summary>
		public string TipoClienteId
		{ get; set; }

		
		public string Ruc
		{ get; set; }

		/// <summary>
		/// Gets or sets the NombreRazonSocial value.
		/// </summary>
		public string RazonSocial
		{ get; set; }

		/// <summary>
		/// Gets or sets the DepartamentoId value.
		/// </summary>
		public int PaisId
		{ get; set; }

		/// <summary>
		/// Gets or sets the ProvinciaId value.
		/// </summary>
		public string Pais
		{ get; set; }
		

		public string Direccion
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
