using System;

namespace CoffeeConnect.Models
{
	public class AduanaCertificacionTipo
	{
		#region Properties


		public int AduanaId
		{ get; set; }


		/// <summary>
		/// Gets or sets the EmpresaProveedoraAcreedoraId value.
		/// </summary>
		public int EmpresaProveedoraAcreedoraId
		{ get; set; }

		/// <summary>
		/// Gets or sets the RazonSocial value.
		/// </summary>
		public string TipoCertificacionId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Ruc value.
		/// </summary>
		public string CodigoCertificacion
		{ get; set; }

		public string TipoId
		{ get; set; }

		#endregion
	}
}
