using Core.Common.Domain.Model;

namespace CoffeeConnect.DTO
{
    public class RegistrarActualizarContratoCompraResponseDTO
    {

        public RegistrarActualizarContratoCompraResponseDTO()
        {
            this.Result = new Result();
        }
        public Result Result { get; set; }


    }
}
