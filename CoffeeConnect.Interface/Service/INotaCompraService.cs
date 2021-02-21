﻿using CoffeeConnect.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoffeeConnect.Interface.Service
{
    public interface INotaCompraService
    {
        int RegistrarNotaCompra(RegistrarActualizarNotaCompraRequestDTO request);

        int ActualizarNotaCompra(RegistrarActualizarNotaCompraRequestDTO request);

        int AnularNotaCompra(AnularNotaCompraRequestDTO request);

        int LiquidarNotaCompra(LiquidarNotaCompraRequestDTO request);

        List<ConsultaNotaCompraBE> ConsultarNotaCompra(ConsultaNotaCompraRequestDTO request);

        ConsultaNotaCompraPorGuiaRecepcionMateriaPrimaIdBE ConsultarNotaCompraPorGuiaRecepcionMateriaPrimaId(ConsultaNotaCompraPorGuiaRecepcionMateriaPrimaIdRequestDTO request);

        ConsultaImpresionNotaCompraPorGuiaRecepcionMateriaPrimaIdBE ConsultarImpresionNotaCompraPorGuiaRecepcionMateriaPrimaId(ConsultaNotaCompraPorGuiaRecepcionMateriaPrimaIdRequestDTO request);
    }
}