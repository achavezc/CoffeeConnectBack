using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class ConsultaLiquidacionProcesoPlantaResultadoBE
    {
        public ConsultaLiquidacionProcesoPlantaResultadoBE()
        {

        }

        public int LiquidacionProcesoPlantaResultadoId { get; set; }
        public int LiquidacionProcesoPlantaId { get; set; }
        public string ReferenciaId { get; set; }
        public string Referencia { get; set; }
        public decimal CantidadSacos { get; set; }
        public decimal KGN { get; set; }
        public decimal KilosNetos { get; set; }
        public decimal Porcentaje { get; set; }

        public decimal KilosBrutos
        { get; set; }

        public decimal Tara
        { get; set; }


        public string EmpaqueId
        { get; set; }


        public string TipoId
        { get; set; }
    }
}
