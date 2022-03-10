using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO.Anticipo
{
    public class GenerarPDFAnticipoResponseDTO
    {
        public GenerarPDFAnticipoResponseDTO()
        {
            Result = new Result();
            resultado = new List<ResultadoPDFAnticipo>();
        }

        public Result Result { get; set; }
        public IList<ResultadoPDFAnticipo> resultado { get; set; }
    }

    public class ResultadoPDFAnticipo
    {
        public int AnticipoId { get; set; }
        public int ProveedorId { get; set; }
        public int EmpresaId { get; set; }
        public string Numero { get; set; }
        public string RucProveedor { get; set; }
        public string NumeroNotaIngresoPlanta { get; set; }
       
        public string RazonSocialProveedor { get; set; }
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
        public string FechaRegistroString { get; set; }
        public string UsuarioRegistro { get; set; }
        public string RazonSocial { get; set; }
        public string Ruc { get; set; }
        public string Logo { get; set; }
        public string Direccion { get; set; }
    }
}
