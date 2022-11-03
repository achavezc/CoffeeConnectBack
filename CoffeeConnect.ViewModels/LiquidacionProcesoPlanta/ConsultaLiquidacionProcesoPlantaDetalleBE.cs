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

        public int LiquidacionProcesoPlantaId { get; set; }
        public int LiquidacionProcesoPlantaDetalleId { get; set; }
        public int NotaIngresoAlmacenPlantaId { get; set; }
        public string Descripcion { get; set; }  
        public decimal PorcentajeHumedad { get; set; }
        public decimal Cantidad { get; set; } 
        public decimal KilosNetos { get; set; }
    }
}
