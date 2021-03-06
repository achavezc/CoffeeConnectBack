﻿
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeConnect.Service
{
    public partial class NotaCompraService : INotaCompraService
    {
        private INotaCompraRepository _INotaCompraRepository;
        private ICorrelativoRepository _ICorrelativoRepository;

        public NotaCompraService(INotaCompraRepository notaCompraRepository, ICorrelativoRepository correlativoRepository)
        {
            _INotaCompraRepository = notaCompraRepository;
            _ICorrelativoRepository = correlativoRepository;
        }

        public int RegistrarNotaCompra(RegistrarActualizarNotaCompraRequestDTO request)
        {
            NotaCompra notaCompra = new NotaCompra();

            notaCompra.GuiaRecepcionMateriaPrimaId = request.GuiaRecepcionMateriaPrimaId;
            notaCompra.EmpresaId = request.EmpresaId;
            notaCompra.Numero = request.Numero;
            notaCompra.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.NotaCompra);
            notaCompra.UnidadMedidaIdPesado = request.UnidadMedidaIdPesado;
            notaCompra.CantidadPesado = request.CantidadPesado;
            notaCompra.KilosBrutosPesado = request.KilosBrutosPesado;
            notaCompra.TaraPesado = request.TaraPesado;
            notaCompra.KilosNetosPesado = request.KilosNetosPesado;
            notaCompra.DescuentoPorHumedad = request.DescuentoPorHumedad;
            notaCompra.KilosNetosDescontar = request.KilosNetosDescontar;
            notaCompra.KilosNetosPagar = request.KilosNetosPagar;
            notaCompra.QQ55 = request.QQ55;
            notaCompra.TipoId = request.TipoId;
            notaCompra.MonedaId = request.MonedaId;
            notaCompra.PrecioGuardado = request.PrecioGuardado;
            notaCompra.PrecioPagado = request.PrecioPagado;
            notaCompra.Importe = request.Importe;
            notaCompra.EstadoId = NotaCompraEstados.PorLiquidar;
            notaCompra.FechaRegistro = DateTime.Now;
            notaCompra.UsuarioRegistro = request.UsuarioNotaCompra;
            notaCompra.Observaciones = request.Observaciones;

            int affected = _INotaCompraRepository.Insertar(notaCompra);

            return affected;
        }

        public int ActualizarNotaCompra(RegistrarActualizarNotaCompraRequestDTO request)
        {
            NotaCompra notaCompra = new NotaCompra();

            notaCompra.GuiaRecepcionMateriaPrimaId = request.GuiaRecepcionMateriaPrimaId;
            notaCompra.NotaCompraId = request.NotaCompraId;
            notaCompra.EmpresaId = request.EmpresaId;
            notaCompra.Numero = request.Numero;
            notaCompra.UnidadMedidaIdPesado = request.UnidadMedidaIdPesado;
            notaCompra.CantidadPesado = request.CantidadPesado;
            notaCompra.KilosBrutosPesado = request.KilosBrutosPesado;
            notaCompra.TaraPesado = request.TaraPesado;
            notaCompra.KilosNetosPesado = request.KilosNetosPesado;
            notaCompra.DescuentoPorHumedad = request.DescuentoPorHumedad;
            notaCompra.KilosNetosDescontar = request.KilosNetosDescontar;
            notaCompra.KilosNetosPagar = request.KilosNetosPagar;
            notaCompra.QQ55 = request.QQ55;
            notaCompra.TipoId = request.TipoId;
            notaCompra.MonedaId = request.MonedaId;
            notaCompra.PrecioGuardado = request.PrecioGuardado;
            notaCompra.PrecioPagado = request.PrecioPagado;
            notaCompra.Importe = request.Importe;
            notaCompra.EstadoId = NotaCompraEstados.PorLiquidar;
            notaCompra.FechaUltimaActualizacion = DateTime.Now;
            notaCompra.UsuarioUltimaActualizacion = request.UsuarioNotaCompra;
            notaCompra.Observaciones = request.Observaciones;

            int affected = _INotaCompraRepository.Actualizar(notaCompra);

            return affected;
        }

        public int AnularNotaCompra(AnularNotaCompraRequestDTO request)
        {
            int affected = _INotaCompraRepository.Anular(request.NotaCompraId, DateTime.Now, request.Usuario, NotaCompraEstados.PorLiquidar);

            return affected;
        }

        public int LiquidarNotaCompra(LiquidarNotaCompraRequestDTO request)
        {
            int affected = _INotaCompraRepository.Liquidar(request.NotaCompraId, DateTime.Now, request.Usuario, NotaCompraEstados.Liquidado, request.MonedaId, request.PrecioPagado, request.Importe);

            return affected;
        }

        public List<ConsultaNotaCompraBE> ConsultarNotaCompra(ConsultaNotaCompraRequestDTO request)
        {
            if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFin == null || request.FechaFin == DateTime.MinValue || string.IsNullOrEmpty(request.EstadoId))
            {
                throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.NotaCompra.ValidacionSeleccioneMinimoUnFiltro.Label" });
            }

            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
            {
                throw new ResultException(new Result { ErrCode = "02", Message = "Acopio.NotaCompra.ValidacionRangoFechaMayor2anios.Label" });
            }

            var list = _INotaCompraRepository.ConsultarNotaCompra(request);
            return list.ToList();
        }

        public ConsultaNotaCompraPorGuiaRecepcionMateriaPrimaIdBE ConsultarNotaCompraPorGuiaRecepcionMateriaPrimaId(ConsultaNotaCompraPorGuiaRecepcionMateriaPrimaIdRequestDTO request)
        {
            return _INotaCompraRepository.ConsultarNotaCompraPorGuiaRecepcionMateriaPrimaId(request.GuiaRecepcionMateriaPrimaId);
        }

        public ConsultaImpresionNotaCompraPorGuiaRecepcionMateriaPrimaIdBE ConsultarImpresionNotaCompraPorGuiaRecepcionMateriaPrimaId(ConsultaNotaCompraPorGuiaRecepcionMateriaPrimaIdRequestDTO request)
        {
            return _INotaCompraRepository.ConsultarImpresionNotaCompraPorGuiaRecepcionMateriaPrimaId(request.GuiaRecepcionMateriaPrimaId);
        }

        public ConsultaNotaCompraPorIdBE ConsultarNotaCompraPorId(ConsultaNotaCompraPorIdRequestDTO request)
        {
            return _INotaCompraRepository.ConsultarNotaCompraPorId(request.NotaCompraId);
        }

    }
}
