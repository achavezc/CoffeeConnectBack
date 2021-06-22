using System;

namespace CoffeeConnect.Models
{
	public class DiagnosticoDatosCampoTipo
	{
		#region Properties
		/// <summary>
		/// Gets or sets the DiagnosticoDatosCampoId value.
		/// </summary>
		

		/// <summary>
		/// Gets or sets the DiagnosticoId value.
		/// </summary>
		public int DiagnosticoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the NumeroLote value.
		/// </summary>
		public int NumeroLote
		{ get; set; }

		/// <summary>
		/// Gets or sets the Hectarea value.
		/// </summary>
		public decimal? Hectarea
		{ get; set; }

		/// <summary>
		/// Gets or sets the Variedad value.
		/// </summary>
		public string Variedad
		{ get; set; }

		/// <summary>
		/// Gets or sets the Edad value.
		/// </summary>
		public string Edad
		{ get; set; }

		/// <summary>
		/// Gets or sets the CosechaPergaminoAnioActual value.
		/// </summary>
		public string CosechaPergaminoAnioActual
		{ get; set; }

		/// <summary>
		/// Gets or sets the CosechaMeses value.
		/// </summary>
		public string CosechaMeses
		{ get; set; }

		/// <summary>
		/// Gets or sets the CosechaPergaminoAnioAnterior value.
		/// </summary>
		public string CosechaPergaminoAnioAnterior
		{ get; set; }

		#endregion
	}
}
