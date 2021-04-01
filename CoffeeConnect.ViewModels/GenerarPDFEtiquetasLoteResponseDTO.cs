using Core.Common.Domain.Model;

namespace CoffeeConnect.DTO
{
    public class GenerarPDFEtiquetasLoteResponseDTO
    {
        public GenerarPDFEtiquetasLoteResponseDTO()
        {
            Result = new Result();
        }

        public Result Result { get; set; }
    }
}
