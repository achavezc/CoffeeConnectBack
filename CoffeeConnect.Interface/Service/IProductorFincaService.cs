using CoffeeConnect.DTO;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IProductorFincaService
    {

        int RegistrarProductor(RegistrarActualizarProductorRequestDTO request);
        int ActualizarProductor(RegistrarActualizarProductorRequestDTO request);

        IEnumerable<ConsultaProductorFincaProductorIdBE> ConsultarProductorFincaIdProductor(ConsultaProductorFincaProductorIdRequestDTO request);
    }
}
