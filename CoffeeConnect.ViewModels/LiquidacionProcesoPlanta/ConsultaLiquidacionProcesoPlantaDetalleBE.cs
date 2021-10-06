using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class ConsultaLiquidacionProcesoPlantaDetalleBE
    {
        public ConsultaLiquidacionProcesoPlantaDetalleBE()
        {

        }

        public int LiquidacionProcesoPlantaDetalleId { get; set; }
        public int LiquidacionProcesoPlantaId { get; set; }
        public int NotaIngresoPlantaId { get; set; }
        public string NumeroNotaIngresoPlanta { get; set; }
        public DateTime FechaNotaIngresoPlanta { get; set; }
        public decimal RendimientoPorcentaje { get; set; }
        public decimal HumedadPorcentaje { get; set; }
        public decimal Cantidad { get; set; }
        public decimal KilosBrutos { get; set; }
        public decimal Tara { get; set; }
        public decimal KilosNetos { get; set; }
    }
}
