using System;

namespace CoffeeConnect.Models
{
	public class ConsultaProductoPrecioDiaBE
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

		public string MonedaId
		{ get; set; }
		


		public string Producto
		{ get; set; }

		/// <summary>
		/// Gets or sets the SubProductoId value.
		/// </summary>
		public string SubProductoId
		{ get; set; }


		public string SubProducto
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
