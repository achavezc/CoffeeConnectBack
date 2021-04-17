using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
    public class ConsultaSocioFincaPorIdBE
    {
        #region Properties
        /// <summary>
        /// Gets or sets the SocioFincaId value.
        /// </summary>
        public int SocioFincaId
        { get; set; }

        /// <summary>
        /// Gets or sets the SocioId value.
        /// </summary>
        public int SocioId
        { get; set; }

        /// <summary>
        /// Gets or sets the ProductorFincaId value.
        /// </summary>
        public int ProductorFincaId
        { get; set; }

        /// <summary>
        /// Gets or sets the ViasAccesoCentroAcopio value.
        /// </summary>
        public string ViasAccesoCentroAcopio
        { get; set; }

        /// <summary>
        /// Gets or sets the DistanciaKilometrosCentroAcopio value.
        /// </summary>
        public decimal? DistanciaKilometrosCentroAcopio
        { get; set; }

        /// <summary>
        /// Gets or sets the TiempoTotalFincaCentroAcopio value.
        /// </summary>
        public decimal? TiempoTotalFincaCentroAcopio
        { get; set; }

        /// <summary>
        /// Gets or sets the MedioTransporte value.
        /// </summary>
        public string MedioTransporte
        { get; set; }

        /// <summary>
        /// Gets or sets the Cultivo value.
        /// </summary>
        public string Cultivo
        { get; set; }

        public List<ConsultaSocioFincaEstimadoPorSocioFincaIdBE> FincaEstimado
        { get; set; }

    /// <summary>
    /// Gets or sets the Precipitacion value.
    /// </summary>
    public string Precipitacion
        { get; set; }

        /// <summary>
        /// Gets or sets the CantidadPersonalCosecha value.
        /// </summary>
        public int? CantidadPersonalCosecha
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
        /// Gets or sets the EstadoId value.
        /// </summary>
        public string EstadoId
        { get; set; }

        /// <summary>
        /// Gets or sets the Activo value.
        /// </summary>
        public bool Activo
        { get; set; }

        public int ProductorId { get; set; }

        #endregion
         
        

    }
}
