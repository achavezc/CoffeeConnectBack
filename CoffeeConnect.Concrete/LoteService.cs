
using AutoMapper;
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
    public partial class LoteService : ILoteService
    {

        private readonly IMapper _Mapper;
        private ILoteRepository _ILoteRepository;

        private INotaIngresoAlmacenRepository _INotaIngresoAlmacenRepository;

        private ICorrelativoRepository _ICorrelativoRepository;

        public LoteService(ILoteRepository loteRepository, INotaIngresoAlmacenRepository notaIngresoAlmacenRepository, ICorrelativoRepository correlativoRepository, IMapper mapper)
        {
            _ILoteRepository = loteRepository;
            _INotaIngresoAlmacenRepository = notaIngresoAlmacenRepository;
            _ICorrelativoRepository = correlativoRepository;
            _Mapper = mapper;
        }

        public int GenerarLote(GenerarLoteRequestDTO request)
        {
            Lote lote = new Lote();
            lote.EmpresaId = request.EmpresaId;
            lote.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.Lote);
            lote.EstadoId = LoteEstados.Ingresado;
            lote.AlmacenId = request.AlmacenId;
            lote.FechaRegistro = DateTime.Now;
            lote.UsuarioRegistro = request.Usuario;

            int loteId = 0;

            decimal totalKilosNetosPesado = 0;
            decimal totalKilosBrutosPesado = 0;
            decimal totalCantidad = 0;
            string unidadMedidaId = String.Empty;
            decimal totalRendimientoPorcentaje = 0;
            decimal totalAnalisisSensorial = 0;
            decimal totalHumedadPorcentaje = 0;


            List<NotaIngresoAlmacen> notasIngreso = _INotaIngresoAlmacenRepository.ConsultarNotaIngresoPorIds(request.NotasIngresoAlmacenId).ToList();

            if (notasIngreso != null)
            {

                List<LoteDetalle> lotesDetalle = new List<LoteDetalle>();

                notasIngreso.ForEach(notaingreso =>
                {
                    LoteDetalle item = new LoteDetalle();
                    item.LoteId = loteId;
                    item.NotaIngresoAlmacenId = notaingreso.NotaIngresoAlmacenId;
                    item.Numero = notaingreso.Numero;
                    item.TipoProvedorId = notaingreso.TipoProvedorId;
                    item.SocioId = notaingreso.SocioId;
                    item.TerceroId = notaingreso.TerceroId;
                    item.IntermediarioId = notaingreso.IntermediarioId;
                    item.ProductoId = notaingreso.ProductoId;
                    item.SubProductoId = notaingreso.SubProductoId;
                    item.UnidadMedidaIdPesado = notaingreso.UnidadMedidaIdPesado;
                    item.CantidadPesado = notaingreso.CantidadPesado;
                    item.KilosNetosPesado = notaingreso.KilosNetosPesado;
                    item.KilosBrutosPesado = notaingreso.KilosBrutosPesado;
                    item.RendimientoPorcentaje = notaingreso.RendimientoPorcentaje;
                    item.HumedadPorcentaje = notaingreso.HumedadPorcentajeAnalisisFisico;
                    item.TotalAnalisisSensorial = notaingreso.TotalAnalisisSensorial.Value;


                    item.NotaIngresoAlmacenId = notaingreso.NotaIngresoAlmacenId;
                    totalKilosNetosPesado = totalKilosNetosPesado + item.KilosNetosPesado;
                    totalKilosBrutosPesado = totalKilosBrutosPesado + item.KilosBrutosPesado;
                    totalRendimientoPorcentaje = totalRendimientoPorcentaje + item.RendimientoPorcentaje.Value;
                    totalAnalisisSensorial = totalAnalisisSensorial + item.TotalAnalisisSensorial;
                    totalHumedadPorcentaje = totalHumedadPorcentaje + item.HumedadPorcentaje;
                    totalCantidad = totalCantidad + item.CantidadPesado;
                    unidadMedidaId = item.UnidadMedidaIdPesado;

                    lotesDetalle.Add(item);
                });


                lote.TotalKilosNetosPesado = totalKilosNetosPesado;
                lote.TotalKilosBrutosPesado = totalKilosBrutosPesado;
                lote.PromedioRendimientoPorcentaje = totalRendimientoPorcentaje / lotesDetalle.Count;
                lote.PromedioHumedadPorcentaje = totalHumedadPorcentaje / lotesDetalle.Count;
                lote.UnidadMedidaId = unidadMedidaId;
                lote.PromedioTotalAnalisisSensorial = totalAnalisisSensorial / lotesDetalle.Count;

                lote.Cantidad = totalCantidad;

                loteId = _ILoteRepository.Insertar(lote);

                lotesDetalle.ForEach(loteDetalle =>
                {
                    loteDetalle.LoteId = loteId;

                });

                int affected = _ILoteRepository.InsertarLoteDetalle(lotesDetalle);

                notasIngreso.ForEach(notaingreso =>
                {
                    _INotaIngresoAlmacenRepository.ActualizarEstado(notaingreso.NotaIngresoAlmacenId, DateTime.Now, request.Usuario, NotaIngresoAlmacenEstados.Lotizado);
                });

            }

            return loteId;
        }


       


        public List<ConsultaImpresionLotePorIdBE> ConsultarImpresionLotePorId(int loteId)
        {

            var list = _ILoteRepository.ConsultarImpresionLotePorId(loteId);

            return list.ToList();
        }

        public List<ConsultaLoteBE> ConsultarLote(ConsultaLoteRequestDTO request)
        {
            if (string.IsNullOrEmpty(request.Numero) && string.IsNullOrEmpty(request.NumeroDocumento) && string.IsNullOrEmpty(request.CodigoSocio) && string.IsNullOrEmpty(request.NombreRazonSocial))
                throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.NotaCompra.ValidacionSeleccioneMinimoUnFiltro.Label" });


            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Acopio.NotaCompra.ValidacionRangoFechaMayor2anios.Label" });



            var list = _ILoteRepository.ConsultarLote(request);

            return list.ToList();
        }

        public int AnularLote(AnularLoteRequestDTO request)
        {
            int affected = _ILoteRepository.ActualizarEstado(request.LoteId, DateTime.Now, request.Usuario, LoteEstados.Anulado);

            List<LoteDetalle> lotesDetalle = _ILoteRepository.ConsultarLoteDetallePorId(request.LoteId).ToList();

            lotesDetalle.ForEach(loteDetalle =>
            {
                _INotaIngresoAlmacenRepository.ActualizarEstado(loteDetalle.NotaIngresoAlmacenId, DateTime.Now, request.Usuario, NotaIngresoAlmacenEstados.Ingresado);
            });

            return affected;
        }

        public int ActualizarLote(ActualizarLoteRequestDTO request)
        {
            int affected = _ILoteRepository.Actualizar(request.LoteId, DateTime.Now, request.Usuario, request.AlmacenId);



            return affected;
        }

        //public ConsultaLoteBandejaBE ConsultarLoteDetallePorLoteId(ConsultaLoteDetallePorLoteIdRequestDTO request)
        //{
        //    ConsultaLoteBandejaBE response = new ConsultaLoteBandejaBE();
        //    IEnumerable<LoteDetalleConsulta> resultado= _ILoteRepository.ConsultarBandejaLoteDetallePorId(request.LoteId);

        //    response.listaDetalle = resultado.ToList();


        //    if (resultado.Any()) {
        //        response.TotalPesoNeto = resultado.Sum(x => x.KilosNetosPesado);
        //        response.PromedioHumedad = resultado.Average(x => x.HumedadPorcentaje);
        //        response.PromedioRendimiento = resultado.Average(x => x.RendimientoPorcentaje);
        //    }
        //    response.LoteId = request.LoteId;


        //    return response;
        //}

        public List<LoteDetalleConsulta> ConsultaLoteDetalleBusquedaPorLoteId(ConsultaLoteDetalleBusquedaPorLoteIdRequestDTO request)
        {
            var resultado = _ILoteRepository.ConsultarBandejaLoteDetallePorId(request.LoteId).ToList();

            return resultado;
        }

        public ConsultaLoteBandejaBE ConsultarLotePorId(ConsultaLoteDetallePorLoteIdRequestDTO request)
        {

            LotesBE Lote = _ILoteRepository.ConsultarLotePorId(request.LoteId);
            ConsultaLoteBandejaBE response = new ConsultaLoteBandejaBE();
            //ConsultaLoteBandejaBE response= _Mapper.Map<ConsultaLoteBandejaBE>(Lote);
            IEnumerable<LoteDetalleConsulta> resultado = _ILoteRepository.ConsultarBandejaLoteDetallePorId(request.LoteId);

            response.LoteId = Lote.LoteId;
            response.Numero = Lote.Numero;
            response.EmpresaId = Lote.EmpresaId;
            response.RazonSocial = Lote.RazonSocial;
            response.Ruc = Lote.Ruc;
            response.Direccion = Lote.Direccion;
            response.Logo = Lote.Logo;
            response.DepartamentoId = Lote.DepartamentoId;
            response.Departamento = Lote.Departamento;
            response.ProvinciaId = Lote.ProvinciaId;
            response.Provincia = Lote.Provincia;
            response.DistritoId = Lote.DistritoId;
            response.Distrito = Lote.Distrito;
            response.EstadoId = Lote.EstadoId;
            response.Estado = Lote.Estado;
            response.AlmacenId = Lote.AlmacenId;
            response.Almacen = Lote.Almacen;
            response.UnidadMedidaId = Lote.UnidadMedidaId;
            response.UnidadMedida = Lote.UnidadMedida;
            response.Cantidad = Lote.Cantidad;
            response.TotalKilosNetosPesado = Lote.TotalKilosNetosPesado;
            response.TotalKilosBrutosPesado = Lote.TotalKilosBrutosPesado;
            response.PromedioRendimientoPorcentaje = Lote.PromedioRendimientoPorcentaje;
            response.PromedioHumedadPorcentaje = Lote.PromedioHumedadPorcentaje;
            response.PromedioTotalAnalisisSensorial = Lote.PromedioTotalAnalisisSensorial;
            response.FechaRegistro = Lote.FechaRegistro;
            response.UsuarioRegistro = Lote.UsuarioRegistro;
            response.FechaUltimaActualizacion = Lote.FechaUltimaActualizacion;
            response.UsuarioUltimaActualizacion = Lote.UsuarioUltimaActualizacion;
            response.Activo = Lote.Activo;
            response.PromedioTotalAnalisisSensorial = Lote.PromedioTotalAnalisisSensorial;
            response.listaDetalle = resultado.ToList();

            //if (resultado.Any())
            //{
            //    response.TotalPesoNeto = resultado.Sum(x => x.KilosNetosPesado);
            //    response.PromedioHumedad = resultado.Average(x => x.HumedadPorcentaje);
            //    response.PromedioRendimiento = resultado.Average(x => x.RendimientoPorcentaje);
            //}
            //response.LoteId = request.LoteId;

            return response;
        }
    }
}
