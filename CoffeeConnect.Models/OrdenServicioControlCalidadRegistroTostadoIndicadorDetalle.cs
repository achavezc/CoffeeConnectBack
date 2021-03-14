using System;

namespace CoffeeConnect.Models
{
	public class OrdenServicioControlCalidadRegistroTostadoIndicadorDetalle
	{
		#region Properties
		/// <summary>
		/// Gets or sets the OrdenServicioControlCalidadRegistroTostadoIndicadorDetalleId value.
		/// </summary>
		public int OrdenServicioControlCalidadRegistroTostadoIndicadorDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the OrdenServicioControlCalidadId value.
		/// </summary>
		public int OrdenServicioControlCalidadId
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
