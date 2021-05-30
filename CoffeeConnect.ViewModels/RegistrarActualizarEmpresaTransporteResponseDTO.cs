using Core.Common.Domain.Model;

namespace CoffeeConnect.DTO
{
    public class RegistrarActualizarEmpresaTransporteResponseDTO
    {

        public RegistrarActualizarEmpresaTransporteResponseDTO()
        {
            this.Result = new Result();
        }
        public Result Result { get; set; }


    }
}
