using System;

namespace CoffeeConnect.DTO
{
	public class ConsultaCatalogoTablasBE
	{
		#region Properties
		/// <summary>
		/// Gets or sets the IdCatalogo value.
		/// </summary>
		public int IdCatalogo
		{ get; set; }

		/// <summary>
		/// Gets or sets the Codigo value.
		/// </summary>
		public string Codigo
		{ get; set; }

		/// <summary>
		/// Gets or sets the Nombre value.
		/// </summary>
		public string Nombre
		{ get; set; }

		/// <summary>
		/// Gets or sets the Descripcion value.
		/// </summary>
		public string Descripcion
		{ get; set; }

		/// <summary>
		/// Gets or sets the CodigoTabla value.
		/// </summary>
		public string CodigoTabla
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
		public DateTime FechaHoraActualizacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the Activo value.
		/// </summary>
		public bool Activo
		{ get; set; }

		/// <summary>
		/// Gets or sets the UltimoCambio value.
		/// </summary>
		public DateTime UltimoCambio
		{ get; set; }

		/// <summary>
		/// Gets or sets the IdCatalogoPadre value.
		/// </summary>
		public int IdCatalogoPadre
		{ get; set; }

		/// <summary>
		/// Gets or sets the CodigoTablaPadre value.
		/// </summary>
		public string CodigoTablaPadre
		{ get; set; }

		#endregion
	}
}
