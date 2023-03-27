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

        int ActualizarEstado(int contratoId, DateTime fecha, string usuario, string estadoId);

        ConsultarTrackingContratoPorContratoIdBE ConsultarTrackingContratoPorContratoId(int contratoId,string idioma);

        IEnumerable<ConsultarTrackingContratoPorContratoIdBE> ConsultarTrackingContrato(ConsultaTrackingContratoRequestDTO request);

        decimal CalcularPrecioDiaContrato(int empresaId);

        int AsignarAcopio(int contratoId, DateTime fecha, string usuario, string estadoId, decimal kgPergaminoAsignacion, decimal porcentajeRendimientoAsignacion, decimal totalKGPergaminoAsignacion);

        int ValidadContratoAsignado(int empresaId, string estadoId);

        ConsultaContratoAsignado ConsultarContratoAsignado(int empresaId, string estadoId);

        int ActualizarSaldoPendienteAsignacionAcopio(int contratoId, decimal totalKGPergaminoIngreso);

        int ValidadContratoExistente(int empresaId, string numero);
        IEnumerable<ConsultaAduanaCargamentoPorIdBE> ConsultarTrackingContratoCargamentoPorContratoId(int contratoId, string idioma);

        IEnumerable<ConsultaAduanaCertificacionPorIdBE> ConsultarTrackingContratoCertificacionPorContratoId(int contratoId, string idioma);


        int InsertarContratoDetalle(ContratoDetalle contratoDetalle);
        int EliminarContratoDetalle(int contratoId);

        IEnumerable<ContratoDetalleBE> ConsultarContratoDetallePorId(int ContratoId);

    }
}