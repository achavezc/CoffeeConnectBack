namespace CoffeeConnect.DTO.Adjunto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;

    /// <summary>
    /// Clase para Eliminar Archivo Adjunto
    /// </summary>
    public class EliminarArchivoAdjuntoDTO : RequestBaseDTO
    {

        /// <summary>
        /// Lista de string
        /// <br/><b>Tipo:</b> List<string> 
        /// </summary>
        public List<string> Archivos { get; set; }

        /// <summary>
        /// Sociedad Propietaria
        /// <br/><b>Tipo:</b> string 
        /// <br/><b>Longitud:</b> 3
        /// </summary>
        public string SociedadPropietaria { get; set; }

    }
}

