using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class ContratoDetalleBE
    {
        public ContratoDetalleBE()
        {
            
        }

        public int ContratoDetalleId { get; set; }

        public int ContratoId { get; set; }
       
        public int ContratoCompraId { get; set; }


        public decimal TotalFacturar1 { get; set; }

        public decimal TotalFacturar3 { get; set; }

        


        public decimal Comision { get; set; }

        public decimal PrecioQQVenta { get; set; }

        public decimal PrecioQQCompra { get; set; }

        public decimal UtilidadBruta { get; set; }

        public decimal UtilidadNeta { get; set; }

       
        


        public decimal GananciaNeta { get; set; }

        public decimal Cantidad { get; set; }

        public decimal KilosNetosQQ { get; set; }

        public decimal CantidadContenedores { get; set; }


        

        public string Numero { get; set; }
 
 
        public DateTime FechaContrato { get; set; }


        public string RucProductor { get; set; }

        public string Productor { get; set; }

        public string CondicionEntregaId { get; set; }


        public string CondicionEntrega { get; set; }

        public string EstadoPagoFacturaId { get; set; }


        public string EstadoPagoFactura { get; set; }


        public decimal TotalContratosAsignados { get; set; }

        public bool ExistePerdida { get; set; }







    }
}
