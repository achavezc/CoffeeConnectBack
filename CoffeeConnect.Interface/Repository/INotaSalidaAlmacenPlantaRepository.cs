
using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface INotaSalidaAlmacenPlantaRepository
    {
        int Insertar(NotaSalidaAlmacenPlanta NotaSalidaAlmacenPlanta);

        int Actualizar(NotaSalidaAlmacenPlanta NotaSalidaAlmacenPlanta);

        int ActualizarEstado(int NotaSalidaAlmacenPlantaId, DateTime fecha, string usuario, string estadoId);


        IEnumerable<ConsultaNotaSalidaAlmacenPlantaBE> ConsultarNotaSalidaAlmacenPlanta(ConsultaNotaSalidaAlmacenPlantaRequestDTO request);
       
        ConsultaNotaSalidaAlmacenPlantaPorIdBE ConsultarNotaSalidaAlmacenPlantaPorId(int NotaSalidaAlmacenPlantaId);

       

    }
}