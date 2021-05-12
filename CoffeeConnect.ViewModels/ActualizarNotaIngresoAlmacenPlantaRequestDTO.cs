using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
   public class ActualizarNotaIngresoAlmacenPlantaRequestDTO
    {
        public int NotaIngresoAlmacenPlantaId { get; set; }
        public String Usuario { get; set; }
        public String AlmacenId { get; set; }

    }
}
