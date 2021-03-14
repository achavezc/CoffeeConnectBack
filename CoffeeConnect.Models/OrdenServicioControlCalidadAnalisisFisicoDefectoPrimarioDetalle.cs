using System;

namespace CoffeeConnect.Models
{
	public class OrdenServicioControlCalidadAnalisisFisicoDefectoPrimarioDetalle
	{
		#region Properties
		/// <summary>
		/// Gets or sets the OrdenServicioControlCalidadAnalisisFisicoDefectoPrimarioDetalleId value.
		/// </summary>
		public int OrdenServicioControlCalidadAnalisisFisicoDefectoPrimarioDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the OrdenServicioControlCalidadId value.
		/// </summary>
		public int OrdenServicioControlCalidadId
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
