using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{   

    public class ConsultaTablaDeTablasRequestDTO
    {     
        public String CodigoTabla { get; set; }

        public int EmpresaId { get; set; }
    }
}
