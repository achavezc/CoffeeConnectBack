using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
	public class ConsultaNotaIngresoAlmacenPlantaPorIdBE
	{

		/// <summary>
		/// Gets or sets the EmpresaId value.
		/// </summary>
		public int EmpresaId
		{ get; set; }

		public string RazonSocial
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

		public string Numero
		{ get; set; }

		/// <summary>
		/// Gets or sets the NumeroIngresoPlanta value.
		/// </summary>
		public string NumeroCalidadPlanta
		{ get; set; }

		public string NumeroNotaIngresoPlanta
		{ get; set; }

		public string NumeroGuiaRemision
		{ get; set; }

		public decimal CantidadControlCalidad
		{ get; set; }

		public decimal PesoBrutoControlCalidad
		{ get; set; }

		public decimal TaraControlCalidad
		{ get; set; }

		public decimal KilosNetosControlCalidad
		{ get; set; }



		public int NotaIngresoPlantaId
		{ get; set; }


		/// <summary>
		/// Gets or sets the NotaIngresoAlmacenPlantaId value.
		/// </summary>
		public int NotaIngresoAlmacenPlantaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the NotaIngresoPlantaId value.
		/// </summary>

		public int ControlCalidadPlantaId
		{ get; set; }

		public DateTime? FechaGuiaRemision
		{ get; set; }

		public DateTime FechaCalidad
		{ get; set; }
		

		/// <summary>
		/// Gets or sets the EmpresaOrigenId value.
		/// </summary>
		public int EmpresaOrigenId
		{ get; set; }

		/// <summary>
		/// Gets or sets the RazonSocial value.
		/// </summary>
		public string RazonSocialEmpresaOrigen
		{ get; set; }

		

public string Ruc
		{ get; set; }


		public string RucEmpresaOrigen
		{ get; set; }

		public string DireccionEmpresaOrigen
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

		public string TipoId
		{ get; set; }

		public string EmpaqueId
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
		/// Gets or sets the CertificacionId value.
		/// </summary>
		public string CertificacionId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Certificacion value.
		/// </summary>
		public string Certificacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the EntidadCertificadoraId value.
		/// </summary>
		public string EntidadCertificadoraId
		{ get; set; }

		/// <summary>
		/// Gets or sets the EntidadCertificadora value.
		/// </summary>
		public string EntidadCertificadora
		{ get; set; }

		public string MotivoIngresoId
		{ get; set; }

		public string MotivoIngreso
		{ get; set; }



		/// <summary>
		/// Gets or sets the AlmacenId value.
		/// </summary>
		public string AlmacenId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Almacen value.
		/// </summary>
		public string Almacen
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
		/// Gets or sets the RendimientoPorcentaje value.
		/// </summary>
		public decimal? RendimientoPorcentaje
		{ get; set; }


		public decimal? TotalAnalisisSensorial
		{ get; set; }


		/// <summary>
		/// Gets or sets the HumedadPorcentajeAnalisisFisico value.
		/// </summary>
		public decimal? HumedadPorcentaje
		{ get; set; }




		public decimal? PuntajeFinal
		{ get; set; }


		public decimal? CantidadRechazadaControlCalidad
		{ get; set; }

		public decimal? KilosNetosRechazadosControlCalidad
		{ get; set; }

		public decimal? Cantidad
		{ get; set; }

		public decimal? PesoBruto
		{ get; set; }

		public decimal? Tara
		{ get; set; }

		public decimal? KilosNetos
		{ get; set; }

		public decimal? CantidadDisponible
		{ get; set; }

		public decimal? KilosNetosDisponibles
		{ get; set; }

		public decimal? CantidadOrdenProceso
		{ get; set; }

		public decimal? KilosNetosOrdenProceso
		{ get; set; }


		public List<NotaIngresoAlmacenPlantaAnalisisFisicoColorDetalle> AnalisisFisicoColorDetalle
		{ get; set; }

		public List<NotaIngresoAlmacenPlantaAnalisisFisicoDefectoPrimarioDetalle> AnalisisFisicoDefectoPrimarioDetalle
		{ get; set; }

		public List<NotaIngresoAlmacenPlantaAnalisisFisicoDefectoSecundarioDetalle> AnalisisFisicoDefectoSecundarioDetalle
		{ get; set; }

		public List<NotaIngresoAlmacenPlantaAnalisisFisicoOlorDetalle> AnalisisFisicoOlorDetalle
		{ get; set; }

		public List<NotaIngresoAlmacenPlantaAnalisisSensorialAtributoDetalle> AnalisisSensorialAtributoDetalle
		{ get; set; }

		public List<NotaIngresoAlmacenPlantaAnalisisSensorialDefectoDetalle> AnalisisSensorialDefectoDetalle
		{ get; set; }

		public List<NotaIngresoAlmacenPlantaRegistroTostadoIndicadorDetalle> RegistroTostadoIndicadorDetalle
		{ get; set; }

		public string EstadoCalidadId
		{ get; set; }


		/// Gets or sets the ObservacionPesado value.
		/// </summary>
		public string ObservacionPesado
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
		/// Gets or sets the HumedadPorcentajeAnalisisFisico value.
		/// </summary>
		public decimal HumedadPorcentajeAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the ObservacionAnalisisFisico value.
		/// </summary>
		public string ObservacionAnalisisFisico
		{ get; set; }



	}
}
