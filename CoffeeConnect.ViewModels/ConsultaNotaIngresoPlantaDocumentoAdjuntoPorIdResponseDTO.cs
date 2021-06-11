using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{   

    public class ConsultaNotaIngresoPlantaDocumentoAdjuntoPorIdResponseDTO
    {
        public ConsultaNotaIngresoPlantaDocumentoAdjuntoPorIdResponseDTO()
        {
            this.Result = new Result();
        }
        public Result Result { get; set; }
    }
}
