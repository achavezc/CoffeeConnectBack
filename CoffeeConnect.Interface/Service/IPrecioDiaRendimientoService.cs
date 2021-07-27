using CoffeeConnect.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Interface.Service
{
    public interface IPrecioDiaRendimientoService
    {
        int RegistrarPrecioDiaRendimiento(RegistrarActualizarPrecioDiaRendimientoRequestDTO request);
    }
}
