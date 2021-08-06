using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO.Adelanto
{
    public class ConsultaAdelantoRequestDTO
    {
        public string Numero { get; set; }

        public string NumeroNotaCompra { get; set; }

        public string CodigoSocio { get; set; }

        public string NombreRazonSocial { get; set; }

        public string TipoDocumentoId { get; set; }

        public string NumeroDocumento { get; set; }
        public string EstadoId { get; set; }

        public int EmpresaId { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }
    }
}
