using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class ConsultaOrdenProcesoPlantaBE
    {
        public ConsultaOrdenProcesoPlantaBE()
        {
            
        }

        public int? OrdenProcesoPlantaId { get; set; }

        public int? OrdenProcesoId { get; set; }
        public int EmpresaId { get; set; }
        public int OrganizacionId { get; set; }
        public string TipoProcesoId { get; set; }
        public int? ContratoId { get; set; }
        public string Numero { get; set; }
        public string NumeroContrato { get; set; }
  
        public string RucOrganizacion { get; set; }
       
        public string RazonOrganizacion { get; set; }
        public string TipoProceso { get; set; }
        public string EstadoId { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaUltimaActualizacion { get; set; }
        public string UsuarioUltimaActualizacion { get; set; }


        public string ProductoId { get; set; }

        public string Producto { get; set; }

        public string SubProductoId { get; set; }

        public string SubProducto { get; set; }

        public string TipoProduccionId { get; set; }

        public string TipoProduccion { get; set; }


        public string EntidadCertificadoraId { get; set; }

        public string EntidadCertificadora { get; set; }


        public string TipoCertificacionId { get; set; }

        public string TipoCertificacion { get; set; }


    }
}
