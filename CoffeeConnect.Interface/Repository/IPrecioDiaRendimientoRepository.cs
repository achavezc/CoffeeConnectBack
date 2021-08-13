using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Interface.Repository
{
    public interface IPrecioDiaRendimientoRepository
    {
        IEnumerable<ConsultaPrecioDiaRendimientoBE> ConsultarPrecioDiaRendimiento(ConsultarPrecioDiaRendimientoRequestDTO request);
        int RegistrarPrecioDiaRendimiento(RegistrarActualizarPrecioDiaRendimientoRequestDTO request);

        int Anular(int precioDiaRendimientoId, DateTime fecha, string usuario, string estadoId);

        int RegistrarPrecioDiaRendimientoDetalle(RegistrarActualizarPrecioDiaRendimientoRequestDTO request);

        int ActualizarPrecioDiaRendimiento(RegistrarActualizarPrecioDiaRendimientoRequestDTO request);

        IEnumerable<ConsultaPrecioDiaRendimientoDetalleBE> ConsultarPrecioDiaRendimientoDetallePorId(int precioDiaRendimientoId);

        ConsultaPrecioDiaRendimientoBE ConsultarPrecioDiaRendimientoPorId(int precioDiaRendimientoId);

    }
}
