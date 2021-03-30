
using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.Service
{
    public partial class SocioFincaCertificacionService : ISocioFincaCertificacionService
    {
        private readonly IMapper _Mapper;

        private ISocioFincaCertificacionRepository _ISocioFincaRepository;




        public SocioFincaCertificacionService(ISocioFincaCertificacionRepository socioFincaRepository, IMapper mapper)
        {
            _ISocioFincaRepository = socioFincaRepository;


            _Mapper = mapper;



        }



        public int RegistrarSocioFincaCertificacion(RegistrarActualizarSocioFincaCertificacionRequestDTO request)
        {
            SocioFincaCertificacion socioFinca = _Mapper.Map<SocioFincaCertificacion>(request);
            socioFinca.FechaRegistro = DateTime.Now;
            socioFinca.UsuarioRegistro = request.Usuario;


            int affected = _ISocioFincaRepository.Insertar(socioFinca);

            return affected;
        }

        public int ActualizarSocioFincaCertificacion(RegistrarActualizarSocioFincaCertificacionRequestDTO request)
        {
            SocioFincaCertificacion socioFinca = _Mapper.Map<SocioFincaCertificacion>(request);
            socioFinca.FechaUltimaActualizacion = DateTime.Now;
            socioFinca.UsuarioUltimaActualizacion = request.Usuario;

            int affected = _ISocioFincaRepository.Actualizar(socioFinca);

            return affected;
        }

        public IEnumerable<ConsultaSocioFincaCertificacionPorSocioFincaId> ConsultarSocioFincaCertificacionPorSocioFincaId(ConsultaSocioFincaCertificacionPorSocioFincaIdRequestDTO request)
        {
            return _ISocioFincaRepository.ConsultarSocioFincaCertificacionPorSocioFincaId(request.SocioFincaId);
        }

        public ConsultaSocioFincaCertificacionPorId ConsultarSocioFincaCertificacionPorId(ConsultaSocioFincaCertificacionPorIdRequestDTO request)
        {
            return _ISocioFincaRepository.ConsultarSocioFincaCertificacionPorId(request.SocioFincaCertificacionId);
        }

    }
}
