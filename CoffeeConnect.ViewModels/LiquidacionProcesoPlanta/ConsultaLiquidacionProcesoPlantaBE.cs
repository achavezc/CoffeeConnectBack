using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class ConsultaLiquidacionProcesoPlantaBE
    {
        public ConsultaLiquidacionProcesoPlantaBE()
        {
            
        }

        public int LiquidacionProcesoPlantaId { get; set; }

        public int OrdenProcesoPlantaId { get; set; }

        

        public int EmpresaId { get; set; }






        public int? OrdenProcesoId { get; set; }
        
        public int OrganizacionId { get; set; }
        public string TipoProcesoId { get; set; }
        public int? ContratoId { get; set; }
        public string Numero { get; set; }
        public string NumeroOrdenProcesoPlanta { get; set; }

        public string NumeroContrato { get; set; }

        public string RucOrganizacion { get; set; }
       
        public string RazonOrganizacion { get; set; }
        public string TipoProceso { get; set; }
        public string EstadoId { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaUltimaActualizacion { get; set; }

        public DateTime? FechaInicioProceso { get; set; }

        public DateTime? FechaFinProceso { get; set; }


        

            
        public string UsuarioUltimaActualizacion { get; set; }
    }
}
