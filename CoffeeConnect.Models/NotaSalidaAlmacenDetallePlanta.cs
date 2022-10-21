using System;

namespace CoffeeConnect.Models
{
	public class NotaSalidaAlmacenPlantaDetalle
	{
		#region Properties
		/// <summary>
		/// Gets or sets the LoteDetalleId value.
		/// </summary>
		public int? NotaSalidaAlmacenPlantaDetalleId
		{ get; set; }
		public int? NotaSalidaAlmacenPlantaId
		{ get; set; }
		/// <summary>
		/// Gets or sets the LoteId value.
		/// </summary>
		public int? NotaIngresoAlmacenPlantaId
		{ get; set; }


		public string EmpaqueId
		{ get; set; }

		public string TipoId
		{ get; set; }


		public decimal Cantidad
		{ get; set; }

		public decimal PesoKilosBrutos
		{ get; set; }

		public decimal PesoKilosNetos
		{ get; set; }

		public decimal Tara
		{ get; set; }



		#endregion
	}
}
