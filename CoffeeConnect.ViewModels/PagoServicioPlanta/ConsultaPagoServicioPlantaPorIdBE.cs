using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class ConsultaPagoServicioPlantaPorIdBE
    {
        public ConsultaPagoServicioPlantaPorIdBE()
        {
            
        }

        public int ServicioPlantaId { get; set; }

        public int EmpresaId { get; set; }

        public int PagoServicioPlantaId { get; set; }       

        public string Numero { get; set; }

        public string NumeroOperacion { get; set; }

        public string TipoOperacionPagoServicioId { get; set; }
 
        public string BancoId { get; set; }
 

        public DateTime FechaOperacion { get; set; }

        public string MonedaId { get; set; }
 

        public decimal Importe
        { get; set; }

        public string Observaciones { get; set; }

        public string EstadoId { get; set; }

        public string Estado { get; set; }
       
        public DateTime FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaUltimaActualizacion { get; set; }       

        public string UsuarioUltimaActualizacion { get; set; }


    }
}
