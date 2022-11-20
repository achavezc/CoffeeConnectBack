using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
    public class RegistrarActualizarLiquidacionProcesoPlantaRequestDTO
    {
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

		public string CertificacionId
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
		/// Gets or sets the UsuarioRegistro value.
		/// </summary>
		public string Usuario
		{ get; set; }

		public decimal? NumeroDefectos
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



		public List<LiquidacionProcesoPlantaDetalle> LiquidacionProcesoPlantaDetalle { get; set; }
		public List<LiquidacionProcesoPlantaResultado> LiquidacionProcesoPlantaResultado { get; set; }
	}
}
