using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
   public class ConsultaSocioRequestDTO
    {

        public String Codigo { get; set; }

        public String NombreRazonSocial { get; set; }

        public String TipoDocumentoId { get; set; }

        public String NumeroDocumento { get; set; }       

        public string EstadoId { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public int EmpresaId { get; set; }

    }
}
