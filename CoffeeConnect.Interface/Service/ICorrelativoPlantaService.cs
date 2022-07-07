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
    }
}
