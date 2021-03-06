using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IProductorFincaRepository
    {
        int Insertar(Productor lote);

        int Actualizar(Productor lote);

        IEnumerable<ConsultaProductorFincaProductorIdBE> ConsultarProductorFincaIdProductor(int productorId);
    }
}