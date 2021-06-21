using System;

namespace CoffeeConnect.Models
{
    public class InspeccionInterna
    {
        #region Properties
        /// <summary>
        /// Gets or sets the InspeccionInternaId value.
        /// </summary>
        public int InspeccionInternaId
        { get; set; }

        /// <summary>
        /// Gets or sets the Numero value.
        /// </summary>
        public string Numero
        { get; set; }

        /// <summary>
        /// Gets or sets the SocioFincaId value.
        /// </summary>
        public int SocioFincaId
        { get; set; }

        public string Inspector
        { get; set; }

        public DateTime? FechaInspeccion
        { get; set; }



        /// <summary>
        /// Gets or sets the Certificaciones value.
        /// </summary>
        public string Certificaciones
        { get; set; }

        /// <summary>
        /// Gets or sets the ExclusionPrograma value.
        /// </summary>
        public bool ExclusionPrograma
        { get; set; }

        /// <summary>
        /// Gets or sets the SuspencionTiempo value.
        /// </summary>
        public bool SuspencionTiempo
        { get; set; }

        /// <summary>
        /// Gets or sets the DuracionSuspencionTiempo value.
        /// </summary>
        public string DuracionSuspencionTiempo
        { get; set; }

        /// <summary>
        /// Gets or sets the NoConformidadObservacionLevantada value.
        /// </summary>
        public bool NoConformidadObservacionLevantada
        { get; set; }

        /// <summary>
        /// Gets or sets the ApruebaSinCondicion value.
        /// </summary>
        public bool ApruebaSinCondicion
        { get; set; }

        /// <summary>
        /// Gets or sets the EmpresaId value.
        /// </summary>
        public int EmpresaId
        { get; set; }

        /// <summary>
        /// Gets or sets the EstadoId value.
        /// </summary>
        public string EstadoId
        { get; set; }

        /// <summary>
        /// Gets or sets the FechaRegistro value.
        /// </summary>
        public DateTime FechaRegistro
        { get; set; }

        /// <summary>
        /// Gets or sets the UsuarioRegistro value.
        /// </summary>
        public string UsuarioRegistro
        { get; set; }

        /// <summary>
        /// Gets or sets the FechaUltimaActualizacion value.
        /// </summary>
        public DateTime? FechaUltimaActualizacion
        { get; set; }

        /// <summary>
        /// Gets or sets the UsuarioUltimaActualizacion value.
        /// </summary>
        public string UsuarioUltimaActualizacion
        { get; set; }

        /// <summary>
        /// Gets or sets the Activo value.
        /// </summary>
        public bool Activo
        { get; set; }
        public string NombreArchivo { get; set; }
        public string PathArchivo { get; set; }

        #endregion
    }
}
