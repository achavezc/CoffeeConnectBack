using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IProductorFincaRepository
    {
        int Insertar(ProductorFinca productorFinca);

        int Actualizar(ProductorFinca productorFinca);

        IEnumerable<ConsultaProductorFincaProductorIdBE> ConsultarProductorFincaPorProductorId(int productorId);
    }
}