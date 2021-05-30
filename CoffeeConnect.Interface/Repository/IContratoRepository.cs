using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IContratoRepository
    {
        int Insertar(Contrato contrato);

        int Actualizar(Contrato contrato);

        IEnumerable<ConsultaContratoBE> ConsultarContrato(ConsultaContratoRequestDTO request);

        ConsultaContratoPorIdBE ConsultarContratoPorId(int contratoId);

        int Anular(int contratoId, DateTime fecha, string usuario, string estadoId);
    }
}