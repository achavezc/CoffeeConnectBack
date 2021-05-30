using Core.Common.Domain.Model;

namespace CoffeeConnect.DTO
{
    public class RegistrarActualizarEmpresaProveedoraAcreedoraResponseDTO
    {

        public RegistrarActualizarEmpresaProveedoraAcreedoraResponseDTO()
        {
            this.Result = new Result();
        }
        public Result Result { get; set; }


    }
}
