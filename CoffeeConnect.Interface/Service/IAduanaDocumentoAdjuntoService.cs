using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adjunto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IAduanaDocumentoAdjuntoService
    {
        int RegistrarAduanaDocumentoAdjunto(RegistrarActualizarAduanaDocumentoAdjuntoRequestDTO request, IFormFile file);
        int ActualizarAduanaDocumentoAdjunto(RegistrarActualizarAduanaDocumentoAdjuntoRequestDTO request, IFormFile file);
        IEnumerable<ConsultaAduanaDocumentoAdjuntoPorId> ConsultarAduanaDocumentoAdjuntoPorAduanaId(ConsultaAduanaDocumentoAdjuntoPorAduanaIdRequestDTO request);
        ConsultaAduanaDocumentoAdjuntoPorId ConsultarAduanaDocumentoAdjuntoPorId(ConsultaAduanaDocumentoAdjuntoPorIdRequestDTO request);
        ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request);

        int EliminarAduanaDocumentoAdjunto(RegistrarActualizarAduanaDocumentoAdjuntoRequestDTO request);
    }
}
