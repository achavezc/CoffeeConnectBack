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

        int Eliminar(int socioDocumentoId);

        IEnumerable<ConsultarProductorDocumentoPorProductorId> ConsultarProductorDocumentoPorProductorId(int ProductorId);

        ProductorDocumento ConsultarProductorDocumentoPorId(int productorDocumentoId);
    }
}
