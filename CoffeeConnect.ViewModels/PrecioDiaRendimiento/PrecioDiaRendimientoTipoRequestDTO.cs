using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO.PrecioDiaRendimiento
{
    public class PrecioDiaRendimientoTipoRequestDTO
    {
        public PrecioDiaRendimientoTipoRequestDTO()
        {

        }
        public decimal RendimientoInicio { get; set; }
        public decimal RendimientoFin { get; set; }
        public decimal PrecioDia { get; set; }
        public decimal Valor1 { get; set; }
        public decimal Valor2 { get; set; }
        public decimal? Valor3 { get; set; }
    }
}
