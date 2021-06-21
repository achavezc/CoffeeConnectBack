using System;

namespace CoffeeConnect.Models
{
	public class DetalleCatalogo
	{
		#region Properties
		/// <summary>
		/// Gets or sets the IdDetalleCatalogo value.
		/// </summary>
		public int IdDetalleCatalogo
		{ get; set; }

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
		/// Gets or sets the Label value.
		/// </summary>
		public string Label
		{ get; set; }

		/// <summary>
		/// Gets or sets the Descripcion value.
		/// </summary>
		public string Descripcion
		{ get; set; }

		/// <summary>
		/// Gets or sets the Mnemonico value.
		/// </summary>
		public string Mnemonico
		{ get; set; }

		/// <summary>
		/// Gets or sets the Val1 value.
		/// </summary>
		public string Val1
		{ get; set; }

		/// <summary>
		/// Gets or sets the Val2 value.
		/// </summary>
		public string Val2
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaID value.
		/// </summary>
		public int EmpresaID
		{ get; set; }

		/// <summary>
		/// Gets or sets the UsuarioCreacion value.
		/// </summary>
		public string UsuarioCreacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaHoraCreacion value.
		/// </summary>
		public DateTime? FechaHoraCreacion
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
		/// Gets or sets the CodigoPadre value.
		/// </summary>
		public string CodigoPadre
		{ get; set; }

		#endregion
	}
}
