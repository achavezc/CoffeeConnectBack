using System;

namespace CoffeeConnect.DTO
{
	public class ConsultaNotaSalidaAlmacenPlantaDetallePorIdBE
	{
		#region Properties
		/// <summary>
		/// Gets or sets the LoteDetalleId value.
		/// </summary>
		

		/// <summary>
		/// Gets or sets the LoteId value.
		/// </summary>
		public int NotaSalidaAlmacenPlantaDetalleId
		{ get; set; }

		public int NotaSalidaAlmacenPlantaId
		{ get; set; }

		public int NotaIngresoAlmacenPlantaId
		{ get; set; }
		
		public string EmpaqueId
		{ get; set; }

		public string Empaque
		{ get; set; }

		public string TipoId
		{ get; set; }

		public string TipoEmpaque
		{ get; set; }

		public string Producto
		{ get; set; }

		public string SubProducto
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
