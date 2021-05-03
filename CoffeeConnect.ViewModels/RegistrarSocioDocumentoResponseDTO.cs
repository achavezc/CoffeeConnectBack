using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class RegistrarSocioDocumentoResponseDTO
    {
        public RegistrarSocioDocumentoResponseDTO()
        {
            Result = new Result();
        }

        public Result Result { get; set; }
    }
}
