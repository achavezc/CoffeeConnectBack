
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
    public partial class SocioService : ISocioService
    {
        private readonly IMapper _Mapper;

        private ISocioRepository _ISocioRepository;

        private ICorrelativoRepository _ICorrelativoRepository;

        public SocioService(ISocioRepository socioRepository, ICorrelativoRepository correlativoRepository, IMapper mapper)
        {
            _ISocioRepository = socioRepository;

            _ICorrelativoRepository = correlativoRepository;

            _Mapper = mapper;



        }

        public List<ConsultaSocioBE> ConsultarSocio(ConsultaSocioRequestDTO request)
        {
            if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFin == null || request.FechaFin == DateTime.MinValue || string.IsNullOrEmpty(request.EstadoId))
                throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.NotaCompra.ValidacionSeleccioneMinimoUnFiltro.Label" });

            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Acopio.NotaCompra.ValidacionRangoFechaMayor2anios.Label" });

            var list = _ISocioRepository.ConsultarSocio(request);
            return list.ToList();
        }

        public int RegistrarSocio(RegistrarActualizarSocioRequestDTO request)
        {

            var list = _ISocioRepository.ValidarSocio(request.ProductorId);

            if (list.ToList().Count > 0)
            {
                throw new ResultException(new Result { ErrCode = "01", Message = "El Socio ya se encuentra registrado." });
            }


            Socio socio = _Mapper.Map<Socio>(request);
            socio.FechaRegistro = DateTime.Now;
            socio.UsuarioRegistro = request.Usuario;
            socio.Codigo = _ICorrelativoRepository.Obtener(null, Documentos.Socio);
            socio.EstadoId = SocioEstados.Activo;
            int affected = _ISocioRepository.Insertar(socio);

            return affected;
        }

        public int ActualizarSocio(RegistrarActualizarSocioRequestDTO request)
        {
            Socio socio = _Mapper.Map<Socio>(request);
            socio.FechaUltimaActualizacion = DateTime.Now;
            socio.UsuarioUltimaActualizacion = request.Usuario;

            int affected = _ISocioRepository.Actualizar(socio);

            return affected;
        }

        public ConsultaSocioPorIdBE ConsultarSocioPorId(ConsultaSocioPorIdRequestDTO request)
        {
            ConsultaSocioPorIdBE consultaSocioPorIdBE = _ISocioRepository.ConsultarSocioPorId(request.SocioId);

            return consultaSocioPorIdBE;

        }
    }
}
