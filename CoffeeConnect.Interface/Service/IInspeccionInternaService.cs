using CoffeeConnect.DTO;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IInspeccionInternaService
    {

        int RegistrarInspeccionInterna(RegistrarActualizarInspeccionInternaRequestDTO request);
        int ActualizarInspeccionInterna(RegistrarActualizarInspeccionInternaRequestDTO request);


        List<ConsultaInspeccionInternaBE> ConsultarInspeccionInterna(ConsultaInspeccionInternaRequestDTO request);
        ConsultaInspeccionInternaPorIdBE ConsultarInspeccionInternaPorId(ConsultaInspeccionInternaPorIdRequestDTO request);

       


    }
}
