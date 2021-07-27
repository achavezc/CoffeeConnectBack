using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Models
{
    public class PrecioDiaRendimiento
    {
        public PrecioDiaRendimiento()
        {

        }

        public int PrecioDiaRendimientoId { get; set; }
        public int EmpresaId { get; set; }
        public string MonedaId { get; set; }
        public string TipoCambio { get; set; }
        public decimal PrecioPromedioContrato { get; set; }
        public decimal RendimientoInicio { get; set; }
        public decimal RendimientoFin { get; set; }
        public decimal Valor1 { get; set; }
        public decimal Valor2 { get; set; }
        public decimal Valor3 { get; set; }
        public bool Activo { get; set; }
        public string EstadoId { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioUltimaActualizacion { get; set; }
        public DateTime? FechaUltimaActualizacion { get; set; }
    }
}
