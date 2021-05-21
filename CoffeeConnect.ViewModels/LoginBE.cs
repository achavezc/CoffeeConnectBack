using CoffeeConnect.DTO.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
    public class LoginBE
    {
        public int IdUsuario { get; set; }
        public int EmpresaId { get; set; }
        
        public string NombreUsuario { get; set; }
        public string NombreCompletoUsuario { get; set; }
        
        public string RazonSocialEmpresa { get; set; }
        public string RucEmpresa { get; set; }
        public string DireccionEmpresa { get; set; }
        public string LogoEmpresa { get; set; }
        public List<Root> Opciones { get; set; }

        public List<ProductoPrecioDiaBE> ProductoPreciosDia { get; set; }

        public string MonedaId { get; set; }
        public string Moneda { get; set; }
    }
}
