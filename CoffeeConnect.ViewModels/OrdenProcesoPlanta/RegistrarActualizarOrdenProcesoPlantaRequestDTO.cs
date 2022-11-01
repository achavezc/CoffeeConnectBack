using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
    public class RegistrarActualizarOrdenProcesoPlantaRequestDTO
    {
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

		public string ProductoIdTerminado
		{ get; set; }

		public string EntidadCertificadoraId
		{ get; set; }

		public DateTime FechaRegistro
		{ get; set; }

		public DateTime? FechaInicioProceso
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaRegistro value.
		/// </summary>
		public DateTime? FechaFinProceso
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

	
		/// <summary>
		/// Gets or sets the UsuarioRegistro value.
		/// </summary>
		public string Usuario
		{ get; set; }

	
		public List<OrdenProcesoPlantaDetalle> OrdenProcesoPlantaDetalle { get; set; }
    }
}
