using System;

namespace CoffeeConnect.Models
{
	public class DiagnosticoInfraestructura
	{
		#region Properties
		/// <summary>
		/// Gets or sets the DiagnosticoInfraestructuraId value.
		/// </summary>
		public int DiagnosticoInfraestructuraId
		{ get; set; }

		/// <summary>
		/// Gets or sets the DiagnosticoId value.
		/// </summary>
		public int DiagnosticoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the ClaseEstadoInfraestructuraId value.
		/// </summary>
		public string ClaseEstadoInfraestructuraId
		{ get; set; }

		/// <summary>
		/// Gets or sets the EstadoInfraestructuraId value.
		/// </summary>
		public string EstadoInfraestructuraId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Observaciones value.
		/// </summary>
		public string Observaciones
		{ get; set; }

		#endregion
	}
}
