using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
   public  class ControlCalidadPlantaAnalisisSensorialDefectoDetalle
    {
		#region Properties
		/// <summary>
		/// Gets or sets the NotaIngresoPlantaAnalisisSensorialDefectoDetalleId value.
		/// </summary>
		public int ControlCalidadPlantaAnalisisSensorialDefectoDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the NotaIngresoPlantaId value.
		/// </summary>
		public int ControlCalidadPlantaId
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
