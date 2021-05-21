using System;

namespace CoffeeConnect.DTO
{
	public class RegistrarActualizarProductoPrecioDiaRequestDTO
	{
		#region Properties
		/// <summary>
		/// Gets or sets the ProductoPrecioDiaId value.
		/// </summary>
		public int ProductoPrecioDiaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaId value.
		/// </summary>
		public int EmpresaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the ProductoId value.
		/// </summary>
		public string ProductoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the SubProductoId value.
		/// </summary>
		public string SubProductoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Fecha value.
		/// </summary>
		public DateTime Fecha
		{ get; set; }

		/// <summary>
		/// Gets or sets the PrecioDia value.
		/// </summary>
		public decimal PrecioDia
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
