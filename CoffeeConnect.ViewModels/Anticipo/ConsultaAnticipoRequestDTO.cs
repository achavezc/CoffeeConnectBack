using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO.Anticipo
{
    public class ConsultaAnticipoRequestDTO
    {
        public string Numero { get; set; }

        public string NumeroNotaIngresoPlanta { get; set; }

        public string RucProveedor { get; set; }

        public string RazonSocialProveedor { get; set; }

        public string EstadoId { get; set; }

        public int EmpresaId { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }
    }
}
