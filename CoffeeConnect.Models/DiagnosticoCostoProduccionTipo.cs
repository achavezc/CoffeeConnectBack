using System;

namespace CoffeeConnect.Models
{
	public class DiagnosticoCostoProduccionTipo
	{
		#region Properties
		/// <summary>
		/// Gets or sets the DiagnosticoCostoProduccionId value.
		/// </summary>
		
		/// <summary>
		/// Gets or sets the DiagnosticoId value.
		/// </summary>
		public int DiagnosticoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the ActividadId value.
		/// </summary>
		public string ActividadId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Hectarea value.
		/// </summary>
		public decimal? Hectarea
		{ get; set; }

		/// <summary>
		/// Gets or sets the CostoHectarea value.
		/// </summary>
		public decimal? CostoHectarea
		{ get; set; }

		/// <summary>
		/// Gets or sets the CostoTotal value.
		/// </summary>
		public decimal? CostoTotal
		{ get; set; }

		/// <summary>
		/// Gets or sets the Observaciones value.
		/// </summary>
		public string Observaciones
		{ get; set; }

		#endregion
	}
}
