using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
	public class ConsultaGuiaRemisionAlmacenPlantaDetalle
	{
		#region Properties
		public int GuiaRemisionAlmacenPlantaDetalleId { get; set; }
		public int GuiaRemisionAlmacenPlantaId { get; set; }
		public int NotaIngresoAlmacenPlantaId { get; set; }
		public String NumeroNotaIngresoAlmacenPlanta { get; set; }	
		public String ProductoId { get; set; }
		public String Producto { get; set; }
		public String SubProductoId { get; set; }
		public String SubProducto { get; set; }
		public String UnidadMedidaIdPesado { get; set; }
		public String UnidadMedida { get; set; }

		public String GradoId { get; set; }

		public String Grado { get; set; }

		public String CalidadId { get; set; }

		public String Calidad { get; set; }

		public Decimal CantidadPesado { get; set; }

		public Decimal CantidadDefectos { get; set; }


		public Decimal KilosBrutosPesado { get; set; }

		public Decimal KilosNetosPesado { get; set; }

		public String TipoProduccionId { get; set; }

		public String TipoCertificacionId { get; set; }

		public String TipoProduccion { get; set; }

		public String TipoCertificacion { get; set; }
	


		#endregion
	}
}
