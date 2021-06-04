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

        IEnumerable<InspeccionInternaParcela> ConsultarInspeccionInternaParcelaPorId(int inspeccionInternaId);

        IEnumerable<InspeccionInternaNorma> ConsultarInspeccionInternaNormasPorId(int inspeccionInternaId);

        IEnumerable<InspeccionInternaNoConformidad> ConsultarInspeccionInternaNoConformidadPorId(int inspeccionInternaId);

        IEnumerable<InspeccionInternaLevantamientoNoConformidad> ConsultarInspeccionInternaLevantamientoNoConformidadPorId(int inspeccionInternaId);


       int ActualizarInspeccionInternaParcela(List<InspeccionInternaParcelaTipo> request, int inspeccionInternaId);

        int ActualizarInspeccionInternaNormas(List<InspeccionInternaNormasTipo> request, int inspeccionInternaId);

        int ActualizarInspeccionInternaNoConformidad(List<InspeccionInternaNoConformidadTipo> request, int inspeccionInternaId);
        
        int ActualizarInspeccionInternaLevantamientoNoConformidad(List<InspeccionInternaLevantamientoNoConformidadTipo> request, int inspeccionInternaId);


    }
}
