using Core.Common.Domain.Model;

namespace CoffeeConnect.DTO
{

    public class ConsultaAduanaPorIdResponseDTO
    {
        public ConsultaAduanaPorIdResponseDTO()
        {
            this.Result = new Result();
        }
        public Result Result { get; set; }
    }
}
