using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
	public class ConsultaGuiaRemisionAlmacenDetalle
	{
		#region Properties
		public int GuiaRemisionAlmacenDetalleId { get; set; }
		public int GuiaRemisionAlmacenId { get; set; }
		public int LoteId { get; set; }
		public String NumeroLote { get; set; }
		public String NumeroNotaIngreso { get; set; }
		public String ProductoId { get; set; }
		public String Producto { get; set; }
		public String SubProductoId { get; set; }
		public String SubProducto { get; set; }
		public String UnidadMedidaIdPesado { get; set; }
		public String UnidadMedida { get; set; }
		public Decimal CantidadPesado { get; set; }
		public Decimal KilosBrutosPesado { get; set; }
		public Decimal RendimientoPorcentaje { get; set; }
		public Decimal HumedadPorcentaje { get; set; }

		public String AgenciaCertificadora { get; set; }

		public String Certificacion { get; set; }


		#endregion
	}
}
