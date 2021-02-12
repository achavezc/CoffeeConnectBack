
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using Core.Common.Domain.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeConnect.Service
{
    public partial class NotaCompraService : INotaCompraService
    {
       
        private INotaCompraRepository _INotaCompraRepository;

        

        public NotaCompraService(INotaCompraRepository notaCompraRepository)
        {
            _INotaCompraRepository = notaCompraRepository;
           
        }

       		
			
        
        public int RegistrarNotaCompra(RegistrarActualizarNotaCompraRequestDTO request)
        {
            NotaCompra notaCompra = new NotaCompra();

            notaCompra.GuiaRecepcionMateriaPrimaId = request.GuiaRecepcionMateriaPrimaId;
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
            notaCompra.ExportableGramosAnalisisFisico = request.ExportableGramosAnalisisFisico;   
            notaCompra.DescarteGramosAnalisisFisico = request.DescarteGramosAnalisisFisico;
            notaCompra.CascarillaGramosAnalisisFisico = request.CascarillaGramosAnalisisFisico;
            notaCompra.TotalGramosAnalisisFisico = request.TotalGramosAnalisisFisico;
            notaCompra.HumedadPorcentajeAnalisisFisico = request.HumedadPorcentajeAnalisisFisico;
            notaCompra.TipoId = request.TipoId;
            notaCompra.PrecioGuardado = request.PrecioGuardado;
            notaCompra.PrecioPagado = request.PrecioPagado;
            notaCompra.Importe = request.Importe;
            notaCompra.EstadoId = NotaCompraEstados.PorLiquidar;          
            notaCompra.FechaRegistro = DateTime.Now;
            notaCompra.UsuarioRegistro = request.UsuarioNotaCompra;  

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
            notaCompra.ExportableGramosAnalisisFisico = request.ExportableGramosAnalisisFisico;
            notaCompra.DescarteGramosAnalisisFisico = request.DescarteGramosAnalisisFisico;
            notaCompra.CascarillaGramosAnalisisFisico = request.CascarillaGramosAnalisisFisico;
            notaCompra.TotalGramosAnalisisFisico = request.TotalGramosAnalisisFisico;
            notaCompra.HumedadPorcentajeAnalisisFisico = request.HumedadPorcentajeAnalisisFisico;
            notaCompra.TipoId = request.TipoId;
            notaCompra.PrecioGuardado = request.PrecioGuardado;
            notaCompra.PrecioPagado = request.PrecioPagado;
            notaCompra.Importe = request.Importe;
            notaCompra.EstadoId = NotaCompraEstados.PorLiquidar;
            notaCompra.FechaUltimaActualizacion = DateTime.Now;
            notaCompra.UsuarioUltimaActualizacion = request.UsuarioNotaCompra;

            int affected = _INotaCompraRepository.Actualizar(notaCompra);

            return affected;
        }

        public int AnularNotaCompra(AnularNotaCompraRequestDTO request)
        {
            int affected = _INotaCompraRepository.Anular(request.NotaCompraId, DateTime.Now, request.Usuario, NotaCompraEstados.Anulado);

            return affected;
        }

        public int LiquidarNotaCompra(LiquidarNotaCompraRequestDTO request)
        {
            int affected = _INotaCompraRepository.Liquidar(request.NotaCompraId, DateTime.Now, request.Usuario, NotaCompraEstados.Liquidado,request.PrecioDia, request.Importe);

            return affected;
        }


        public List<ConsultaNotaCompraBE> ConsultarNotaCompra(ConsultaNotaCompraRequestDTO request)
        {
            if (string.IsNullOrEmpty(request.Numero) && string.IsNullOrEmpty(request.NumeroGuiaRecepcion) && string.IsNullOrEmpty(request.NumeroDocumento) && string.IsNullOrEmpty(request.CodigoSocio) && string.IsNullOrEmpty(request.NombreRazonSocial))
                throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.NotaCompra.ValidacionSeleccioneMinimoUnFiltro.Label" });


            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Acopio.NotaCompra.ValidacionRangoFechaMayor2anios.Label" });



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


       
}
}
