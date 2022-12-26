using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class RegistrarActualizarPagoServicioPlantaRequestDTO
    {
		public int PagoServicioPlantaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaId value.
		/// </summary>
		public int EmpresaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the ServicioPlantaId value.
		/// </summary>
		public int ServicioPlantaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Numero value.
		/// </summary>
		public string Numero
		{ get; set; }

		/// <summary>
		/// Gets or sets the NumeroOperacion value.
		/// </summary>
		public string NumeroOperacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the TipoOperacionPagoServicioId value.
		/// </summary>
		public string TipoOperacionPagoServicioId
		{ get; set; }

		/// <summary>
		/// Gets or sets the BancoId value.
		/// </summary>
		public string BancoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaOperacion value.
		/// </summary>
		public DateTime FechaOperacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the Importe value.
		/// </summary>
		public decimal Importe
		{ get; set; }

		/// <summary>
		/// Gets or sets the MonedaId value.
		/// </summary>
		public string MonedaId
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

		 
	}
}
