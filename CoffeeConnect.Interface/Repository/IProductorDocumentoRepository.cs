using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Interface.Repository
{
    public interface IProductorDocumentoRepository
    {
        int Insertar(ProductorDocumento ProductorDocumento);

        int Actualizar(ProductorDocumento ProductorDocumento);

        IEnumerable<ConsultarProductorDocumentoPorProductorId> ConsultarProductorDocumentoPorProductorId(int ProductorId);
    }
}
