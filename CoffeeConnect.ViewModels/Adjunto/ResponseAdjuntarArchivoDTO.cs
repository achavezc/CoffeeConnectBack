
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeConnect.DTO.Adjunto
{
    /// <summary>
    /// Clase para Response Adjuntar Archivo DTO//
    /// </summary>
    public class ResponseAdjuntarArchivoDTO// : BaseDTO
    {
        /// <summary>
        /// error
        /// <br/><b>Tipo:</b> String 
        /// <br/><b>Longitud:</b> 255
        /// </summary>
        public String error { get; set; }

        /// <summary>
        /// fichero Visual
        /// <br/><b>Tipo:</b> String 
        /// <br/><b>Longitud:</b> 255
        /// </summary>
        public String ficheroVisual { get; set; }

        /// <summary>
        /// fichero Real
        /// <br/><b>Tipo:</b> String 
        /// <br/><b>Longitud:</b> 255
        /// </summary>
        public String ficheroReal { get; set; }

        /// <summary>
        /// link
        /// <br/><b>Tipo:</b> String 
        /// <br/><b>Longitud:</b> 255
        /// </summary>
        public String link { get; set; }
    }
}

