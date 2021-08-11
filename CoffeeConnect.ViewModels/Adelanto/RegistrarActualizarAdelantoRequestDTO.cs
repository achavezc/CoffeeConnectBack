using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO.Adelanto
{
    public class RegistrarActualizarAdelantoRequestDTO
    {
        public int AdelantoId { get; set; }
        public int SocioId { get; set; }
        public int EmpresaId { get; set; }
        public string Numero { get; set; }
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
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaUltimaActualizacion { get; set; }
        public string UsuarioUltimaActualizacion { get; set; }
        public string UsuarioRegistro { get; set; }
    }
}
