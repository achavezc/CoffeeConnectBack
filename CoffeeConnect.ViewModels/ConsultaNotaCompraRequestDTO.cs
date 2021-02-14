using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
   public class ConsultaNotaCompraRequestDTO
    {

        public String Numero { get; set; }

        public String NumeroGuiaRecepcion { get; set; }

        public String NombreRazonSocial { get; set; }

        public String TipoDocumentoId { get; set; }

        public String ProductoId { get; set; }

        public String NumeroDocumento { get; set; }

        public String CodigoSocio { get; set; }

        public String EstadoId { get; set; }

        public String TipoId { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public int EmpresaId { get; set; }

    }
}
