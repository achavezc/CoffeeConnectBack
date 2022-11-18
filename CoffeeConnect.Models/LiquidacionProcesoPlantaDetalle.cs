using System;

namespace CoffeeConnect.Models
{
	public class LiquidacionProcesoPlantaDetalle
	{
		#region Properties
		/// <summary>
		/// Gets or sets the LiquidacionProcesoPlantaId value.
		/// </summary>
		public int? LiquidacionProcesoPlantaDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the OrdenProcesoPlantaId value.
		/// </summary>
		public int? LiquidacionProcesoPlantaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Numero value.
		/// </summary>
		public int NotaIngresoAlmacenPlantaId
		{ get; set; }

		public decimal Cantidad { get; set; }

		public decimal KilosNetos { get; set; }

		public decimal PorcentajeHumedad { get; set; }

		public string Descripcion { get; set; }

		public decimal KilosBrutos { get; set; }
		public decimal Tara { get; set; }

		public string EmpaqueId { get; set; }

		public string TipoId { get; set; }




		#endregion
	}
}
