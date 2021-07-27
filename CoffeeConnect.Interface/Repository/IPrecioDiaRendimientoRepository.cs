using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Interface.Repository
{
    public interface IPrecioDiaRendimientoRepository
    {
        int RegistrarPrecioDiaRendimiento(RegistrarActualizarPrecioDiaRendimientoRequestDTO request);
    }
}
