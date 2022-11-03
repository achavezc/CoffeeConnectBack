using System;

namespace CoffeeConnect.Models
{
	public class LiquidacionProcesoPlanta
	{
		#region Properties
		/// <summary>
		/// Gets or sets the LiquidacionProcesoPlantaId value.
		/// </summary>
		public int LiquidacionProcesoPlantaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the OrdenProcesoPlantaId value.
		/// </summary>
		public int OrdenProcesoPlantaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Numero value.
		/// </summary>
		public string Numero
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaId value.
		/// </summary>
		public int EmpresaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Observacion value.
		/// </summary>
		public string Observacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the EnvasesProductos value.
		/// </summary>
		public string EnvasesProductos
		{ get; set; }

		public decimal? NumeroDefectos
		{ get; set; }

		

		/// <summary>
		/// Gets or sets the TrabajosRealizados value.
		/// </summary>
		public string TrabajosRealizados
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
		/// Gets or sets the Activo value.
		/// </summary>
		public bool Activo
		{ get; set; }


		public string ProductoId
		{ get; set; }

		public string ProductoIdTerminado
		{ get; set; }

		public string EntidadCertificadoraId
		{ get; set; }

		

		public DateTime FechaInicioProceso
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaRegistro value.
		/// </summary>
		public DateTime FechaFinProceso
		{ get; set; }



		#endregion
	}
}
