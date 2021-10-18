using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Interface.Repository
{
    public interface IKardexProcesoRepository
    {
        IEnumerable<ConsultaKardexProcesoBE> ConsultarKardexProceso(ConsultaKardexProcesoRequestDTO request);

        public int Insertar(KardexProceso kardexProceso);

        public int Actualizar(KardexProceso kardexProceso);

        public ConsultaKardexProcesoPorIdBE ConsultarKardexProcesoPorId(int KardexProcesoId);
    }
}
