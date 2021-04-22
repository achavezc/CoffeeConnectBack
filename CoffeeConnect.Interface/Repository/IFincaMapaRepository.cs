using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IFincaMapaRepository
    {
        int Insertar(FincaMapa fincaMapa);

        int Actualizar(FincaMapa fincaMapa);

        IEnumerable<ConsultaFincaMapaPorId> ConsultarFincaMapaPorFincaId(int fincaId);

        ConsultaFincaMapaPorId ConsultarFincaMapaPorId(int fincaMapaId);
    }
}