using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IDevolucionPrestamoPlantaRepository
    {
        IEnumerable<ConsultaDevolucionPrestamoPlantaBE> ConsultarDevolucionPrestamoPlanta(ConsultaDevolucionPrestamoPlantaRequestDTO request);
        int Insertar(DevolucionPrestamoPlanta DevolucionPrestamoPlanta);
        ConsultaDevolucionPrestamoPlantaPorIdBE ConsultarDevolucionPrestamoPlantaPorId(int DevolucionPrestamoPlantaId);
        int Actualizar(DevolucionPrestamoPlanta DevolucionPrestamoPlanta);

        int AnularDevolucionPrestamoPlanta(int DevolucionPrestamoPlantaId, DateTime fecha, string usuario, string estadoId,string Observacion);
    }
}