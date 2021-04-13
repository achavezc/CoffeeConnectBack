using System;

namespace CoffeeConnect.DTO.Adjunto
{
    /// <summary>
    /// Clase para Adjuntar Archivos
    /// </summary>
    public class AdjuntarArchivosDTO
    {
        /// <summary>
        /// archivo Stream
        /// <br/><b>Tipo:</b> Byte[] 
        /// <br/><b>Longitud:</b> variable
        /// </summary>
        public Byte[] archivoStream { get; set; }

        /// <summary>
        /// filename
        /// <br/><b>Tipo:</b> string 
        /// <br/><b>Longitud:</b> 250
        /// </summary>
        public string filename { get; set; }
    }
}