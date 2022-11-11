using System;

namespace CoffeeConnect.Models
{
	public class NotaIngresoProductoTerminadoAlmacenPlanta
	{
		#region Properties
		/// <summary>
		/// Gets or sets the NotaIngresoAlmacenPlantaId value.
		/// </summary>
		public int NotaIngresoProductoTerminadoAlmacenPlantaId
		{ get; set; }

		public int? NotaIngresoPlantaId
		{ get; set; }


		/// <summary>
		/// Gets or sets the EmpresaId value.
		/// </summary>
		public int EmpresaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the AlmacenId value.
		/// </summary>
		public string AlmacenId
		{ get; set; }

		

		/// <summary>
		/// Gets or sets the Numero value.
		/// </summary>
		public string Numero
		{ get; set; }



		public string MotivoIngresoId
		{ get; set; }

		public string ProductoId
		{ get; set; }

		public string SubProductoId
		{ get; set; }

		public string TipoId
		{ get; set; }

		public string EmpaqueId
		{ get; set; }

		public decimal? Cantidad
		{ get; set; }


		public decimal? KGN
		{ get; set; }

		public decimal? KilosNetos
		{ get; set; }

		public decimal? KilosBrutos
		{ get; set; }

		public decimal? CantidadSalidaAlmacen
		{ get; set; }

		public decimal? KilosNetosSalidaAlmacen
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
		/// Gets or sets the TipoProduccionId value.
		/// </summary>
		public string Observacion
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


		public int? LiquidacionProcesoPlantaId
		{ get; set; }

		#endregion
	}
}
