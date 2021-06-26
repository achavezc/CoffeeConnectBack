using System;

namespace CoffeeConnect.DTO
{
	public class ConsultaUbigeoPorIdBE
	{
		#region Properties
		/// <summary>
		/// Gets or sets the IdUbigeo value.
		/// </summary>
		public int IdUbigeo
		{ get; set; }

		/// <summary>
		/// Gets or sets the Codigo value.
		/// </summary>
		public string Codigo
		{ get; set; }

		/// <summary>
		/// Gets or sets the Descripcion value.
		/// </summary>
		public string Descripcion
		{ get; set; }

		/// <summary>
		/// Gets or sets the UsuarioCreacion value.
		/// </summary>
		public string UsuarioCreacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaHoraCreacion value.
		/// </summary>
		public DateTime FechaHoraCreacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the UsuarioActualizacion value.
		/// </summary>
		public string UsuarioActualizacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaHoraActualizacion value.
		/// </summary>
		public DateTime? FechaHoraActualizacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the EstadoRegistro value.
		/// </summary>
		public bool EstadoRegistro
		{ get; set; }

		/// <summary>
		/// Gets or sets the CodigoPais value.
		/// </summary>
		public string CodigoPais
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaId value.
		/// </summary>
		public int EmpresaId
		{ get; set; }

		#endregion
	}
}
