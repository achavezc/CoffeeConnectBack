
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
    public partial class OrdenServicioControlCalidadService : IOrdenServicioControlCalidadService
	{
       
        private IOrdenServicioControlCalidadRepository _IOrdenServicioControlCalidadRepository;

       

		private ICorrelativoRepository _ICorrelativoRepository;


		public OrdenServicioControlCalidadService(IOrdenServicioControlCalidadRepository ordenServicioControlCalidadRepository,  ICorrelativoRepository correlativoRepository)
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
	}
}
