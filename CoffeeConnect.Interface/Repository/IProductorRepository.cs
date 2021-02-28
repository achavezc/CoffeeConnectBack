using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IProductorRepository
    {
        int Insertar(Productor lote);

        int Actualizar(Productor lote);

        IEnumerable<ConsultaProductorBE> ConsultarProductor(ConsultaProductorRequestDTO request);
        
        ConsultaProductorIdBE ConsultarProductorId(int productorId);
}
}