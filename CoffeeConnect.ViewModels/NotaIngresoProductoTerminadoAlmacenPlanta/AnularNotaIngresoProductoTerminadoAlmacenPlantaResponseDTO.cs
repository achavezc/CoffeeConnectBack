using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class AnularNotaIngresoProductoTerminadoAlmacenPlantaResponseDTO
    {
        public AnularNotaIngresoProductoTerminadoAlmacenPlantaResponseDTO()
        {
            Result = new Result();
        }

        public Result Result { get; set; }
    }
}
