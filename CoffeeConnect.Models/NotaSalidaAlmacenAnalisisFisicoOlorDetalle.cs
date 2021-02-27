using System;

namespace CoffeeConnect.Models
{
	public class NotaSalidaAlmacenAnalisisFisicoOlorDetalle
	{
		#region Properties
		/// <summary>
		/// Gets or sets the NotaSalidaAlmacenAnalisisFisicoOlorDetalleId value.
		/// </summary>
		public int NotaSalidaAlmacenAnalisisFisicoOlorDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the NotaSalidaAlmacenId value.
		/// </summary>
		public int NotaSalidaAlmacenId
		{ get; set; }

		/// <summary>
		/// Gets or sets the OlorDetalleId value.
		/// </summary>
		public string OlorDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the OlorDetalleDescripcion value.
		/// </summary>
		public string OlorDetalleDescripcion
		{ get; set; }

		/// <summary>
		/// Gets or sets the Valor value.
		/// </summary>
		public bool? Valor
		{ get; set; }

		#endregion
	}
}
