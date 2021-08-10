using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adelanto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Interface.Repository
{
    public interface IAdelantoRepository
    {
        IEnumerable<ConsultaAdelantoBE> ConsultarAdelanto(ConsultaAdelantoRequestDTO request);
        IEnumerable<ResultadoPDFAdelanto> GenerarPDF(int idAdelanto);
        int Anular(int adelantoId, DateTime fecha, string usuario, string estadoId);

        int AsociarNotaCompra(int adelantoId, int notaCompraId, DateTime fecha, string usuario);
    }
}
