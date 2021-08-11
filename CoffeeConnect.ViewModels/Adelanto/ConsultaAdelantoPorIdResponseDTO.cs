using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO.Adelanto
{
    public class ConsultaAdelantoPorIdResponseDTO
    {
        public ConsultaAdelantoPorIdResponseDTO()
        {
            this.Result = new Result();
        }
        public Result Result { get; set; }
    }
}
