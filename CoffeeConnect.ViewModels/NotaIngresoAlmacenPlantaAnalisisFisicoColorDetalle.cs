using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
   public  class NotaIngresoAlmacenPlantaAnalisisFisicoColorDetalle
    {
		#region Properties
		/// <summary>
		/// Gets or sets the NotaIngresoPlantaAnalisisFisicoColorDetalleId value.
		/// </summary>
		public int NotaIngresoAlmacenPlantaAnalisisFisicoColorDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the NotaIngresoPlantaId value.
		/// </summary>
		public int NotaIngresoAlmacenPlantaId
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
