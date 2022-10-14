
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
    public partial class NotaIngresoAlmacenPlantaService : INotaIngresoAlmacenPlantaService
    {
        private readonly IMapper _Mapper;
        private INotaIngresoAlmacenPlantaRepository _INotaIngresoAlmacenPlantaRepository;
        private INotaIngresoPlantaRepository _INotaIngresoPlantaRepository;
        private ICorrelativoRepository _ICorrelativoRepository;

        public NotaIngresoAlmacenPlantaService(INotaIngresoAlmacenPlantaRepository NotaIngresoAlmacenPlantaRepository, IMapper mapper, INotaIngresoPlantaRepository notaIngresoPlantaRepository, ICorrelativoRepository correlativoRepository)
        {
            _INotaIngresoAlmacenPlantaRepository = NotaIngresoAlmacenPlantaRepository;
            _INotaIngresoPlantaRepository = notaIngresoPlantaRepository;
            _ICorrelativoRepository = correlativoRepository;
            _Mapper = mapper;
        }

        public int Registrar(RegistrarActualizarNotaIngresoAlmacenPlantaRequestDTO request)
        {
            //ConsultaNotaIngresoPlantaPorIdBE notaIngresoPlanta = _INotaIngresoPlantaRepository.ConsultarNotaIngresoPlantaPorId(request.NotaIngresoPlantaId);

            NotaIngresoAlmacenPlanta NotaIngresoAlmacenPlanta = _Mapper.Map<NotaIngresoAlmacenPlanta>(request);


            NotaIngresoAlmacenPlanta.UsuarioRegistro = request.Usuario;
            NotaIngresoAlmacenPlanta.FechaRegistro = DateTime.Now;
            NotaIngresoAlmacenPlanta.EstadoId = NotaIngresoAlmacenPlantaEstados.Ingresado;
        




            int affected = _INotaIngresoAlmacenPlantaRepository.Insertar(NotaIngresoAlmacenPlanta);

            //_INotaIngresoPlantaRepository.ActualizarEstado(request.NotaIngresoPlantaId, DateTime.Now, request.Usuario, NotaIngresoPlantaEstados.EnviadoAlmacen);

            return affected;
        }

        public List<ConsultaNotaIngresoAlmacenPlantaBE> ConsultarNotaIngresoAlmacenPlanta(ConsultaNotaIngresoAlmacenPlantaRequestDTO request)
        {

            /*if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFin == null || request.FechaFin == DateTime.MinValue || string.IsNullOrEmpty(request.EstadoId))
                throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.NotaCompra.ValidacionSeleccioneMinimoUnFiltro.Label" }); */

            //if (string.IsNullOrEmpty(request.EstadoId))
            //    throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.NotaCompra.ValidacionSeleccioneMinimoUnFiltro.Label" });

            var timeSpan = request.FechaFin - request.FechaInicio;

            /*if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Acopio.NotaCompra.ValidacionRangoFechaMayor2anios.Label" });*/

            var list = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlanta(request);
            return list.ToList(); 
        }

        //public int AnularNotaIngresoAlmacenPlanta(AnularNotaIngresoAlmacenPlantaRequestDTO request)
        //{
        //    ConsultaNotaIngresoAlmacenPlantaPorIdBE consultaNotaIngresoAlmacenPlantaPorIdBE = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaPorId(request.NotaIngresoAlmacenPlantaId);

        //    int affected = 0;

        //    if (consultaNotaIngresoAlmacenPlantaPorIdBE != null)
        //    {
        //        affected = _INotaIngresoAlmacenPlantaRepository.ActualizarEstado(request.NotaIngresoAlmacenPlantaId, DateTime.Now, request.Usuario, LoteEstados.Anulado);

        //        _IGuiaRecepcionMateriaPrimaRepository.ActualizarEstado(consultaNotaIngresoAlmacenPlantaPorIdBE.GuiaRecepcionMateriaPrimaId, DateTime.Now, request.Usuario, GuiaRecepcionMateriaPrimaEstados.Analizado);

        //    }

        //    return affected;
        //}

        public int ActualizarNotaIngresoAlmacenPlanta(ActualizarNotaIngresoAlmacenPlantaRequestDTO request)
        {
            int affected = 0;


            affected = _INotaIngresoAlmacenPlantaRepository.Actualizar(request.NotaIngresoAlmacenPlantaId, DateTime.Now, request.Usuario, request.AlmacenId);



            return affected;
        }

        public ConsultaNotaIngresoAlmacenPlantaPorIdBE ConsultarNotaIngresoAlmacenPlantaPorId(ConsultaNotaIngresoAlmacenPlantaPorIdRequestDTO request)
        {
            ConsultaNotaIngresoAlmacenPlantaPorIdBE consultaNotaIngresoAlmacenPlantaPorIdBE = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaPorId(request.NotaIngresoAlmacenPlantaId);

            if (consultaNotaIngresoAlmacenPlantaPorIdBE != null)
            {
               
                consultaNotaIngresoAlmacenPlantaPorIdBE.AnalisisFisicoColorDetalle = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaAnalisisFisicoColorDetallePorId(consultaNotaIngresoAlmacenPlantaPorIdBE.ControlCalidadPlantaId).ToList();

                consultaNotaIngresoAlmacenPlantaPorIdBE.AnalisisFisicoOlorDetalle = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaAnalisisFisicoOlorDetallePorId(consultaNotaIngresoAlmacenPlantaPorIdBE.ControlCalidadPlantaId).ToList();

                consultaNotaIngresoAlmacenPlantaPorIdBE.AnalisisFisicoDefectoPrimarioDetalle = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaAnalisisFisicoDefectoPrimarioDetallePorId(consultaNotaIngresoAlmacenPlantaPorIdBE.ControlCalidadPlantaId).ToList();

                consultaNotaIngresoAlmacenPlantaPorIdBE.AnalisisFisicoDefectoSecundarioDetalle = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaAnalisisFisicoDefectoSecundarioDetallePorId(consultaNotaIngresoAlmacenPlantaPorIdBE.ControlCalidadPlantaId).ToList();

                consultaNotaIngresoAlmacenPlantaPorIdBE.AnalisisSensorialAtributoDetalle = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaAnalisisSensorialAtributoDetallePorId(consultaNotaIngresoAlmacenPlantaPorIdBE.ControlCalidadPlantaId).ToList();

                consultaNotaIngresoAlmacenPlantaPorIdBE.AnalisisSensorialDefectoDetalle = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaAnalisisSensorialDefectoDetallePorId(consultaNotaIngresoAlmacenPlantaPorIdBE.ControlCalidadPlantaId).ToList();

                consultaNotaIngresoAlmacenPlantaPorIdBE.RegistroTostadoIndicadorDetalle = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaRegistroTostadoIndicadorDetallePorId(consultaNotaIngresoAlmacenPlantaPorIdBE.ControlCalidadPlantaId).ToList();

                
            }

            return consultaNotaIngresoAlmacenPlantaPorIdBE;
        }
    }
}
