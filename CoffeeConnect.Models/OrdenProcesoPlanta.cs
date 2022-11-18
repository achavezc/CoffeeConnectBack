using System;

namespace CoffeeConnect.Models
{
	public class OrdenProcesoPlanta
	{
		#region Properties
		/// <summary>
		/// Gets or sets the OrdenProcesoPlantaId value.
		/// </summary>
		public int OrdenProcesoPlantaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaId value.
		/// </summary>
		public int EmpresaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the OrganizacionId value.
		/// </summary>
		public int OrganizacionId
		{ get; set; }

		/// <summary>
		/// Gets or sets the TipoProcesoId value.
		/// </summary>
		public string TipoProcesoId
		{ get; set; }


		public string NumeroContrato
		{ get; set; }


		/// <summary>
		/// Gets or sets the Numero value.
		/// </summary>
		public string Numero
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
		

		/// <summary>
		/// Gets or sets the CantidadDefectos value.
		/// </summary>
		public decimal CantidadDefectos
		{ get; set; }

		/// <summary>
	 
		/// <summary>
		/// Gets or sets the NombreArchivo value.
		/// </summary>
		public string NombreArchivo
		{ get; set; }

		/// <summary>
		/// Gets or sets the DescripcionArchivo value.
		/// </summary>
		public string DescripcionArchivo
		{ get; set; }

		/// <summary>
		/// Gets or sets the PathArchivo value.
		/// </summary>
		public string PathArchivo
		{ get; set; }

		/// <summary>
		/// Gets or sets the Observacion value.
		/// </summary>
		public string Observacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the EstadoId value.
		/// </summary>
		public string EstadoId
		{ get; set; }

		public string ProductoId
		{ get; set; }

		public string ProductoIdTerminado
		{ get; set; }

		public string CertificacionId
		{ get; set; }


		public string EntidadCertificadoraId
		{ get; set; }

		public DateTime FechaRegistro
		{ get; set; }

		public DateTime FechaInicioProceso
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaRegistro value.
		/// </summary>
		public DateTime FechaFinProceso
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

		#endregion
	}
}
