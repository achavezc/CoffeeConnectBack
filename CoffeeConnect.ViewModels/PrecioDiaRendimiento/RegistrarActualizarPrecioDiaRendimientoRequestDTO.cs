using CoffeeConnect.DTO.PrecioDiaRendimiento;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class RegistrarActualizarPrecioDiaRendimientoRequestDTO
    {
        public RegistrarActualizarPrecioDiaRendimientoRequestDTO()
        {

        }

        public int PrecioDiaRendimientoId { get; set; }

        public int EmpresaId { get; set; }
        public string MonedaId { get; set; }
        public decimal TipoCambio { get; set; }
        public decimal PrecioPromedioContrato { get; set; }
        public IList<PrecioDiaRendimientoTipoRequestDTO> Rendimientos { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
