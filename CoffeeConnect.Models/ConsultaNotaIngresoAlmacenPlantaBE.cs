using System;

namespace CoffeeConnect.Models
{
	public class ConsultaNotaIngresoAlmacenPlantaBE
	{

		/// <summary>
		/// Gets or sets the Numero value.
		/// </summary>
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

		#region Properties
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

		public DateTime FechaGuiaRemision
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

		public string RucEmpresaOrigen
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






		#endregion
	}
}
