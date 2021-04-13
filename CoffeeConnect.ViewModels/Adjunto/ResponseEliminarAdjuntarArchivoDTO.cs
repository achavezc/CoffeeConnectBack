namespace CoffeeConnect.DTO.Adjunto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;

    /// <summary>
    /// Clase para Response Eliminar Adjuntar Archivo
    /// </summary>
    public class ResponseEliminarAdjuntarArchivoDTO
    {

        /// <summary>
        /// error
        /// <br/><b>Tipo:</b> string 
        /// <br/><b>Longitud:</b> 255
        /// </summary>
        public string error { get; set; }

        /// <summary>
        /// Lista de string
        /// <br/><b>Tipo:</b> List<string> 
        /// </summary>
        public List<string> Archivos { get; set; }
    }
}

