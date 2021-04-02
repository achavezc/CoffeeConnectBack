using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
	public class ConsultaOrdenServicioControlCalidadPorIdBE
	{

		#region Properties
		public int OrdenServicioControlCalidadId { get; set; }
		public int EmpresaId { get; set; }
		public String RazonSocialEmpresa { get; set; }
		public String RucEmpresa { get; set; }
		public String DireccionEmpresa { get; set; }
		public int EmpresaProcesadoraId { get; set; }
		public String RazonSocialEmpresaProcesadora { get; set; }
		public String RucEmpresaProcesadora { get; set; }
		public String DireccionEmpresaProcesadora { get; set; }
		public String Numero { get; set; }
		public String UnidadMedidaId { get; set; }
		public String UnidadMedida { get; set; }
		public Decimal? CantidadPesado { get; set; }
		public String ProductoId { get; set; }
		public String Producto { get; set; }
		public String SubProductoId { get; set; }
		public String SubProducto { get; set; }

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
		public Decimal? ObservacionAnalisisFisico { get; set; }
		public Decimal? ObservacionRegistroTostado { get; set; }
		public Decimal? TotalAnalisisSensorial { get; set; }
		public String ObservacionAnalisisSensorial { get; set; }
		public String EstadoId { get; set; }
		public String Estado { get; set; }
		public DateTime FechaRegistro { get; set; }
		public String UsuarioRegistro { get; set; }
		public DateTime? FechaUltimaActualizacion { get; set; }
		public String UsuarioUltimaActualizacion { get; set; }
		public bool Activo { get; set; }



		public ConsultaOrdenServicioControlCalidadPorIdBE() {
			
		}

	    public IEnumerable<OrdenServicioControlCalidadAnalisisFisicoColorDetalle> AnalisisFisicoColorDetalle
		{ get; set; }

		public IEnumerable<OrdenServicioControlCalidadAnalisisFisicoDefectoPrimarioDetalle> AnalisisFisicoDefectoPrimarioDetalle
		{ get; set; }

		public IEnumerable<OrdenServicioControlCalidadAnalisisFisicoDefectoSecundarioDetalle> AnalisisFisicoDefectoSecundarioDetalle
		{ get; set; }

		public IEnumerable<OrdenServicioControlCalidadAnalisisFisicoOlorDetalle> AnalisisFisicoOlorDetalle
		{ get; set; }

		public IEnumerable<OrdenServicioControlCalidadAnalisisSensorialAtributoDetalle> AnalisisSensorialAtributoDetalle
		{ get; set; }

		public IEnumerable<OrdenServicioControlCalidadAnalisisSensorialDefectoDetalle> AnalisisSensorialDefectoDetalle
		{ get; set; }

		public IEnumerable<OrdenServicioControlCalidadRegistroTostadoIndicadorDetalle> RegistroTostadoIndicadorDetalle
		{ get; set; }


		#endregion
	}
}
