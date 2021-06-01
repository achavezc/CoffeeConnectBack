using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IInspeccionInternaRepository
    {
        IEnumerable<ConsultaInspeccionInternaBE> ConsultarInspeccionInterna(ConsultaInspeccionInternaRequestDTO request);

        int Insertar(InspeccionInterna inspeccionInterna);

        int Actualizar(InspeccionInterna inspeccionInterna);

        ConsultaInspeccionInternaPorIdBE ConsultarInspeccionInternaPorId(int InspeccionInternaId);

       int ActualizarInspeccionInternaParcela(List<InspeccionInternaParcelaTipo> request, int inspeccionInternaId);

        int ActualizarInspeccionInternaNormas(List<InspeccionInternaNormasTipo> request, int inspeccionInternaId);

    }
}
