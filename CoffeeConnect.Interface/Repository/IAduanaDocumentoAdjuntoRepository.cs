using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IAduanaDocumentoAdjuntoRepository
    {
        int Insertar(AduanaDocumentoAdjunto AduanaDocumentoAdjunto);

        int Actualizar(AduanaDocumentoAdjunto AduanaDocumentoAdjunto);

        IEnumerable<ConsultaAduanaDocumentoAdjuntoPorId> ConsultarAduanaDocumentoAdjuntoPorAduanaId(int AduanaId);

        ConsultaAduanaDocumentoAdjuntoPorId ConsultarAduanaDocumentoAdjuntoPorId(int AduanaDocumentoAdjuntoId);

        int Eliminar(int AduanaDocumentoAdjuntoId);
    }
}