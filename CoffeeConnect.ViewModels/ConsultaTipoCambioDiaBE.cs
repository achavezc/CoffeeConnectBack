using System;

namespace CoffeeConnect.Models
{
	public class ConsultaTipoCambioDiaBE
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
		public string UsuarioRegistro
		{ get; set; }

		

		/// <summary>
		/// Gets or sets the EstadoId value.
		/// </summary>
		public string EstadoId
		{ get; set; }

		public string Estado
		{ get; set; }

		#endregion
	}
}
