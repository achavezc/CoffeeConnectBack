using System;

namespace CoffeeConnect.Models
{
	public class NotaIngresoAlmacenPlantaRegistroTostadoIndicadorDetalleTipo
	{
		#region Properties
		

		/// <summary>
		/// Gets or sets the NotaIngresoAlmacenPlantaId value.
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
