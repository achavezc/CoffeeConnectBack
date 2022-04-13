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
    public class KardexPlantaService : IKardexPlantaService
    {
        private IKardexPlantaRepository _IKardexPlantaRepository;

        private readonly IMapper _Mapper;

        private ICorrelativoRepository _ICorrelativoRepository;
        public KardexPlantaService(IKardexPlantaRepository KardexPlantaRepository, IMapper mapper, ICorrelativoRepository correlativoRepository)
        {
            _IKardexPlantaRepository = KardexPlantaRepository;

            _Mapper = mapper;

            _ICorrelativoRepository = correlativoRepository;
        }

        public List<ConsultaKardexPlantaBE> ConsultarKardexPlanta(ConsultaKardexPlantaRequestDTO request)
        {
            if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFin == null || request.FechaFin == DateTime.MinValue)
                throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.KardexPlanta.ValidacionSeleccioneMinimoUnFiltro.Label" });

            var list = _IKardexPlantaRepository.ConsultarKardexPlanta(request);

            return list.ToList();
        }

        public int Registrar(RegistrarActualizarKardexPlantaRequestDTO request)
        {
            KardexPlanta KardexPlanta = _Mapper.Map<KardexPlanta>(request);

            KardexPlanta.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.KardexPlanta);
            KardexPlanta.FechaRegistro = DateTime.Now;
            KardexPlanta.UsuarioRegistro = request.Usuario;


            int affected = _IKardexPlantaRepository.Insertar(KardexPlanta);

            return affected;
        }

        public int Actualizar(RegistrarActualizarKardexPlantaRequestDTO request)
        {
            KardexPlanta KardexPlanta = _Mapper.Map<KardexPlanta>(request);
            KardexPlanta.FechaActualizacion = DateTime.Now;
            KardexPlanta.UsuarioActualizacion = request.Usuario;
            int affected = _IKardexPlantaRepository.Actualizar(KardexPlanta);
            return affected;
        }

        public ConsultaKardexPlantaPorIdBE ConsultarKardexPlantaPorId(ConsultaKardexPlantaPorIdRequestDTO request)
        {
            return _IKardexPlantaRepository.ConsultarKardexPlantaPorId(request.KardexPlantaId);
        }

        public int Anular(AnularKardexPlantaRequestDTO request)
        {
            int result = 0;
            if (request.KardexPlantaId > 0)
            {
                result = _IKardexPlantaRepository.Anular(request.KardexPlantaId, DateTime.Now, request.Usuario, KardexPlantaEstados.Anulado);
            }
            return result;
        }
    }
}
