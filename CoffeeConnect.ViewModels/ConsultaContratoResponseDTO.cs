using Core.Common.Domain.Model;

namespace CoffeeConnect.DTO
{

    public class ConsultaContratoResponseDTO
    {
        public ConsultaContratoResponseDTO()
        {
            this.Result = new Result();
        }
        public Result Result { get; set; }
    }
}
