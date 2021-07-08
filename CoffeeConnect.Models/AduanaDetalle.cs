using System;

namespace CoffeeConnect.Models
{
    public class AduanaDetalle
    {
        #region Properties
        /// <summary>
        /// Gets or sets the OrdenProcesoId value.
        /// </summary>
        public int AduanaId { get; set; }
        /// <summary>
        /// Gets or sets the EmpresaId value.
        /// </summary>
        public int AduanaDetalleId { get; set; }
        /// <summary>
        /// Gets or sets the EmpresaProcesadoraId value.
        /// </summary>
        public string NroNotaIngresoPlanta { get; set; }
       
        public decimal CantidadSacos { get; set; }
   
        public string NumeroLote { get; set; }

        public decimal KilosNetos { get; set; }

        #endregion
    }
}
