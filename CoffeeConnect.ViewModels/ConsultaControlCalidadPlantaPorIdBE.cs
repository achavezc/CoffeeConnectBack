using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
   public  class ConsultaControlCalidadPlantaPorIdBE
    {
		#region Properties
		/// <summary>
		/// Gets or sets the NotaIngresoPlantaId value.
		/// </summary>
		public int ControlCalidadPlantaId
		{ get; set; }


		public int NotaIngresoPlantaId
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
		/// Gets or sets the NumeroGuiaRemision value.
		/// </summary>
		public string NumeroGuiaRemision
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaGuiaRemision value.
		/// </summary>
		public DateTime FechaGuiaRemision
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaOrigenId value.
		/// </summary>
		public int EmpresaOrigenId
		{ get; set; }

		/// <summary>
		/// Gets or sets the TipoProduccionId value.
		/// </summary>
		public string TipoProduccionId
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
		/// Gets or sets the CertificacionId value.
		/// </summary>
		public string CertificacionId
		{ get; set; }

		/// <summary>
		/// Gets or sets the EntidadCertificadoraId value.
		/// </summary>
		public string EntidadCertificadoraId
		{ get; set; }

		/// <summary>
		/// Gets or sets the MotivoIngresoId value.
		/// </summary>
		public string MotivoIngresoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpaqueId value.
		/// </summary>
		public string EmpaqueId
		{ get; set; }

		/// <summary>
		/// Gets or sets the TipoId value.
		/// </summary>
		public string TipoId
		{ get; set; }

		public string CalidadId
		{ get; set; }

		public string GradoId
		{ get; set; }

		public decimal CantidadDefectos
		{ get; set; }

		public decimal? PesoPorSaco
		{ get; set; }


		/// <summary>
		/// Gets or sets the Cantidad value.
		/// </summary>
		public decimal Cantidad
		{ get; set; }

		/// <summary>
		/// Gets or sets the KilosBrutos value.
		/// </summary>
		public decimal KilosBrutos
		{ get; set; }

		public decimal KilosNetos
		{ get; set; }





		public decimal Tara
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
		/// Gets or sets the HumedadPorcentaje value.
		/// </summary>
		public decimal HumedadPorcentaje
		{ get; set; }

		/// <summary>
		/// Gets or sets the RendimientoPorcentaje value.
		/// </summary>
		public decimal RendimientoPorcentaje
		{ get; set; }

		/// <summary>
		/// Gets or sets the RucEmpresaTransporte value.
		/// </summary>
		public string RucEmpresaTransporte
		{ get; set; }

		/// <summary>
		/// Gets or sets the RazonEmpresaTransporte value.
		/// </summary>
		public string RazonEmpresaTransporte
		{ get; set; }

		/// <summary>
		/// Gets or sets the PlacaTractorEmpresaTransporte value.
		/// </summary>
		public string PlacaTractorEmpresaTransporte
		{ get; set; }

		/// <summary>
		/// Gets or sets the ConductorEmpresaTransporte value.
		/// </summary>
		public string ConductorEmpresaTransporte
		{ get; set; }

		/// <summary>
		/// Gets or sets the LicenciaConductorEmpresaTransporte value.
		/// </summary>
		public string LicenciaConductorEmpresaTransporte
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
		/// Gets or sets the TotalAnalisisSensorial value.
		/// </summary>
		public decimal? TotalAnalisisSensorial
		{ get; set; }

		/// <summary>
		/// Gets or sets the ObservacionAnalisisSensorial value.
		/// </summary>
		public string ObservacionAnalisisSensorial
		{ get; set; }

		/// <summary>
		/// Gets or sets the EstadoId value.
		/// </summary>
		public string EstadoId
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
		/// Gets or sets the Estado value.
		/// </summary>
		public string Estado
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
		/// Gets or sets the Logo value.
		/// </summary>
		public string Logo
		{ get; set; }

		/// <summary>
		/// Gets or sets the Direccion value.
		/// </summary>
		public string Direccion
		{ get; set; }

		public string Distrito
		{ get; set; }
		public string Provincia
		{ get; set; }
		public string Departamento
		{ get; set; }

		/// <summary>
		/// Gets or sets the RazonSocialOrganizacion value.
		/// </summary>
		public string RazonSocialOrganizacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the NumeroOrganizacion value.
		/// </summary>
		public string NumeroOrganizacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the RucOrganizacion value.
		/// </summary>
		public string RucOrganizacion
		{ get; set; }

		public string DireccionOrganizacion
		{ get; set; }



		/// <summary>
		/// Gets or sets the ProvinciaId value.
		/// </summary>
		public string ProvinciaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the DepartamentoId value.
		/// </summary>
		public string DepartamentoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the DistritoId value.
		/// </summary>
		public string DistritoId
		{ get; set; }


		public decimal Taza { get; set; }
		public decimal Intensidad { get; set; }
		public decimal TazaIntensidad { get; set; }
		public decimal PuntajeFinal { get; set; }
		public List<ControlCalidadPlantaAnalisisFisicoColorDetalle> AnalisisFisicoColorDetalle
		{ get; set; }

		public List<ControlCalidadPlantaAnalisisFisicoDefectoPrimarioDetalle> AnalisisFisicoDefectoPrimarioDetalle
		{ get; set; }

		public List<ControlCalidadPlantaAnalisisFisicoDefectoSecundarioDetalle> AnalisisFisicoDefectoSecundarioDetalle
		{ get; set; }

		public List<ControlCalidadPlantaAnalisisFisicoOlorDetalle> AnalisisFisicoOlorDetalle
		{ get; set; }

		public List<ControlCalidadPlantaAnalisisSensorialAtributoDetalle> AnalisisSensorialAtributoDetalle
		{ get; set; }

		public List<ControlCalidadPlantaAnalisisSensorialDefectoDetalle> AnalisisSensorialDefectoDetalle
		{ get; set; }

		public List<ControlCalidadPlantaRegistroTostadoIndicadorDetalle> RegistroTostadoIndicadorDetalle
		{ get; set; }

		public string MotivoIngreso { get; set; }

		public string Marca { get; set; }

		public string Producto { get; set; }
		public string Empaque { get; set; }
		public string TipoEmpaque { get; set; }
		public string Certificacion { get; set; }

		public string CodigoCampania { get; set; }
		public string CodigoTipoConcepto { get; set; }

		public decimal CantidadControlCalidad { get; set; }
		public decimal PesoBrutoControlCalidad { get; set; }
		public decimal TaraControlCalidad { get; set; }
		public decimal KilosNetosControlCalidad { get; set; }

		public string ControlCalidadTipoId { get; set; }
		public string ControlCalidadEmpaqueId { get; set; }

		#endregion

	}
}
