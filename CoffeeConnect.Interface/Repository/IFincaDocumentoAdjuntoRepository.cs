using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IFincaDocumentoAdjuntoRepository
    {
        int Insertar(FincaDocumentoAdjunto FincaDocumentoAdjunto);

        int Actualizar(FincaDocumentoAdjunto FincaDocumentoAdjunto);

        IEnumerable<ConsultaFincaDocumentoAdjuntoPorId> ConsultarFincaDocumentoAdjuntoPorFincaId(int fincaId);

        ConsultaFincaDocumentoAdjuntoPorId ConsultarFincaDocumentoAdjuntoPorId(int FincaDocumentoAdjuntoId);

        int Eliminar(int fincaDocumentoAdjuntoId);
    }
}