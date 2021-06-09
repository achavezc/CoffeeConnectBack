using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class ConsultaLiquidacionProcesoPlantaRequestDTO
    {
        public ConsultaLiquidacionProcesoPlantaRequestDTO()
        {

        }

        public string Numero { get; set; }
        public string RucOrganizacion { get; set; }
        public string NumeroContrato { get; set; }
        public string RazonSocialOrganizacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }      
        public string TipoProcesoId { get; set; }
        public string EstadoId { get; set; }
        public int EmpresaId { get; set; }
    }
}
