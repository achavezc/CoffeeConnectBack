using Core.Common.Domain.Model;

namespace CoffeeConnect.DTO
{
    public class RegistrarActualizarInspeccionInternaResponseDTO
    {

        public RegistrarActualizarInspeccionInternaResponseDTO()
        {
            this.Result = new Result();
        }
        public Result Result { get; set; }


    }
}
