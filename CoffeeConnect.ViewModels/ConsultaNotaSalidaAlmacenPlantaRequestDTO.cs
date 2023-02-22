using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
   public class ConsultaNotaSalidaAlmacenPlantaRequestDTO
    {

        public String Numero { get; set; }
        public int? EmpresaIdDestino { get; set; }
        public int? EmpresaTransporteId { get; set; }
        public String AlmacenId { get; set; }
        public string CodigoTipoConcepto { get; set; }
        public string CodigoCampania { get; set; }

        public String EstadoId { get; set; }
        public String MotivoSalidaId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int EmpresaId { get; set; }

    }
}
