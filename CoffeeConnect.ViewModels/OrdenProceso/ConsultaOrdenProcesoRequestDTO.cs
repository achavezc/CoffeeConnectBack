using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class ConsultaOrdenProcesoRequestDTO
    {
        public ConsultaOrdenProcesoRequestDTO()
        {

        }

        public string Numero { get; set; }
        public string RucEmpresaProcesadora { get; set; }
        public string NumeroContrato { get; set; }
        public string RazonSocialEmpresaProcesadora { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string NumeroCliente { get; set; }
        public string RazonSocialCliente { get; set; }
        public string TipoProcesoId { get; set; }
        public string EstadoId { get; set; }
        public int EmpresaId { get; set; }
    }
}
