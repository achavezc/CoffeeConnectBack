using System;

namespace CoffeeConnect.Models
{
	public class LoteAnalisisSensorialDefectoDetalle
	{
		#region Properties
		/// <summary>
		/// Gets or sets the LoteAnalisisSensorialDefectoDetalleId value.
		/// </summary>
		public int LoteAnalisisSensorialDefectoDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the LoteId value.
		/// </summary>
		public int LoteId
		{ get; set; }

		/// <summary>
		/// Gets or sets the DefectoDetalleId value.
		/// </summary>
		public string DefectoDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the DefectoDetalleDescripcion value.
		/// </summary>
		public string DefectoDetalleDescripcion
		{ get; set; }

		/// <summary>
		/// Gets or sets the Valor value.
		/// </summary>
		public bool? Valor
		{ get; set; }

		#endregion
	}
}
