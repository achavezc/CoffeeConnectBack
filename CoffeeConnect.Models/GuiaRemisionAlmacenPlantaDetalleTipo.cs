using System;

namespace CoffeeConnect.Models
{
	public class GuiaRemisionAlmacenPlantaDetalleTipo
	{
		#region Properties
		public int GuiaRemisionAlmacenPlantaId { get; set; }
		public int NotaIngresoAlmacenPlantaId { get; set; }
		
		public String NumeroNotaIngresoAlmacenPlanta { get; set; }
		
		public String ProductoId { get; set; }
		public String SubProductoId { get; set; }
		public String UnidadMedidaIdPesado { get; set; }
		public Decimal CantidadPesado { get; set; }

		public Decimal KilosNetosPesado { get; set; }

		public Decimal KilosBrutosPesado { get; set; }			

		public Decimal CantidadDefectos { get; set; }

		public Decimal TaraPesado { get; set; }

		


		public String SubCalidadId { get; set; }

		public String SubGradoId { get; set; }

		#endregion
	}
}
