using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
   public class ActualizarLoteRequestDTO
    {

        public int LoteId { get; set; }

        public string AlmacenId { get; set; }
        public String Usuario { get; set; }

        public int? ContratoId { get; set; }

        public List<ListaIdsAccion> NotasIngresoAlmacenId { get; set; }

    }
}
