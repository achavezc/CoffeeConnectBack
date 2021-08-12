using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
   public class AsignarAcopioContratoRequestDTO
    {
        public int EmpresaId { get; set; }

        public int ContratoId { get; set; }
        public String Usuario { get; set; }

        public decimal KGPergaminoAsignacion { get; set; }
        public decimal PorcentajeRendimientoAsignacion { get; set; }
        public decimal TotalKGPergaminoAsignacion { get; set; }


    }
}
