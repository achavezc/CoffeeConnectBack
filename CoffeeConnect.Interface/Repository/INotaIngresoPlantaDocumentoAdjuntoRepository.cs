using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface INotaIngresoPlantaDocumentoAdjuntoRepository
    {
        int Insertar(NotaIngresoPlantaDocumentoAdjunto NotaIngresoPlantaDocumentoAdjunto);

        int Actualizar(NotaIngresoPlantaDocumentoAdjunto NotaIngresoPlantaDocumentoAdjunto);

        IEnumerable<ConsultaNotaIngresoPlantaDocumentoAdjuntoPorId> ConsultarNotaIngresoPlantaDocumentoAdjuntoPorNotaIngresoPlantaId(int NotaIngresoPlantaId);

        ConsultaNotaIngresoPlantaDocumentoAdjuntoPorId ConsultarNotaIngresoPlantaDocumentoAdjuntoPorId(int NotaIngresoPlantaDocumentoAdjuntoId);

        int Eliminar(int NotaIngresoPlantaDocumentoAdjuntoId);
    }
}