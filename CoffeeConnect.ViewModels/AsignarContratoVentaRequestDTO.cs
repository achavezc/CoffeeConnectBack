using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
   public class AsignarContratoVentaRequestDTO
    {
        public int EmpresaId { get; set; }

        public int ContratoCompraId { get; set; }
        public int ContratoVentaId { get; set; }
        public String Usuario { get; set; }

        


    }
}
