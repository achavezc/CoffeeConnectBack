using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IPrestamoPlantaRepository
    {   

        IEnumerable<ConsultaPrestamoPlantaBE> ConsultarPrestamoPlanta(ConsultaPrestamoPlantaRequestDTO request);
         
        ConsultaPrestamoPlantaPorIdBE ConsultarPrestamoPlantaPorId(int PrestamoPlantaId);
        int InsertarPrestamoPlanta(PrestamoPlanta PrestamoPlanta);
        int Actualizar(PrestamoPlanta PrestamoPlanta);
       // int PrestamoPlantaActualizarTotalImporteProcesado(PrestamoPlantaActualizarTotalImporteProcesado PrestamoPlanta2);

        

        int ActualizarPrestamoPlantaEstado(int PrestamoPlantaId, DateTime fecha, string usuario, string estadoId);

        int ActualizarPrestamoPlantaEstadoMontos(int PrestamoPlantaId, DateTime fecha, string usuario, string estadoId, decimal importe);

        int PrestamoPlantaActualizarImporteProcesado(PrestamoPlantaActualizarImporteProcesado PrestamoPlanta);

    }
}