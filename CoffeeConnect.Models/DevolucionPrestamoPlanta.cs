using System;

namespace CoffeeConnect.Models
{
	public class DevolucionPrestamoPlanta
	{
		#region Properties
		/// <summary>
		/// Gets or sets the DevolucionPrestamoPlantaId value.
		/// </summary>
		public int DevolucionPrestamoPlantaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaId value.
		/// </summary>
		public int EmpresaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the PrestamoPlantaId value.
		/// </summary>
		public int PrestamoPlantaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Numero value.
		/// </summary>
		public string Numero
		{ get; set; }

		/// <summary>
		/// Gets or sets the DestinoDevolucionId value.
		/// </summary>
		public string DestinoDevolucionId
		{ get; set; }

		/// <summary>
		/// Gets or sets the BancoId value.
		/// </summary>
		public string BancoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaDevolucion value.
		/// </summary>
		public DateTime FechaDevolucion
		{ get; set; }

		/// <summary>
		/// Gets or sets the MonedaId value.
		/// </summary>
		public string MonedaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Importe value.
		/// </summary>
		public decimal Importe
		{ get; set; }

		/// <summary>
		/// Gets or sets the ImporteCambio value.
		/// </summary>
		public decimal ImporteCambio
		{ get; set; }

		/// <summary>
		/// Gets or sets the Observaciones value.
		/// </summary>
		public string Observaciones
		{ get; set; }

		/// <summary>
		/// Gets or sets the EstadoId value.
		/// </summary>
		public string EstadoId
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
		/// Gets or sets the FechaUltimaActualizacion value.
		/// </summary>
		public DateTime FechaUltimaActualizacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the UsuarioUltimaActualizacion value.
		/// </summary>
		public string UsuarioUltimaActualizacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the Activo value.
		/// </summary>
		public bool Activo
		{ get; set; }

		#endregion

	}
}
