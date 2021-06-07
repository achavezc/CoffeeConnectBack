using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IDiagnosticoRepository
    {
        IEnumerable<ConsultaDiagnosticoBE> ConsultarDiagnostico(ConsultaDiagnosticoRequestDTO request);

        int Insertar(Diagnostico diagnostico);

        int Actualizar(Diagnostico diagnostico);

        ConsultaDiagnosticoPorIdBE ConsultarDiagnosticoPorId(int diagnosticoId);

        int ActualizarDiagnosticoCostoProduccion(List<DiagnosticoCostoProduccionTipo> request, int diagnosticoId);

        int ActualizarDiagnosticoDatosCampo(List<DiagnosticoDatosCampoTipo> request, int diagnosticoId);

        int ActualizarDiagnosticoInfraestructura(List<DiagnosticoInfraestructuraTipo> request, int diagnosticoId);

        IEnumerable<DiagnosticoCostoProduccion> ConsultarDiagnosticoCostoProduccionPorId(int diagnosticoId);


        IEnumerable<DiagnosticoDatosCampo> ConsultarDiagnosticoDatosCampoPorId(int diagnosticoId);

        IEnumerable<DiagnosticoInfraestructura> ConsultarDiagnosticoInfraestructuraPorId(int diagnosticoId);



    }
}
