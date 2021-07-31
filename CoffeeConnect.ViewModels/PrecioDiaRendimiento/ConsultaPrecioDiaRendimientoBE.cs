using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class ConsultaPrecioDiaRendimientoBE
    {
        public ConsultaPrecioDiaRendimientoBE()
        {

        }

        public int PrecioDiaRendimientoId { get; set; }
        public int EmpresaId { get; set; }
        public string MonedaId { get; set; }
        public double TipoCambio { get; set; }
        public double PrecioPromedioContrato { get; set; }
        public double RendimientoInicio { get; set; }
        public double RendimientoFin { get; set; }
        public double Valor1 { get; set; }
        public double Valor2 { get; set; }
        public double Valor3 { get; set; }
        public string EstadoId { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
    }
}
