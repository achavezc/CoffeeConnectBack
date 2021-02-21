﻿
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
    public partial class NotaIngresoAlmacenService : INotaIngresoAlmacenService
    {
       
        private INotaIngresoAlmacenRepository _INotaIngresoAlmacenRepository;

        private IGuiaRecepcionMateriaPrimaRepository _IGuiaRecepcionMateriaPrimaRepository;

		private ICorrelativoRepository _ICorrelativoRepository;


		public NotaIngresoAlmacenService(INotaIngresoAlmacenRepository notaIngresoAlmacenRepository, IGuiaRecepcionMateriaPrimaRepository guiaRecepcionMateriaPrimaRepository, ICorrelativoRepository correlativoRepository)
        {
            _INotaIngresoAlmacenRepository = notaIngresoAlmacenRepository;
            _IGuiaRecepcionMateriaPrimaRepository = guiaRecepcionMateriaPrimaRepository;
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
			notaIngresoAlmacen.IntermediarioId = guiaRecepcionMateriaPrima.IntermediarioId;
			notaIngresoAlmacen.ProductoId = guiaRecepcionMateriaPrima.ProductoId;
			notaIngresoAlmacen.SubProductoId = guiaRecepcionMateriaPrima.SubProductoId;
			notaIngresoAlmacen.UnidadMedidaIdPesado = guiaRecepcionMateriaPrima.UnidadMedidaIdPesado;
			notaIngresoAlmacen.CantidadPesado = guiaRecepcionMateriaPrima.CantidadPesado;
			notaIngresoAlmacen.KilosBrutosPesado = guiaRecepcionMateriaPrima.KilosBrutosPesado;
			notaIngresoAlmacen.TaraPesado = guiaRecepcionMateriaPrima.TaraPesado;
			notaIngresoAlmacen.KilosNetosPesado = guiaRecepcionMateriaPrima.KilosBrutosPesado - notaIngresoAlmacen.TaraPesado;
			notaIngresoAlmacen.QQ55 = notaIngresoAlmacen.KilosNetosPesado /  Convert.ToDecimal(55.2);
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
			notaIngresoAlmacen.RendimientoPorcentaje = (guiaRecepcionMateriaPrima.ExportableGramosAnalisisFisico / guiaRecepcionMateriaPrima.TotalGramosAnalisisFisico) * 100;
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
			if (string.IsNullOrEmpty(request.Numero) && string.IsNullOrEmpty(request.NumeroDocumento) && string.IsNullOrEmpty(request.CodigoSocio) && string.IsNullOrEmpty(request.NombreRazonSocial))
				throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.NotaCompra.ValidacionSeleccioneMinimoUnFiltro.Label" });


			var timeSpan = request.FechaFin - request.FechaInicio;

			if (timeSpan.Days > 730)
				throw new ResultException(new Result { ErrCode = "02", Message = "Acopio.NotaCompra.ValidacionRangoFechaMayor2anios.Label" });



			var list = _INotaIngresoAlmacenRepository.ConsultarNotaIngresoAlmacen(request);

			return list.ToList();
		}

		public int AnularNotaIngresoAlmacen(AnularNotaIngresoAlmacenRequestDTO request)
		{
			int affected = _INotaIngresoAlmacenRepository.ActualizarEstado(request.NotaIngresoAlmacenId, DateTime.Now, request.Usuario, LoteEstados.Ingresado);

			return affected;
		}
	}
}