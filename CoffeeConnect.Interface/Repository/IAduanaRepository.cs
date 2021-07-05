using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IAduanaRepository
    {
        int Insertar(Aduana Aduana);

        int Actualizar(Aduana Aduana);

        IEnumerable<ConsultaAduanaBE> ConsultarAduana(ConsultaAduanaRequestDTO request);

        ConsultaAduanaPorIdBE ConsultarAduanaPorId(int AduanaId);

        int Anular(int AduanaId, DateTime fecha, string usuario, string estadoId);


        IEnumerable<ConsultaAduanaCertificacionPorIdBE> ConsultarAduanaCertificacionPorId(int aduanaId);
        int ActualizarAduanaCertificacion(List<AduanaCertificacionTipo> request, int aduanaId);

    }
}