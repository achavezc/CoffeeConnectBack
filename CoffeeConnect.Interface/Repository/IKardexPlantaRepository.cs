using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using CoffeeConnect.Models.Kardex;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Interface.Repository
{
    public interface IKardexPlantaRepository
    {
        IEnumerable<ConsultaKardexPlantaBE> ConsultarKardexPlanta(ConsultaKardexPlantaRequestDTO request);

        public int Insertar(KardexPlanta kardexPlanta);

        public int Actualizar(KardexPlanta kardexPlanta);

        public ConsultaKardexPlantaPorIdBE ConsultarKardexPlantaPorId(int KardexPlantaId);

        public int Anular(int KardexPlantaId, DateTime fecha, string usuario, string estadoId);
        
    }
}
