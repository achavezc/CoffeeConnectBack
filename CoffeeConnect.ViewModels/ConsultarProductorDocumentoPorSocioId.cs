using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    [Serializable]
    public class ConsultarProductorDocumentoPorProductorId
    {
        public int ProductorDocumentoId { get; set; }

        /// <summary>
        /// Gets or sets the FincaId value.
        /// </summary>
        public int ProductorId { get; set; }

        /// <summary>
        /// Gets or sets the Nombre value.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets the Descripcion value.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Gets or sets the Path value.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the FechaRegistro value.
        /// </summary>
        public DateTime FechaRegistro { get; set; }

        /// <summary>
        /// Gets or sets the UsuarioRegistro value.
        /// </summary>
        public string UsuarioRegistro { get; set; }

        /// <summary>
        /// Gets or sets the EstadoId value.
        /// </summary>
        public string EstadoId { get; set; }

        public string Estado { get; set; }
        /// <summary>
        /// Gets or sets the Activo value.
        /// </summary>
        public bool Activo { get; set; }
    }
}
