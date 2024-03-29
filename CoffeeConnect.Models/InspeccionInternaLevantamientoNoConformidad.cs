using System;

namespace CoffeeConnect.Models
{
	public class InspeccionInternaLevantamientoNoConformidad
	{
		#region Properties
		/// <summary>
		/// Gets or sets the InspeccionInternaLevantamientoNoConformidadId value.
		/// </summary>
		public int InspeccionInternaLevantamientoNoConformidadId
		{ get; set; }

		/// <summary>
		/// Gets or sets the InspeccionInternaId value.
		/// </summary>
		public int InspeccionInternaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the PuntoControl value.
		/// </summary>
		public string PuntoControl
		{ get; set; }

		/// <summary>
		/// Gets or sets the NoConformidad value.
		/// </summary>
		public string NoConformidad
		{ get; set; }

		/// <summary>
		/// Gets or sets the AccionCorrectiva value.
		/// </summary>
		public string AccionCorrectiva
		{ get; set; }

		/// <summary>
		/// Gets or sets the PlazoLevantamiento value.
		/// </summary>
		public string PlazoLevantamiento
		{ get; set; }

		/// <summary>
		/// Gets or sets the Cumplio value.
		/// </summary>
		public bool Cumplio
		{ get; set; }

		#endregion
	}
}
