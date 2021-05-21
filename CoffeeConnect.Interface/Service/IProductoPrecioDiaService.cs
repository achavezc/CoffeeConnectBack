using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IProductoPrecioDiaService
    {

        int RegistrarProductoPrecioDia(RegistrarActualizarProductoPrecioDiaRequestDTO request);
        int ActualizarProductoPrecioDia(RegistrarActualizarProductoPrecioDiaRequestDTO request);


        List<ConsultaProductoPrecioDiaBE> ConsultarProductoPrecioDia(ConsultaProductoPrecioDiaRequestDTO request);
        ConsultaProductoPrecioDiaPorIdBE ConsultarProductoPrecioDiaPorId(ConsultaProductoPrecioDiaPorIdRequestDTO request);


    }
}
