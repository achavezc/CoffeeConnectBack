using System;
using System.Collections.Generic;

namespace CoffeeConnect.Models
{
    public class OrdenProcesoPlantaDetalle
    {
        #region Properties
        /// <summary>
        /// Gets or sets the OrdenProcesoId value.
        /// </summary>
        public int OrdenProcesoPlantaId { get; set; }

        /// <summary>
        /// Gets or sets the EmpresaId value.
        /// </summary>
        public int OrdenProcesoPlantaDetalleId { get; set; }


        public int NotaIngresoPlantaId { get; set; }


        
        #endregion
    }
}
