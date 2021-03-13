using CoffeeConnect.DTO;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface ISocioFincaService
    {

        //int RegistrarProductorFinca(RegistrarActualizarProductorFincaRequestDTO request);
        //int ActualizarProductorFinca(RegistrarActualizarProductorFincaRequestDTO request);

        IEnumerable<ConsultaSocioFincaPorSocioIdBE> ConsultarSocioFincaPorSocioId(ConsultaSocioFincaPorSocioIdRequestDTO request);

        ConsultaSocioFincaPorIdBE ConsultarSocioFincaPorId(ConsultaSocioFincaPorIdRequestDTO request);
    }
}
