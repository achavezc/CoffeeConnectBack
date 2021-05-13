using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class ConsultaOrdenProcesoPorIdResponseDTO
    {
        public ConsultaOrdenProcesoPorIdResponseDTO()
        {
            Result = new Result();
        }
        public Result Result { get; set; }
    }
}
