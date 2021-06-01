using System;

namespace CoffeeConnect.Models
{
	public class InspeccionInternaNorma
	{
		#region Properties
		/// <summary>
		/// Gets or sets the InspeccionInternaNormasId value.
		/// </summary>
		public int InspeccionInternaNormasId
		{ get; set; }

		/// <summary>
		/// Gets or sets the InspeccionInternaId value.
		/// </summary>
		public int InspeccionInternaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the ClaseTipoInspeccionInternaNormasId value.
		/// </summary>
		public string ClaseTipoInspeccionInternaNormasId
		{ get; set; }

		/// <summary>
		/// Gets or sets the TipoInspeccionInternaNormasId value.
		/// </summary>
		public string TipoInspeccionInternaNormasId
		{ get; set; }

		/// <summary>
		/// Gets or sets the CriticoPara value.
		/// </summary>
		public string CriticoPara
		{ get; set; }

		/// <summary>
		/// Gets or sets the NoAplica value.
		/// </summary>
		public bool NoAplica
		{ get; set; }

		/// <summary>
		/// Gets or sets the Si value.
		/// </summary>
		public bool Si
		{ get; set; }

		/// <summary>
		/// Gets or sets the No value.
		/// </summary>
		public bool No
		{ get; set; }

		/// <summary>
		/// Gets or sets the Observaciones value.
		/// </summary>
		public string Observaciones
		{ get; set; }

		#endregion
	}
}
