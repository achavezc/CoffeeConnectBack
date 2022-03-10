using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Anticipo;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Interface.Repository
{
    public interface IAnticipoRepository
    {
        IEnumerable<ConsultaAnticipoBE> ConsultarAnticipo(ConsultaAnticipoRequestDTO request);
        IEnumerable<ResultadoPDFAnticipo> GenerarPDF(int idAnticipo);
        int Insertar(Anticipo anticipo);
        int Actualizar(Anticipo anticipo);
        ConsultaAnticipoPorIdBE ConsultarAnticipoPorId(int anticipoId);
        int Anular(int AnticipoId, DateTime fecha, string usuario, string estadoId);

        int AsociarNotaIngresoPlanta(int anticipoId, int notaIngresoPlantaId, DateTime fecha, string usuario);

        IEnumerable<ConsultaAnticipoBE> ConsultarAnticiposPorNotaIngresoPlanta(int notaIngresoPlantaId, string estadoId);

        int ActualizarEstadoPorNotaIngresoPlanta(int notaIngresoPlantaId, DateTime fecha, string usuario, string estadoId);

        IEnumerable<ConsultaImpresionAnticipoBE> ConsultarImpresionAnticiposPorNotaIngresoPlanta(int notaIngresoPlantaId);
    }
}
