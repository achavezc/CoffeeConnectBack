using System;
using System.Collections.Generic;

namespace CoffeeConnect.Models
{
    public class ContratoDetalle
    {
        #region Properties
        /// <summary>
        /// Gets or sets the OrdenProcesoId value.
        /// </summary>
        public int ContratoId { get; set; }

        public int ContratoCompraId { get; set; }

        public int ContratoDetalleId { get; set; }

        public decimal Cantidad { get; set; }

        public decimal CantidadContenedores { get; set; }
        

        public decimal TotalFacturar1 { get; set; }

        public decimal Comision { get; set; }


        

        public decimal KilosNetosQQ { get; set; }

        public decimal PrecioQQVenta { get; set; }

        public decimal PrecioQQCompra { get; set; }

        public decimal UtilidadBruta { get; set; }
        public decimal UtilidadNeta { get; set; }

        public decimal GananciaNeta { get; set; }

        




        #endregion
    }
}
