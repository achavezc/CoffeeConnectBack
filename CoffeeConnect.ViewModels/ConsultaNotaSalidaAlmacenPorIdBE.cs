using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
	public class ConsultaNotaSalidaAlmacenPorIdBE
	{
		#region Properties
		/// <summary>
		/// Gets or sets the GuiaRecepcionMateriaPrimaId value.
		/// </summary>
		public int NotaSalidaId
		{ get; set; }

		public int EmpresaId
		{ get; set; }		

		/// <summary>
		/// Gets or sets the Numero value.
		/// </summary>
		public string Numero
		{ get; set; }


		public DateTime FechaRegistro
		{ get; set; }



		#endregion
	}
}
