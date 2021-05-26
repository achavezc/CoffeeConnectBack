using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adjunto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Interface.Service
{
    public interface ISocioDocumentoService
    {
        int RegistrarSocioDocumento(RegistrarSocioDocumentoRequestDTO request, IFormFile file);
        int ActualizarSocioDocumento(RegistrarSocioDocumentoRequestDTO request, IFormFile file);
        IEnumerable<ConsultarSocioDocumentoPorSocioId> ConsultarSocioDocumentoPorSocioId(ConsultarSocioDocumentoPorSocioIdRequestDTO request);
        ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request);

        int EliminarSocioDocumento(RegistrarSocioDocumentoRequestDTO request);

    }
}
