using System;

namespace CoffeeConnect.Models
{
	public class GuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalle
	{
		#region Properties
		/// <summary>
		/// Gets or sets the GuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalleId value.
		/// </summary>
		public int GuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the GuiaRecepcionMateriaPrimaId value.
		/// </summary>
		public int GuiaRecepcionMateriaPrimaId
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
		public decimal Valor
		{ get; set; }

		#endregion
	}
}
