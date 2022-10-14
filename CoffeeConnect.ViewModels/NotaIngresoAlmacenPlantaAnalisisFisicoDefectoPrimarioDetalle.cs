using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
   public  class NotaIngresoAlmacenPlantaAnalisisFisicoDefectoPrimarioDetalle
    {
		#region Properties
		/// <summary>
		/// Gets or sets the NotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetalleId value.
		/// </summary>
		public int NotaIngresoAlmacenPlantaAnalisisFisicoDefectoPrimarioDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the NotaIngresoPlantaId value.
		/// </summary>
		public int NotaIngresoAlmacenPlantaId
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
		/// Gets or sets the DefectoDetalleEquivalente value.
		/// </summary>
		public string DefectoDetalleEquivalente
		{ get; set; }

		/// <summary>
		/// Gets or sets the Valor value.
		/// </summary>
		public decimal? Valor
		{ get; set; }

		#endregion
	}
}
