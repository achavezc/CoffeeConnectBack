using CoffeeConnect.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IGuiaRemisionAlmacenPlantaService
    {           
        GenerarPDFGuiaRemisionResponseDTO GenerarPDFGuiaRemisionPlantaPorNotaSalidaAlmacenId(int notaSalidaAlmacenIdId);
        

    }
}
