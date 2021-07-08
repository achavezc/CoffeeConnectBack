using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
	public class RegistrarActualizarAduanaRequestDTO
	{
		#region Properties
		/// <summary>
		/// Gets or sets the AduanaId value.
		/// </summary>
		public int AduanaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the ContratoId value.
		/// </summary>
		public int ContratoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaExportadoraId value.
		/// </summary>
		public int EmpresaExportadoraId
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaProductoraId value.
		/// </summary>
		public int EmpresaProductoraId
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


		public DateTime FechaEmbarque
		{ get; set; }

		public DateTime? FechaFacturacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the Marca value.
		/// </summary>
		public string Marca
		{ get; set; }

		/// <summary>
		/// Gets or sets the PO value.
		/// </summary>
		public string PO
		{ get; set; }

		/// <summary>
		/// Gets or sets the LaboratorioId value.
		/// </summary>
		public string LaboratorioId
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaEnvioMuestra value.
		/// </summary>
		public DateTime FechaEnvioMuestra
		{ get; set; }

		/// <summary>
		/// Gets or sets the NumeroSeguimientoMuestra value.
		/// </summary>
		public string NumeroSeguimientoMuestra
		{ get; set; }

		/// <summary>
		/// Gets or sets the EstadoMuestraId value.
		/// </summary>
		public string EstadoMuestraId
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaRecepcionMuestra value.
		/// </summary>
		public DateTime FechaRecepcionMuestra
		{ get; set; }



		/// <summary>
		/// Gets or sets the NavieraId value.
		/// </summary>
		public string NavieraId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Observacion value.
		/// </summary>
		public string Observacion
		{ get; set; }

		
		/// <summary>
		/// Gets or sets the FechaRegistro value.
		/// </summary>
		
		/// <summary>
		/// Gets or sets the UsuarioRegistro value.
		/// </summary>
		public string Usuario
		{ get; set; }

		public int EmpresaAgenciaAduaneraId
		{ get; set; }




		public List<ActualizarAduanaCertificacionRequestDTO> Certificaciones { get; set; }



		#endregion
	}
}
