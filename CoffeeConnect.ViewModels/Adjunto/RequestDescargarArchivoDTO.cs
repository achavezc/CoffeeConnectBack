using System;

namespace CoffeeConnect.DTO.Adjunto
{
    /// <summary>
    /// Clase para Request Descargar Archivo
    /// </summary>
    [Serializable]
    public class RequestDescargarArchivoDTO : RequestBaseDTO
    {

        /// <summary>
        /// Archivo Visual
        /// <br/><b>Tipo:</b> string 
        /// <br/><b>Longitud:</b> 255
        /// </summary>
        public string ArchivoVisual { get; set; }

        /// <summary>
        /// Sociedad Propietaria
        /// <br/><b>Tipo:</b> string 
        /// <br/><b>Longitud:</b> 4
        ///</summary>
        public string PathFile { get; set; }
    }
}

