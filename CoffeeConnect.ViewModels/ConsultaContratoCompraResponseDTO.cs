using Core.Common.Domain.Model;

namespace CoffeeConnect.DTO
{

    public class ConsultaContratoCompraResponseDTO
    {
        public ConsultaContratoCompraResponseDTO()
        {
            this.Result = new Result();
        }
        public Result Result { get; set; }
    }
}
