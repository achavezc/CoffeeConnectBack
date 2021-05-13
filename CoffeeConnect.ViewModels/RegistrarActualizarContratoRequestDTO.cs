using System;

namespace CoffeeConnect.DTO
{
    public class RegistrarActualizarContratoRequestDTO
    {
        /// <summary>
        /// Gets or sets the ContratoId value.
        /// </summary>
        public int ContratoId
        { get; set; }

        /// <summary>
        /// Gets or sets the Numero value.
        /// </summary>
        public string Numero
        { get; set; }

        /// <summary>
        /// Gets or sets the ClienteId value.
        /// </summary>
        public int ClienteId
        { get; set; }

        /// <summary>
        /// Gets or sets the FloId value.
        /// </summary>
        public string FloId
        { get; set; }

        /// <summary>
        /// Gets or sets the CondicionEmbarqueId value.
        /// </summary>
        public string CondicionEmbarqueId
        { get; set; }

        /// <summary>
        /// Gets or sets the FechaEmbarque value.
        /// </summary>
        public DateTime FechaEmbarque
        { get; set; }

        /// <summary>
        /// Gets or sets the FechaContrato value.
        /// </summary>
        public DateTime FechaContrato
        { get; set; }

        /// <summary>
        /// Gets or sets the FechaFacturacion value.
        /// </summary>
        public DateTime FechaFacturacion
        { get; set; }

        /// <summary>
        /// Gets or sets the PaisDestinoId value.
        /// </summary>
        public string PaisDestinoId
        { get; set; }

        public string CalculoContratoId
        { get; set; }

        /// <summary>
        /// Gets or sets the DepartamentoDestinoId value.
        /// </summary>
        public string DepartamentoDestinoId
        { get; set; }

        /// <summary>
        /// Gets or sets the ProductoId value.
        /// </summary>
        public string ProductoId
        { get; set; }

        /// <summary>
        /// Gets or sets the TipoProduccionId value.
        /// </summary>
        public string TipoProduccionId
        { get; set; }

        /// <summary>
        /// Gets or sets the MonedadId value.
        /// </summary>
        public string MonedadId
        { get; set; }

        /// <summary>
        /// Gets or sets the Monto value.
        /// </summary>
        public decimal Monto
        { get; set; }

        /// <summary>
        /// Gets or sets the UnidadMedicionId value.
        /// </summary>
        public string UnidadMedicionId
        { get; set; }

        /// <summary>
        /// Gets or sets the UnidadMedidaId value.
        /// </summary>
        public string UnidadMedidaId
        { get; set; }

        /// <summary>
        /// Gets or sets the EntidadCertificadoraId value.
        /// </summary>
        public string EntidadCertificadoraId
        { get; set; }

        /// <summary>
        /// Gets or sets the TipoCertificacionId value.
        /// </summary>
        public string TipoCertificacionId
        { get; set; }

        /// <summary>
        /// Gets or sets the CalidadId value.
        /// </summary>
        public string CalidadId
        { get; set; }

        /// <summary>
        /// Gets or sets the GradoId value.
        /// </summary>
        public string GradoId
        { get; set; }

        /// <summary>
        /// Gets or sets the Cantidad value.
        /// </summary>
        public decimal CantidadPorSaco
        { get; set; }

        /// <summary>
        /// Gets or sets the PesoPorSaco value.
        /// </summary>
        public decimal PesoPorSaco
        { get; set; }

        /// <summary>
        /// Gets or sets the PreparacionCantidadDefectos value.
        /// </summary>
        public decimal PreparacionCantidadDefectos
        { get; set; }

        /// <summary>
        /// Gets or sets the RequiereAprobacionMuestra value.
        /// </summary>
        public string LaboratorioId
        { get; set; }

        /// <summary>
        /// Gets or sets the MuestraEnviadaCliente value.
        /// </summary>
        public string NumeroSeguimientoMuestra
        { get; set; }

        /// <summary>
        /// Gets or sets the MuestraEnviadaAnalisisGlifosato value.
        /// </summary>
        public string EstadoMuestraId
        { get; set; }

        public DateTime? FechaEnvioMuestra
        { get; set; }

        public DateTime? FechaRecepcionMuestra
        { get; set; }

        /// <summary>
        /// Gets or sets the NombreArchivo value.
        /// </summary>
        public string NombreArchivo
        { get; set; }



        public string ObservacionMuestra
        { get; set; }

        public string NavieraId
        { get; set; }

        public string DescripcionArchivo
        { get; set; }

        /// <summary>
        /// Gets or sets the PathArchivo value.
        /// </summary>
        public string PathArchivo
        { get; set; }
        public string EmpaqueId { get; set; }
        public string TipoId { get; set; }

        /// <summary>
        /// Gets or sets the UsuarioRegistro value.
        /// </summary>
        public string Usuario
        { get; set; }


        public string EstadoId
        { get; set; }


    }
}
