using CoffeeConnect.DTO;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface INotaIngresoAlmacenService
    {
       
        int Registrar(EnviarAlmacenGuiaRecepcionMateriaPrimaRequestDTO request);

        List<ConsultaNotaIngresoAlmacenBE> ConsultarNotaIngresoAlmacen(ConsultaNotaIngresoAlmacenRequestDTO request);

    }
}
