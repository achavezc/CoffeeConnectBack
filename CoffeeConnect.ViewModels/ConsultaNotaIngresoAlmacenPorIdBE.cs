using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
	public class ConsultaNotaIngresoAlmacenPorIdBE
	{
		#region Properties
		/// <summary>
		/// Gets or sets the GuiaRecepcionMateriaPrimaId value.
		/// </summary>
		public int GuiaRecepcionMateriaPrimaId
		{ get; set; }

		public int NotaIngresoAlmacenId
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
		/// Gets or sets the AlmacenId value.
		/// </summary>
		public string AlmacenId
		{ get; set; }

		/// <summary>
		/// Gets or sets the NumeroGuiaRecepcionMateriaPrima value.
		/// </summary>
		public string NumeroGuiaRecepcionMateriaPrima
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

		/// <summary>
		/// Gets or sets the TaraPesado value.
		/// </summary>
		public decimal? TaraPesado
		{ get; set; }

		/// <summary>
		/// Gets or sets the Observacion value.
		/// </summary>
		public string Observacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the ExportableGramosAnalisisFisico value.
		/// </summary>
		public decimal ExportableGramosAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the ExportablePorcentajeAnalisisFisico value.
		/// </summary>
		public decimal ExportablePorcentajeAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the DescarteGramosAnalisisFisico value.
		/// </summary>
		public decimal DescarteGramosAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the DescartePorcentajeAnalisisFisico value.
		/// </summary>
		public decimal DescartePorcentajeAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the CascarillaGramosAnalisisFisico value.
		/// </summary>
		public decimal CascarillaGramosAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the CascarillaPorcentajeAnalisisFisico value.
		/// </summary>
		public decimal CascarillaPorcentajeAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the TotalGramosAnalisisFisico value.
		/// </summary>
		public decimal TotalGramosAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the TotalPorcentajeAnalisisFisico value.
		/// </summary>
		public decimal TotalPorcentajeAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the TotalAnalisisSensorial value.
		/// </summary>
		public decimal TotalAnalisisSensorial
		{ get; set; }

		/// <summary>
		/// Gets or sets the HumedadPorcentajeAnalisisFisico value.
		/// </summary>
		public decimal HumedadPorcentajeAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the Activo value.
		/// </summary>
		public bool Activo
		{ get; set; }

		/// <summary>
		/// Gets or sets the SocioFincaId value.
		/// </summary>
		public int? SocioFincaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the TerceroFincaId value.
		/// </summary>
		public int? TerceroFincaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the TipoProduccionId value.
		/// </summary>
		public string TipoProduccionId
		{ get; set; }

		/// <summary>
		/// Gets or sets the TipoProduccion value.
		/// </summary>
		public string TipoProduccion
		{ get; set; }

		/// <summary>
		/// Gets or sets the Finca value.
		/// </summary>
		public string Finca
		{ get; set; }

		public List<GuiaRecepcionMateriaPrimaAnalisisSensorialDefectoDetalle> AnalisisSensorialDefectoDetalle
		{ get; set; }

		#endregion
	}
}
