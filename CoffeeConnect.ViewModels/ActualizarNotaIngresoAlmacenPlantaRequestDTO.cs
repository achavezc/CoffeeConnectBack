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
        public int ControlCalidadPlantaId { get; set; }
        public string AlmacenId { get; set; }

        public string EstadoId { get; set; }

        public string TipoId { get; set; }

        public string EmpaqueId { get; set; }

        public decimal Cantidad { get; set; }
        public decimal PesoBruto { get; set; }

        public decimal Tara { get; set; }

        public decimal KilosNetos { get; set; }




        public String Usuario { get; set; }
        

    }
}
