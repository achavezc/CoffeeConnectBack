using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO.Anticipo
{
    public class RegistrarActualizarAnticipoRequestDTO
    {
        public int AnticipoId { get; set; }
        public int ProveedorId { get; set; }
        public int EmpresaId { get; set; }
        public string Numero { get; set; }
    
        public string MonedaId { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public string Motivo { get; set; }
        public DateTime FechaEntregaProducto { get; set; }
       
        public int EstadoId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaUltimaActualizacion { get; set; }
        public string UsuarioUltimaActualizacion { get; set; }
        public string UsuarioRegistro { get; set; }
    }
}
