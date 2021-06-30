using Core.Common.Domain.Model;

namespace CoffeeConnect.DTO
{
    public class RegistrarActualizarAduanaResponseDTO
    {

        public RegistrarActualizarAduanaResponseDTO()
        {
            this.Result = new Result();
        }
        public Result Result { get; set; }


    }
}
