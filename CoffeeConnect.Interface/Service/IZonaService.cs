using CoffeeConnect.DTO;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IZonaService
    {

        int RegistrarZona(RegistrarActualizarZonaRequestDTO request);
        int ActualizarZona(RegistrarActualizarZonaRequestDTO request);


        List<ConsultaZonaBE> ConsultarZona(ConsultaZonaRequestDTO request);
        ConsultaZonaPorIdBE ConsultarZonaPorId(ConsultaZonaPorIdRequestDTO request);

       


    }
}
