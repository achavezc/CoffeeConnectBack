using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class NotaIngresoAlmacenPlantaRegistroTostadoIndicadorDetalle
    {
		#region Properties
		/// <summary>
		/// Gets or sets the NotaIngresoPlantaRegistroTostadoIndicadorDetalleId value.
		/// </summary>
		public int NotaIngresoAlmacenPlantaRegistroTostadoIndicadorDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the NotaIngresoPlantaId value.
		/// </summary>
		public int NotaIngresoAlmacenPlantaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the IndicadorDetalleId value.
		/// </summary>
		public string IndicadorDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the IndicadorDetalleDescripcion value.
		/// </summary>
		public string IndicadorDetalleDescripcion
		{ get; set; }

		/// <summary>
		/// Gets or sets the Valor value.
		/// </summary>
		public decimal? Valor
		{ get; set; }

		#endregion
	}
}
