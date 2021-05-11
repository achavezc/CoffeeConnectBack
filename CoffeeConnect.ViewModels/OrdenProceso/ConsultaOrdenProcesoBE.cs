using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class ConsultaOrdenProcesoBE
    {
        public ConsultaOrdenProcesoBE()
        {
            
        }

        public int OrdenProcesoId { get; set; }
        public int EmpresaId { get; set; }
        public int EmpresaProcesadoraId { get; set; }
        public string TipoProcesoId { get; set; }
        public int ContratoId { get; set; }
        public string Numero { get; set; }
        public string NumeroContrato { get; set; }
        public string NumeroCliente { get; set; }
        public string Cliente { get; set; }
        public string Ruc { get; set; }
        public string RucEmpresaProcesadora { get; set; }
        public string RazonSocialEmpresaProcesadora { get; set; }
        public string TipoProceso { get; set; }
        public string EstadoId { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaUltimaActualizacion { get; set; }
        public string UsuarioUltimaActualizacion { get; set; }
    }
}
