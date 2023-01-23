using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class PagoServicioPlantaAnularRequestDTO
    {
        public PagoServicioPlantaAnularRequestDTO()
        {

        }

        public int PagoServicioPlantaId { get; set; }

        public int ServicioPlantaId { get; set; }

        public decimal Importe { get; set; }

        public string Usuario { get; set; }

        public string ObservacionAnulacion { get; set; }
        
        
    }
}
