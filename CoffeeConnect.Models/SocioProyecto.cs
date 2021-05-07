using System;

namespace CoffeeConnect.Models
{
    public class SocioProyecto
    {
        #region Properties
        /// <summary>
        /// Gets or sets the SocioProyectoId value.
        /// </summary>
        public int SocioProyectoId
        { get; set; }

        /// <summary>
        /// Gets or sets the EmpresaId value.
        /// </summary>
        public int EmpresaId
        { get; set; }

        /// <summary>
        /// Gets or sets the OrganizacionProyectoAnte value.
        /// </summary>
        public string OrganizacionProyectoAnterior
        { get; set; }

        public DateTime? FechaProyectoAnterior
        { get; set; }

        /// <summary>
        /// Gets or sets the ProyectoId value.
        /// </summary>
        public string ProyectoId
        { get; set; }

        /// <summary>
        /// Gets or sets the MonedaId value.
        /// </summary>
        public string MonedaId
        { get; set; }

        /// <summary>
        /// Gets or sets the Monto value.
        /// </summary>
        public decimal? Monto
        { get; set; }

        /// <summary>
        /// Gets or sets the PeriodoDesde value.
        /// </summary>
        public int? PeriodoDesde
        { get; set; }

        /// <summary>
        /// Gets or sets the PeriodoHasta value.
        /// </summary>
        public int? PeriodoHasta
        { get; set; }

        /// <summary>
        /// Gets or sets the CantidadHectareas value.
        /// </summary>
        public int? CantidadHectareas
        { get; set; }

        /// <summary>
        /// Gets or sets the MontoPrimerDesembolso value.
        /// </summary>
        public decimal? MontoPrimerDesembolso
        { get; set; }

        /// <summary>
        /// Gets or sets the FechaInicioPrimerDesembolso value.
        /// </summary>
        public DateTime? FechaInicioPrimerDesembolso
        { get; set; }

        /// <summary>
        /// Gets or sets the FechaFinPrimerDesembolso value.
        /// </summary>
        public DateTime? FechaFinPrimerDesembolso
        { get; set; }

        /// <summary>
        /// Gets or sets the MontoSegundoDesembolso value.
        /// </summary>
        public decimal? MontoSegundoDesembolso
        { get; set; }

        /// <summary>
        /// Gets or sets the FechaInicioSegundoDesembolso value.
        /// </summary>
        public DateTime? FechaInicioSegundoDesembolso
        { get; set; }

        /// <summary>
        /// Gets or sets the FechaFinSegundoDesembolso value.
        /// </summary>
        public DateTime? FechaFinSegundoDesembolso
        { get; set; }

        /// <summary>
        /// Gets or sets the Cobrado value.
        /// </summary>
        public bool CobradoPrimerDesembolso { get; set; }

        /// <summary>
        /// Gets or sets the FechaCobro value.
        /// </summary>
        public DateTime? FechaCobroPrimerDesembolso { get; set; }

        public bool CobradoSegundoDesembolso { get; set; }
        public DateTime? FechaCobroSegundoDesembolso { get; set; }

        /// <summary>
        /// Gets or sets the UnidadMedidaId value.
        /// </summary>
        public string UnidadMedidaId
        { get; set; }

        /// <summary>
        /// Gets or sets the TipoInsumoId value.
        /// </summary>
        public string TipoInsumoId
        { get; set; }

        /// <summary>
        /// Gets or sets the CantidadInsumo value.
        /// </summary>
        public int? CantidadInsumo
        { get; set; }

        /// <summary>
        /// Gets or sets the CantidadInsumoEntregado value.
        /// </summary>
        public int? CantidadInsumoEntregado
        { get; set; }

        /// <summary>
        /// Gets or sets the CantidadInsumoPedidoFinal value.
        /// </summary>
        public int? CantidadInsumoPedidoFinal
        { get; set; }

        /// <summary>
        /// Gets or sets the ObservacionCapacitacion value.
        /// </summary>
        public string ObservacionCapacitacion
        { get; set; }

        /// <summary>
        /// Gets or sets the FechaInicioCapacitacion value.
        /// </summary>
        public DateTime? FechaInicioCapacitacion
        { get; set; }

        /// <summary>
        /// Gets or sets the FechaFinCapacitacion value.
        /// </summary>
        public DateTime? FechaFinCapacitacion
        { get; set; }

        /// <summary>
        /// Gets or sets the AdopcionTecnologias value.
        /// </summary>
        public bool AdopcionTecnologias
        { get; set; }

        /// <summary>
        /// Gets or sets the Requisitos value.
        /// </summary>
        public string Requisitos
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

        #endregion
    }
}
