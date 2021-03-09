using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
   public class ActualizarNotaIngresoAlmacenRequestDTO
    {
        public int NotaIngresoAlmacenId { get; set; }
        public String Usuario { get; set; }
        public String AlmacenId { get; set; }

    }
}
