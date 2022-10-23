using System;

namespace CoffeeConnect.Models
{
	public class NotaIngresoAlmacenPlantaAnalisisFisicoOlorDetalleTipo
	{
		#region Properties
		
		/// <summary>
		/// Gets or sets the NotaIngresoAlmacenPlantaId value.
		/// </summary>
		public int NotaIngresoAlmacenPlantaId
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
