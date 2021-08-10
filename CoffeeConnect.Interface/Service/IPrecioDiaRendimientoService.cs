using CoffeeConnect.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Interface.Service
{
    public interface IPrecioDiaRendimientoService
    {
        List<ConsultaPrecioDiaRendimientoBE> ConsultaPrecioDiaRendimiento(ConsultarPrecioDiaRendimientoRequestDTO request);
        int RegistrarPrecioDiaRendimiento(RegistrarActualizarPrecioDiaRendimientoRequestDTO request);

        int AnularPrecioDiaRendimiento(AnularPrecioDiaRendimientoRequestDTO request);
    }
}
