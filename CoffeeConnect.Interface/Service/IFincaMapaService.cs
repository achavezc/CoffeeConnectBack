using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adjunto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IFincaMapaService
    {

        int RegistrarFincaMapa(RegistrarActualizarFincaMapaRequestDTO request, IFormFile file);
        int ActualizarFincaMapa(RegistrarActualizarFincaMapaRequestDTO request, IFormFile file);

        IEnumerable<ConsultaFincaMapaPorId> ConsultarFincaMapaPorFincaId(ConsultaFincaMapaPorFincaIdRequestDTO request);

        ConsultaFincaMapaPorId ConsultarFincaMapaPorId(ConsultaFincaMapaPorIdRequestDTO request);
        ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request);

        int EliminarFincaMapa(RegistrarActualizarFincaMapaRequestDTO request);
    }
}
