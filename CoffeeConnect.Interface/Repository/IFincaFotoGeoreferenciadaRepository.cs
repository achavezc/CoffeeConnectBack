using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IFincaFotoGeoreferenciadaRepository
    {
        int Insertar(FincaFotoGeoreferenciada FincaFotoGeoreferenciada);

        int Actualizar(FincaFotoGeoreferenciada FincaFotoGeoreferenciada);

        IEnumerable<ConsultaFincaFotoGeoreferenciadaPorId> ConsultarFincaFotoGeoreferenciadaPorFincaId(int fincaId);

        ConsultaFincaFotoGeoreferenciadaPorId ConsultarFincaFotoGeoreferenciadaPorId(int FincaFotoGeoreferenciadaId);
    }
}