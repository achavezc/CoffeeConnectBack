using CoffeeConnect.DTO;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface ISocioService
    {

        int RegistrarSocio(RegistrarActualizarSocioRequestDTO request);
        int ActualizarSocio(RegistrarActualizarSocioRequestDTO request);


        List<ConsultaSocioBE> ConsultarSocio(ConsultaSocioRequestDTO request);

       
    }
}
