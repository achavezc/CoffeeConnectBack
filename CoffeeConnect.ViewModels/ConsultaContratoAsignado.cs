
using System;

using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class ConsultaContratoAsignado
    {
        #region Properties

        public int ContratoId
        { get; set; }
               

        public decimal? SaldoPendienteKGPergaminoAsignacion
        { get; set; }

        public decimal? PorcentajeRendimientoAsignacion
        { get; set; }


        public decimal? TotalKGPergaminoAsignacion
        { get; set; }



        #endregion
    }
}
