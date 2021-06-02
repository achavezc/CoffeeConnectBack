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
		public int NotaIngresoAlmacenPlantaId
		{ get; set; }


		public string NumeroNotaIngresoAlmacenPlanta
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


		public string SubProducto
		{ get; set; }

		public string CalidadId
		{ get; set; }

		public string Calidad
		{ get; set; }


		public string GradoId
		{ get; set; }

		public string Grado
		{ get; set; }

		public decimal? CantidadDefectos
		{ get; set; }

		public decimal? CantidadPesado
		{ get; set; }


		public decimal? KilosBrutosPesado
		{ get; set; }


		public decimal? KilosNetosPesado
		{ get; set; }

		public decimal? TaraPesado
		{ get; set; }



		#endregion
	}
}
