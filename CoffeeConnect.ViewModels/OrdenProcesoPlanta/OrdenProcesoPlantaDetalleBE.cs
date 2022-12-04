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
       
        public int NotaIngresoAlmacenPlantaId { get; set; }

        
        
        public string NumeroIngresoAlmacenPlanta { get; set; }
 


        public string FechaIngresoAlmacenString { get; set; }

        public DateTime FechaIngresoAlmacen { get; set; }


        public string ProductoId { get; set; }

        public string SubProductoId { get; set; }

        public decimal PorcentajeHumedad { get; set; }

        public decimal Cantidad { get; set; }
        public decimal KilosBrutos { get; set; }

        public decimal CantidadNotaIngreso { get; set; }
        public decimal KilosNetosNotaIngreso { get; set; }

        public decimal KilosNetosExportables { get; set; }


 

        public decimal Tara { get; set; }

        public decimal KilosNetos { get; set; }

        public decimal PorcentajeExportable { get; set; }
	    public decimal PorcentajeDescarte { get; set; }
	    public decimal PorcentajeCascarilla { get; set; }
	    public decimal SacosCalculo { get; set; }


       
         

    }
}
