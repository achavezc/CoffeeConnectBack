using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class OrdenProcesoPlantaDetalleBE
    {
        public OrdenProcesoPlantaDetalleBE()
        {
            
        }

        public int OrdenProcesoPlantaDetalleId { get; set; }

        public int OrdenProcesoPlantaId { get; set; }
        public int EmpresaId { get; set; }
        public int NotaIngresoPlantaId { get; set; }

        public string NumeroNotaIngresoPlanta { get; set; }

        public DateTime FechaNotaIngresoPlanta { get; set; }


        public decimal RendimientoPorcentaje { get; set; }
        public decimal HumedadPorcentaje { get; set; }

        public decimal Cantidad { get; set; }
        public decimal KilosBrutos { get; set; }

        public decimal Tara { get; set; }

        public decimal KilosNetos { get; set; }

        public decimal PorcentajeExportable { get; set; }
	    public decimal PorcentajeDescarte { get; set; }
	    public decimal PorcentajeCascarilla { get; set; }
	    public decimal SacosCalculo { get; set; }

    }
}
