using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class ConsultarPrecioDiaRendimientoRequestDTO
    {
        public ConsultarPrecioDiaRendimientoRequestDTO()
        {

        }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string EstadoId { get; set; }
    }
}
