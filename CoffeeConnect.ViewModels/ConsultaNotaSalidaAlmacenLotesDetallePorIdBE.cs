using System;

namespace CoffeeConnect.DTO
{
	public class ConsultaNotaSalidaAlmacenLotesDetallePorIdBE
	{
		#region Properties
		/// <summary>
		/// Gets or sets the LoteDetalleId value.
		/// </summary>
		

		/// <summary>
		/// Gets or sets the LoteId value.
		/// </summary>
		public int LoteId
		{ get; set; }




		public string NumeroLote
		{ get; set; }
		



		/// <summary>
		/// Gets or sets the FechaIngresoAlmacen value.
		/// </summary>
		public DateTime FechaRegistro
		{ get; set; }

		public string ProductoId
		{ get; set; }

		public string Producto
		{ get; set; }

		public string SubProductoId
		{ get; set; }

		public string TipoProduccionId
		{ get; set; }

		public string TipoCertificacionId
		{ get; set; }



		public string SubProducto
		{ get; set; }

		public string UnidadMedidaId
		{ get; set; }

		public string UnidadMedida
		{ get; set; }

		public int Cantidad
		{ get; set; }

		public decimal TotalKilosBrutosPesado
		{ get; set; }


		public decimal TotalKilosNetosPesado
		{ get; set; }

		public decimal RendimientoPorcentaje
		{ get; set; }

		public decimal HumedadPorcentajeAnalisisFisico
		{ get; set; }


		#endregion
	}
}
