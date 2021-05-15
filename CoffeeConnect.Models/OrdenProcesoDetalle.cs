using System;

namespace CoffeeConnect.Models
{
    public class OrdenProcesoDetalle
    {
        #region Properties
        /// <summary>
        /// Gets or sets the OrdenProcesoId value.
        /// </summary>
        public int OrdenProcesoId { get; set; }

        /// <summary>
        /// Gets or sets the EmpresaId value.
        /// </summary>
        public int OrdenProcesoDetalleId { get; set; }

        /// <summary>
        /// Gets or sets the EmpresaProcesadoraId value.
        /// </summary>
        public string NroNotaIngresoPlanta { get; set; }

        /// <summary>
        /// Gets or sets the TipoProcesoId value.
        /// </summary>
        public DateTime FechaNotaIngresoPlanta { get; set; }
        public decimal RendimientoPorcentaje { get; set; }
        public decimal HumedadPorcentaje { get; set; }
        public decimal CantidadSacos { get; set; }
        public decimal KilosBrutos { get; set; }
        public decimal Tara { get; set; }
        public decimal KilosNetos { get; set; }

        #endregion
    }
}
