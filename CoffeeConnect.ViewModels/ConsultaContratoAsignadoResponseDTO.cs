using Core.Common.Domain.Model;

namespace CoffeeConnect.DTO
{

    public class ConsultaContratoAsignadoResponseDTO
    {
        public ConsultaContratoAsignadoResponseDTO()
        {
            this.Result = new Result();
        }
        public Result Result { get; set; }
    }
}
