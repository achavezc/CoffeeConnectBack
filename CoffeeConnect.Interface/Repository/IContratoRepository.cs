﻿using CoffeeConnect.DTO;
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


    }
}