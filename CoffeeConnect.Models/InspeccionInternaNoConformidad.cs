using System;

namespace CoffeeConnect.Models
{
	public class InspeccionInternaNoConformidad
	{
		#region Properties
		/// <summary>
		/// Gets or sets the InspeccionInternaNoConformidadId value.
		/// </summary>
		public int InspeccionInternaNoConformidadId
		{ get; set; }

		/// <summary>
		/// Gets or sets the InspeccionInternaId value.
		/// </summary>
		public int InspeccionInternaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the NumeroItem value.
		/// </summary>
		public string NumeroItem
		{ get; set; }

		/// <summary>
		/// Gets or sets the ManifiestoProductor value.
		/// </summary>
		public string ManifiestoProductor
		{ get; set; }

		#endregion
	}
}
