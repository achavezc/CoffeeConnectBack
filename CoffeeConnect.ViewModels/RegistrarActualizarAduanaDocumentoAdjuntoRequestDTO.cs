namespace CoffeeConnect.DTO
{
    public class RegistrarActualizarAduanaDocumentoAdjuntoRequestDTO
    {
        /// <summary>
        /// Gets or sets the AduanaMapaId value.
        /// </summary>
        public int AduanaDocumentoAdjuntoId
        { get; set; }

        /// <summary>
        /// Gets or sets the AduanaId value.
        /// </summary>
        public int AduanaId
        { get; set; }

        /// <summary>
        /// Gets or sets the Nombre value.
        /// </summary>
        public string Nombre
        { get; set; }

        /// <summary>
        /// Gets or sets the Descripcion value.
        /// </summary>
        public string Descripcion
        { get; set; }

        /// <summary>
        /// Gets or sets the Path value.
        /// </summary>
        public string Path
        { get; set; }


        /// <summary>
        /// Gets or sets the UsuarioRegistro value.
        /// </summary>
        public string Usuario
        { get; set; }

        /// <summary>
        /// Gets or sets the EstadoId value.
        /// </summary>
        public string EstadoId
        { get; set; }
    }
}
