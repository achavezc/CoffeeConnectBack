using System;

namespace CoffeeConnect.DTO
{
	public class RegistrarActualizarPrestamoPlantaRequestDTO
	{
		#region Properties
		/// <summary>
		/// Gets or sets the ServicioPlantaId value.
		/// </summary>


		public int PrestamoPlantaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaId value.
		/// </summary>
		public int EmpresaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Numero value.
		/// </summary>
		public string Numero
		{ get; set; }

		/// <summary>
		/// Gets or sets the DetallePrestamo value.
		/// </summary>
		public string DetallePrestamo
		{ get; set; }

		/// <summary>
		/// Gets or sets the FondoPrestamoId value.
		/// </summary>
		public string FondoPrestamoId
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
		/// Gets or sets the Activo value.
		/// </summary>
		public bool Activo
		{ get; set; }

		/// <summary>
		/// Gets or sets the UsuarioRegistro value.
		/// </summary>
		public string Usuario 
		{ get; set; }

		

		#endregion
	}
}
