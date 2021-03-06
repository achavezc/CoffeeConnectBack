using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface ILoteRepository
    {
        int Insertar(Lote lote);
        int InsertarLoteDetalle(List<LoteDetalle> request);
        IEnumerable<ConsultaLoteBE> ConsultarLote(ConsultaLoteRequestDTO request);

        int ActualizarEstado(int loteId, DateTime fecha, string usuario, string estadoId);
        IEnumerable<LoteDetalle> ConsultarLoteDetallePorId(int loteId);
        IEnumerable<LoteDetalleConsulta> ConsultarBandejaLoteDetallePorId(int loteId);

    }
}