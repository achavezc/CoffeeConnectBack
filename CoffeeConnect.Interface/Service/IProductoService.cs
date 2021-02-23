using CoffeeConnect.DTO;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IProductorService
    {
       
        

        List<ConsultaProductorBE> ConsultarProductor(ConsultaProductorRequestDTO request);

       
    }
}
