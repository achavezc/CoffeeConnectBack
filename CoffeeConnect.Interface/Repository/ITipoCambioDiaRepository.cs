using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface ITipoCambioDiaRepository
    {
        int Insertar(TipoCambioDia TipoCambioDia);

        int Actualizar(TipoCambioDia TipoCambioDia);

        IEnumerable<ConsultaTipoCambioDiaBE> ConsultarTipoCambioDia(ConsultaTipoCambioDiaRequestDTO request);

        IEnumerable<ConsultaTipoCambioDiaBE> ConsultarTipoCambioDiaPorSubProductoIdPorEmpresaId(int empresaID, string subProductoId);

        ConsultaTipoCambioDiaPorIdBE ConsultarTipoCambioDiaPorId(int TipoCambioDiaId);

        IEnumerable<ConsultaTipoCambioDiaBE> ConsultarTipoCambioDiaPorEmpresaId(int empresaID);

        int Anular(int TipoCambioDiaId, DateTime fecha, string usuario, string estadoId);

        decimal ObtenerTipoCambioDia(int empresaId);
    }
}