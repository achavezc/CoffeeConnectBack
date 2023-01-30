using System;

namespace CoffeeConnect.DTO
{
	public class RegistrarActualizarDevolucionPrestamoPlantaRequestDTO
	{
		#region Properties
		/// <summary>
		/// Gets or sets the ServicioPlantaId value.
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
		/// Gets or sets the UsuarioRegistro value.
		/// </summary>
		public string Usuario
		{ get; set; }

		



		#endregion
	}
}
