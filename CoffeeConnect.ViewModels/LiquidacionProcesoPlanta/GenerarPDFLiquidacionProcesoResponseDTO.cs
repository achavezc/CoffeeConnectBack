using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class GenerarPDFLiquidacionProcesoResponseDTO
    {
        public GenerarPDFLiquidacionProcesoResponseDTO()
        {
            Result = new Result();
            data = new ConsultaLiquidacionProcesoPlantaPorIdBE();
        }

        public Result Result { get; set; }
        public ConsultaLiquidacionProcesoPlantaPorIdBE data { get; set; }
    }
}
