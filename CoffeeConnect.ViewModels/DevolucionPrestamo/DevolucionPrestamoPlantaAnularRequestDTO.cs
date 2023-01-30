using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class DevolucionPrestamoPlantaAnularRequestDTO
    { 
        public int DevolucionPrestamoPlantaId { get; set; }
        public int PrestamoPlantaId { get; set; }

        public string ObservacionAnulacion { get; set; }

        public decimal Importe { get; set; }

        public string Usuario { get; set; }
    }
}
