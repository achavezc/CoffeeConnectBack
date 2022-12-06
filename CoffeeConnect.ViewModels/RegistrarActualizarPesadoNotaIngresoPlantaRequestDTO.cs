using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
   public class RegistrarActualizarPesadoNotaIngresoPlantaRequestDTO
	{
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
		public DateTime? FechaGuiaRemision
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

		public decimal KilosBrutos
		{ get; set; }

		public decimal KilosNetos
		{ get; set; }

		public decimal Tara
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
		/// Gets or sets the TipoId value.
		/// </summary>
		public string TipoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Cantidad value.
		/// </summary>
		public decimal Cantidad
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
		public string UsuarioPesado
		{ get; set; }

		public DateTime FechaPesado
		{ get; set; }

		public string Direccion { get; set; }
		public string Marca { get; set; }

		public string CodigoConcepto { get; set; }

		public string CodigoCampania { get; set; }

		public string CodigoTipoConcepto { get; set; }

		public List<NotaIngresoPlantaDetalle> NotaIngresoPlantaDetalle { get; set; }
	}
}
