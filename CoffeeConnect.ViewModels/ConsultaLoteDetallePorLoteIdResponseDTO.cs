using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{   

    public class ConsultaLoteDetallePorLoteIdResponseDTO
    {
        public ConsultaLoteDetallePorLoteIdResponseDTO()
        {
            this.Result = new Result();
        }
        public Result Result { get; set; }
        public Decimal TotalPesoNeto { get; set; }
        public Decimal PromedioRendimiento { get; set; }
        public Decimal PromedioHumedad { get; set; }
    }
}
