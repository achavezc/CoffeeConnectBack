using System;

namespace CoffeeConnect.Models
{
	public class GuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalle
	{
		#region Properties
		/// <summary>
		/// Gets or sets the GuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleId value.
		/// </summary>
		public int GuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the GuiaRecepcionMateriaPrimaId value.
		/// </summary>
		public int GuiaRecepcionMateriaPrimaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the ColorDetalleId value.
		/// </summary>
		public string ColorDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the ColorDetalleDescripcion value.
		/// </summary>
		public string ColorDetalleDescripcion
		{ get; set; }

		/// <summary>
		/// Gets or sets the Valor value.
		/// </summary>
		public bool? Valor
		{ get; set; }

		#endregion
	}
}
