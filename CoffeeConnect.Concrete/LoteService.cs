
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeConnect.Service
{
    public partial class LoteService : ILoteService
    {
       
        private ILoteRepository _ILoteRepository;

        private INotaIngresoAlmacenRepository _INotaIngresoAlmacenRepository;

        private ICorrelativoRepository _ICorrelativoRepository;

        public LoteService(ILoteRepository loteRepository, INotaIngresoAlmacenRepository notaIngresoAlmacenRepository, ICorrelativoRepository correlativoRepository)
        {
            _ILoteRepository = loteRepository;
            _INotaIngresoAlmacenRepository = notaIngresoAlmacenRepository;
            _ICorrelativoRepository = correlativoRepository;
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
            decimal totalRendimientoPorcentaje = 0;
            decimal totalHumedadPorcentaje = 0;
                            

            List<NotaIngresoAlmacen> notasIngreso = _INotaIngresoAlmacenRepository.ConsultarNotaIngresoPorIds(request.NotasIngresoAlmacenId).ToList();

            if (notasIngreso!=null)
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
                    item.RendimientoPorcentaje = notaingreso.RendimientoPorcentaje;
                    item.HumedadPorcentaje = notaingreso.HumedadPorcentajeAnalisisFisico;


                    item.NotaIngresoAlmacenId = notaingreso.NotaIngresoAlmacenId;
                    totalKilosNetosPesado = totalKilosNetosPesado + item.KilosNetosPesado;
                    totalRendimientoPorcentaje = totalRendimientoPorcentaje + item.RendimientoPorcentaje.Value;
                    totalHumedadPorcentaje = totalHumedadPorcentaje + item.HumedadPorcentaje;
                    

                    lotesDetalle.Add(item);
                });


                lote.TotalKilosNetosPesado = totalKilosNetosPesado;
                lote.PromedioRendimientoPorcentaje = totalRendimientoPorcentaje/ lotesDetalle.Count;
                lote.PromedioHumedadPorcentaje = totalHumedadPorcentaje / lotesDetalle.Count;

                loteId = _ILoteRepository.Insertar(lote);

                lotesDetalle.ForEach(loteDetalle =>
                {                    
                    loteDetalle.LoteId = loteId;                    

                });

                int    affected = _ILoteRepository.InsertarLoteDetalle(lotesDetalle);

                notasIngreso.ForEach(notaingreso =>
                {
                    _INotaIngresoAlmacenRepository.ActualizarEstado(notaingreso.NotaIngresoAlmacenId,DateTime.Now, request.Usuario, NotaIngresoAlmacenEstados.Lotizado);
                });

            }       

            return loteId;
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
    }
}
