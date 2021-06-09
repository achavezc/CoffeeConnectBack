using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adjunto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IOrdenProcesoPlantaService
    {
        List<ConsultaLiquidacionProcesoPlantaBE> ConsultarOrdenProcesoPlanta(ConsultaOrdenProcesoPlantaRequestDTO request);
        int RegistrarOrdenProcesoPlanta(RegistrarActualizarOrdenProcesoPlantaRequestDTO request, IFormFile file);
        int ActualizarOrdenProcesoPlanta(RegistrarActualizarOrdenProcesoPlantaRequestDTO request, IFormFile file);
        ConsultaOrdenProcesoPlantaPorIdBE ConsultarOrdenProcesoPlantaPorId(ConsultaOrdenProcesoPlantaPorIdRequestDTO request);
        //int AnularOrdenProcesoPlanta(AnularOrdenProcesoPlantaRequestDTO request);
        //ConsultarImpresionOrdenProcesoPlantaResponseDTO ConsultarImpresionOrdenProcesoPlanta(ConsultarImpresionOrdenProcesoPlantaRequestDTO request);
        ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request);


        ConsultaOrdenProcesoPlantaPorIdBE ConsultarOrdenProcesoPlantaDetallePorId(ConsultaOrdenProcesoPlantaPorIdRequestDTO request);

    }
}
