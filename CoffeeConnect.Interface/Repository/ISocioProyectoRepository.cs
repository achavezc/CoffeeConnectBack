using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Interface.Repository
{
    public interface ISocioProyectoRepository
    {
        int Insertar(SocioProyecto socioProyecto);

        int Actualizar(SocioProyecto socioProyecto);

        IEnumerable<ConsultaSocioProyectoPorSocioIdBE> ConsultarSocioProyectoPorSocioId(int socioId);

        ConsultaSocioProyectoPorIdBE ConsultarSocioProyectoPorId(int socioProyectoId);
    }
}
