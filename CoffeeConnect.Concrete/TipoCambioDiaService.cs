
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
    public partial class TipoCambioDiaService : ITipoCambioDiaService
    {
        private readonly IMapper _Mapper;
        private ITipoCambioDiaRepository _ITipoCambioDiaRepository;
        private ICorrelativoRepository _ICorrelativoRepository;

        public TipoCambioDiaService(ITipoCambioDiaRepository TipoCambioDiaRepository, ICorrelativoRepository correlativoRepository, IMapper mapper)
        {
            _ITipoCambioDiaRepository = TipoCambioDiaRepository;

            _ICorrelativoRepository = correlativoRepository;

            _Mapper = mapper;



        }

        public List<ConsultaTipoCambioDiaBE> ConsultarTipoCambioDia(ConsultaTipoCambioDiaRequestDTO request)
        {
            if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFin == null || request.FechaFin == DateTime.MinValue || string.IsNullOrEmpty(request.EstadoId))
                throw new ResultException(new Result { ErrCode = "01", Message = "Comercial.TipoCambioDia.ValidacionSeleccioneMinimoUnFiltro.Label" });

            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Comercial.TipoCambioDia.ValidacionRangoFechaMayor2anios.Label" });

            var list = _ITipoCambioDiaRepository.ConsultarTipoCambioDia(request);
            return list.ToList();
        }

        public int RegistrarTipoCambioDia(RegistrarActualizarTipoCambioDiaRequestDTO request)
        {
            TipoCambioDia TipoCambioDia = _Mapper.Map<TipoCambioDia>(request);
            TipoCambioDia.FechaRegistro = DateTime.Now;
            TipoCambioDia.UsuarioRegistro = request.Usuario;


            int affected = _ITipoCambioDiaRepository.Insertar(TipoCambioDia);

            return affected;
        }

        public int ActualizarTipoCambioDia(RegistrarActualizarTipoCambioDiaRequestDTO request)
        {
            TipoCambioDia TipoCambioDia = _Mapper.Map<TipoCambioDia>(request);
            TipoCambioDia.FechaUltimaActualizacion = DateTime.Now;
            TipoCambioDia.UsuarioUltimaActualizacion = request.Usuario;

            int affected = _ITipoCambioDiaRepository.Actualizar(TipoCambioDia);

            return affected;
        }

        public ConsultaTipoCambioDiaPorIdBE ConsultarTipoCambioDiaPorId(ConsultaTipoCambioDiaPorIdRequestDTO request)
        {
            return _ITipoCambioDiaRepository.ConsultarTipoCambioDiaPorId(request.TipoCambioDiaId);
        }

        public int AnularTipoCambioDia(AnularTipoCambioDiaRequestDTO request)
        {
            int result = 0;
            if (request.TipoCambioDiaId > 0)
            {

                result = _ITipoCambioDiaRepository.Anular(request.TipoCambioDiaId, DateTime.Now, request.Usuario, TipoCambioDiaEstados.Anulado);
            }
            return result;
        }

    }
}
