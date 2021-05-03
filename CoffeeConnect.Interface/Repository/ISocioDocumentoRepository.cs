using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Interface.Repository
{
    public interface ISocioDocumentoRepository
    {
        int Insertar(SocioDocumento socioDocumento);

        int Actualizar(SocioDocumento socioDocumento);

        IEnumerable<ConsultarSocioDocumentoPorSocioId> ConsultarSocioDocumentoPorSocioId(int socioId);
    }
}
