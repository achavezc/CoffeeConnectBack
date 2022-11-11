using System;

namespace CoffeeConnect.DTO
{
	public class ConsultaNotaIngresoProductoTerminadoAlmacenPlantaBE
	{

		
		public int NotaIngresoProductoTerminadoAlmacenPlantaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Numero value.
		/// </summary>
		public string Numero
		{ get; set; }



		public string EmpaqueId
		{ get; set; }


		public string Empaque
		{ get; set; }



		public string TipoEmpaque
		{ get; set; }




		public int? NotaIngresoPlantaId
		{ get; set; }
		/// <summary>
		/// Gets or sets the NumeroIngresoPlanta value.
		/// </summary>
		public string NumeroNotaIngresoPlanta
		{ get; set; }

		public DateTime? FechaGuiaRemision
		{ get; set; }


		

		public string NumeroGuiaRemision
		{ get; set; }

		public decimal Cantidad
		{ get; set; }

		public decimal? KGN
		{ get; set; }

		public decimal KilosNetos
		{ get; set; }

		public decimal KilosBrutos
		{ get; set; }


		public decimal CantidadSalidaAlmacen
		{ get; set; }

		public decimal KilosNetosSalidaAlmacen
		{ get; set; }

		public decimal KilosNetos46
		{ get; set; }


		public int? LiquidacionProcesoPlantaId
		{ get; set; }

		public int EmpresaOrigenId
		{ get; set; }

		public string RazonSocialEmpresaOrigen
		{ get; set; }


		public string RucEmpresaOrigen
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



		public string MotivoIngresoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the SubProducto value.
		/// </summary>
		public string MotivoIngreso
		{ get; set; }


		public string AlmacenId
		{ get; set; }

		public string Almacen
		{ get; set; }

		public string EstadoId
		{ get; set; }

		public string Estado
		{ get; set; }

		public DateTime FechaRegistro
		{ get; set; }

		public string UsuarioRegistro
		{ get; set; }


		public decimal CantidadDisponible
		{ get; set; }


		public decimal KilosNetosDisponibles
		{ get; set; }


		public string Observacion
		{ get; set; }

 
	}
}
