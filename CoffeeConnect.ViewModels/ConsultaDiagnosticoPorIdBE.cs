using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
    public class ConsultaDiagnosticoPorIdBE
    {
        #region Properties
        /// <summary>
        /// Gets or sets the DiagnosticoId value.
        /// </summary>
        public int DiagnosticoId
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
        /// Gets or sets the ObservacionInfraestructura value.
        /// </summary>
        public string ObservacionInfraestructura
        { get; set; }

        /// <summary>
        /// Gets or sets the ObservacionDatosCampo value.
        /// </summary>
        public string ObservacionDatosCampo
        { get; set; }

        /// <summary>
        /// Gets or sets the Responsable value.
        /// </summary>
        public string Responsable
        { get; set; }

        /// <summary>
        /// Gets or sets the TecnicoCampo value.
        /// </summary>
        public string TecnicoCampo
        { get; set; }

        /// <summary>
        /// Gets or sets the EmpresaId value.
        /// </summary>
        public int EmpresaId
        { get; set; }

        /// <summary>
        /// Gets or sets the AreaTotal value.
        /// </summary>
        public decimal? AreaTotal
        { get; set; }

        /// <summary>
        /// Gets or sets the AreaCafeEnProduccion value.
        /// </summary>
        public decimal? AreaCafeEnProduccion
        { get; set; }

        /// <summary>
        /// Gets or sets the Crecimiento value.
        /// </summary>
        public decimal? Crecimiento
        { get; set; }

        /// <summary>
        /// Gets or sets the Bosque value.
        /// </summary>
        public decimal? Bosque
        { get; set; }

        /// <summary>
        /// Gets or sets the Purma value.
        /// </summary>
        public decimal? Purma
        { get; set; }

        /// <summary>
        /// Gets or sets the PanLlevar value.
        /// </summary>
        public decimal? PanLlevar
        { get; set; }

        /// <summary>
        /// Gets or sets the Vivienda value.
        /// </summary>
        public decimal? Vivienda
        { get; set; }

        /// <summary>
        /// Gets or sets the IngresoPromedioMensual value.
        /// </summary>
        public decimal? IngresoPromedioMensual
        { get; set; }

        /// <summary>
        /// Gets or sets the IngresoAgricultura value.
        /// </summary>
        public decimal? IngresoAgricultura
        { get; set; }

        /// <summary>
        /// Gets or sets the IngresoBodega value.
        /// </summary>
        public decimal? IngresoBodega
        { get; set; }

        /// <summary>
        /// Gets or sets the IngresoTransporte value.
        /// </summary>
        public decimal? IngresoTransporte
        { get; set; }

        /// <summary>
        /// Gets or sets the IngresoOtro value.
        /// </summary>
        public decimal? IngresoOtro
        { get; set; }

        /// <summary>
        /// Gets or sets the PrestamoEntidades value.
        /// </summary>
        public string PrestamoEntidades
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

        public List<DiagnosticoInfraestructura> DiagnosticoInfraestructura { get; set; }
        public List<DiagnosticoDatosCampo> DiagnosticoDatosCampo { get; set; }
        public List<DiagnosticoCostoProduccion> DiagnosticoCostoProduccion { get; set; }

        #endregion
    }
}
