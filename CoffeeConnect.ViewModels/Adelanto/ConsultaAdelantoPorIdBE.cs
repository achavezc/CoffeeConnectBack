using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO.Adelanto
{
    public class ConsultaAdelantoPorIdBE
    {
        public int AdelantoId { get; set; }
        public int SocioId { get; set; }
        public int EmpresaId { get; set; }
        public string Numero { get; set; }
        public string CodigoSocio { get; set; }
        public string NumeroNotaCompra { get; set; }

        public string TipoDocumentoId { get; set; }
        public string NumeroDocumento { get; set; }
        public string NombreRazonSocial { get; set; }
        public string MonedaId { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public string Motivo { get; set; }
        public DateTime FechaEntregaProducto { get; set; }
        public int NotaCompraId { get; set; }
        public int EstadoId { get; set; }
        public string Estado { get; set; }
        public string TipoDocumento { get; set; }
        public string Moneda { get; set; }

        public DateTime FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public string RazonSocial { get; set; }
        public string Ruc { get; set; }
        public string Logo { get; set; }
        public string Direccion { get; set; }
    }
}
