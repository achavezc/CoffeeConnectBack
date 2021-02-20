using System;

namespace CoffeeConnect.Models
{
	public class NotaSalidaAlmacenAnalisisFisicoColorDetalle
	{
		#region Properties
		/// <summary>
		/// Gets or sets the NotaSalidaAlmacenAnalisisFisicoColorDetalleId value.
		/// </summary>
		public int NotaSalidaAlmacenAnalisisFisicoColorDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the NotaSalidaAlmacenId value.
		/// </summary>
		public int NotaSalidaAlmacenId
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
		public bool Valor
		{ get; set; }

		#endregion
	}
}
