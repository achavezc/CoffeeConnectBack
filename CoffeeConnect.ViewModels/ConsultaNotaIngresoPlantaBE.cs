using System;

namespace CoffeeConnect.DTO
{
    public class ConsultaNotaIngresoPlantaBE
    {

        public int NotaIngresoPlantaId { get; set; }

        public string Numero { get; set; }

        public string NumeroGuiaRemision { get; set; }

        public int EmpresaOrigenId { get; set; }

        public string RazonSocial { get; set; }
        public string TipoProduccionId { get; set; }
        public string TipoProduccion { get; set; }


        public string Producto { get; set; }

        public string ProductoId
        { get; set; }
        public string SubProducto { get; set; }



        public string SubProductoId { get; set; }


        public string CertificacionId { get; set; }
        public string Certificacion { get; set; }
        public string EntidadCertificadoraId { get; set; }
        public string EntidadCertificadora { get; set; }

        public string MotivoIngresoId { get; set; }
        public string MotivoIngreso { get; set; }
        public string EstadoId { get; set; }
        public string Estado { get; set; }

        public DateTime FechaRegistro { get; set; }

        public string UsuarioRegistro { get; set; }



        
    }
}
