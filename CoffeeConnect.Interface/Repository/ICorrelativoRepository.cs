using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface ICorrelativoRepository
    {
        string Obtener(int? empresaId, string documento);
        string ObtenerCorrelativoNotaIngreso(string Campaña, string CodigoTipo, string CodigoTipoConcepto);
  
        IEnumerable<CorrelativoPlantaBE> ConsultarCorrelativo(ConsultaCorrelativoPlantaRequestDTO request);
        public CorrelativoPlantaBE ConsultarCorrelativoPlantaPorId(int CorrelativoPlantaId);
        public int ActualizarCorrelativo(CorrelativoPlanta correlativoPlanta);
        public int InsertarCorrelativo(CorrelativoPlanta correlativoPlanta);
        IEnumerable<CorrelativoPlanta> ObtenerCorrelativoPlanta(string codigoTipo);
        IEnumerable<CorrelativoPlanta> ObtenerTipoCorrelativoPlanta();
    }
}