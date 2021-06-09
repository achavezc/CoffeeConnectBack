using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adjunto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface ILiquidacionProcesoPlantaService
    {
        List<ConsultaLiquidacionProcesoPlantaBE> ConsultarLiquidacionProcesoPlanta(ConsultaLiquidacionProcesoPlantaRequestDTO request);
        //int RegistrarLiquidacionProcesoPlanta(RegistrarActualizarLiquidacionProcesoPlantaRequestDTO request, IFormFile file);
        //int ActualizarLiquidacionProcesoPlanta(RegistrarActualizarLiquidacionProcesoPlantaRequestDTO request, IFormFile file);
        //ConsultaLiquidacionProcesoPlantaPorIdBE ConsultarLiquidacionProcesoPlantaPorId(ConsultaLiquidacionProcesoPlantaPorIdRequestDTO request);
        ////int AnularLiquidacionProcesoPlanta(AnularLiquidacionProcesoPlantaRequestDTO request);
        ////ConsultarImpresionLiquidacionProcesoPlantaResponseDTO ConsultarImpresionLiquidacionProcesoPlanta(ConsultarImpresionLiquidacionProcesoPlantaRequestDTO request);
        //ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request);


        //ConsultaLiquidacionProcesoPlantaPorIdBE ConsultarLiquidacionProcesoPlantaDetallePorId(ConsultaLiquidacionProcesoPlantaPorIdRequestDTO request);

    }
}
