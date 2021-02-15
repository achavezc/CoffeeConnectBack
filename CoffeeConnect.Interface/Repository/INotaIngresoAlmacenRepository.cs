using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface INotaIngresoAlmacenRepository
    {       
        int Insertar(NotaIngresoAlmacen notaIngresoAlmacen);

        IEnumerable<ConsultaNotaIngresoAlmacenBE> ConsultarNotaIngresoAlmacen(ConsultaNotaIngresoAlmacenRequestDTO request);

    }
}