using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IOrdenServicioControlCalidadRepository
    {
        IEnumerable<ConsultaOrdenServicioControlCalidadBE> ConsultarOrdenServicioControlCalidad(ConsultaOrdenServicioControlCalidadRequestDTO request);

        int ActualizarEstado(int ordenServicioControlCalidadId, DateTime fecha, string usuario, string estadoId);
    }
}