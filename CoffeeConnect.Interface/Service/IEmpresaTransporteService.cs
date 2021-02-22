using CoffeeConnect.DTO;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IEmpresaTransporteService
    {
        List<EmpresaTransporteBE> ConsultarEmpresaTransporte(int empresaId);
        List<ConsultaTransportistaBE> ConsultarTransportista(ConsultaTransportistaRequestDTO request);

    }
}
