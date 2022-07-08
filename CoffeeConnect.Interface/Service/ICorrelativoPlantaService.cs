using CoffeeConnect.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Interface.Service
{
    public interface ICorrelativoPlantaService
    {
        List<ConsultaDetalleTablaBE> obtenerConceptos(string codigoTipo);
        List<ConsultaDetalleTablaBE> obtenerCampanias(string codigoTipo);
        public List<CorrelativoPlantaBE> ConsultarCorrelativo(ConsultaCorrelativoPlantaRequestDTO request);
        public int RegistrarCorrelativo(RegistrarActualizarCorrelativoPlantaRequestDTO request);
        public int ActualizarCorrelativoPlanta(RegistrarActualizarCorrelativoPlantaRequestDTO request);
        public CorrelativoPlantaBE ConsultarCorrelativoPlantaPorId(ConsultaCorrelativoPlantaPorIdRequestDTO request);
        public List<ConsultaDetalleTablaBE> obtenerTipo();
    }
}
