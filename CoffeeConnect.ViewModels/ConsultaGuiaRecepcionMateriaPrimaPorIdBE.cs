using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
	public class ConsultaGuiaRecepcionMateriaPrimaPorIdBE
	{
		#region Properties
		/// <summary>
		/// Gets or sets the GuiaRecepcionMateriaPrimaId value.
		/// </summary>
		public int GuiaRecepcionMateriaPrimaId
		{ get; set; }

		public int EmpresaId
		{ get; set; }



		public int ContratoAsignadoId
		{ get; set; }
		
		/// <summary>
		/// Gets or sets the Numero value.
		/// </summary>
		public string Numero
		{ get; set; }

		/// <summary>
		/// Gets or sets the NumeroReferencia value.
		/// </summary>
		public string NumeroReferencia
		{ get; set; }

		public string SocioFincaCertificacion
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

		public string TipoProduccionId
		{ get; set; }


		/// <summary>
		/// Gets or sets the SubProducto value.
		/// </summary>
		public string SubProducto
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaCosecha value.
		/// </summary>
		public DateTime FechaCosecha
		{ get; set; }

		/// <summary>
		/// Gets or sets the EstadoId value.
		/// </summary>
		public string EstadoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Estado value.
		/// </summary>
		public string Estado
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
		/// Gets or sets the TipoProvedorId value.
		/// </summary>
		public string TipoProvedorId
		{ get; set; }

		/// <summary>
		/// Gets or sets the TipoProveedor value.
		/// </summary>
		public string TipoProveedor
		{ get; set; }

		/// <summary>
		/// Gets or sets the SocioId value.
		/// </summary>
		public int SocioId
		{ get; set; }

		/// <summary>
		/// Gets or sets the TerceroId value.
		/// </summary>
		public int TerceroId
		{ get; set; }

		/// <summary>
		/// Gets or sets the IntermediarioId value.
		/// </summary>
		public int IntermediarioId
		{ get; set; }

		/// <summary>
		/// Gets or sets the CodigoSocio value.
		/// </summary>
		public string CodigoSocio
		{ get; set; }

		/// <summary>
		/// Gets or sets the NombreRazonSocial value.
		/// </summary>
		public string NombreRazonSocial
		{ get; set; }

		/// <summary>
		/// Gets or sets the TipoDocumentoId value.
		/// </summary>
		public string TipoDocumentoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the TipoDocumento value.
		/// </summary>
		public string TipoDocumento
		{ get; set; }

		/// <summary>
		/// Gets or sets the NumeroDocumento value.
		/// </summary>
		public string NumeroDocumento
		{ get; set; }

		/// <summary>
		/// Gets or sets the Departamento value.
		/// </summary>
		public string Departamento
		{ get; set; }

		/// <summary>
		/// Gets or sets the Provincia value.
		/// </summary>
		public string Provincia
		{ get; set; }

		/// <summary>
		/// Gets or sets the Distrito value.
		/// </summary>
		public string Distrito
		{ get; set; }

		/// <summary>
		/// Gets or sets the Zona value.
		/// </summary>
		public string Zona
		{ get; set; }

		/// <summary>
		

		/// <summary>
		/// Gets or sets the RazonSocial value.
		/// </summary>
		public string RazonSocial
		{ get; set; }

		/// <summary>
		/// Gets or sets the Ruc value.
		/// </summary>
		public string Ruc
		{ get; set; }

		/// <summary>
		/// Gets or sets the Logo value.
		/// </summary>
		public string Logo
		{ get; set; }

		/// <summary>
		/// Gets or sets the Direccion value.
		/// </summary>
		public string Direccion
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
		/// Gets or sets the KilosBrutosPesado value.
		/// </summary>
		public decimal KilosBrutosPesado
		{ get; set; }

		public decimal KilosNetosPesado
		{ get; set; }

		


		/// <summary>
		/// Gets or sets the TaraPesado value.
		/// </summary>
		public decimal TaraPesado
		{ get; set; }

		/// <summary>
		/// Gets or sets the ObservacionPesado value.
		/// </summary>
		public string ObservacionPesado
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
		/// Gets or sets the TotalAnalisisSensorial value.
		/// </summary>
		public decimal? TotalAnalisisSensorial
		{ get; set; }

		/// <summary>
		/// Gets or sets the HumedadPorcentajeAnalisisFisico value.
		/// </summary>
		public decimal? HumedadPorcentajeAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the ObservacionAnalisisFisico value.
		/// </summary>
		public string ObservacionAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaPesado value.
		/// </summary>
		public DateTime FechaPesado
		{ get; set; }

		/// <summary>
		/// Gets or sets the UsuarioPesado value.
		/// </summary>
		public string UsuarioPesado
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaCalidad value.
		/// </summary>
		public DateTime? FechaCalidad
		{ get; set; }

		/// <summary>
		/// Gets or sets the UsuarioCalidad value.
		/// </summary>
		public string UsuarioCalidad
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
		/// Gets or sets the Activo value.
		/// </summary>
		public bool Activo
		{ get; set; }

		public int? SocioFincaId
		{ get; set; }

		public int? TerceroFincaId
		{ get; set; }

		public string Finca
		{ get; set; }


		//public int? NotaCompraId
		//{ get; set; }

		//public decimal? DescuentoPorHumedad
		//{ get; set; }

		//public decimal? KilosNetosDescontar
		//{ get; set; }

		//public decimal? KilosNetosPagar
		//{ get; set; }

		//public decimal? QQ55
		//{ get; set; }

		//public decimal? PrecioGuardado
		//{ get; set; }

		//public decimal? PrecioPagado
		//{ get; set; }

		//public decimal? Importe
		//{ get; set; }


		public List<GuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalle> AnalisisFisicoColorDetalle
		{ get; set; }

		public List<GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetalle> AnalisisFisicoDefectoPrimarioDetalle
		{ get; set; }

		public List<GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetalle> AnalisisFisicoDefectoSecundarioDetalle
		{ get; set; }

		public List<GuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalle> AnalisisFisicoOlorDetalle
		{ get; set; }

		public List<GuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalle> AnalisisSensorialAtributoDetalle
		{ get; set; }

		public List<GuiaRecepcionMateriaPrimaAnalisisSensorialDefectoDetalle> AnalisisSensorialDefectoDetalle
		{ get; set; }

		public List<GuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetalle> RegistroTostadoIndicadorDetalle
		{ get; set; }


		public ConsultaNotaCompraPorGuiaRecepcionMateriaPrimaIdBE NotaCompra
		{ get; set; }



		#endregion
	}
}
