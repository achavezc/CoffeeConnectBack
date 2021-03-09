using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
   public class RegistrarNotaSalidaAlmacenDetalleRequestDTO
	{
		public int NotaSalidaAlmacenId { get; set; }
        public List<NotaSalidaAlmacenDetalleDTO> ListNotaSalidaAlmacenDetalle { get; set; }

        public RegistrarNotaSalidaAlmacenDetalleRequestDTO() {
            ListNotaSalidaAlmacenDetalle = new List<NotaSalidaAlmacenDetalleDTO>();

        }
    }
}
