using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface INotaSalidaRepository
    {
        int Insertar(NotaCompra notaCompra);

        int Actualizar(NotaCompra notaCompra);

        int Anular(int notaCompraId, DateTime fecha, string usuario, string estadoId);

        IEnumerable<ConsultaNotaSalidaBE> ConsultarNotaSalida(ConsultaNotaSalidaRequestDTO request);

        
    }
}