using CoffeeConnect.DTO;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IClienteService
    {

        int RegistrarCliente(RegistrarActualizarClienteRequestDTO request);
        int ActualizarCliente(RegistrarActualizarClienteRequestDTO request);


        List<ConsultaClienteBE> ConsultarCliente(ConsultaClienteRequestDTO request);
        ConsultaClientePorIdBE ConsultarClientePorId(ConsultaClientePorIdRequestDTO request);


    }
}
