using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using CoffeeConnect.Models.Kardex;
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

        public int Anular(int KardexProcesoId, DateTime fecha, string usuario, string estadoId);
        IEnumerable<KardexPergaminoIngresoConsultaResponse> KardexPergaminoIngresoConsulta(KardexPergaminoIngresoConsultaRequest request);
        IEnumerable<KardexPergaminoSalidaConsultaResponse> KardexPergaminoSalidadConsulta(KardexPergaminoSalidaConsultaRequest request);
    }
}
