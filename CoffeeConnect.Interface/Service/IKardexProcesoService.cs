using CoffeeConnect.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Interface.Service
{
    public interface IKardexProcesoService
    {
        List<ConsultaKardexProcesoBE> ConsultarKardexProceso(ConsultaKardexProcesoRequestDTO request);

        public int Registrar(RegistrarActualizarKardexProcesoRequestDTO request);

        public int Actualizar(RegistrarActualizarKardexProcesoRequestDTO request);

        public ConsultaKardexProcesoPorIdBE ConsultarKardexProcesoPorId(ConsultaKardexProcesoPorIdRequestDTO request);
    }
}
