using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
   public class LiquidarNotaCompraRequestDTO
    {

        public int NotaCompraId { get; set; }
        public String Usuario { get; set; }
		
		public decimal? PrecioDia
		{ get; set; }

		/// <summary>
		/// Gets or sets the Importe value.
		/// </summary>
		public decimal? Importe
		{ get; set; }


	}
}
