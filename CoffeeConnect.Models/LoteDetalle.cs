using System;

namespace CoffeeConnect.Models
{
	public class LoteDetalle
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

		/// <summary>
		/// Gets or sets the NotaIngresoAlmacenId value.
		/// </summary>
		public int NotaIngresoAlmacenId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Numero value.
		/// </summary>
		public string Numero
		{ get; set; }

		/// <summary>
		/// Gets or sets the TipoProvedorId value.
		/// </summary>
		public string TipoProvedorId
		{ get; set; }




		
		/// <summary>
		/// Gets or sets the SocioId value.
		/// </summary>
		public int? SocioId
		{ get; set; }

		/// <summary>
		/// Gets or sets the TerceroId value.
		/// </summary>
		public int? TerceroId
		{ get; set; }

		/// <summary>
		/// Gets or sets the IntermediarioId value.
		/// </summary>
		public int? IntermediarioId
		{ get; set; }

		/// <summary>
		/// Gets or sets the ProductoId value.
		/// </summary>
		public string ProductoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the SubProductoId value.
		/// </summary>
		public string SubProductoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the UnidadMedidaIdPesado value.
		/// </summary>
		public string UnidadMedidaIdPesado
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


		public decimal KilosBrutosPesado
		{ get; set; }

		/// <summary>
		/// Gets or sets the RendimientoPorcentaje value.
		/// </summary>
		public decimal? RendimientoPorcentaje
		{ get; set; }

		/// <summary>
		/// Gets or sets the HumedadPorcentaje value.
		/// </summary>
		public decimal HumedadPorcentaje
		{ get; set; }

		public decimal TotalAnalisisSensorial
		{ get; set; }

		

		#endregion
	}
}
