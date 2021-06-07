using CoffeeConnect.DTO;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface ITransporteService
    {
        List<ConsultaTransportePorEmpresaTransporteId> ConsultarTransportePorEmpresaTransporteId(ConsultaTransporteRequestDTO request);

        ConsultaTransportePorIdBE ConsultarTransportePorId(ConsultaTransportePorIdRequestDTO request);
        int ActualizarTransporte(RegistrarActualizarTransporteRequestDTO request);

        int RegistrarTransporte(RegistrarActualizarTransporteRequestDTO request);



    }
}
