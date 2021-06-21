using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{   

    public class ConsultaDetalleCatalogoRequestDTO
    {     
        public int IdCatalogo { get; set; }

        public String EstadoId { get; set; }

        public int EmpresaId { get; set; }
    }
}
