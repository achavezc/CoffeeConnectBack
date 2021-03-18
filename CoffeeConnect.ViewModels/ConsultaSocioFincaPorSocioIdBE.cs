namespace CoffeeConnect.DTO
{
    public class ConsultaSocioFincaPorSocioIdBE
    {
        #region Properties
        /// <summary>
        /// Gets or sets the SocioFincaId value.
        /// </summary>
        public int SocioFincaId
        { get; set; }

        /// <summary>
        /// Gets or sets the ProductorFincaId value.
        /// </summary>
        public int ProductorFincaId
        { get; set; }

        /// <summary>
        /// Gets or sets the Nombre value.
        /// </summary>
        public string Nombre
        { get; set; }

        /// <summary>
        /// Gets or sets the DepartamentoId value.
        /// </summary>
        public string DepartamentoId
        { get; set; }

        /// <summary>
        /// Gets or sets the Departamento value.
        /// </summary>
        public string Departamento
        { get; set; }

        /// <summary>
        /// Gets or sets the ProvinciaId value.
        /// </summary>
        public string ProvinciaId
        { get; set; }

        /// <summary>
        /// Gets or sets the Provincia value.
        /// </summary>
        public string Provincia
        { get; set; }

        /// <summary>
        /// Gets or sets the DistritoId value.
        /// </summary>
        public string DistritoId
        { get; set; }

        /// <summary>
        /// Gets or sets the Distrito value.
        /// </summary>
        public string Distrito
        { get; set; }

        /// <summary>
        /// Gets or sets the ZonaId value.
        /// </summary>
        public string ZonaId
        { get; set; }

        /// <summary>
        /// Gets or sets the Zona value.
        /// </summary>
        public string Zona
        { get; set; }

        /// <summary>
        /// Gets or sets the EstadoId value.
        /// </summary>
        public string EstadoId
        { get; set; }

        /// <summary>
        /// Gets or sets the Estado value.
        /// </summary>
        public string Estado
        { get; set; }

        /// <summary>
        /// Gets or sets the Activo value.
        /// </summary>
        public bool Activo
        { get; set; }

        public int SocioId { get; set; }
        public int ProductorId { get; set; }

        #endregion
    }
}
