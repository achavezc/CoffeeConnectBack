using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface  IGuiaRecepcionMateriaPrimaRepository
    {
        IEnumerable<ConsultaGuiaRecepcionMateriaPrimaBE> ConsultarGuiaRecepcionMateriaPrima(ConsultaGuiaRecepcionMateriaPrimaRequestDTO request);
        int AnularGuiaRecepcionMateriaPrima(int guiaRecepcionMateriaPrimaId, DateTime fecha,string usuario,string estadoId);
        ConsultaGuiaRecepcionMateriaPrimaPorIdBE ConsultarGuiaRecepcionMateriaPrimaPorId(int guiaRecepcionMateriaPrimaId);
        int Insert(GuiaRecepcionMateriaPrima guiaRecepcionMateriaPrima);
        int ActualizarAnalisisCalidad(GuiaRecepcionMateriaPrima guiaRecepcionMateriaPrima);

    }
}