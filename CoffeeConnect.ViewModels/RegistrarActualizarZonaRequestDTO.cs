using System;

namespace CoffeeConnect.DTO
{
	public class RegistrarActualizarZonaRequestDTO
	{
		#region Properties
		/// <summary>
		/// Gets or sets the ZonaId value.
		/// </summary>
		public int ZonaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Nombre value.
		/// </summary>
		public string Nombre
		{ get; set; }

		/// <summary>
		/// Gets or sets the DistritoId value.
		/// </summary>
		public string DistritoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaId value.
		/// </summary>
		public int EmpresaId
		{ get; set; }

		

		/// <summary>
		/// Gets or sets the UsuarioRegistro value.
		/// </summary>
		public string Usuario
		{ get; set; }

		
		/// <summary>
		/// Gets or sets the EstadoId value.
		/// </summary>
		public string EstadoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Activo value.
		/// </summary>
	
		#endregion
	}
}
