using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
   public class ActualizarGuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalleRequestDTO
	{


		/// <summary>
		/// Gets or sets the GuiaRecepcionMateriaPrimaId value.
		/// </summary>
		//public int GuiaRecepcionMateriaPrimaId
		//{ get; set; }

		/// <summary>
		/// Gets or sets the OlorDetalleId value.
		/// </summary>
		public string OlorDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the OlorDetalleDescripcion value.
		/// </summary>
		public string OlorDetalleDescripcion
		{ get; set; }

		/// <summary>
		/// Gets or sets the Valor value.
		/// </summary>
		public bool Valor
		{ get; set; }
	}
}
