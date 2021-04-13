using CoffeeConnect.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IGuiaRemisionAlmacenService
    {           
        GenerarPDFGuiaRemisionResponseDTO GenerarPDFGuiaRemisionPorNotaSalidaAlmacenId(int guiaRemisionAlmacenId);
        

    }
}
