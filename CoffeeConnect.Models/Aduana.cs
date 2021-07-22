using System;

namespace CoffeeConnect.Models
{
    public class Aduana
    {
        #region Properties
        /// <summary>
        /// Gets or sets the AduanaId value.
        /// </summary>
        public int AduanaId
        { get; set; }

        /// <summary>
        /// Gets or sets the ContratoId value.
        /// </summary>
        public int ContratoId
        { get; set; }

        /// <summary>
        /// Gets or sets the EmpresaExportadoraId value.
        /// </summary>
        public int EmpresaExportadoraId
        { get; set; }

        public int EmpresaAgenciaAduaneraId
        { get; set; }




        public DateTime FechaEmbarque
        { get; set; }

        public DateTime? FechaFacturacion
        { get; set; }


        /// <summary>
        /// Gets or sets the EmpresaProductoraId value.
        /// </summary>
        public int EmpresaProductoraId
        { get; set; }

        /// <summary>
        /// Gets or sets the EmpresaId value.
        /// </summary>
        public int EmpresaId
        { get; set; }

        /// <summary>
        /// Gets or sets the Numero value.
        /// </summary>
        public string Numero
        { get; set; }

        public string Courier
        { get; set; }





        /// <summary>
        /// Gets or sets the Marca value.
        /// </summary>
        public string Marca
        { get; set; }

        /// <summary>
        /// Gets or sets the PO value.
        /// </summary>
        public string PO
        { get; set; }

        /// <summary>
        /// Gets or sets the LaboratorioId value.
        /// </summary>
        public string LaboratorioId
        { get; set; }

        /// <summary>
        /// Gets or sets the FechaEnvioMuestra value.
        /// </summary>
        public DateTime FechaEnvioMuestra
        { get; set; }

        /// <summary>
        /// Gets or sets the NumeroSeguimientoMuestra value.
        /// </summary>
        public string NumeroSeguimientoMuestra
        { get; set; }

        /// <summary>
        /// Gets or sets the EstadoMuestraId value.
        /// </summary>
        public string EstadoMuestraId
        { get; set; }

        /// <summary>
        /// Gets or sets the FechaRecepcionMuestra value.
        /// </summary>
        public DateTime FechaRecepcionMuestra
        { get; set; }

        /// <summary>
        /// Gets or sets the ObservacionMuestra value.
        /// </summary>
        public string ObservacionMuestra
        { get; set; }

        /// <summary>
        /// Gets or sets the NavieraId value.
        /// </summary>
        public string NavieraId
        { get; set; }

        /// <summary>
        /// Gets or sets the Observacion value.
        /// </summary>
        public string Observacion
        { get; set; }

        /// <summary>
        /// Gets or sets the NombreArchivo value.
        /// </summary>
        public string NombreArchivo
        { get; set; }

        /// <summary>
        /// Gets or sets the DescripcionArchivo value.
        /// </summary>
        public string DescripcionArchivo
        { get; set; }

        /// <summary>
        /// Gets or sets the PathArchivo value.
        /// </summary>
        public string PathArchivo
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
        public string EstadoSeguimientoId { get; set; }

        #endregion
    }
}
