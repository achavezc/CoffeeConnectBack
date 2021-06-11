
using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            lote.ProductoId = request.ProductoId;
            lote.SubProductoId = request.SubProductoId;
            lote.TipoCertificacionId = request.TipoCertificacionId;

            int loteId = 0;

            decimal totalKilosNetosPesado = 0;
            decimal totalKilosBrutosPesado = 0;
            decimal totalCantidad = 0;
            string unidadMedidaId = String.Empty;
            decimal totalRendimientoPorcentaje = 0;
            decimal totalAnalisisSensorial = 0;
            decimal totalHumedadPorcentaje = 0;
            string tipoProduccionId = String.Empty;

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
                    tipoProduccionId = notaingreso.TipoProduccionId;
                    lotesDetalle.Add(item);
                });


                lote.TotalKilosNetosPesado = totalKilosNetosPesado;
                lote.TotalKilosBrutosPesado = totalKilosBrutosPesado;
                //lote.PromedioRendimientoPorcentaje = totalRendimientoPorcentaje / lotesDetalle.Count;
                //lote.PromedioHumedadPorcentaje = totalHumedadPorcentaje / lotesDetalle.Count;
                lote.UnidadMedidaId = unidadMedidaId;
                lote.TipoProduccionId = tipoProduccionId;
                //lote.PromedioTotalAnalisisSensorial = totalAnalisisSensorial / lotesDetalle.Count;

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

            if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFin == null || request.FechaFin == DateTime.MinValue || string.IsNullOrEmpty(request.EstadoId))
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

            List<LoteDetalle> lotesDetalle = _ILoteRepository.ConsultarLoteDetallePorLoteId(request.LoteId).ToList();

            lotesDetalle.ForEach(loteDetalle =>
            {
                _INotaIngresoAlmacenRepository.ActualizarEstado(loteDetalle.NotaIngresoAlmacenId, DateTime.Now, request.Usuario, NotaIngresoAlmacenEstados.Ingresado);
            });

            return affected;
        }

        public int ActualizarLote(ActualizarLoteRequestDTO request)
        {
            int affected = _ILoteRepository.Actualizar(request.LoteId, DateTime.Now, request.Usuario, request.AlmacenId, request.Cantidad, request.TotalKilosNetosPesado, request.TotalKilosBrutosPesado, request.ContratoId);

            if (request.NotasIngresoAlmacenId != null && request.NotasIngresoAlmacenId.Count > 0)
            {
                List<ListaIdsAccion> notasIngresoAlmacenIdEliminar = request.NotasIngresoAlmacenId.Where(a => a.Accion == "E").ToList();

                if (notasIngresoAlmacenIdEliminar != null && notasIngresoAlmacenIdEliminar.Count > 0)
                {
                    List<TablaIdsTipo> loteDetalleIdEliminar = new List<TablaIdsTipo>();
                    List<TablaIdsTipo> notasIntegresoIdActualizar = new List<TablaIdsTipo>();

                    foreach (ListaIdsAccion id in notasIngresoAlmacenIdEliminar)
                    {
                        TablaIdsTipo tablaIdsTipo = new TablaIdsTipo();
                        tablaIdsTipo.Id = id.Id;
                        loteDetalleIdEliminar.Add(tablaIdsTipo);


                        LoteDetalle loteDetalle = _ILoteRepository.ConsultarLoteDetallePorId(id.Id);

                        if (loteDetalle != null)
                        {
                            TablaIdsTipo tablaNotasIntegresoIdsTipo = new TablaIdsTipo();
                            tablaNotasIntegresoIdsTipo.Id = loteDetalle.LoteDetalleId;
                            notasIntegresoIdActualizar.Add(tablaNotasIntegresoIdsTipo);

                        }
                    }

                    _ILoteRepository.EliminarLoteDetalle(loteDetalleIdEliminar);

                    _INotaIngresoAlmacenRepository.ActualizarEstadoPorIds(loteDetalleIdEliminar, DateTime.Now, request.Usuario, NotaIngresoAlmacenEstados.Ingresado);
                }

                List<ListaIdsAccion> notasIngresoAlmacenIdNuevo = request.NotasIngresoAlmacenId.Where(a => a.Accion == "N").ToList();

                if (notasIngresoAlmacenIdNuevo != null && notasIngresoAlmacenIdNuevo.Count > 0)
                {

                    List<TablaIdsTipo> notasIngresoAlmacenIdConsulta = new List<TablaIdsTipo>();

                    foreach (ListaIdsAccion id in notasIngresoAlmacenIdNuevo)
                    {
                        TablaIdsTipo tablaIdsTipo = new TablaIdsTipo();
                        tablaIdsTipo.Id = id.Id;
                        notasIngresoAlmacenIdConsulta.Add(tablaIdsTipo);
                    }

                    List<NotaIngresoAlmacen> notasIngreso = _INotaIngresoAlmacenRepository.ConsultarNotaIngresoPorIds(notasIngresoAlmacenIdConsulta).ToList();

                    if (notasIngreso != null && notasIngreso.Count > 0)
                    {

                        List<LoteDetalle> lotesDetalle = new List<LoteDetalle>();

                        notasIngreso.ForEach(notaingreso =>
                        {
                            LoteDetalle item = new LoteDetalle();
                            item.LoteId = request.LoteId;
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
                            //totalKilosNetosPesado = totalKilosNetosPesado + item.KilosNetosPesado;
                            //totalKilosBrutosPesado = totalKilosBrutosPesado + item.KilosBrutosPesado;
                            //totalRendimientoPorcentaje = totalRendimientoPorcentaje + item.RendimientoPorcentaje.Value;
                            //totalAnalisisSensorial = totalAnalisisSensorial + item.TotalAnalisisSensorial;
                            //totalHumedadPorcentaje = totalHumedadPorcentaje + item.HumedadPorcentaje;
                            //totalCantidad = totalCantidad + item.CantidadPesado;
                            //unidadMedidaId = item.UnidadMedidaIdPesado;

                            lotesDetalle.Add(item);
                        });


                        /*
                        lote.TotalKilosNetosPesado = totalKilosNetosPesado;
                        lote.TotalKilosBrutosPesado = totalKilosBrutosPesado;
                        //lote.PromedioRendimientoPorcentaje = totalRendimientoPorcentaje / lotesDetalle.Count;
                        //lote.PromedioHumedadPorcentaje = totalHumedadPorcentaje / lotesDetalle.Count;
                        lote.UnidadMedidaId = unidadMedidaId;
                        //lote.PromedioTotalAnalisisSensorial = totalAnalisisSensorial / lotesDetalle.Count;

                        lote.Cantidad = totalCantidad;

                        loteId = _ILoteRepository.Insertar(lote);



                        

                        */

                        _ILoteRepository.InsertarLoteDetalle(lotesDetalle);

                        notasIngreso.ForEach(notaingreso =>
                        {
                            _INotaIngresoAlmacenRepository.ActualizarEstado(notaingreso.NotaIngresoAlmacenId, DateTime.Now, request.Usuario, NotaIngresoAlmacenEstados.Lotizado);
                        });
                    }

                }
            }

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

            ConsultaLoteBandejaBE response = _ILoteRepository.ConsultarLotePorId(request.LoteId);
            //ConsultaLoteBandejaBE response = new ConsultaLoteBandejaBE();
            //ConsultaLoteBandejaBE response= _Mapper.Map<ConsultaLoteBandejaBE>(Lote);
            IEnumerable<LoteDetalleConsulta> resultado = _ILoteRepository.ConsultarBandejaLoteDetallePorId(request.LoteId);

            //response.LoteId = Lote.LoteId;
            //response.Numero = Lote.Numero;
            //response.EmpresaId = Lote.EmpresaId;
            //response.RazonSocial = Lote.RazonSocial;
            //response.Ruc = Lote.Ruc;
            //response.Direccion = Lote.Direccion;
            //response.Logo = Lote.Logo;
            //response.DepartamentoId = Lote.DepartamentoId;
            //response.Departamento = Lote.Departamento;
            //response.ProvinciaId = Lote.ProvinciaId;
            //response.Provincia = Lote.Provincia;
            //response.DistritoId = Lote.DistritoId;
            //response.Distrito = Lote.Distrito;
            //response.EstadoId = Lote.EstadoId;
            //response.Estado = Lote.Estado;
            //response.AlmacenId = Lote.AlmacenId;
            //response.Almacen = Lote.Almacen;
            //response.UnidadMedidaId = Lote.UnidadMedidaId;
            //response.UnidadMedida = Lote.UnidadMedida;
            //response.Cantidad = Lote.Cantidad;
            //response.TotalKilosNetosPesado = Lote.TotalKilosBrutosPesado;
            //response.TotalKilosBrutosPesado = Lote.TotalKilosBrutosPesado;
            //response.PromedioRendimientoPorcentaje = Lote.PromedioRendimientoPorcentaje;
            //response.PromedioHumedadPorcentaje = Lote.PromedioHumedadPorcentaje;
            //response.PromedioTotalAnalisisSensorial = Lote.PromedioTotalAnalisisSensorial;
            //response.FechaRegistro = Lote.FechaRegistro;
            //response.UsuarioRegistro = Lote.UsuarioRegistro;
            //response.FechaUltimaActualizacion = Lote.FechaUltimaActualizacion;
            //response.UsuarioUltimaActualizacion = Lote.UsuarioUltimaActualizacion;
            //response.Activo = Lote.Activo;
            //response.PromedioTotalAnalisisSensorial = Lote.PromedioTotalAnalisisSensorial;
            //response.ProductoId = Lote.ProductoId;
            //response.Producto = Lote.Producto;
            //response.SubProductoId = Lote.SubProductoId;
            //response.SubProducto = Lote.SubProducto;
            //response.TipoCertificacionId = Lote.TipoCertificacionId;
            //response.TipoCertificacion = Lote.TipoCertificacion;

            response.listaDetalle = resultado.ToList();

            response.AnalisisFisicoColorDetalle = _ILoteRepository.ConsultarLoteAnalisisFisicoColorDetallePorId(request.LoteId);
            response.AnalisisFisicoDefectoPrimarioDetalle = _ILoteRepository.ConsultarLoteAnalisisFisicoDefectoPrimarioDetallePorId(request.LoteId);
            response.AnalisisFisicoDefectoSecundarioDetalle = _ILoteRepository.ConsultarLoteAnalisisFisicoDefectoSecundarioDetallePorId(request.LoteId);
            response.AnalisisFisicoOlorDetalle = _ILoteRepository.ConsultarLoteAnalisisFisicoOlorDetallePorId(request.LoteId);
            response.AnalisisSensorialAtributoDetalle = _ILoteRepository.ConsultarLoteAnalisisSensorialAtributoDetallePorId(request.LoteId);
            response.AnalisisSensorialDefectoDetalle = _ILoteRepository.ConsultarLoteAnalisisSensorialDefectoDetallePorId(request.LoteId);
            response.RegistroTostadoIndicadorDetalle = _ILoteRepository.ConsultarLoteRegistroTostadoIndicadorDetallePorId(request.LoteId).ToList();



            //if (resultado.Any())
            //{
            //    response.TotalPesoNeto = resultado.Sum(x => x.KilosNetosPesado);
            //    response.PromedioHumedad = resultado.Average(x => x.HumedadPorcentaje);
            //    response.PromedioRendimiento = resultado.Average(x => x.RendimientoPorcentaje);
            //}
            //response.LoteId = request.LoteId;

            return response;
        }

        public string ObtenerHTMLReporteEtiquetasLotes(List<ConsultaImpresionLotePorIdBE> listaEtiquetasLotes)
        {
            StringBuilder sb = new StringBuilder();
            if (listaEtiquetasLotes != null && listaEtiquetasLotes.Count > 0)
            {
                ConsultaImpresionLotePorIdBE impresionLote = new ConsultaImpresionLotePorIdBE();
                decimal cantidadTotal = listaEtiquetasLotes.Sum(x => x.Cantidad);
                decimal cantTotalxSocio = 0;

                IEnumerable<long> codigosSocios = listaEtiquetasLotes.Select(x => x.SocioId).Distinct();

                sb.Append("<div>");

                for (int i = 0; i < codigosSocios.Count(); i++)
                {
                    impresionLote = listaEtiquetasLotes.Where(x => x.SocioId == codigosSocios.ElementAt(i)).FirstOrDefault();
                    cantTotalxSocio = listaEtiquetasLotes.Where(x => x.SocioId == codigosSocios.ElementAt(i)).Sum(x => x.Cantidad);
                    if (impresionLote != null)
                    {
                        for (int j = 0; j < cantTotalxSocio; j++)
                        {
                            sb.Append($"<table style='width: 100%; height: 50%; margin-top: 15px;border: 2px solid #000;'><tr style='width: 100px;'><td></td><td><img src='http://localhost:4200/assets/img/LogoJuanSantosAtahualpa.jpg' width='120' height='160'></ td><td style='text-align: center;font-weight: bold;'>COOPERATIVA AGROECOLOGICA INDUSTRIAL JUAN SANTOS ATAHUALPA<br/>SISTEMA DE TRAZABILIDAD DE CALIDAD DE CAFÉ</td><td></td></tr><tr><td></td><td colspan='2'><table border='1' style='width: 100%; height: 100%;'><tr style='padding: 20px;'><td style='background-color: #AED6F1;font-weight: bold;padding-left: 10px;'>LOTE</td><td style='text-align: center;padding:10px;'>{impresionLote.Numero.Trim()}</td><td style='background-color: #AED6F1;font-weight: bold;text-align: center;'>CÓDIGO</td><td style='text-align: center;'>{impresionLote.CodigoSocio.Trim()}</td><td colspan='2' style='background-color: #AED6F1;font-weight: bold;text-align: center;'>AGENCIA CERTIFICADORA</td><td style='text-align: center;'>{impresionLote.AgenciaCertificadora}</td></tr><tr><td colspan='2' style='background-color: #AED6F1;font-weight: bold;padding: 10px;'>FECHA</td><td colspan='5' style='padding-left: 20px;'>{DateTime.Now.ToString("dd/MM/yyyy")}</td></tr><tr><td colspan='2' style='background-color: #AED6F1;font-weight: bold;padding: 10px;'>PRODUCTOR</td><td colspan='5' style='padding-left: 20px;'>{impresionLote.Socio.Trim()}</td></tr><tr><td colspan='2' style='background-color: #AED6F1;font-weight: bold;padding: 10px;'>ZONA</td><td colspan='5' style='padding-left: 20px;'>{impresionLote.Zona.Trim()}</td></tr><tr><td colspan='2' style='background-color: #AED6F1;font-weight: bold;padding: 10px;'>FINCA</td><td colspan='5' style='padding-left: 20px;'>{impresionLote.Finca.Trim()}</td></tr><tr><td style='background-color: #AED6F1;font-weight: bold;padding: 10px;'>HUMEDAD</td><td style='text-align:center;'>{impresionLote.PromedioHumedadPorcentaje}</td><td colspan='2' style='background-color: #AED6F1;font-weight: bold;text-align: center;'>RENDIMIENTO</td><td colspan='3' style='text-align:center;'>{impresionLote.PromedioRendimientoPorcentaje}</td></tr><tr><td style='background-color: #AED6F1;font-weight: bold;padding: 10px;'>SACOS</td><td colspan='3' style='text-align:center;'>{cantidadTotal}</td><td style='background-color: #AED6F1;font-weight: bold;text-align: center;'>KILOS BRUTOS</td><td colspan='2' style='text-align:center;'>{impresionLote.TotalKilosBrutosPesado}</td></tr><tr><td colspan='7' style='padding:10px;'></td></tr><tr><td colspan='3' style='background-color: #AED6F1;font-weight: bold;text-align:center;padding:10px;'>TIPO DE PRODUCCIÓN</td><td colspan='4' style='padding-left:20px;'>{impresionLote.TipoProduccion.Trim()}</td></tr><tr><td colspan='2' style='background-color: #AED6F1;font-weight: bold;text-align:center;padding:10px;'>CERTIFICACIÓN</td><td colspan='5' style='padding-left:20px;'>{impresionLote.Certificacion.Trim()}</td></tr></table></td><td></td></tr><tr><td></td><td colspan='2' style='text-align: center; font-weight: bold;padding: 10px 0px 10px 0px;'>Este producto cumple con el reglamento técnico para productos orgánicos</td><td></td></tr></table>");
                        }
                    }
                }
                sb.Append("</div>");
            }
            return sb.ToString();
        }

        public int ActualizarLoteAnalisisCalidad(ActualizarLoteAnalisisCalidadRequestDTO request)
        {
            Lote Lote = new Lote();

            Lote.LoteId = request.LoteId;
            Lote.ExportableGramosAnalisisFisico = request.ExportableGramosAnalisisFisico;
            Lote.ExportablePorcentajeAnalisisFisico = request.ExportablePorcentajeAnalisisFisico;
            Lote.DescarteGramosAnalisisFisico = request.DescarteGramosAnalisisFisico;
            Lote.DescartePorcentajeAnalisisFisico = request.DescartePorcentajeAnalisisFisico;
            Lote.CascarillaGramosAnalisisFisico = request.CascarillaGramosAnalisisFisico;
            Lote.CascarillaPorcentajeAnalisisFisico = request.CascarillaPorcentajeAnalisisFisico;
            Lote.TotalGramosAnalisisFisico = request.TotalGramosAnalisisFisico;
            Lote.TotalPorcentajeAnalisisFisico = request.TotalPorcentajeAnalisisFisico;
            Lote.HumedadPorcentajeAnalisisFisico = request.HumedadPorcentajeAnalisisFisico;
            Lote.ObservacionAnalisisFisico = request.ObservacionAnalisisFisico;
            Lote.UsuarioCalidad = request.UsuarioCalidad;
            Lote.ObservacionRegistroTostado = request.ObservacionRegistroTostado;
            Lote.ObservacionAnalisisSensorial = request.ObservacionAnalisisSensorial;
            Lote.TotalAnalisisSensorial = request.TotalAnalisisSensorial;
            Lote.UsuarioCalidad = request.UsuarioCalidad;
            Lote.EstadoId = LoteEstados.Analizado;
            Lote.FechaCalidad = DateTime.Now;


            int affected = _ILoteRepository.ActualizarLoteAnalisisCalidad(Lote);


            #region "Analisis Fisico Color"
            if (request.AnalisisFisicoColorDetalleList.FirstOrDefault() != null)
            {

                List<LoteAnalisisFisicoColorDetalleTipo> AnalisisFisicoColorDetalleList = new List<LoteAnalisisFisicoColorDetalleTipo>();

                request.AnalisisFisicoColorDetalleList.ForEach(z =>
                {
                    LoteAnalisisFisicoColorDetalleTipo item = new LoteAnalisisFisicoColorDetalleTipo();
                    item.ColorDetalleDescripcion = z.ColorDetalleDescripcion;
                    item.ColorDetalleId = z.ColorDetalleId;
                    item.LoteId = request.LoteId;
                    item.Valor = z.Valor;
                    AnalisisFisicoColorDetalleList.Add(item);
                });

                affected = _ILoteRepository.ActualizarLoteAnalisisFisicoColorDetalle(AnalisisFisicoColorDetalleList, request.LoteId);
            }
            #endregion

            #region Analisis Fisico Defecto Primario
            if (request.AnalisisFisicoDefectoPrimarioDetalleList.FirstOrDefault() != null)
            {
                List<LoteAnalisisFisicoDefectoPrimarioDetalleTipo> AnalisisFisicoDefectoPrimarioDetalleList = new List<LoteAnalisisFisicoDefectoPrimarioDetalleTipo>();

                request.AnalisisFisicoDefectoPrimarioDetalleList.ForEach(z =>
                {
                    LoteAnalisisFisicoDefectoPrimarioDetalleTipo item = new LoteAnalisisFisicoDefectoPrimarioDetalleTipo();
                    item.DefectoDetalleId = z.DefectoDetalleId;
                    item.DefectoDetalleDescripcion = z.DefectoDetalleDescripcion;
                    item.DefectoDetalleEquivalente = z.DefectoDetalleEquivalente;
                    item.LoteId = request.LoteId;
                    item.Valor = z.Valor;
                    AnalisisFisicoDefectoPrimarioDetalleList.Add(item);
                });

                affected = _ILoteRepository.ActualizarLoteAnalisisFisicoDefectoPrimarioDetalle(AnalisisFisicoDefectoPrimarioDetalleList, request.LoteId);
            }
            #endregion

            #region "Analisis Fisico Defecto Secundario Detalle"
            if (request.AnalisisFisicoDefectoSecundarioDetalleList.FirstOrDefault() != null)
            {
                List<LoteAnalisisFisicoDefectoSecundarioDetalleTipo> AnalisisFisicoDefectoSecundarioDetalleList = new List<LoteAnalisisFisicoDefectoSecundarioDetalleTipo>();

                request.AnalisisFisicoDefectoSecundarioDetalleList.ForEach(z =>
                {
                    LoteAnalisisFisicoDefectoSecundarioDetalleTipo item = new LoteAnalisisFisicoDefectoSecundarioDetalleTipo();
                    item.DefectoDetalleId = z.DefectoDetalleId;
                    item.DefectoDetalleDescripcion = z.DefectoDetalleDescripcion;
                    item.DefectoDetalleEquivalente = z.DefectoDetalleEquivalente;
                    item.LoteId = request.LoteId;
                    item.Valor = z.Valor;
                    AnalisisFisicoDefectoSecundarioDetalleList.Add(item);
                });

                affected = _ILoteRepository.ActualizarLoteAnalisisFisicoDefectoSecundarioDetalle(AnalisisFisicoDefectoSecundarioDetalleList, request.LoteId);
            }
            #endregion

            #region "Analisis Fisico Olor Detalle"
            if (request.AnalisisFisicoOlorDetalleList.FirstOrDefault() != null)
            {
                List<LoteAnalisisFisicoOlorDetalleTipo> AnalisisFisicoDefectoSecundarioDetalleList = new List<LoteAnalisisFisicoOlorDetalleTipo>();

                request.AnalisisFisicoOlorDetalleList.ForEach(z =>
                {
                    LoteAnalisisFisicoOlorDetalleTipo item = new LoteAnalisisFisicoOlorDetalleTipo();
                    item.LoteId = request.LoteId;
                    item.OlorDetalleDescripcion = z.OlorDetalleDescripcion;
                    item.OlorDetalleId = z.OlorDetalleId;
                    item.Valor = z.Valor;
                    AnalisisFisicoDefectoSecundarioDetalleList.Add(item);
                });

                affected = _ILoteRepository.ActualizarLoteAnalisisFisicoOlorDetalle(AnalisisFisicoDefectoSecundarioDetalleList, request.LoteId);
            }
            #endregion

            #region "Analisis Sensorial Atributo"
            if (request.AnalisisSensorialAtributoDetalleList.FirstOrDefault() != null)
            {
                List<LoteAnalisisSensorialAtributoDetalleTipo> AnalisisSensorialAtributoDetalle = new List<LoteAnalisisSensorialAtributoDetalleTipo>();

                request.AnalisisSensorialAtributoDetalleList.ForEach(z =>
                {
                    LoteAnalisisSensorialAtributoDetalleTipo item = new LoteAnalisisSensorialAtributoDetalleTipo();
                    item.LoteId = request.LoteId;
                    item.AtributoDetalleDescripcion = z.AtributoDetalleDescripcion;
                    item.AtributoDetalleId = z.AtributoDetalleId;
                    item.Valor = z.Valor;
                    AnalisisSensorialAtributoDetalle.Add(item);
                });

                affected = _ILoteRepository.ActualizarLoteAnalisisSensorialAtributoDetalle(AnalisisSensorialAtributoDetalle, request.LoteId);
            }
            #endregion

            if (request.AnalisisSensorialDefectoDetalleList.FirstOrDefault() != null)
            {
                List<LoteAnalisisSensorialDefectoDetalleTipo> AnalisisSensorialDefectoDetalle = new List<LoteAnalisisSensorialDefectoDetalleTipo>();

                request.AnalisisSensorialDefectoDetalleList.ForEach(z =>
                {
                    LoteAnalisisSensorialDefectoDetalleTipo item = new LoteAnalisisSensorialDefectoDetalleTipo();
                    item.LoteId = request.LoteId;
                    item.DefectoDetalleDescripcion = z.DefectoDetalleDescripcion;
                    item.DefectoDetalleId = z.DefectoDetalleId;

                    item.Valor = z.Valor;
                    AnalisisSensorialDefectoDetalle.Add(item);
                });

                affected = _ILoteRepository.ActualizarLoteAnalisisSensorialDefectoDetalle(AnalisisSensorialDefectoDetalle, request.LoteId);
            }


            if (request.RegistroTostadoIndicadorDetalleList.FirstOrDefault() != null)
            {
                List<LoteRegistroTostadoIndicadorDetalleTipo> RegistroTostadoIndicadorDetalle = new List<LoteRegistroTostadoIndicadorDetalleTipo>();

                request.RegistroTostadoIndicadorDetalleList.ForEach(z =>
                {

                    LoteRegistroTostadoIndicadorDetalleTipo item = new LoteRegistroTostadoIndicadorDetalleTipo();
                    item.LoteId = request.LoteId;
                    item.IndicadorDetalleDescripcion = z.IndicadorDetalleDescripcion;
                    item.IndicadorDetalleId = z.IndicadorDetalleId;
                    item.Valor = z.Valor;

                    RegistroTostadoIndicadorDetalle.Add(item);
                });

                affected = _ILoteRepository.ActualizarLoteRegistroTostadoIndicadorDetalle(RegistroTostadoIndicadorDetalle, request.LoteId);
            }

            return affected;
        }
    }
}
