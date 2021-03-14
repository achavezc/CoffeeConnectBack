using System;

namespace CoffeeConnect.Models
{
	public class OrdenServicioControlCalidadAnalisisFisicoColorDetalle
	{
		#region Properties
		/// <summary>
		/// Gets or sets the OrdenServicioControlCalidadAnalisisFisicoColorDetalleId value.
		/// </summary>
		public int OrdenServicioControlCalidadAnalisisFisicoColorDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the OrdenServicioControlCalidadId value.
		/// </summary>
		public int OrdenServicioControlCalidadId
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
