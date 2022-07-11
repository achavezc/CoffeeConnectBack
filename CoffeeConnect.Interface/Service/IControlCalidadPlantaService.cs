using CoffeeConnect.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Interface.Service
{
   public  interface IControlCalidadPlantaService
    {
        List<ConsultaControlCalidadPlantaBE> ConsultarControlCalidadPlanta(ConsultaControlCalidadPlantaRequestDTO consultaNotaIngresoPlantaRequestDTO);
        int AnularControlCalidadPlanta(AnularControlCalidadPlantaRequestDTO request);

        ConsultaControlCalidadPlantaPorIdBE ConsultaControlCalidadPlantaPorId(ConsultaControlCalidadPlantaPorIdRequestDTO request);
        int RegistrarPesadoControlCalidadPlanta(RegistrarActualizarPesadoControlCalidadPlantaRequestDTO request);
        int ActualizarPesadoControlCalidadPlanta(RegistrarActualizarPesadoControlCalidadPlantaRequestDTO request);

        int ActualizarControlCalidadPlantaAnalisisCalidad(ActualizarControlCalidadPlantaAnalisisCalidadRequestDTO request);
        GenerarPDFGuiaRemisionResponseDTO GenerarPDFGuiaRemisionPorNotaIngreso(int notaSalidaAlmacenIdId, int empresaId);

        //int EnviarGuardiolaNotaIngresoPlanta(EnviarGuardiolaNotaIngresoPlantaRequestDTO request);
    }
}
