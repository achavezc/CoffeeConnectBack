using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
   public  class NotaIngresoAlmacenPlantaAnalisisSensorialAtributoDetalle
    {
		#region Properties
		/// <summary>
		/// Gets or sets the NotaIngresoPlantaAnalisisSensorialAtributoDetalleId value.
		/// </summary>
		public int NotaIngresoAlmacenPlantaAnalisisSensorialAtributoDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the NotaIngresoPlantaId value.
		/// </summary>
		public int NotaIngresoAlmacenPlantaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the AtributoDetalleId value.
		/// </summary>
		public string AtributoDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the AtributoDetalleDescripcion value.
		/// </summary>
		public string AtributoDetalleDescripcion
		{ get; set; }

		/// <summary>
		/// Gets or sets the Valor value.
		/// </summary>
		public decimal? Valor
		{ get; set; }

		#endregion
	}
}
