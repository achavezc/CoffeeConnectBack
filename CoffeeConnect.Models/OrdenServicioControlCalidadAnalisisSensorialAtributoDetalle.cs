using System;

namespace CoffeeConnect.Models
{
	public class OrdenServicioControlCalidadAnalisisSensorialAtributoDetalle
	{
		#region Properties
		/// <summary>
		/// Gets or sets the OrdenServicioControlCalidadAnalisisSensorialAtributoDetalleId value.
		/// </summary>
		public int OrdenServicioControlCalidadAnalisisSensorialAtributoDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the OrdenServicioControlCalidadId value.
		/// </summary>
		public int OrdenServicioControlCalidadId
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
