using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;


namespace CoffeeConnect.DTO.Adjunto
{
    /// <summary>
    /// Clase para Response Descargar Archivo DTO:Base
    /// </summary>
    [Serializable]
    public class ResponseDescargarArchivoDTO : BaseDTO
    {

        /// <summary>
        /// fichero Visual
        /// <br/><b>Tipo:</b> string 
        /// <br/><b>Longitud:</b> 255
        /// </summary>
        public string ficheroVisual { get; set; }

        /// <summary>
        /// archivo Bytes
        /// <br/><b>Tipo:</b> byte[] 
        /// <br/><b>Longitud:</b> variable
        /// </summary>
        public byte[] archivoBytes { get; set; }
    }
}
