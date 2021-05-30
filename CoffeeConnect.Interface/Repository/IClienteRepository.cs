using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IClienteRepository
    {
        int Insertar(Cliente cliente);

        int Actualizar(Cliente cliente);

        IEnumerable<ConsultaClienteBE> ConsultarCliente(ConsultaClienteRequestDTO request);

        ConsultaClientePorIdBE ConsultarClientePorId(int clienteId);

        int Anular(int clienteId, DateTime fecha, string usuario, string estadoId);
    }
}