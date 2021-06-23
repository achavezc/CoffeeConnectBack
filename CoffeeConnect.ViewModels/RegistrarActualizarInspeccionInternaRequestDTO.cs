using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
    public class RegistrarActualizarInspeccionInternaRequestDTO
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


        public string Inspector
        { get; set; }

        public DateTime? FechaInspeccion
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


        /// <summary>
        /// Gets or sets the UsuarioRegistro value.
        /// </summary>
        public string Usuario
        { get; set; }



        public List<InspeccionInternaNormasTipo> InspeccionInternaNormaList { get; set; }

        public List<InspeccionInternaParcelaTipo> InspeccionInternaParcelaList { get; set; }

        public List<InspeccionInternaLevantamientoNoConformidadTipo> InspeccionInternaLevantamientoNoConformidadList { get; set; }

        public List<InspeccionInternaNoConformidadTipo> InspeccionInternaNoConformidadList { get; set; }


        public RegistrarActualizarInspeccionInternaRequestDTO()
        {
            InspeccionInternaNormaList = new List<InspeccionInternaNormasTipo>();
            InspeccionInternaParcelaList = new List<InspeccionInternaParcelaTipo>();
            InspeccionInternaLevantamientoNoConformidadList = new List<InspeccionInternaLevantamientoNoConformidadTipo>();
            InspeccionInternaNoConformidadList = new List<InspeccionInternaNoConformidadTipo>();

        }

        public string NombreArchivo { get; set; }
        public string PathArchivo { get; set; }

        #endregion
    }
}
