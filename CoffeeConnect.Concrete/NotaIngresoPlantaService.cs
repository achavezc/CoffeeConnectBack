
using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using Core.Common.Domain.Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeConnect.Service
{
    public partial class NotaIngresoPlantaService : INotaIngresoPlantaService
    {
        private readonly IMapper _Mapper;
        private INotaIngresoPlantaRepository _INotaIngresoPlantaRepository;
        private ICorrelativoRepository _ICorrelativoRepository;
        public IOptions<ParametrosSettings> _ParametrosSettings;

        public NotaIngresoPlantaService(INotaIngresoPlantaRepository NotaIngresoPlanta, ICorrelativoRepository correlativoRepository, IOptions<ParametrosSettings> parametrosSettings, IMapper mapper)
        {
            _INotaIngresoPlantaRepository = NotaIngresoPlanta;
            _ICorrelativoRepository = correlativoRepository;
            _ParametrosSettings = parametrosSettings;
            _Mapper = mapper;
        }
        
        public List<ConsultaNotaIngresoPlantaBE> ConsultarNotaIngresoPlanta(ConsultaNotaIngresoPlantaRequestDTO request)
        {
            if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFin == null || request.FechaFin == DateTime.MinValue || string.IsNullOrEmpty(request.EstadoId))
                throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.NotaIngresoPlanta.ValidacionSeleccioneMinimoUnFiltro.Label" });

            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Acopio.NotaIngresoPlanta.ValidacionRangoFechaMayor2anios.Label" });

            var list = _INotaIngresoPlantaRepository.ConsultarNotaIngresoPlanta(request);
            return list.ToList();
        }

        public int AnularNotaIngresoPlanta(AnularNotaIngresoPlantaRequestDTO request)
        {
            int affected = _INotaIngresoPlantaRepository.ActualizarEstado(request.NotaIngresoPlantaId, DateTime.Now, request.Usuario, NotaIngresoPlantaEstados.Anulado);

            return affected;
        }

        public ConsultaNotaIngresoPlantaPorIdBE ConsultarNotaIngresoPlantaPorId(ConsultaNotaIngresoPlantaPorIdRequestDTO request)
        {
            int NotaIngresoPlantaId = request.NotaIngresoPlantaId;

            ConsultaNotaIngresoPlantaPorIdBE consultaNotaIngresoPlantaPorIdBE = _INotaIngresoPlantaRepository.ConsultarNotaIngresoPlantaPorId(request.NotaIngresoPlantaId);

            if (consultaNotaIngresoPlantaPorIdBE != null)
            {
                if (consultaNotaIngresoPlantaPorIdBE.EstadoId != NotaIngresoPlantaEstados.Pesado)
                {
                    consultaNotaIngresoPlantaPorIdBE.AnalisisFisicoColorDetalle = _INotaIngresoPlantaRepository.ConsultarNotaIngresoPlantaAnalisisFisicoColorDetallePorId(NotaIngresoPlantaId).ToList();

                    consultaNotaIngresoPlantaPorIdBE.AnalisisFisicoOlorDetalle = _INotaIngresoPlantaRepository.ConsultarNotaIngresoPlantaAnalisisFisicoOlorDetallePorId(NotaIngresoPlantaId).ToList();

                    consultaNotaIngresoPlantaPorIdBE.AnalisisFisicoDefectoPrimarioDetalle = _INotaIngresoPlantaRepository.ConsultarNotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetallePorId(NotaIngresoPlantaId).ToList();

                    consultaNotaIngresoPlantaPorIdBE.AnalisisFisicoDefectoSecundarioDetalle = _INotaIngresoPlantaRepository.ConsultarNotaIngresoPlantaAnalisisFisicoDefectoSecundarioDetallePorId(NotaIngresoPlantaId).ToList();

                    consultaNotaIngresoPlantaPorIdBE.AnalisisSensorialAtributoDetalle = _INotaIngresoPlantaRepository.ConsultarNotaIngresoPlantaAnalisisSensorialAtributoDetallePorId(NotaIngresoPlantaId).ToList();

                    consultaNotaIngresoPlantaPorIdBE.AnalisisSensorialDefectoDetalle = _INotaIngresoPlantaRepository.ConsultarNotaIngresoPlantaAnalisisSensorialDefectoDetallePorId(NotaIngresoPlantaId).ToList();

                    consultaNotaIngresoPlantaPorIdBE.RegistroTostadoIndicadorDetalle = _INotaIngresoPlantaRepository.ConsultarNotaIngresoPlantaRegistroTostadoIndicadorDetallePorId(NotaIngresoPlantaId).ToList();

                }
            }



            return consultaNotaIngresoPlantaPorIdBE;

        }

        public int RegistrarPesadoNotaIngresoPlanta(RegistrarActualizarPesadoNotaIngresoPlantaRequestDTO request)
        {
            NotaIngresoPlanta NotaIngresoPlanta = _Mapper.Map<NotaIngresoPlanta>(request);


            NotaIngresoPlanta.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.NotaIngresoPlanta);

            NotaIngresoPlanta.FechaPesado = DateTime.Now;
            NotaIngresoPlanta.EstadoId = NotaIngresoPlantaEstados.Pesado;
            NotaIngresoPlanta.FechaRegistro = DateTime.Now;
            NotaIngresoPlanta.UsuarioRegistro = request.UsuarioPesado;


            int affected = _INotaIngresoPlantaRepository.InsertarPesado(NotaIngresoPlanta);

            return affected;
        }

        public int ActualizarPesadoNotaIngresoPlanta(RegistrarActualizarPesadoNotaIngresoPlantaRequestDTO request)
        {
            NotaIngresoPlanta NotaIngresoPlanta = _Mapper.Map<NotaIngresoPlanta>(request);

            NotaIngresoPlanta.FechaPesado = DateTime.Now;
            NotaIngresoPlanta.UsuarioPesado = request.UsuarioPesado;

            NotaIngresoPlanta.EstadoId = NotaIngresoPlantaEstados.Pesado;
            NotaIngresoPlanta.FechaUltimaActualizacion = DateTime.Now;
            NotaIngresoPlanta.UsuarioUltimaActualizacion = request.UsuarioPesado;


            int affected = _INotaIngresoPlantaRepository.ActualizarPesado(NotaIngresoPlanta);


            return affected;
        }

        public int ActualizarNotaIngresoPlantaAnalisisCalidad(ActualizarNotaIngresoPlantaAnalisisCalidadRequestDTO request)
        {

            NotaIngresoPlanta NotaIngresoPlanta = new NotaIngresoPlanta();

            NotaIngresoPlanta.NotaIngresoPlantaId = request.NotaIngresoPlantaId;
            NotaIngresoPlanta.ExportableGramosAnalisisFisico = request.ExportableGramosAnalisisFisico;
            NotaIngresoPlanta.ExportablePorcentajeAnalisisFisico = request.ExportablePorcentajeAnalisisFisico;
            NotaIngresoPlanta.DescarteGramosAnalisisFisico = request.DescarteGramosAnalisisFisico;
            NotaIngresoPlanta.DescartePorcentajeAnalisisFisico = request.DescartePorcentajeAnalisisFisico;
            NotaIngresoPlanta.CascarillaGramosAnalisisFisico = request.CascarillaGramosAnalisisFisico;
            NotaIngresoPlanta.CascarillaPorcentajeAnalisisFisico = request.CascarillaPorcentajeAnalisisFisico;
            NotaIngresoPlanta.TotalGramosAnalisisFisico = request.TotalGramosAnalisisFisico;
            NotaIngresoPlanta.TotalPorcentajeAnalisisFisico = request.TotalPorcentajeAnalisisFisico;
            NotaIngresoPlanta.HumedadPorcentajeAnalisisFisico = request.HumedadPorcentajeAnalisisFisico;
            NotaIngresoPlanta.ObservacionAnalisisFisico = request.ObservacionAnalisisFisico;
            NotaIngresoPlanta.UsuarioCalidad = request.UsuarioCalidad;
            NotaIngresoPlanta.ObservacionRegistroTostado = request.ObservacionRegistroTostado;
            NotaIngresoPlanta.ObservacionAnalisisSensorial = request.ObservacionAnalisisSensorial;
            NotaIngresoPlanta.UsuarioCalidad = request.UsuarioCalidad;
            NotaIngresoPlanta.EstadoId = NotaIngresoPlantaEstados.Analizado;
            NotaIngresoPlanta.FechaCalidad = DateTime.Now;
            NotaIngresoPlanta.Taza = request.Taza;
            NotaIngresoPlanta.Intensidad = request.Intensidad;
            NotaIngresoPlanta.PuntajeFinal = request.PuntajeFinal;
            NotaIngresoPlanta.TazaIntensidad = request.TazaIntensidad;

            decimal totalAnalisisSensorial = 0;

            if (request.AnalisisSensorialAtributoDetalleList.FirstOrDefault() != null)
            {
                List<NotaIngresoPlantaAnalisisSensorialAtributoDetalleTipo> AnalisisSensorialAtributoDetalle = new List<NotaIngresoPlantaAnalisisSensorialAtributoDetalleTipo>();

                request.AnalisisSensorialAtributoDetalleList.ForEach(z =>
                {
                    if (z.Valor.HasValue)
                    {
                        totalAnalisisSensorial = totalAnalisisSensorial + z.Valor.Value;
                    }
                });

            }



            NotaIngresoPlanta.TotalAnalisisSensorial = totalAnalisisSensorial;

            int affected = _INotaIngresoPlantaRepository.ActualizarAnalisisCalidad(NotaIngresoPlanta);


            #region "Analisis Fisico Color"
            if (request.AnalisisFisicoColorDetalleList.FirstOrDefault() != null)
            {

                List<NotaIngresoPlantaAnalisisFisicoColorDetalleTipo> AnalisisFisicoColorDetalleList = new List<NotaIngresoPlantaAnalisisFisicoColorDetalleTipo>();

                request.AnalisisFisicoColorDetalleList.ForEach(z =>
                {
                    NotaIngresoPlantaAnalisisFisicoColorDetalleTipo item = new NotaIngresoPlantaAnalisisFisicoColorDetalleTipo();
                    item.ColorDetalleDescripcion = z.ColorDetalleDescripcion;
                    item.ColorDetalleId = z.ColorDetalleId;
                    item.NotaIngresoPlantaId = request.NotaIngresoPlantaId;
                    item.Valor = z.Valor;
                    AnalisisFisicoColorDetalleList.Add(item);
                });

                affected = _INotaIngresoPlantaRepository.ActualizarNotaIngresoPlantaAnalisisFisicoColorDetalle(AnalisisFisicoColorDetalleList, request.NotaIngresoPlantaId);
            }
            #endregion

            #region Analisis Fisico Defecto Primario
            if (request.AnalisisFisicoDefectoPrimarioDetalleList.FirstOrDefault() != null)
            {
                List<NotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetalleTipo> AnalisisFisicoDefectoPrimarioDetalleList = new List<NotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetalleTipo>();

                request.AnalisisFisicoDefectoPrimarioDetalleList.ForEach(z =>
                {
                    NotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetalleTipo item = new NotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetalleTipo();
                    item.DefectoDetalleId = z.DefectoDetalleId;
                    item.DefectoDetalleDescripcion = z.DefectoDetalleDescripcion;
                    item.DefectoDetalleEquivalente = z.DefectoDetalleEquivalente;
                    item.NotaIngresoPlantaId = request.NotaIngresoPlantaId;
                    item.Valor = z.Valor;
                    AnalisisFisicoDefectoPrimarioDetalleList.Add(item);
                });

                affected = _INotaIngresoPlantaRepository.ActualizarNotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetalle(AnalisisFisicoDefectoPrimarioDetalleList, request.NotaIngresoPlantaId);
            }
            #endregion

            #region "Analisis Fisico Defecto Secundario Detalle"
            if (request.AnalisisFisicoDefectoSecundarioDetalleList.FirstOrDefault() != null)
            {
                List<NotaIngresoPlantaAnalisisFisicoDefectoSecundarioDetalleTipo> AnalisisFisicoDefectoSecundarioDetalleList = new List<NotaIngresoPlantaAnalisisFisicoDefectoSecundarioDetalleTipo>();

                request.AnalisisFisicoDefectoSecundarioDetalleList.ForEach(z =>
                {
                    NotaIngresoPlantaAnalisisFisicoDefectoSecundarioDetalleTipo item = new NotaIngresoPlantaAnalisisFisicoDefectoSecundarioDetalleTipo();
                    item.DefectoDetalleId = z.DefectoDetalleId;
                    item.DefectoDetalleDescripcion = z.DefectoDetalleDescripcion;
                    item.DefectoDetalleEquivalente = z.DefectoDetalleEquivalente;
                    item.NotaIngresoPlantaId = request.NotaIngresoPlantaId;
                    item.Valor = z.Valor;
                    AnalisisFisicoDefectoSecundarioDetalleList.Add(item);
                });

                affected = _INotaIngresoPlantaRepository.ActualizarNotaIngresoPlantaAnalisisFisicoDefectoSecundarioDetalle(AnalisisFisicoDefectoSecundarioDetalleList, request.NotaIngresoPlantaId);
            }
            #endregion

            #region "Analisis Fisico Olor Detalle"
            if (request.AnalisisFisicoOlorDetalleList.FirstOrDefault() != null)
            {
                List<NotaIngresoPlantaAnalisisFisicoOlorDetalleTipo> AnalisisFisicoDefectoSecundarioDetalleList = new List<NotaIngresoPlantaAnalisisFisicoOlorDetalleTipo>();

                request.AnalisisFisicoOlorDetalleList.ForEach(z =>
                {
                    NotaIngresoPlantaAnalisisFisicoOlorDetalleTipo item = new NotaIngresoPlantaAnalisisFisicoOlorDetalleTipo();
                    item.NotaIngresoPlantaId = request.NotaIngresoPlantaId;
                    item.OlorDetalleDescripcion = z.OlorDetalleDescripcion;
                    item.OlorDetalleId = z.OlorDetalleId;
                    item.Valor = z.Valor;
                    AnalisisFisicoDefectoSecundarioDetalleList.Add(item);
                });

                affected = _INotaIngresoPlantaRepository.ActualizarNotaIngresoPlantaAnalisisFisicoOlorDetalle(AnalisisFisicoDefectoSecundarioDetalleList, request.NotaIngresoPlantaId);
            }
            #endregion

            #region "Analisis Sensorial Atributo"
            if (request.AnalisisSensorialAtributoDetalleList.FirstOrDefault() != null)
            {
                List<NotaIngresoPlantaAnalisisSensorialAtributoDetalleTipo> AnalisisSensorialAtributoDetalle = new List<NotaIngresoPlantaAnalisisSensorialAtributoDetalleTipo>();

                request.AnalisisSensorialAtributoDetalleList.ForEach(z =>
                {
                    NotaIngresoPlantaAnalisisSensorialAtributoDetalleTipo item = new NotaIngresoPlantaAnalisisSensorialAtributoDetalleTipo();
                    item.NotaIngresoPlantaId = request.NotaIngresoPlantaId;
                    item.AtributoDetalleDescripcion = z.AtributoDetalleDescripcion;
                    item.AtributoDetalleId = z.AtributoDetalleId;
                    item.Valor = z.Valor;
                    AnalisisSensorialAtributoDetalle.Add(item);
                });

                affected = _INotaIngresoPlantaRepository.ActualizarNotaIngresoPlantaAnalisisSensorialAtributoDetalle(AnalisisSensorialAtributoDetalle, request.NotaIngresoPlantaId);
            }
            #endregion

            if (request.AnalisisSensorialDefectoDetalleList.FirstOrDefault() != null)
            {
                List<NotaIngresoPlantaAnalisisSensorialDefectoDetalleTipo> AnalisisSensorialDefectoDetalle = new List<NotaIngresoPlantaAnalisisSensorialDefectoDetalleTipo>();

                request.AnalisisSensorialDefectoDetalleList.ForEach(z =>
                {
                    NotaIngresoPlantaAnalisisSensorialDefectoDetalleTipo item = new NotaIngresoPlantaAnalisisSensorialDefectoDetalleTipo();
                    item.NotaIngresoPlantaId = request.NotaIngresoPlantaId;
                    item.DefectoDetalleDescripcion = z.DefectoDetalleDescripcion;
                    item.DefectoDetalleId = z.DefectoDetalleId;

                    item.Valor = z.Valor;
                    AnalisisSensorialDefectoDetalle.Add(item);
                });

                affected = _INotaIngresoPlantaRepository.ActualizarNotaIngresoPlantaAnalisisSensorialDefectoDetalle(AnalisisSensorialDefectoDetalle, request.NotaIngresoPlantaId);
            }


            if (request.RegistroTostadoIndicadorDetalleList.FirstOrDefault() != null)
            {
                List<NotaIngresoPlantaRegistroTostadoIndicadorDetalleTipo> RegistroTostadoIndicadorDetalle = new List<NotaIngresoPlantaRegistroTostadoIndicadorDetalleTipo>();

                request.RegistroTostadoIndicadorDetalleList.ForEach(z =>
                {

                    NotaIngresoPlantaRegistroTostadoIndicadorDetalleTipo item = new NotaIngresoPlantaRegistroTostadoIndicadorDetalleTipo();
                    item.NotaIngresoPlantaId = request.NotaIngresoPlantaId;
                    item.IndicadorDetalleDescripcion = z.IndicadorDetalleDescripcion;
                    item.IndicadorDetalleId = z.IndicadorDetalleId;
                    item.Valor = z.Valor;

                    RegistroTostadoIndicadorDetalle.Add(item);
                });

                affected = _INotaIngresoPlantaRepository.ActualizarNotaIngresoPlantaRegistroTostadoIndicadorDetalle(RegistroTostadoIndicadorDetalle, request.NotaIngresoPlantaId);
            }

            return affected;
        }

    }
}
