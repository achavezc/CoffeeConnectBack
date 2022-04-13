using CoffeeConnect.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Interface.Service
{
    public interface IKardexPlantaService
    {
        List<ConsultaKardexPlantaBE> ConsultarKardexPlanta(ConsultaKardexPlantaRequestDTO request);

        public int Registrar(RegistrarActualizarKardexPlantaRequestDTO request);

        public int Actualizar(RegistrarActualizarKardexPlantaRequestDTO request);

        public ConsultaKardexPlantaPorIdBE ConsultarKardexPlantaPorId(ConsultaKardexPlantaPorIdRequestDTO request);

        public int Anular(AnularKardexPlantaRequestDTO request);
    }
}
