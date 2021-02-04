using System;

namespace CoffeeConnect.DTO
{
    public class ConsultaGuiaRecepcionMateriaPrimaBE
    {

        public int GuiaRecepcionMateriaPrimaId { get; set; }

        public string Numero { get; set; }

        public string TipoProvedorId { get; set; }

        public string TipoProvedor { get; set; }

        public int? SocioId { get; set; }

        public string CodigoSocio { get; set; }

        public int? TerceroId { get; set; }

        public int? IntermediarioId { get; set; }

        public string TipoDocumentoId { get; set; }

        public string TipoDocumento { get; set; }

        public string NumeroDocumento { get; set; }
        


        public string NombreRazonSocialProveedor { get; set; }
        public string Producto { get; set; }
        public string SubProducto { get; set; }
        public DateTime FechaPesado { get; set; }

        public DateTime? FechaCalidad { get; set; }

        public string UsuarioPesado { get; set; }
       
        public string UsuarioCalidad { get; set; }

        public string EstadoId { get; set; }

        public string Estado { get; set; }

        public DateTime FechaRegistro { get; set; }

        public string UsuarioRegistro { get; set; }

        public DateTime? FechaUltimaActualizacion { get; set; }

        public string UsuarioUltimaActualizacion { get; set; }

        public bool Activo { get; set; }

        
    }
}
