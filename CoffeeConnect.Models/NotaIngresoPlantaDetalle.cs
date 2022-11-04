using System;
using System.Collections.Generic;

namespace CoffeeConnect.Models
{
    public class NotaIngresoPlantaDetalle
    {
        #region Properties
        /// <summary>
        /// Gets or sets the OrdenProcesoId value.
        /// </summary>
        public int NotaIngresoPlantaDetalleId { get; set; }

        /// <summary>
        /// Gets or sets the EmpresaId value.
        /// </summary>
        public int NotaIngresoPlantaId { get; set; }

        public string EmpaqueId { get; set; }
        public string TipoId { get; set; }

        public string SubProductoId { get; set; }
        

        public decimal Cantidad { get; set; }

        public decimal KilosBrutos { get; set; }

        public decimal KilosNetos { get; set; }

        public decimal Tara { get; set; }

      

       
        #endregion
    }
}
