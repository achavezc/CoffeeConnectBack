using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class ConsultaKardexProcesoRequestDTO
    {
        public String NumeroContrato { get; set; }
        public String NumeroCliente { get; set; }
        public String RazonSocial { get; set; }

        public String PlantaProcesoAlmacenId { get; set; }
        public String TipoDocumentoInternoId { get; set; }

        public String TipoOperacionId { get; set; }

        public String CalidadId { get; set; }
        public String TipoCertificacionId { get; set; }

        public String EstadoId { get; set; }

        public int EmpresaId { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

    }
}
