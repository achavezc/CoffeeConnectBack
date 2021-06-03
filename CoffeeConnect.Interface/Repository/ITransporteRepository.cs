using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface ITransporteRepository
    {


        IEnumerable<ConsultaTransportePorEmpresaTransporteId> ConsultarTransportePorEmpresaTransporteId(int empresaTransporteId);
        
        ConsultaTransportePorIdBE ConsultarTransportePorId(int transporteId);
        int Actualizar(Transporte transporte);
        int Insertar(Transporte transporte);

    }
}
