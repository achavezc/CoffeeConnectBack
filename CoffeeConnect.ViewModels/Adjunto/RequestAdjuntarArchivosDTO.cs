using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeConnect.DTO.Adjunto
{
    /// <summary>
    /// Clase para Request Adjuntar Archivos
    /// </summary>
    public class RequestAdjuntarArchivosDTO : RequestBaseDTO
    {

        /// <summary>
        /// filtros
        /// <br/><b>Tipo:</b> AdjuntarArchivosDTO 
        /// </summary>
        public AdjuntarArchivosDTO filtros { get; set; }

        /// <summary>
        /// Sociedad Propietaria
        /// <br/><b>Tipo:</b> string 
        /// <br/><b>Longitud:</b> 4
        ///</summary>
        public string pathFile { get; set; }
    }
}
