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

        ConsultarTrackingContratoPorContratoIdBE ConsultarTrackingContratoPorContratoId(int contratoId,string idioma);

        IEnumerable<ConsultarTrackingContratoPorContratoIdBE> ConsultarTrackingContrato(ConsultaTrackingContratoRequestDTO request);

        decimal CalcularPrecioDiaContrato(int empresaId);

        int AsignarAcopio(int contratoId, DateTime fecha, string usuario, string estadoId, decimal kgPergaminoAsignacion, decimal porcentajeRendimientoAsignacion, decimal totalKGPergaminoAsignacion);

    }
}