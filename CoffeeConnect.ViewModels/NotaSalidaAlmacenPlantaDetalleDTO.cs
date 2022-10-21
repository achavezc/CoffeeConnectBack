using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
   public class NotaSalidaAlmacenPlantaDetalleDTO
	{
		public int? NotaIngresoAlmacenPlantaId { get; set; }
		public int? NotaSalidaAlmacenPlantaDetalleId { get; set; }

		public string EmpaqueId
		{ get; set; }

		public string TipoId
		{ get; set; }


		public decimal Cantidad
		{ get; set; }

		public decimal PesoKilosBrutos
		{ get; set; }

		public decimal PesoKilosNetos
		{ get; set; }

		public decimal Tara
		{ get; set; }

	}
}
