using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
    public class GenerarLoteRequestDTO
    {
        public List<TablaIdsTipo> NotasIngresoAlmacenId { get; set; }

        

        public String Usuario { get; set; }

        public int EmpresaId { get; set; }
        public string AlmacenId { get; set; }
        
    }
}
