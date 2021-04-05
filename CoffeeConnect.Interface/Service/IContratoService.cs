using CoffeeConnect.DTO;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IContratoService
    {

        int RegistrarContrato(RegistrarActualizarContratoRequestDTO request);
        int ActualizarContrato(RegistrarActualizarContratoRequestDTO request);
        List<ConsultaContratoBE> ConsultarContrato(ConsultaContratoRequestDTO request);
        ConsultaContratoPorIdBE ConsultarContratoPorId(ConsultaContratoPorIdRequestDTO request);


    }
}
