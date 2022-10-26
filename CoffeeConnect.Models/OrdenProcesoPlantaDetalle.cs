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
        public DateTime? FechaRegistroFinal { get; set; }

        public int Cantidad { get; set; }

        public decimal KilosNetos { get; set; }

        public int CantidadNotaIngreso { get; set; }

        public decimal KilosNetosNotaIngreso { get; set; }


        public decimal HumedadPorcentaje { get; set; }
        public decimal PorcentajeExportable { get; set; }
        public decimal PorcentajeDescarte { get; set; }
        public decimal PorcentajeCascarilla { get; set; }
      

        public decimal KilosExportables { get; set; }

        public decimal SacosCalculo { get; set; }

        public string NumeroIngresoPlanta { get; set; }
        #endregion
    }
}
