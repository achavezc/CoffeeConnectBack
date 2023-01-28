using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class ConsultaPrestamoPlantaRequestDTO
    {
        public ConsultaPrestamoPlantaRequestDTO()
        {

        }

        public string Numero { get; set; }

        
        public string FondoPrestamoId { get; set; }

        public string DetallePrestamo { get; set; }

         

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }      
         
        public string EstadoId { get; set; }
        public int EmpresaId { get; set; }
    }
}
