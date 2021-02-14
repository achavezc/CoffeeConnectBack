using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
   public class ActualizarGuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetalleRequestDTO
	{
		public int GuiaRecepcionMateriaPrimaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the IndicadorDetalleId value.
		/// </summary>
		public string IndicadorDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the IndicadorDetalleDescripcion value.
		/// </summary>
		public string IndicadorDetalleDescripcion
		{ get; set; }

		/// <summary>
		/// Gets or sets the Valor value.
		/// </summary>
		public decimal Valor
		{ get; set; }


	}
}
