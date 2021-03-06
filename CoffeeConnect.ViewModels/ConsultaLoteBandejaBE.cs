using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
	public class ConsultaLoteBandejaBE
	{
        public ConsultaLoteBandejaBE() {
            listaDetalle = new List<LoteDetalleConsulta>();
        }
        public int LoteId { get; set; }
        public List<LoteDetalleConsulta> listaDetalle { get; set; }
        public Decimal TotalPesoNeto { get; set; }
        public Decimal PromedioRendimiento { get; set; }
        public Decimal PromedioHumedad { get; set; }
    }
}
