using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class CalculoPrecioDiaRendimientoBE
    {
        public CalculoPrecioDiaRendimientoBE()
        {

        }

        public decimal RendimientoInicio { get; set; }
        public decimal RendimientoFin { get; set; }
        public decimal KGPergamino { get; set; }
        public decimal PrecioDia { get; set; }
     
        
    }
}
