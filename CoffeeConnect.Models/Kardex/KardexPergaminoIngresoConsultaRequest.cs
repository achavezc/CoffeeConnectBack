using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Models.Kardex
{
    public class KardexPergaminoIngresoConsultaRequest
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int EmpresaId { get; set; }
    }
}

