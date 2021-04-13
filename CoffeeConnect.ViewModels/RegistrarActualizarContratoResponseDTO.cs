using Core.Common.Domain.Model;

namespace CoffeeConnect.DTO
{
    public class RegistrarActualizarContratoResponseDTO
    {

        public RegistrarActualizarContratoResponseDTO()
        {
            this.Result = new Result();
        }
        public Result Result { get; set; }


    }
}
