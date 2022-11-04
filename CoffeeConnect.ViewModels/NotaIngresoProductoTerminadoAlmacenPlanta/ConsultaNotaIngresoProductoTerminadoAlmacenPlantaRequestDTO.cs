using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class ConsultaNotaIngresoProductoTerminadoAlmacenPlantaRequestDTO
    {
        public ConsultaNotaIngresoProductoTerminadoAlmacenPlantaRequestDTO()
        {

        }

        public string Numero { get; set; }

        public string NumeroNotaIngresoPlanta { get; set; }

        public string NumeroGuiaRemision { get; set; }

        public string AlmacenId { get; set; }

        public int EmpresaId { get; set; }


        public string RazonSocialEmpresaOrigen { get; set; }
        
        public string RucEmpresaOrigen { get; set; }

        public DateTime? FechaInicioGuiaRemision { get; set; }
        public DateTime? FechaFinGuiaRemision { get; set; }


        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public string ProductoId { get; set; }

        public string SubProductoId { get; set; }
        public string MotivoIngresoId { get; set; }
        public string EstadoId { get; set; }
       
    }
}
