using CoffeeConnect.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface INotaSalidaService
    {
        int RegistrarNotaCompra(RegistrarActualizarNotaCompraRequestDTO request);

        int ActualizarNotaCompra(RegistrarActualizarNotaCompraRequestDTO request);

        int AnularNotaCompra(AnularNotaCompraRequestDTO request);

        
        List<ConsultaNotaSalidaBE> ConsultarNotaSalida(ConsultaNotaSalidaRequestDTO request);



    }
}
