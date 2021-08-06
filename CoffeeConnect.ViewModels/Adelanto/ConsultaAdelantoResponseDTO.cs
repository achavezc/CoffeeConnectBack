using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO.Adelanto
{
    public class ConsultaAdelantoResponseDTO
    {
        public ConsultaAdelantoResponseDTO()
        {
            this.Result = new Result();
        }
        public Result Result { get; set; }
    }
}
