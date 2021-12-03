using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO.Adelanto
{
    public class ConsultaImpresionAdelantoBE
    {
       
        public string NumeroAdelanto { get; set; }

       public string MonedaAdelanto { get; set; }
        public decimal ImporteAdelanto { get; set; }
        public String FechaPagoString { get; set; }
        public string EstadoAdelanto { get; set; }
       
    }
}
