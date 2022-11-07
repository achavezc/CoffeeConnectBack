using Core.Common.Domain.Model;

namespace CoffeeConnect.DTO
{
    public class EnviarAlmacenNotaIngresoPlantaResponseDTO
    {
        public EnviarAlmacenNotaIngresoPlantaResponseDTO()
        {
            Result = new Result();
        }

        public Result Result { get; set; }
    }
}
