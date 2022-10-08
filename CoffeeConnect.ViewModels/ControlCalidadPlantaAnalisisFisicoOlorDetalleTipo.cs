using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
   public  class ControlCalidadPlantaAnalisisFisicoOlorDetalleTipo
    {
		#region Properties

		/// <summary>
		/// Gets or sets the NotaIngresoPlantaId value.
		/// </summary>
		public int ControlCalidadPlantaId
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
