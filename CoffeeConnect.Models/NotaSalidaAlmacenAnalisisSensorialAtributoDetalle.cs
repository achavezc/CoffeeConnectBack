using System;

namespace CoffeeConnect.Models
{
	public class NotaSalidaAlmacenAnalisisSensorialAtributoDetalle
	{
		#region Properties
		/// <summary>
		/// Gets or sets the NotaSalidaAlmacenAnalisisSensorialAtributoDetalleId value.
		/// </summary>
		public int NotaSalidaAlmacenAnalisisSensorialAtributoDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the NotaSalidaAlmacenId value.
		/// </summary>
		public int NotaSalidaAlmacenId
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
