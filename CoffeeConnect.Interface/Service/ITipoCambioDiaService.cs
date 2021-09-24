using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface ITipoCambioDiaService
    {

        int RegistrarTipoCambioDia(RegistrarActualizarTipoCambioDiaRequestDTO request);
        int ActualizarTipoCambioDia(RegistrarActualizarTipoCambioDiaRequestDTO request);


        List<ConsultaTipoCambioDiaBE> ConsultarTipoCambioDia(ConsultaTipoCambioDiaRequestDTO request);
        ConsultaTipoCambioDiaPorIdBE ConsultarTipoCambioDiaPorId(ConsultaTipoCambioDiaPorIdRequestDTO request);

        int AnularTipoCambioDia(AnularTipoCambioDiaRequestDTO request);
    }
}
