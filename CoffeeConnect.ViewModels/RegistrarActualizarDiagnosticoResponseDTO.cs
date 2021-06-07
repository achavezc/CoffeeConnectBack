using Core.Common.Domain.Model;

namespace CoffeeConnect.DTO
{
    public class RegistrarActualizarDiagnosticoResponseDTO
    {

        public RegistrarActualizarDiagnosticoResponseDTO()
        {
            this.Result = new Result();
        }
        public Result Result { get; set; }


    }
}
