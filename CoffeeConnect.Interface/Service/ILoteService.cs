using CoffeeConnect.DTO;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface ILoteService
    {
        int GenerarLote(GenerarLoteRequestDTO request);

        List<ConsultaLoteBE> ConsultarLote(ConsultaLoteRequestDTO request);

    }
}
