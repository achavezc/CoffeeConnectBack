using CoffeeConnect.DTO;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IProductorFincaService
    {

        int RegistrarProductorFinca(RegistrarActualizarProductorFincaRequestDTO request);
        int ActualizarProductorFinca(RegistrarActualizarProductorFincaRequestDTO request);

        IEnumerable<ConsultaProductorFincaProductorIdBE> ConsultarProductorFincaPorProductorId(ConsultaProductorFincaProductorIdRequestDTO request);
    }
}
