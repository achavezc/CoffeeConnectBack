using System;

namespace CoffeeConnect.DTO
{
	public class ConsultaSocioBE
	{
		#region Properties
		/// <summary>
		/// Gets or sets the ProductorId value.
		/// </summary>
		public int SocioId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Numero value.
		/// </summary>
		public string NumeroProductor
		{ get; set; }

		public string Codigo
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
		/// Gets or sets the ZonaId value.
		/// </summary>
		public int ZonaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Departamento value.
		/// </summary>
		public string Departamento
		{ get; set; }

		/// <summary>
		/// Gets or sets the Provincia value.
		/// </summary>
		public string Provincia
		{ get; set; }

		/// <summary>
		/// Gets or sets the Distrito value.
		/// </summary>
		public string Distrito
		{ get; set; }

		/// <summary>
		/// Gets or sets the Zona value.
		/// </summary>
		public string Zona
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaRegistro value.
		/// </summary>
		public DateTime FechaRegistro
		{ get; set; }

		/// <summary>
		/// Gets or sets the Activo value.
		/// </summary>
		public bool Activo
		{ get; set; }

		public string Estado
		{ get; set; }

		#endregion
	}
}
