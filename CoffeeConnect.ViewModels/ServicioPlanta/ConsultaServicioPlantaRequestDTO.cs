using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class ConsultaServicioPlantaRequestDTO
    {
        public ConsultaServicioPlantaRequestDTO()
        {

        }

        public string Numero { get; set; }

        
        public string TipoServicioId { get; set; }

        public string TipoComprobanteId { get; set; }

        public string SerieComprobante { get; set; }


        public string NumeroComprobante { get; set; }

        public string RazonSocialEmpresaCliente { get; set; }

        public string RucEmpresaCliente { get; set; }

        public string CodigoCampania { get; set; }


        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }      
         
        public string EstadoId { get; set; }
        public int EmpresaId { get; set; }
    }
}
