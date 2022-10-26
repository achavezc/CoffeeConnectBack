using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class ConsultaOrdenProcesoPlantaPorIdBE
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
		/// Gets or sets the FechaInicioProceso value.
		/// </summary>
		public DateTime? FechaOrdenProceso
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


		public string RazonSocial { get; set; }

		public string Ruc { get; set; }

		public string Logo { get; set; }

		public string Direccion { get; set; }

		public string RucOrganizacion { get; set; }

		public string RazonSocialOrganizacion { get; set; }



		public IEnumerable<OrdenProcesoPlantaDetalleBE> detalle { get; set; }
    }
}
