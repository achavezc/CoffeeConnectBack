using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IUbigeoRepository
    {
        int Insertar(Ubigeo ubigeo);

        int Actualizar(Ubigeo ubigeo);

        IEnumerable<ConsultaUbigeoBE> ConsultarUbigeoPorCodigoPais(ConsultaUbigeoPorCodigoPaisRequestDTO request);

        ConsultaUbigeoPorIdBE ConsultarUbigeoPorId(int UbigeoId);

    }
}