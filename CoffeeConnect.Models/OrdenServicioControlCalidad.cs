using System;

namespace CoffeeConnect.Models
{
	public class OrdenServicioControlCalidad
	{
		public int? OrdenServicioControlCalidadId { get; set; }
		public int EmpresaId { get; set; }
		public int EmpresaProcesadoraId { get; set; }
		public String Numero { get; set; }
		public String UnidadMedidaId { get; set; }
		public Decimal CantidadPesado { get; set; }
		public String ProductoId { get; set; }
		public String SubProductoId { get; set; }

		public String TipoProduccionId { get; set; }

		public Decimal? RendimientoEsperadoPorcentaje { get; set; }
		public Decimal? ExportableGramosAnalisisFisico { get; set; }
		public Decimal? ExportablePorcentajeAnalisisFisico { get; set; }
		public Decimal? DescarteGramosAnalisisFisico { get; set; }
		public Decimal? DescartePorcentajeAnalisisFisico { get; set; }
		public Decimal? CascarillaGramosAnalisisFisico { get; set; }
		public Decimal? CascarillaPorcentajeAnalisisFisico { get; set; }
		public Decimal? TotalGramosAnalisisFisico { get; set; }
		public Decimal? TotalPorcentajeAnalisisFisico { get; set; }
		public Decimal? HumedadPorcentajeAnalisisFisico { get; set; }
		public String ObservacionAnalisisFisico { get; set; }
		public String ObservacionRegistroTostado { get; set; }
		public Decimal? TotalAnalisisSensorial { get; set; }
		public String ObservacionAnalisisSensorial { get; set; }
		public String EstadoId { get; set; }
		public DateTime FechaRegistro { get; set; }
		public String UsuarioRegistro { get; set; }
		public DateTime? FechaUltimaActualizacion { get; set; }
		public String UsuarioUltimaActualizacion { get; set; }

		public DateTime? FechaCalidad
		{ get; set; }

		/// <summary>
		/// Gets or sets the UsuarioCalidad value.
		/// </summary>
		public string UsuarioCalidad
		{ get; set; }

	}
}
