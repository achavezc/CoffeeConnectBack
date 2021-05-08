
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
    public partial class OrdenServicioControlCalidadService : IOrdenServicioControlCalidadService
    {

        private IOrdenServicioControlCalidadRepository _IOrdenServicioControlCalidadRepository;



        private ICorrelativoRepository _ICorrelativoRepository;


        public OrdenServicioControlCalidadService(IOrdenServicioControlCalidadRepository ordenServicioControlCalidadRepository, ICorrelativoRepository correlativoRepository)
        {
            _IOrdenServicioControlCalidadRepository = ordenServicioControlCalidadRepository;
            _ICorrelativoRepository = correlativoRepository;
        }

        /*
         
 
	
	
			parameters.Add("@TotalGramosAnalisisFisico", notaIngresoAlmacen.TotalGramosAnalisisFisico);
			parameters.Add("@TotalPorcentajeAnalisisFisico", notaIngresoAlmacen.TotalPorcentajeAnalisisFisico);
			parameters.Add("@HumedadPorcentajeAnalisisFisico", notaIngresoAlmacen.HumedadPorcentajeAnalisisFisico);
			parameters.Add("@Observacion", notaIngresoAlmacen.Observacion);
			parameters.Add("@EstadoId", notaIngresoAlmacen.EstadoId);
			parameters.Add("@FechaRegistro", notaIngresoAlmacen.FechaRegistro);
			parameters.Add("@UsuarioRegistro", notaIngresoAlmacen.UsuarioRegistro);
			parameters.Add("@FechaUltimaActualizacion", notaIngresoAlmacen.FechaUltimaActualizacion);
			parameters.Add("@UsuarioUltimaActualizacion", notaIngresoAlmacen.UsuarioUltimaActualizacion);
			parameters.Add("@Activo", notaIngresoAlmacen.Activo);
 
         */

        public List<ConsultaOrdenServicioControlCalidadBE> ConsultarOrdenServicioControlCalidad(ConsultaOrdenServicioControlCalidadRequestDTO request)
        {
            if (string.IsNullOrEmpty(request.Numero) && string.IsNullOrEmpty(request.Ruc) && string.IsNullOrEmpty(request.RazonSocial))
                throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.NotaCompra.ValidacionSeleccioneMinimoUnFiltro.Label" });


            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Acopio.NotaCompra.ValidacionRangoFechaMayor2anios.Label" });



            var list = _IOrdenServicioControlCalidadRepository.ConsultarOrdenServicioControlCalidad(request);

            return list.ToList();
        }

        public int AnularOrdenServicioControlCalidad(AnularOrdenServicioControlCalidadRequestDTO request)
        {
            int affected = _IOrdenServicioControlCalidadRepository.ActualizarEstado(request.OrdenServicioControlCalidadId, DateTime.Now, request.Usuario, OrdenServicioControlCalidadEstados.Anulado);

            return affected;
        }


        public int RegistrarOrdenServicioControlCalidad(RegistrarActualizarOrdenServicioControlCalidadRequestDTO request)
        {
            OrdenServicioControlCalidad OrdenServicioControlCalidad = new OrdenServicioControlCalidad();

            int affected = 0;

            OrdenServicioControlCalidad.EmpresaId = request.EmpresaId;
            OrdenServicioControlCalidad.EmpresaProcesadoraId = request.EmpresaProcesadoraId;
            OrdenServicioControlCalidad.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.OrdenServicioControlCalidad);
            OrdenServicioControlCalidad.UnidadMedidaId = request.UnidadMedidaId;
            OrdenServicioControlCalidad.CantidadPesado = request.CantidadPesado;
            OrdenServicioControlCalidad.ProductoId = request.ProductoId;
            OrdenServicioControlCalidad.SubProductoId = request.SubProductoId;
            OrdenServicioControlCalidad.TipoProduccionId = request.TipoProduccionId;
            OrdenServicioControlCalidad.RendimientoEsperadoPorcentaje = request.RendimientoEsperadoPorcentaje;
            OrdenServicioControlCalidad.EstadoId = OrdenServicioControlCalidadEstados.Ingresado;
            OrdenServicioControlCalidad.FechaRegistro = DateTime.Now;
            OrdenServicioControlCalidad.UsuarioRegistro = request.UsuarioOrdenServicioControlCalidad;

            affected = _IOrdenServicioControlCalidadRepository.Insertar(OrdenServicioControlCalidad);
            OrdenServicioControlCalidad.OrdenServicioControlCalidadId = request.OrdenServicioControlCalidadId = affected;

            return affected;
        }

        public int ActualizarOrdenServicioControlCalidad(RegistrarActualizarOrdenServicioControlCalidadRequestDTO request)
        {
            OrdenServicioControlCalidad OrdenServicioControlCalidad = new OrdenServicioControlCalidad();

            int affected = 0;

            OrdenServicioControlCalidad.OrdenServicioControlCalidadId = request.OrdenServicioControlCalidadId;
            OrdenServicioControlCalidad.EmpresaId = request.EmpresaId;
            OrdenServicioControlCalidad.EmpresaProcesadoraId = request.EmpresaProcesadoraId;
            OrdenServicioControlCalidad.UnidadMedidaId = request.UnidadMedidaId;
            OrdenServicioControlCalidad.CantidadPesado = request.CantidadPesado;
            OrdenServicioControlCalidad.ProductoId = request.ProductoId;
            OrdenServicioControlCalidad.SubProductoId = request.SubProductoId;
            OrdenServicioControlCalidad.TipoProduccionId = request.TipoProduccionId;
            OrdenServicioControlCalidad.RendimientoEsperadoPorcentaje = request.RendimientoEsperadoPorcentaje;
            OrdenServicioControlCalidad.FechaUltimaActualizacion = DateTime.Now;
            OrdenServicioControlCalidad.UsuarioUltimaActualizacion = request.UsuarioOrdenServicioControlCalidad;




            affected = _IOrdenServicioControlCalidadRepository.Actualizar(OrdenServicioControlCalidad);

            //if (affected != 0)
            //{
            //    request.ListOrdenServicioControlCalidadDetalle.ForEach(x => {
            //        OrdenServicioControlCalidadDetalle obj = new OrdenServicioControlCalidadDetalle();
            //        obj.LoteId = x.LoteId;
            //        obj.OrdenServicioControlCalidadDetalleId = x.OrdenServicioControlCalidadDetalleId;
            //        obj.OrdenServicioControlCalidadId = request.OrdenServicioControlCalidadId;

            //        lstOrdenServicioControlCalidad.Add(obj);
            //    });

            //    affected = _IOrdenServicioControlCalidadRepository.ActualizarOrdenServicioControlCalidadDetalle(lstOrdenServicioControlCalidad, request.OrdenServicioControlCalidadId);
            //}
            return affected;
        }



        public ConsultaOrdenServicioControlCalidadPorIdBE ConsultarOrdenServicioControlCalidadPorId(ConsultaOrdenServicioCalidadServicioPorIdRequestDTO request)
        {
            ConsultaOrdenServicioControlCalidadPorIdBE OrdenServicioControlCalidadPorIdBE = _IOrdenServicioControlCalidadRepository.ConsultarOrdenServicioControlCalidadPorId(request.OrdenServicioControlCalidadId);

            if (OrdenServicioControlCalidadPorIdBE != null)
            {
                OrdenServicioControlCalidadPorIdBE.AnalisisFisicoColorDetalle = _IOrdenServicioControlCalidadRepository.ConsultarOrdenServicioControlCalidadAnalisisFisicoColorDetallePorId(request.OrdenServicioControlCalidadId);
                OrdenServicioControlCalidadPorIdBE.AnalisisFisicoDefectoPrimarioDetalle = _IOrdenServicioControlCalidadRepository.ConsultarOrdenServicioControlCalidadAnalisisFisicoDefectoPrimarioDetallePorId(request.OrdenServicioControlCalidadId);
                OrdenServicioControlCalidadPorIdBE.AnalisisFisicoDefectoSecundarioDetalle = _IOrdenServicioControlCalidadRepository.ConsultarOrdenServicioControlCalidadAnalisisFisicoDefectoSecundarioDetallePorId(request.OrdenServicioControlCalidadId);
                OrdenServicioControlCalidadPorIdBE.AnalisisFisicoOlorDetalle = _IOrdenServicioControlCalidadRepository.ConsultarOrdenServicioControlCalidadAnalisisFisicoOlorDetallePorId(request.OrdenServicioControlCalidadId);
                OrdenServicioControlCalidadPorIdBE.AnalisisSensorialAtributoDetalle = _IOrdenServicioControlCalidadRepository.ConsultarOrdenServicioControlCalidadAnalisisSensorialAtributoDetallePorId(request.OrdenServicioControlCalidadId);
                OrdenServicioControlCalidadPorIdBE.AnalisisSensorialDefectoDetalle = _IOrdenServicioControlCalidadRepository.ConsultarOrdenServicioControlCalidadAnalisisSensorialDefectoDetallePorId(request.OrdenServicioControlCalidadId);
                OrdenServicioControlCalidadPorIdBE.RegistroTostadoIndicadorDetalle = _IOrdenServicioControlCalidadRepository.ConsultarOrdenServicioControlCalidadRegistroTostadoIndicadorDetallePorId(request.OrdenServicioControlCalidadId);

            }



            return OrdenServicioControlCalidadPorIdBE;

        }




        public int ActualizarOrdenServicioControlCalidadAnalisisCalidad(ActualizarOrderServicioControlCalidadRequestDTO request)
        {
            OrdenServicioControlCalidad ordenServicioControlCalidad = new OrdenServicioControlCalidad();

            ordenServicioControlCalidad.OrdenServicioControlCalidadId = request.OrdenServicioControlCalidadId;
            ordenServicioControlCalidad.ExportableGramosAnalisisFisico = request.ExportableGramosAnalisisFisico;
            ordenServicioControlCalidad.ExportablePorcentajeAnalisisFisico = request.ExportablePorcentajeAnalisisFisico;
            ordenServicioControlCalidad.DescarteGramosAnalisisFisico = request.DescarteGramosAnalisisFisico;
            ordenServicioControlCalidad.DescartePorcentajeAnalisisFisico = request.DescartePorcentajeAnalisisFisico;
            ordenServicioControlCalidad.CascarillaGramosAnalisisFisico = request.CascarillaGramosAnalisisFisico;
            ordenServicioControlCalidad.CascarillaPorcentajeAnalisisFisico = request.CascarillaPorcentajeAnalisisFisico;
            ordenServicioControlCalidad.TotalGramosAnalisisFisico = request.TotalGramosAnalisisFisico;
            ordenServicioControlCalidad.TotalPorcentajeAnalisisFisico = request.TotalPorcentajeAnalisisFisico;
            ordenServicioControlCalidad.HumedadPorcentajeAnalisisFisico = request.HumedadPorcentajeAnalisisFisico;
            ordenServicioControlCalidad.ObservacionAnalisisFisico = request.ObservacionAnalisisFisico;
            ordenServicioControlCalidad.UsuarioCalidad = request.UsuarioCalidad;
            ordenServicioControlCalidad.ObservacionRegistroTostado = request.ObservacionRegistroTostado;
            ordenServicioControlCalidad.ObservacionAnalisisSensorial = request.ObservacionAnalisisSensorial;
            ordenServicioControlCalidad.UsuarioCalidad = request.UsuarioCalidad;
            ordenServicioControlCalidad.EstadoId = GuiaRecepcionMateriaPrimaEstados.Analizado;
            ordenServicioControlCalidad.FechaCalidad = DateTime.Now;
            ordenServicioControlCalidad.TotalAnalisisSensorial = request.TotalAnalisisSensorial;



            int affected = _IOrdenServicioControlCalidadRepository.ActualizarAnalisisCalidad(ordenServicioControlCalidad);

            #region "Analisis Fisico Color"
            if (request.AnalisisFisicoColorDetalleList.FirstOrDefault() != null)
            {

                List<OrdenServicioControlCalidadAnalisisFisicoColorDetalleTipo> AnalisisFisicoColorDetalleList = new List<OrdenServicioControlCalidadAnalisisFisicoColorDetalleTipo>();

                request.AnalisisFisicoColorDetalleList.ForEach(z =>
                {
                    OrdenServicioControlCalidadAnalisisFisicoColorDetalleTipo item = new OrdenServicioControlCalidadAnalisisFisicoColorDetalleTipo();
                    item.ColorDetalleDescripcion = z.ColorDetalleDescripcion;
                    item.ColorDetalleId = z.ColorDetalleId;
                    item.OrdenServicioControlCalidadId = request.OrdenServicioControlCalidadId;
                    item.Valor = z.Valor;
                    AnalisisFisicoColorDetalleList.Add(item);
                });

                affected = _IOrdenServicioControlCalidadRepository.ActualizarOrdenServicioControlCalidadAnalisisFisicoColorDetalle(AnalisisFisicoColorDetalleList, request.OrdenServicioControlCalidadId);
            }
            #endregion


            #region Analisis Fisico Defecto Primario
            if (request.AnalisisFisicoDefectoPrimarioDetalleList.FirstOrDefault() != null)
            {
                List<OrdenServicioControlCalidadAnalisisFisicoDefectoPrimarioDetalleTipo> AnalisisFisicoDefectoPrimarioDetalleList = new List<OrdenServicioControlCalidadAnalisisFisicoDefectoPrimarioDetalleTipo>();

                request.AnalisisFisicoDefectoPrimarioDetalleList.ForEach(z =>
                {
                    OrdenServicioControlCalidadAnalisisFisicoDefectoPrimarioDetalleTipo item = new OrdenServicioControlCalidadAnalisisFisicoDefectoPrimarioDetalleTipo();
                    item.DefectoDetalleId = z.DefectoDetalleId;
                    item.DefectoDetalleDescripcion = z.DefectoDetalleDescripcion;
                    item.DefectoDetalleEquivalente = z.DefectoDetalleEquivalente;
                    item.OrdenServicioControlCalidadId = request.OrdenServicioControlCalidadId;
                    item.Valor = z.Valor;
                    AnalisisFisicoDefectoPrimarioDetalleList.Add(item);
                });

                affected = _IOrdenServicioControlCalidadRepository.ActualizarOrdenServicioControlCalidadAnalisisFisicoDefectoPrimarioDetalle(AnalisisFisicoDefectoPrimarioDetalleList, request.OrdenServicioControlCalidadId);
            }
            #endregion

            #region "Analisis Fisico Defecto Secundario Detalle"
            if (request.AnalisisFisicoDefectoSecundarioDetalleList.FirstOrDefault() != null)
            {
                List<OrdenServicioControlCalidadAnalisisFisicoDefectoSecundarioDetalleTipo> AnalisisFisicoDefectoSecundarioDetalleList = new List<OrdenServicioControlCalidadAnalisisFisicoDefectoSecundarioDetalleTipo>();

                request.AnalisisFisicoDefectoSecundarioDetalleList.ForEach(z =>
                {
                    OrdenServicioControlCalidadAnalisisFisicoDefectoSecundarioDetalleTipo item = new OrdenServicioControlCalidadAnalisisFisicoDefectoSecundarioDetalleTipo();
                    item.DefectoDetalleId = z.DefectoDetalleId;
                    item.DefectoDetalleDescripcion = z.DefectoDetalleDescripcion;
                    item.DefectoDetalleEquivalente = z.DefectoDetalleEquivalente;
                    item.OrdenServicioControlCalidadId = request.OrdenServicioControlCalidadId;
                    item.Valor = z.Valor;
                    AnalisisFisicoDefectoSecundarioDetalleList.Add(item);
                });

                affected = _IOrdenServicioControlCalidadRepository.ActualizarOrdenServicioControlCalidadAnalisisFisicoDefectoSecundarioDetalle(AnalisisFisicoDefectoSecundarioDetalleList, request.OrdenServicioControlCalidadId);
            }
            #endregion

            #region "Analisis Fisico Olor Detalle"
            if (request.AnalisisFisicoOlorDetalleList.FirstOrDefault() != null)
            {
                List<OrdenServicioControlCalidadAnalisisFisicoOlorDetalleTipo> AnalisisFisicoDefectoSecundarioDetalleList = new List<OrdenServicioControlCalidadAnalisisFisicoOlorDetalleTipo>();

                request.AnalisisFisicoOlorDetalleList.ForEach(z =>
                {
                    OrdenServicioControlCalidadAnalisisFisicoOlorDetalleTipo item = new OrdenServicioControlCalidadAnalisisFisicoOlorDetalleTipo();
                    item.OrdenServicioControlCalidadId = request.OrdenServicioControlCalidadId;
                    item.OlorDetalleDescripcion = z.OlorDetalleDescripcion;
                    item.OlorDetalleId = z.OlorDetalleId;
                    item.Valor = z.Valor;
                    AnalisisFisicoDefectoSecundarioDetalleList.Add(item);
                });

                affected = _IOrdenServicioControlCalidadRepository.ActualizarOrdenServicioControlCalidadAnalisisFisicoOlorDetalle(AnalisisFisicoDefectoSecundarioDetalleList, request.OrdenServicioControlCalidadId);
            }
            #endregion

            #region "Analisis Sensorial Atributo"
            if (request.AnalisisSensorialAtributoDetalleList.FirstOrDefault() != null)
            {
                List<OrdenServicioControlCalidadAnalisisSensorialAtributoDetalleTipo> AnalisisSensorialAtributoDetalle = new List<OrdenServicioControlCalidadAnalisisSensorialAtributoDetalleTipo>();

                request.AnalisisSensorialAtributoDetalleList.ForEach(z =>
                {
                    OrdenServicioControlCalidadAnalisisSensorialAtributoDetalleTipo item = new OrdenServicioControlCalidadAnalisisSensorialAtributoDetalleTipo();
                    item.OrdenServicioControlCalidadId = request.OrdenServicioControlCalidadId;
                    item.AtributoDetalleDescripcion = z.AtributoDetalleDescripcion;
                    item.AtributoDetalleId = z.AtributoDetalleId;
                    item.Valor = z.Valor;
                    AnalisisSensorialAtributoDetalle.Add(item);
                });

                affected = _IOrdenServicioControlCalidadRepository.ActualizarOrdenServicioControlCalidadAnalisisSensorialAtributoDetalle(AnalisisSensorialAtributoDetalle, request.OrdenServicioControlCalidadId);
            }
            #endregion

            #region "Analisis Sensorial Defecto Detalle"

            if (request.AnalisisSensorialDefectoDetalleList.FirstOrDefault() != null)
            {
                List<OrdenServicioControlCalidadAnalisisSensorialDefectoDetalleTipo> AnalisisSensorialDefectoDetalle = new List<OrdenServicioControlCalidadAnalisisSensorialDefectoDetalleTipo>();

                request.AnalisisSensorialDefectoDetalleList.ForEach(z =>
                {
                    OrdenServicioControlCalidadAnalisisSensorialDefectoDetalleTipo item = new OrdenServicioControlCalidadAnalisisSensorialDefectoDetalleTipo();
                    item.OrdenServicioControlCalidadId = request.OrdenServicioControlCalidadId;
                    item.DefectoDetalleDescripcion = z.DefectoDetalleDescripcion;
                    item.DefectoDetalleId = z.DefectoDetalleId;

                    item.Valor = z.Valor;
                    AnalisisSensorialDefectoDetalle.Add(item);
                });

                affected = _IOrdenServicioControlCalidadRepository.ActualizarOrdenServicioControlCalidadAnalisisSensorialDefectoDetalle(AnalisisSensorialDefectoDetalle, request.OrdenServicioControlCalidadId);
            }

            #endregion

            #region "Registro Tostado Indicador Detalle"

            if (request.RegistroTostadoIndicadorDetalleList.FirstOrDefault() != null)
            {
                List<OrdenServicioControlCalidadRegistroTostadoIndicadorDetalleTipo> RegistroTostadoIndicadorDetalle = new List<OrdenServicioControlCalidadRegistroTostadoIndicadorDetalleTipo>();

                request.RegistroTostadoIndicadorDetalleList.ForEach(z =>
                {

                    OrdenServicioControlCalidadRegistroTostadoIndicadorDetalleTipo item = new OrdenServicioControlCalidadRegistroTostadoIndicadorDetalleTipo();
                    item.OrdenServicioControlCalidadId = request.OrdenServicioControlCalidadId;
                    item.IndicadorDetalleDescripcion = z.IndicadorDetalleDescripcion;
                    item.IndicadorDetalleId = z.IndicadorDetalleId;
                    item.Valor = z.Valor;

                    RegistroTostadoIndicadorDetalle.Add(item);
                });

                affected = _IOrdenServicioControlCalidadRepository.ActualizarOrdenServicioControlCalidadRegistroTostadoIndicadorDetalle(RegistroTostadoIndicadorDetalle, request.OrdenServicioControlCalidadId);
            }

            #endregion

            return affected;
        }

    }
}
