using CoffeeConnect.DTO;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IClienteService
    {

        //int RegistrarProductor(RegistrarActualizarProductorRequestDTO request);
        //int ActualizarProductor(RegistrarActualizarProductorRequestDTO request);


        List<ConsultaClienteBE> ConsultarCliente(ConsultaClienteRequestDTO request);
        //ConsultaProductorIdBE ConsultarProductorId(ConsultaProductorIdRequestDTO request);


    }
}
