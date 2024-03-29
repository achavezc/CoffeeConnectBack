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
    public partial class NotaIngresoAlmacenService : INotaIngresoAlmacenService
    {
        private INotaIngresoAlmacenRepository _INotaIngresoAlmacenRepository;
        private IGuiaRecepcionMateriaPrimaRepository _IGuiaRecepcionMateriaPrimaRepository;
        private ICorrelativoRepository _ICorrelativoRepository;
        private IMaestroRepository _IMaestroRepository;
        private ISocioFincaCertificacionRepository _ISocioFincaCertificacionRepository;

        public NotaIngresoAlmacenService(INotaIngresoAlmacenRepository notaIngresoAlmacenRepository, ISocioFincaCertificacionRepository socioFincaCertificacionRepository,  IMaestroRepository maestroRepository, IGuiaRecepcionMateriaPrimaRepository guiaRecepcionMateriaPrimaRepository, ICorrelativoRepository correlativoRepository)
        {
            _INotaIngresoAlmacenRepository = notaIngresoAlmacenRepository;
            _IGuiaRecepcionMateriaPrimaRepository = guiaRecepcionMateriaPrimaRepository;
            _ICorrelativoRepository = correlativoRepository;
            _IMaestroRepository = maestroRepository;
            _ISocioFincaCertificacionRepository = socioFincaCertificacionRepository;

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

        public int Registrar(EnviarAlmacenGuiaRecepcionMateriaPrimaRequestDTO request)
        {
            ConsultaGuiaRecepcionMateriaPrimaPorIdBE guiaRecepcionMateriaPrima = _IGuiaRecepcionMateriaPrimaRepository.ConsultarGuiaRecepcionMateriaPrimaPorId(request.GuiaRecepcionMateriaPrimaId);

            NotaIngresoAlmacen notaIngresoAlmacen = new NotaIngresoAlmacen();
            notaIngresoAlmacen.GuiaRecepcionMateriaPrimaId = request.GuiaRecepcionMateriaPrimaId;

            notaIngresoAlmacen.EmpresaId = guiaRecepcionMateriaPrima.EmpresaId;
            notaIngresoAlmacen.Numero = _ICorrelativoRepository.Obtener(guiaRecepcionMateriaPrima.EmpresaId, Documentos.NotaIngresoAlmacen);
            notaIngresoAlmacen.AlmacenId = null;
            notaIngresoAlmacen.TipoProvedorId = guiaRecepcionMateriaPrima.TipoProvedorId;
            notaIngresoAlmacen.SocioId = guiaRecepcionMateriaPrima.SocioId;
            notaIngresoAlmacen.TerceroId = guiaRecepcionMateriaPrima.TerceroId;
            notaIngresoAlmacen.TipoProduccionId = guiaRecepcionMateriaPrima.TipoProduccionId;
            notaIngresoAlmacen.IntermediarioId = guiaRecepcionMateriaPrima.IntermediarioId;
            notaIngresoAlmacen.ProductoId = guiaRecepcionMateriaPrima.ProductoId;
            notaIngresoAlmacen.SubProductoId = guiaRecepcionMateriaPrima.SubProductoId;
            notaIngresoAlmacen.UnidadMedidaIdPesado = guiaRecepcionMateriaPrima.UnidadMedidaIdPesado;
            notaIngresoAlmacen.CantidadPesado = guiaRecepcionMateriaPrima.CantidadPesado;
            notaIngresoAlmacen.KilosBrutosPesado = guiaRecepcionMateriaPrima.KilosBrutosPesado;
            notaIngresoAlmacen.TaraPesado = guiaRecepcionMateriaPrima.TaraPesado;
            notaIngresoAlmacen.KilosNetosPesado = guiaRecepcionMateriaPrima.KilosBrutosPesado - notaIngresoAlmacen.TaraPesado;
            notaIngresoAlmacen.QQ55 = notaIngresoAlmacen.KilosNetosPesado / Convert.ToDecimal(55.2);
            notaIngresoAlmacen.ExportableGramosAnalisisFisico = guiaRecepcionMateriaPrima.ExportableGramosAnalisisFisico;
            notaIngresoAlmacen.ExportablePorcentajeAnalisisFisico = guiaRecepcionMateriaPrima.ExportablePorcentajeAnalisisFisico;
            notaIngresoAlmacen.DescarteGramosAnalisisFisico = guiaRecepcionMateriaPrima.DescarteGramosAnalisisFisico;
            notaIngresoAlmacen.DescartePorcentajeAnalisisFisico = guiaRecepcionMateriaPrima.DescartePorcentajeAnalisisFisico;
            notaIngresoAlmacen.CascarillaGramosAnalisisFisico = guiaRecepcionMateriaPrima.CascarillaGramosAnalisisFisico;
            notaIngresoAlmacen.CascarillaPorcentajeAnalisisFisico = guiaRecepcionMateriaPrima.CascarillaPorcentajeAnalisisFisico;
            notaIngresoAlmacen.TotalGramosAnalisisFisico = guiaRecepcionMateriaPrima.TotalGramosAnalisisFisico;
            notaIngresoAlmacen.TotalPorcentajeAnalisisFisico = guiaRecepcionMateriaPrima.TotalPorcentajeAnalisisFisico;
            notaIngresoAlmacen.TotalAnalisisSensorial = guiaRecepcionMateriaPrima.TotalAnalisisSensorial;
            notaIngresoAlmacen.HumedadPorcentajeAnalisisFisico = guiaRecepcionMateriaPrima.HumedadPorcentajeAnalisisFisico.Value;

            List<ConsultaSocioFincaCertificacionPorSocioFincaId> certificacionesSocio = _ISocioFincaCertificacionRepository.ConsultarSocioFincaCertificacionPorSocioFincaId(guiaRecepcionMateriaPrima.SocioFincaId.Value).ToList();

            string certificaciones = String.Empty;
            string certificadoras = String.Empty;
            int contador = 1;


            foreach (ConsultaSocioFincaCertificacionPorSocioFincaId certificacion in certificacionesSocio)
            {
                if(contador==1)
                {
                    certificaciones = certificacion.TipoCertificacionId + "|";
                    certificadoras = certificacion.EntidadCertificadoraId + "|";
                }
                else
                {
                    certificaciones = certificaciones + certificacion.TipoCertificacionId + "|";
                    certificadoras = certificadoras + certificacion.EntidadCertificadoraId + "|";

                }
                contador = contador + 1;
                
            }

            notaIngresoAlmacen.TipoCertificacionId = certificaciones;
            notaIngresoAlmacen.EntidadCertificadoraId = certificadoras;

            if (guiaRecepcionMateriaPrima.TotalGramosAnalisisFisico.HasValue && guiaRecepcionMateriaPrima.TotalGramosAnalisisFisico > 0)
            {
                notaIngresoAlmacen.RendimientoPorcentaje = (guiaRecepcionMateriaPrima.ExportableGramosAnalisisFisico / guiaRecepcionMateriaPrima.TotalGramosAnalisisFisico) * 100;
            }
            else
            {
                notaIngresoAlmacen.RendimientoPorcentaje = 0;
            }
            //notaIngresoAlmacen.Observacion = guiaRecepcionMateriaPrima.Observacion;
            notaIngresoAlmacen.UsuarioRegistro = request.Usuario;
            notaIngresoAlmacen.FechaRegistro = DateTime.Now;
            notaIngresoAlmacen.EstadoId = NotaIngresoAlmacenEstados.Ingresado;




            int affected = _INotaIngresoAlmacenRepository.Insertar(notaIngresoAlmacen);

            _IGuiaRecepcionMateriaPrimaRepository.ActualizarEstado(request.GuiaRecepcionMateriaPrimaId, DateTime.Now, request.Usuario, GuiaRecepcionMateriaPrimaEstados.EnviadoAlmacen);

            return affected;
        }

        public List<ConsultaNotaIngresoAlmacenBE> ConsultarNotaIngresoAlmacen(ConsultaNotaIngresoAlmacenRequestDTO request)
        {
            if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFin == null || request.FechaFin == DateTime.MinValue || string.IsNullOrEmpty(request.EstadoId))
                throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.NotaCompra.ValidacionSeleccioneMinimoUnFiltro.Label" });

            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Acopio.NotaCompra.ValidacionRangoFechaMayor2anios.Label" });

            var list = _INotaIngresoAlmacenRepository.ConsultarNotaIngresoAlmacen(request);


            List<ConsultaDetalleTablaBE> lista = _IMaestroRepository.ConsultarDetalleTablaDeTablas(request.EmpresaId, String.Empty).ToList();

            foreach (ConsultaNotaIngresoAlmacenBE consultaNotaIngresoAlmacenBE in list)
            {

                if (!string.IsNullOrEmpty(consultaNotaIngresoAlmacenBE.TipoCertificacionId) && !string.IsNullOrEmpty(consultaNotaIngresoAlmacenBE.EntidadCertificadoraId))
                {


                    string[] certificacionesIds = consultaNotaIngresoAlmacenBE.TipoCertificacionId.Split('|');

                    string[] certificadorasIds = consultaNotaIngresoAlmacenBE.EntidadCertificadoraId.Split('|');

                    string certificacionLabel = string.Empty;

                    string certificadoraLabel = string.Empty;

                    if (certificacionesIds.Length > 0)
                    {
                        List<ConsultaDetalleTablaBE> certificaciones = lista.Where(a => a.CodigoTabla.Trim().Equals("TipoCertificacion")).ToList();

                        List<ConsultaDetalleTablaBE> certificadoras = lista.Where(a => a.CodigoTabla.Trim().Equals("EntidadCertificadora")).ToList();

                        foreach (string certificacionId in certificacionesIds)
                        {
                            ConsultaDetalleTablaBE certificacion = certificaciones.Where(a => a.Codigo == certificacionId).FirstOrDefault();

                            if (certificacion != null)
                            {
                                certificacionLabel = certificacionLabel + certificacion.Label + " ";
                            }
                        }

                        foreach (string certificadoraId in certificadorasIds)
                        {
                            ConsultaDetalleTablaBE certificadora = certificadoras.Where(a => a.Codigo == certificadoraId).FirstOrDefault();

                            if (certificadora != null)
                            {
                                certificadoraLabel = certificadoraLabel + certificadora.Label + " ";
                            }
                        }

                    }

                    consultaNotaIngresoAlmacenBE.Certificacion = certificacionLabel;
                    consultaNotaIngresoAlmacenBE.Certificadora = certificadoraLabel;

                }
            }
            return list.ToList();
        }

        public int AnularNotaIngresoAlmacen(AnularNotaIngresoAlmacenRequestDTO request)
        {
            ConsultaNotaIngresoAlmacenPorIdBE consultaNotaIngresoAlmacenPorIdBE = _INotaIngresoAlmacenRepository.ConsultarNotaIngresoAlmacenPorId(request.NotaIngresoAlmacenId);

            int affected = 0;

            if (consultaNotaIngresoAlmacenPorIdBE != null)
            {
                affected = _INotaIngresoAlmacenRepository.ActualizarEstado(request.NotaIngresoAlmacenId, DateTime.Now, request.Usuario, LoteEstados.Anulado);

                _IGuiaRecepcionMateriaPrimaRepository.ActualizarEstado(consultaNotaIngresoAlmacenPorIdBE.GuiaRecepcionMateriaPrimaId, DateTime.Now, request.Usuario, GuiaRecepcionMateriaPrimaEstados.Analizado);

            }

            return affected;
        }

        public int ActualizarNotaIngresoAlmacen(ActualizarNotaIngresoAlmacenRequestDTO request)
        {
            int affected = 0;


            affected = _INotaIngresoAlmacenRepository.Actualizar(request.NotaIngresoAlmacenId, DateTime.Now, request.Usuario, request.AlmacenId);



            return affected;
        }

        public ConsultaNotaIngresoAlmacenPorIdBE ConsultarNotaIngresoAlmacenPorId(ConsultaNotaIngresoAlmacenPorIdRequestDTO request)
        {
            ConsultaNotaIngresoAlmacenPorIdBE consultaNotaIngresoAlmacenPorIdBE = _INotaIngresoAlmacenRepository.ConsultarNotaIngresoAlmacenPorId(request.NotaIngresoAlmacenId);

            consultaNotaIngresoAlmacenPorIdBE.AnalisisSensorialDefectoDetalle = _IGuiaRecepcionMateriaPrimaRepository.ConsultarGuiaRecepcionMateriaPrimaAnalisisSensorialDefectoDetallePorId(consultaNotaIngresoAlmacenPorIdBE.GuiaRecepcionMateriaPrimaId).ToList();

            return consultaNotaIngresoAlmacenPorIdBE;
        }

    }
}
