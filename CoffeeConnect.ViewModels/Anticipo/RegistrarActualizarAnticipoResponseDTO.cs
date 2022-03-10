using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO.Anticipo
{
    public class RegistrarActualizarAnticipoResponseDTO
    { 
    
          public RegistrarActualizarAnticipoResponseDTO()
        {
            this.Result = new Result();
        }
        public Result Result { get; set; }
    }
}
