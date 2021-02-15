using CoffeeConnect.DTO;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface INotaIngresoAlmacenService
    {
       
        int Registrar(EnviarAlmacenGuiaRecepcionMateriaPrimaRequestDTO request);

        public List<ConsultaNotaIngresoAlmacenBE> ConsultarNotaIngresoAlmacen(ConsultaNotaIngresoAlmacenRequestDTO request);

    }
}
