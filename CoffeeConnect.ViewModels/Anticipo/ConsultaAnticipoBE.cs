using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO.Anticipo
{
    public class ConsultaAnticipoBE
    {
        public int AnticipoId { get; set; }

        public int ProveedorId { get; set; }

        public int EmpresaId { get; set; }

        public string Numero { get; set; }

       // public string RucProveedor { get; set; }

        public string NumeroNotaIngresoPlanta { get; set; }


        public string RucEmpresa { get; set; }

        public string RazonSocialEmpresa { get; set; }


        //  public string RazonSocialProveedor { get; set; }
        public string MonedaId { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public string Motivo { get; set; }

        public DateTime FechaEntregaProducto { get; set; }

        public int NotaIngresoPlantaId { get; set; }
        public string EstadoId { get; set; }
        public string Estado { get; set; }
       
        public string Moneda { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }


    }
}
