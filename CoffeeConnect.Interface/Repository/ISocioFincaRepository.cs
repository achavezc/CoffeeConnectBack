using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface ISocioFincaRepository
    {
        int Insertar(SocioFinca productorFinca);

        int Actualizar(SocioFinca productorFinca);

        IEnumerable<ConsultaSocioFincaPorSocioIdBE> ConsultarSocioFincaPorSocioId(int socioId);

        ConsultaSocioFincaPorIdBE ConsultarSocioFincaPorId(int socioFincaId);


        IEnumerable<ConsultaSocioFincaEstimadoPorSocioFincaIdBE> ConsultarSocioFincaEstimadoPorSocioFincaId(int socioId);

        int ActualizarSocioFincaEstimado(List<SocioFincaEstimadoTipo> request, int socioFincaId);
    }
}