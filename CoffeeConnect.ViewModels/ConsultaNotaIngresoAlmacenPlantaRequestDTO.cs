using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
   public class ConsultaNotaIngresoAlmacenPlantaRequestDTO
    {

        public String Numero { get; set; }

        public String NumeroNotaIngresoPlanta { get; set; }

        public String NumeroControlCalidad { get; set; }

        public String NumeroGuiaRemision { get; set; }

        public string AlmacenId { get; set; }

        public int EmpresaId { get; set; }



        public String NumeroOrganizacion { get; set; }

        public String RazonSocialEmpresaOrigen { get; set; }

        public String RucEmpresaOrigen { get; set; }


        public DateTime? FechaInicioGuiaRemision { get; set; }

        public DateTime? FechaFinGuiaRemision { get; set; }


        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public String ProductoId { get; set; }

        public String SubProductoId { get; set; }

        public String MotivoIngresoId { get; set; }


        public String EstadoId { get; set; }     

       

        public decimal? RendimientoPorcentajeInicio
        { get; set; }

        public decimal? RendimientoPorcentajeFin
        { get; set; }

        public decimal? PuntajeAnalisisSensorialInicio
        { get; set; }

        public decimal? PuntajeAnalisisSensorialFin
        { get; set; }


    }
}
