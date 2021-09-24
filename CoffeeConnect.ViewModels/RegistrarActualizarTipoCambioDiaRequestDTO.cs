using System;

namespace CoffeeConnect.DTO
{
	public class RegistrarActualizarTipoCambioDiaRequestDTO
	{
		#region Properties
		/// <summary>
		/// Gets or sets the TipoCambioDiaId value.
		/// </summary>
		public int TipoCambioDiaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaId value.
		/// </summary>
		public int EmpresaId
		{ get; set; }

	

		/// <summary>
		/// Gets or sets the Fecha value.
		/// </summary>
		public DateTime Fecha
		{ get; set; }

		/// <summary>
		/// Gets or sets the PrecioDia value.
		/// </summary>
		public decimal Monto
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaRegistro value.
		/// </summary>
		public DateTime FechaRegistro
		{ get; set; }

		/// <summary>
		/// Gets or sets the UsuarioRegistro value.
		/// </summary>
	
		/// <summary>
		/// Gets or sets the UsuarioUltimaActualizacion value.
		/// </summary>
		public string Usuario
		{ get; set; }

		/// <summary>
		/// Gets or sets the EstadoId value.
		/// </summary>
		public string EstadoId
		{ get; set; }

	

		#endregion
	}
}
