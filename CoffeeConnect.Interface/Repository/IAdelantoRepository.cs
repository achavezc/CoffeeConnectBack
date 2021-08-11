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
        int Insertar(Adelanto adelanto);
        int Actualizar(Adelanto adelanto);
        ConsultaAdelantoPorIdBE ConsultarAdelantoPorId(int adelantoId);
    }
}
