using System;

namespace CoffeeConnect.DTO
{
	public class ActualizarEmpresaProveedoraAcreedoraCertificacionRequestDTO
	{
		#region Properties
		/// <summary>
		/// Gets or sets the EmpresaProveedoraAcreedoraId value.
		/// </summary>
		public int EmpresaProveedoraAcreedoraId
		{ get; set; }

		/// <summary>
		/// Gets or sets the RazonSocial value.
		/// </summary>
		public string TipoCertificacionId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Ruc value.
		/// </summary>
		public string CodigoCertificacion
		{ get; set; }

		public string EstadoId
		{ get; set; }

		public DateTime? FechaVigencia
		{ get; set; }


		#endregion
	}
}
