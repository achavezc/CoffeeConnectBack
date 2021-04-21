using CoffeeConnect.DTO;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface ISocioFincaService
    {

        int RegistrarSocioFinca(RegistrarActualizarSocioFincaRequestDTO request);
        int ActualizarSocioFinca(RegistrarActualizarSocioFincaRequestDTO request);

        IEnumerable<ConsultaSocioFincaPorSocioIdBE> ConsultarSocioFincaPorSocioId(ConsultaSocioFincaPorSocioIdRequestDTO request);

        ConsultaSocioFincaPorIdBE ConsultarSocioFincaPorId(ConsultaSocioFincaPorIdRequestDTO request);

        public ConsultaSocioFincaEstimadoPorSocioFincaIdBE ConsultarSocioFincaEstimadoPorSocioFincaId(ConsultaSocioFincaEstimadoPorSocioFincaIdRequest request);
    }
}
