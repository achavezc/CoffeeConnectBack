using CoffeeConnect.DTO;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IDiagnosticoService
    {

        int RegistrarDiagnostico(RegistrarActualizarDiagnosticoRequestDTO request);
        int ActualizarDiagnostico(RegistrarActualizarDiagnosticoRequestDTO request);


        List<ConsultaDiagnosticoBE> ConsultarDiagnostico(ConsultaDiagnosticoRequestDTO request);
        ConsultaDiagnosticoPorIdBE ConsultarDiagnosticoPorId(ConsultaDiagnosticoPorIdRequestDTO request);

       


    }
}
