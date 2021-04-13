namespace CoffeeConnect.DTO.Adjunto { 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;



    /// <summary>
    /// Clase para Request Descargar Archivo
    /// </summary>
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
        public string SociedadPropietaria { get; set; }
    }
}

