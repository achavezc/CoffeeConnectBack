using CoffeeConnect.DTO;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface IGuiaRecepcionMateriaPrimaService
    {
        List<ConsultaGuiaRecepcionMateriaPrimaBE> ConsultarGuiaRecepcionMateriaPrima(ConsultaGuiaRecepcionMateriaPrimaRequestDTO consultaGuiaRecepcionMateriaPrimaRequestDTO);
        int AnularGuiaRecepcionMateriaPrima(AnularGuiaRecepcionMateriaPrimaRequestDTO request);

        ConsultaGuiaRecepcionMateriaPrimaPorIdBE ConsultarGuiaRecepcionMateriaPrimaPorId(ConsultaGuiaRecepcionMateriaPrimaPorIdRequestDTO request);
        int RegistrarGuiaRecepcionMateriaPrima(RegistrarGuiaRecepcionMateriaPrimaRequestDTO request);
        int ActualizarGuiaRecepcionMateriaPrimaAnalisisCalidad(ActualizarGuiaRecepcionMateriaPrimaAnalisisCalidadRequestDTO request);
    }
}
