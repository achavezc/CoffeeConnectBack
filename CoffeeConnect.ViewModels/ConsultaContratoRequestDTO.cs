using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
   public class ConsultaContratoRequestDTO
    {       
        
        public String Numero { get; set; }

        public String NumeroCliente { get; set; }

        public String RazonSocial { get; set; }

        public String ProductoId { get; set; }

        public String TipoProduccionId { get; set; }

        public String CalidadId { get; set; }

        public String EstadoId { get; set; }       

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }       

    }
}
