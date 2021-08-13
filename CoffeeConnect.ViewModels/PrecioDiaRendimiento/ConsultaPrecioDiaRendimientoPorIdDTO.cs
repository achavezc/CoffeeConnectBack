using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
	public class ConsultaPrecioDiaRendimientoPorIdDTO
	{
		#region Properties

		public int PrecioDiaRendimientoId
		{ get; set; }

		public decimal TipoCambio
		{ get; set; }

		public decimal PrecioPromedioContrato
		{ get; set; }

		public DateTime FechaRegistro
		{ get; set; }		

		public List<ConsultaPrecioDiaRendimientoDetalleBE> PrecioDiaRendimientoDetalle
		{ get; set; }




		#endregion
	}
}
