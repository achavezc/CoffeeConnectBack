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
            DatosPDf = new List<DatosPDf>();
        }

        public Result Result { get; set; }
        public IList<DatosPDf> DatosPDf { get; set; }
    }

    public class DatosPDf
    {
        public string Empresa { get; set; }
    }
}
