using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class ActualizarNotaIngresoProductoTerminadoAlmacenPlantaRequestDTO
    {
        public ActualizarNotaIngresoProductoTerminadoAlmacenPlantaRequestDTO()
        {

        }

        public int NotaIngresoProductoTerminadoAlmacenPlantaId { get; set; }
        public string Usuario { get; set; }

        public string AlmacenId { get; set; }
    }
}
