using System;

namespace CoffeeConnect.Models
{
	public class GuiaRemisionAlmacenDetalleTipo
	{
		#region Properties
		public int GuiaRemisionAlmacenId { get; set; }
		public int LoteId { get; set; }

		

		
		public String NumeroLote { get; set; }
		public String NumeroNotaIngreso { get; set; }
		public String ProductoId { get; set; }
		public String SubProductoId { get; set; }
		public String UnidadMedidaIdPesado { get; set; }
		public Decimal CantidadPesado { get; set; }

		public Decimal KilosBrutosPesado { get; set; }		
		

		public Decimal RendimientoPorcentaje { get; set; }
		public Decimal HumedadPorcentaje { get; set; }

		public int NotaIngresoAlmacenId { get; set; }
		#endregion
	}
}
