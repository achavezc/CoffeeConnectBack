using CoffeeConnect.DTO.Adelanto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Interface.Service
{
    public interface IAdelantoService
    {
        List<ConsultaAdelantoBE> ConsultarAdelanto(ConsultaAdelantoRequestDTO request);
    }
}
