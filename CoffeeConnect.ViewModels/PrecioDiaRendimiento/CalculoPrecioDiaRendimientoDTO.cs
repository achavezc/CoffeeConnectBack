using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
	public class CalculoPrecioDiaRendimientoDTO
	{
		#region Properties

		public double PrecioPromedioContrato
		{ get; set; }

		public double TipoCambio
		{ get; set; }		

		public List<CalculoPrecioDiaRendimientoBE> CalculoPrecioDiaRendimiento
		{ get; set; }




		#endregion
	}
}
