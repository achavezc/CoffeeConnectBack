using System;

namespace CoffeeConnect.Models
{
	public class NotaIngresoAlmacenPlanta
	{
		#region Properties
		/// <summary>
		/// Gets or sets the NotaIngresoAlmacenPlantaId value.
		/// </summary>
		public int NotaIngresoAlmacenPlantaId
		{ get; set; }

		public int ControlCalidadPlantaId
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
		public string TipoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the ProductoId value.
		/// </summary>
		public string EmpaqueId
		{ get; set; }


		/// <summary>
		/// Gets or sets the CantidadPesado value.
		/// </summary>
		public decimal Cantidad
		{ get; set; }

		public decimal PesoBruto
		{ get; set; }

		public decimal Tara
		{ get; set; }

		public decimal KilosNetos
		{ get; set; }

		public decimal? CantidadDisponible
		{ get; set; }

		public decimal? KilosNetosDisponibles
		{ get; set; }

		public decimal? CantidadOrdenProceso
		{ get; set; }

		public decimal? KilosNetosOrdenProceso
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

		#endregion
	}
}
