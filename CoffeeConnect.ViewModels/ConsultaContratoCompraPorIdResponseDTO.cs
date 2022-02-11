using Core.Common.Domain.Model;

namespace CoffeeConnect.DTO
{

    public class ConsultaContratoCompraPorIdResponseDTO
    {
        public ConsultaContratoCompraPorIdResponseDTO()
        {
            this.Result = new Result();
        }
        public Result Result { get; set; }
    }
}
