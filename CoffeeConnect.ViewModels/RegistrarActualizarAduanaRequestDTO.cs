using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
    public class RegistrarActualizarAduanaRequestDTO
    {
        #region Properties
        public int EmpresaId
        { get; set; }


        public int AduanaId
        { get; set; }

        public string Numero
        { get; set; }
        /// <summary>
        /// Gets or sets the ContratoId value.
        /// </summary>
        public int ContratoId
        { get; set; }

        

        public int? EmpresaAgenciaAduaneraId
        { get; set; }
        /// <summary>
        /// Gets or sets the EmpresaExportadoraId value.
        /// </summary>
        public int? EmpresaExportadoraId
        { get; set; }

        /// <summary>
        /// Gets or sets the EmpresaProductoraId value.
        /// </summary>
        public int EmpresaProductoraId
        { get; set; }

        public string NumeroContratoInternoProductor
        { get; set; }



        public DateTime? FechaEmbarque
        { get; set; }

        public DateTime? FechaZarpeNave
        { get; set; }

        public DateTime? FechaFacturacion
        { get; set; }

        public string Puerto
        { get; set; }


        public string Marca
        { get; set; }

        /// <summary>
        /// Gets or sets the PO value.
        /// </summary>
        public string PO
        { get; set; }




        public decimal NumeroContenedores
        { get; set; }


        public string EstadoSeguimientoId { get; set; }


        public DateTime? FechaEstampado { get; set; }


        public DateTime? FechaEnvioMuestra
        { get; set; }

        public DateTime? FechaRecepcionMuestra
        { get; set; }


        public string EstadoMuestraId
        { get; set; }

        public string Courier
        { get; set; }

        public string NumeroSeguimientoMuestra
        { get; set; }

        public string Observacion
        { get; set; }


        public DateTime? FechaEnvioDocumentos
        { get; set; }

        public DateTime? FechaLlegadaDocumentos
        { get; set; }

       

        

        
        

        public List<ActualizarAduanaCertificacionRequestDTO> Certificaciones { get; set; }

        public List<AduanaDetalle> Detalle { get; set; }

        public List<AduanaCargamento> Cargamentos { get; set; }


        public string Usuario
        { get; set; }










        #endregion
    }
}
