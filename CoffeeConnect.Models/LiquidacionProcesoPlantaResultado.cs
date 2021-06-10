using System;

namespace CoffeeConnect.Models
{
	public class LiquidacionProcesoPlantaResultado
	{
		#region Properties
		/// <summary>
		/// Gets or sets the LiquidacionProcesoPlantaResultadoId value.
		/// </summary>
		public int LiquidacionProcesoPlantaResultadoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the LiquidacionProcesoPlantaId value.
		/// </summary>
		public int LiquidacionProcesoPlantaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the NotaIngresoPlantaId value.
		/// </summary>
		public string ReferenciaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the CantidadSacos value.
		/// </summary>
		public decimal? CantidadSacos
		{ get; set; }

		/// <summary>
		/// Gets or sets the KGN value.
		/// </summary>
		public decimal? KGN
		{ get; set; }

		/// <summary>
		/// Gets or sets the KilosNetos value.
		/// </summary>
		public decimal? KilosNetos
		{ get; set; }

		#endregion
	}
}
