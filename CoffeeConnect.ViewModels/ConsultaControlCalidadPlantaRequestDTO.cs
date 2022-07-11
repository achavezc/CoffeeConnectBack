using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
   public  class ConsultaControlCalidadPlantaRequestDTO
    {
        public String Numero { get; set; }

        public String NumeroGuiaRemision { get; set; }

        public String RazonSocialOrganizacion { get; set; }

        public String RucOrganizacion { get; set; }

        public String ProductoId { get; set; }

        public String MotivoIngresoId { get; set; }

        public String SubProductoId { get; set; }

        public String EstadoId { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public DateTime FechaGuiaRemisionInicio { get; set; }

        public DateTime FechaGuiaRemisionFin { get; set; }

        public int EmpresaId { get; set; }

        public String CodigoCampania { get; set; }

        public String CodigoTipoConcepto { get; set; }
        public string CodigoTipo { get; set; }
    }
}
