using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IProductoPrecioDiaRepository
    {
        int Insertar(ProductoPrecioDia ProductoPrecioDia);

        int Actualizar(ProductoPrecioDia ProductoPrecioDia);

        IEnumerable<ConsultaProductoPrecioDiaBE> ConsultarProductoPrecioDia(ConsultaProductoPrecioDiaRequestDTO request);

        ConsultaProductoPrecioDiaPorIdBE ConsultarProductoPrecioDiaPorId(int ProductoPrecioDiaId);
    }
}