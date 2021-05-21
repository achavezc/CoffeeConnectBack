namespace CoffeeConnect.DTO
{
    public class RegistrarProductorDocumentoRequestDTO
    {
        /// <summary>
        /// Gets or sets the ProductorDocumentoId value.
        /// </summary>
        public int ProductorDocumentoId
        { get; set; }

        /// <summary>
        /// Gets or sets the ProductorId value.
        /// </summary>
        public int ProductorId
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
