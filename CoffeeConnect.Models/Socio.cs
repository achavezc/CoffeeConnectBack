using System;

namespace CoffeeConnect.Models
{
	public class Socio
	{
		#region Properties
		/// <summary>
		/// Gets or sets the SocioId value.
		/// </summary>
		public int SocioId
		{ get; set; }

		/// <summary>
		/// Gets or sets the ProductorId value.
		/// </summary>
		public int ProductorId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Codigo value.
		/// </summary>
		public string Codigo
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaRegistro value.
		/// </summary>
		public DateTime FechaRegistro
		{ get; set; }

		public int EmpresaId { get; set; }

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

		

		public string EstadoId { get; set; }

		#endregion
	}
}
