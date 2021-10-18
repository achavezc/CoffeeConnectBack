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
    public class KardexProcesoService : IKardexProcesoService
    {
        private IKardexProcesoRepository _IKardexProcesoRepository;

        private readonly IMapper _Mapper;

        public KardexProcesoService(IKardexProcesoRepository kardexProcesoRepository, IMapper mapper)
        {
            _IKardexProcesoRepository = kardexProcesoRepository;

            _Mapper = mapper;
        }

        public List<ConsultaKardexProcesoBE> ConsultarKardexProceso(ConsultaKardexProcesoRequestDTO request)
        {
            if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFin == null || request.FechaFin == DateTime.MinValue)
                throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.KardexProceso.ValidacionSeleccioneMinimoUnFiltro.Label" });

            var list = _IKardexProcesoRepository.ConsultarKardexProceso(request);

            return list.ToList();
        }

        public int Registrar(RegistrarActualizarKardexProcesoRequestDTO request)
        {
            KardexProceso kardexProceso = _Mapper.Map<KardexProceso>(request);
            kardexProceso.FechaRegistro = DateTime.Now;
            kardexProceso.UsuarioRegistro = request.Usuario;


            int affected = _IKardexProcesoRepository.Insertar(kardexProceso);

            return affected;
        }

        public int Actualizar(RegistrarActualizarKardexProcesoRequestDTO request)
        {
            KardexProceso kardexProceso = _Mapper.Map<KardexProceso>(request);
            kardexProceso.FechaActualizacion = DateTime.Now;
            kardexProceso.UsuarioActualizacion = request.Usuario;
            int affected = _IKardexProcesoRepository.Actualizar(kardexProceso);
            return affected;
        }

        public ConsultaKardexProcesoPorIdBE ConsultarKardexProcesoPorId(ConsultaKardexProcesoPorIdRequestDTO request)
        {
            return _IKardexProcesoRepository.ConsultarKardexProcesoPorId(request.KardexProcesoId);
        }
    }
}
