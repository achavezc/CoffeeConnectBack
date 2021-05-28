using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
    
    public class EmpresaTransporteBE
    {
    
        public int EmpresaTransporteId { get; set; }
        public int EmpresaId { get; set; }
        public string RazonSocial { get; set; }
        public string Ruc { get; set; }
        public string Direccion { get; set; }

        public string DepartamentoId { get; set; }
        public string ProvinciaId { get; set; }
        public string DistritoId { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string EstadoId
        { get; set; }

        public string Estado
        { get; set; }

    }

}
