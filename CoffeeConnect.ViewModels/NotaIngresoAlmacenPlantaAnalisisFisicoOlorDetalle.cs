using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
  public   class NotaIngresoAlmacenPlantaAnalisisFisicoOlorDetalle
    {
		#region Properties
		/// <summary>
		/// Gets or sets the NotaIngresoPlantaAnalisisFisicoOlorDetalleId value.
		/// </summary>
		public int NotaIngresoAlmacenPlantaAnalisisFisicoOlorDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the NotaIngresoPlantaId value.
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
