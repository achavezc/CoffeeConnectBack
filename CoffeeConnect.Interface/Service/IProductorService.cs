using CoffeeConnect.DTO;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IProductorService
    {

        int RegistrarProductor(RegistrarActualizarProductorRequestDTO request);
        int ActualizarProductor(RegistrarActualizarProductorRequestDTO request);


        List<ConsultaProductorBE> ConsultarProductor(ConsultaProductorRequestDTO request);
        ConsultaProductorIdBE ConsultarProductorId(ConsultaProductorIdRequestDTO request);


    }
}
