using System;

namespace CoffeeConnect.Models
{
	public class Lote
	{
		#region Properties
		/// <summary>
		/// Gets or sets the LoteId value.
		/// </summary>
		public int LoteId
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaId value.
		/// </summary>
		public int EmpresaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Numero value.
		/// </summary>
		public string Numero
		{ get; set; }

		/// <summary>
		/// Gets or sets the EstadoId value.
		/// </summary>
		public string EstadoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the AlmacenId value.
		/// </summary>
		public string AlmacenId
		{ get; set; }

		/// <summary>
		/// Gets or sets the TotalKilosNetosPesado value.
		/// </summary>
		public decimal TotalKilosNetosPesado
		{ get; set; }

		public decimal TotalKilosBrutosPesado
		{ get; set; }

		
		public string UnidadMedidaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the TotalKilosNetosPesado value.
		/// </summary>
		public decimal Cantidad
		{ get; set; }


		/// <summary>
		/// Gets or sets the PromedioRendimientoPorcentaje value.
		/// </summary>
		public decimal PromedioRendimientoPorcentaje
		{ get; set; }

		public decimal PromedioTotalAnalisisSensorial
		{ get; set; }
		

		/// <summary>
		/// Gets or sets the PromedioHumedadPorcentaje value.
		/// </summary>
		public decimal PromedioHumedadPorcentaje
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaRegistro value.
		/// </summary>
		public DateTime FechaRegistro
		{ get; set; }

		/// <summary>
		/// Gets or sets the UsuarioRegistro value.
		/// </summary>
		public string UsuarioRegistro
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaUltimaActualizacion value.
		/// </summary>
		public DateTime? FechaUltimaActualizacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the UsuarioUltimaActualizacion value.
		/// </summary>
		public string UsuarioUltimaActualizacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the Activo value.
		/// </summary>
		public bool Activo
		{ get; set; }


		public string ProductoId
		{ get; set; }

		public string SubProductoId
		{ get; set; }
		

		public string TipoCertificacionId
		{ get; set; }



		/// <summary>
		/// Gets or sets the HumedadPorcentajeAnalisisFisico value.
		/// </summary>
		public decimal? HumedadPorcentajeAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the ExportableGramosAnalisisFisico value.
		/// </summary>
		public decimal? ExportableGramosAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the ExportablePorcentajeAnalisisFisico value.
		/// </summary>
		public decimal? ExportablePorcentajeAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the DescarteGramosAnalisisFisico value.
		/// </summary>
		public decimal? DescarteGramosAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the DescartePorcentajeAnalisisFisico value.
		/// </summary>
		public decimal? DescartePorcentajeAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the CascarillaGramosAnalisisFisico value.
		/// </summary>
		public decimal? CascarillaGramosAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the CascarillaPorcentajeAnalisisFisico value.
		/// </summary>
		public decimal? CascarillaPorcentajeAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the TotalGramosAnalisisFisico value.
		/// </summary>
		public decimal? TotalGramosAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the TotalPorcentajeAnalisisFisico value.
		/// </summary>
		public decimal? TotalPorcentajeAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the Observacion value.
		/// </summary>
		public string Observacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the ObservacionAnalisisFisico value.
		/// </summary>
		public string ObservacionAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the ObservacionRegistroTostado value.
		/// </summary>
		public string ObservacionRegistroTostado
		{ get; set; }

		/// <summary>
		/// Gets or sets the ObservacionAnalisisSensorial value.
		/// </summary>
		public string ObservacionAnalisisSensorial
		{ get; set; }

		/// <summary>
		/// Gets or sets the TotalAnalisisSensorial value.
		/// </summary>
		public decimal? TotalAnalisisSensorial
		{ get; set; }

		/// <summary>
		/// Gets or sets the TotalLote value.
		/// </summary>
		public int CantidadLotes
		{ get; set; }

		/// <summary>
		/// Gets or sets the TotalPromedioPorcentajeRendimiento value.
		/// </summary>
		public decimal PromedioPorcentajeRendimiento
		{ get; set; }

		/// <summary>
		/// Gets or sets the CantidadTotal value.
		/// </summary>
		public int CantidadTotal
		{ get; set; }

		/// <summary>
		/// Gets or sets the TotalKilosBrutos value.
		/// </summary>
		public decimal PesoKilosBrutos
		{ get; set; }

		/// <summary>
		/// Gets or sets the UsuarioCalidad value.
		/// </summary>
		public string UsuarioCalidad
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaCalidad value.
		/// </summary>
		public DateTime FechaCalidad
		{ get; set; }

		#endregion
	}
}
