using System;

namespace CoffeeConnect.DTO
{
	public class ConsultaNotaSalidaAlmacenLotesDetallePorIdBE
	{
		#region Properties
		/// <summary>
		/// Gets or sets the LoteDetalleId value.
		/// </summary>
		public int LoteDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the LoteId value.
		/// </summary>
		public int LoteId
		{ get; set; }

		public string NumeroLote
		{ get; set; }
		

		/// <summary>
		/// Gets or sets the NumeroNotaIngresoAlmacen value.
		/// </summary>
		public string NumeroNotaIngresoAlmacen
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaIngresoAlmacen value.
		/// </summary>
		public DateTime FechaIngresoAlmacen
		{ get; set; }

		/// <summary>
		/// Gets or sets the AlmacenId value.
		/// </summary>
		public string AlmacenId
		{ get; set; }

		/// <summary>
		/// Gets or sets the ProductoId value.
		/// </summary>
		public string ProductoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Producto value.
		/// </summary>
		public string Producto
		{ get; set; }

		/// <summary>
		/// Gets or sets the SubProductoId value.
		/// </summary>
		public string SubProductoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the SubProducto value.
		/// </summary>
		public string SubProducto
		{ get; set; }

		/// <summary>
		/// Gets or sets the UnidadMedidaIdPesado value.
		/// </summary>
		public string UnidadMedidaIdPesado
		{ get; set; }

		/// <summary>
		/// Gets or sets the UnidadMedida value.
		/// </summary>
		public string UnidadMedida
		{ get; set; }

		/// <summary>
		/// Gets or sets the CantidadPesado value.
		/// </summary>
		public decimal CantidadPesado
		{ get; set; }

		/// <summary>
		/// Gets or sets the KilosNetosPesado value.
		/// </summary>
		public decimal KilosNetosPesado
		{ get; set; }

		/// <summary>
		/// Gets or sets the RendimientoPorcentaje value.
		/// </summary>
		public decimal RendimientoPorcentaje
		{ get; set; }

		/// <summary>
		/// Gets or sets the HumedadPorcentaje value.
		/// </summary>
		public decimal HumedadPorcentaje
		{ get; set; }

		/// <summary>
		/// Gets or sets the TotalAnalisisSensorial value.
		/// </summary>
		public decimal TotalAnalisisSensorial
		{ get; set; }

		#endregion
	}
}
