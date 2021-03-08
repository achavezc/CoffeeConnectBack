using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface ILoteService
    {
        int GenerarLote(GenerarLoteRequestDTO request);

        List<ConsultaLoteBE> ConsultarLote(ConsultaLoteRequestDTO request);

        int AnularLote(AnularLoteRequestDTO request);

        //ConsultaLoteBandejaBE ConsultarLoteDetallePorLoteId(ConsultaLoteDetallePorLoteIdRequestDTO request);
        ConsultaLoteBandejaBE ConsultarLotePorId(ConsultaLoteDetallePorLoteIdRequestDTO request);

        int ActualizarLote(ActualizarLoteRequestDTO request);

    }
}
