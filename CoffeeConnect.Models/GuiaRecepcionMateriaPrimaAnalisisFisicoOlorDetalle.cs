using System;

namespace CoffeeConnect.Models
{
	public class GuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalle
	{
		#region Properties
		/// <summary>
		/// Gets or sets the GuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalleId value.
		/// </summary>
		public int GuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the GuiaRecepcionMateriaPrimaId value.
		/// </summary>
		public int GuiaRecepcionMateriaPrimaId
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
		public bool Valor
		{ get; set; }

		#endregion
	}
}
