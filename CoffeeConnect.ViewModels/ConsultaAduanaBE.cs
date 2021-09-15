using System;

namespace CoffeeConnect.DTO
{
    public class ConsultaAduanaBE
    {
        #region Properties
        ///// <summary>
        ///// Gets or sets the ProductorId value.
        ///// </summary>
        //public int AduanaId
        //{ get; set; }

        //public int ContratoId
        //{ get; set; }

        //public int ClienteId
        //{ get; set; }

        ///// <summary>
        ///// Gets or sets the Numero value.
        ///// </summary>
        //public string Numero
        //{ get; set; }

        //public string NumeroContrato
        //{ get; set; }

        //public string RazonSocialCliente
        //{ get; set; }



        ///// <summary>
        ///// Gets or sets the TipoDocumentoId value.
        ///// </summary>
        //public int  EmpresaExportadoraId
        //{ get; set; }


        //public string RucEmpresaExportadora
        //{ get; set; }

        ///// <summary>
        ///// Gets or sets the NombreRazonSocial value.
        ///// </summary>
        //public string RazonSocialEmpresaExportadora
        //{ get; set; }

        //public string RucEmpresaAgenciaAduanera
        //{ get; set; }

        ///// <summary>
        ///// Gets or sets the NombreRazonSocial value.
        ///// </summary>
        //public string RazonSocialEmpresaAgenciaAduanera
        //{ get; set; }



        //public string RucEmpresaProductora
        //{ get; set; }

        //public string RazonSocialEmpresaProductora
        //{ get; set; }


        //public DateTime? FechaEmbarque
        //{ get; set; }



        ///// <summary>
        ///// Gets or sets the Activo value.
        ///// </summary>
        //public string EstadoId
        //{ get; set; }

        //public string Estado
        //{ get; set; }


        public int AduanaId
        { get; set; }

      
        public string FloId
        { get; set; }

       

        public string TipoCertificacion
        { get; set; }

        public string TipoCertificacionId
        { get; set; }

        public decimal? PreparacionCantidadDefectos
        { get; set; }




        public string Courier
        { get; set; }


        public string NumeroContrato
        { get; set; }

        public string NumeroCliente
        { get; set; }

        public string RazonSocialCliente
        { get; set; }


        public string RucEmpresaAgenciaAduanera
        { get; set; }

        public string RazonSocialEmpresaAgenciaAduanera
        { get; set; }

        public string RucEmpresaExportadora
        { get; set; }

        public string RazonSocialEmpresaExportadora
        { get; set; }

        public string RucEmpresaProductora
        { get; set; }

        public decimal TotalSacos
        { get; set; }

        public decimal PesoPorSaco
        { get; set; }

        public decimal PesoKilos
        { get; set; }

        public string RazonSocialEmpresaProductora
        { get; set; }

        public string Estado
        { get; set; }

        public string Empaque
        { get; set; }

  
        public string TipoEmpaque
        { get; set; }

     



        public string Producto
        { get; set; }



        public string SubProducto
        { get; set; }


        public string Calidad
        { get; set; }




        public DateTime? FechaEmbarque
        { get; set; }

        public DateTime? FechaFacturacion
        { get; set; }

        /// <summary>
        /// Gets or sets the EmpresaProductoraId value.
        /// </summary>
      
       
        /// <summary>
        /// Gets or sets the Numero value.
        /// </summary>
        public string Numero
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
        /// Gets or sets the FechaEnvioMuestra value.
        /// </summary>
        public DateTime? FechaEnvioMuestra
        { get; set; }

        /// <summary>
        /// Gets or sets the NumeroSeguimientoMuestra value.
        /// </summary>
        public string NumeroSeguimientoMuestra
        { get; set; }

      

        /// <summary>
        /// Gets or sets the FechaRecepcionMuestra value.
        /// </summary>
        public DateTime? FechaRecepcionMuestra
        { get; set; }



        /// <summary>
        /// Gets or sets the Observacion value.
        /// </summary>
        public string Observacion
        { get; set; }

        /// <summary>
        /// Gets or sets the NombreArchivo value.
        /// </summary>


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

        public string EstadoMuestra { get; set; }

        

        public string EstadoSeguimientoDescripcion { get; set; }

        public string EstadoPagoFactura { get; set; }

        public DateTime? FechaPagoFactura { get; set; }


        public DateTime? FechaZarpeNave
        { get; set; }

        public DateTime? FechaEstampado
        { get; set; }

        public DateTime? FechaEnvioDocumentos
        { get; set; }

        public DateTime? FechaLlegadaDocumentos
        { get; set; }

        public string NumeroContratoInternoProductor
        { get; set; }

        public string Puerto
        { get; set; }

        public decimal NumeroContenedores
        { get; set; }


        #endregion
    }
}
