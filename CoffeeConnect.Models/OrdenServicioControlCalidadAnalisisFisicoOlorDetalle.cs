using System;

namespace CoffeeConnect.Models
{
	public class OrdenServicioControlCalidadAnalisisFisicoOlorDetalle
	{
		#region Properties
		/// <summary>
		/// Gets or sets the OrdenServicioControlCalidadAnalisisFisicoOlorDetalleId value.
		/// </summary>
		public int OrdenServicioControlCalidadAnalisisFisicoOlorDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the OrdenServicioControlCalidadId value.
		/// </summary>
		public int OrdenServicioControlCalidadId
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
