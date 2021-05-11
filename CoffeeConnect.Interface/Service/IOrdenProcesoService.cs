using CoffeeConnect.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Interface.Service
{
    public interface IOrdenProcesoService
    {
        List<ConsultaOrdenProcesoBE> ConsultarOrdenProceso(ConsultaOrdenProcesoRequestDTO request);
        int RegistrarOrdenProceso(RegistrarActualizarOrdenProcesoRequestDTO request, IFormFile file);
        int ActualizarOrdenProceso(RegistrarActualizarOrdenProcesoRequestDTO request, IFormFile file);
    }
}
