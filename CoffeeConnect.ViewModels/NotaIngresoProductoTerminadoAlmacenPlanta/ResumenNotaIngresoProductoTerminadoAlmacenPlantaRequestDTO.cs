using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class ResumenNotaIngresoProductoTerminadoAlmacenPlantaRequestDTO
    {
        public ResumenNotaIngresoProductoTerminadoAlmacenPlantaRequestDTO()
        {

        }

       

        public string AlmacenId { get; set; }

        public int EmpresaId { get; set; }


        public string RazonSocialEmpresaOrigen { get; set; }
        
        public string RucEmpresaOrigen { get; set; }
 
        public string ProductoId { get; set; }

        public string SubProductoId { get; set; }
        
    }
}
