﻿using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface INotaCompraRepository
    {
        int Insertar(NotaCompra notaCompra);

        int Actualizar(NotaCompra notaCompra);

        int Anular(int notaCompraId, DateTime fecha, string usuario, string estadoId);

        int Liquidar(int notaCompraId, DateTime fecha, string usuario, string estadoId, decimal? precioDia, decimal? importe);

        IEnumerable<ConsultaNotaCompraBE> ConsultarNotaCompra(ConsultaNotaCompraRequestDTO request);

        ConsultaNotaCompraPorGuiaRecepcionMateriaPrimaIdBE ConsultarNotaCompraPorGuiaRecepcionMateriaPrimaId(int guiaRecepcionMateriaPrimaId);
    }
}