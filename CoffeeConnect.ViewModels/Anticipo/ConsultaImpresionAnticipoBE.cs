using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO.Anticipo
{
    public class ConsultaImpresionAnticipoBE
    {
       
        public string NumeroAnticipo { get; set; }

       public string MonedaAnticipo { get; set; }
        public decimal ImporteAnticipo { get; set; }
        public String FechaPagoString { get; set; }
        public string EstadoAnticipo { get; set; }
       
    }
}
