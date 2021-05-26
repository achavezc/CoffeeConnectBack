using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adjunto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IFincaFotoGeoreferenciadaService
    {

        int RegistrarFincaFotoGeoreferenciada(RegistrarActualizarFincaFotoGeoreferenciadaRequestDTO request, IFormFile file);
        int ActualizarFincaFotoGeoreferenciada(RegistrarActualizarFincaFotoGeoreferenciadaRequestDTO request, IFormFile file);

        IEnumerable<ConsultaFincaFotoGeoreferenciadaPorId> ConsultarFincaFotoGeoreferenciadaPorFincaId(ConsultaFincaFotoGeoreferenciadaPorFincaIdRequestDTO request);

        ConsultaFincaFotoGeoreferenciadaPorId ConsultarFincaFotoGeoreferenciadaPorId(ConsultaFincaFotoGeoreferenciadaPorIdRequestDTO request);
        ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request);

        int EliminarFincaFotoGeoreferenciada(RegistrarActualizarFincaFotoGeoreferenciadaRequestDTO request);

    }
}
