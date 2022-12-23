using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class ConsultaPagoServicioPlantaRequestDTO
    {
        public ConsultaPagoServicioPlantaRequestDTO()
        {

        }

        public string Numero { get; set; }
        public string NumeroOperacion { get; set; }
        
        public string TipoOperacionPagoServicioId { get; set; }

        public string BancoId { get; set; }

        public string MonedaId { get; set; }

        public int ServicioPlantaId { get; set; }

         


        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }      
         
        public string EstadoId { get; set; }
        public int EmpresaId { get; set; }
    }
}
