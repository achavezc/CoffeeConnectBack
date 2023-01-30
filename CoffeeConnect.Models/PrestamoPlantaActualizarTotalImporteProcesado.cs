using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Models
{
  public   class PrestamoPlantaActualizarImporteProcesado
	{
		#region Properties
		/// <summary>
		/// Gets or sets the ServicioPlantaId value.
		/// </summary>
		public int PrestamoPlantaId
		{ get; set; }

		 

		/// <summary>
		/// Gets or sets the Numero value.
		/// </summary>
		public string EstadoId
		{ get; set; }

		public decimal  ImporteProcesado { get; set; }

		

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

		/// <summary>
		/// Gets or sets the Activo value.
		/// </summary>
		public bool Activo
		{ get; set; }

		#endregion
	}
}
