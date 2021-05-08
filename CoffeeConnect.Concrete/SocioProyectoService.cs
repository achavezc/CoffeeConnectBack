
using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.Service
{
    public partial class SocioProyectoService : ISocioProyectoService
    {
        private readonly IMapper _Mapper;

        private ISocioProyectoRepository _ISocioProyectoRepository;

        public SocioProyectoService(ISocioProyectoRepository socioProyectoRepository, IMapper mapper)
        {
            _ISocioProyectoRepository = socioProyectoRepository;


            _Mapper = mapper;



        }

        public int RegistrarSocioProyecto(RegistrarActualizarSocioProyectoRequestDTO request)
        {
            SocioProyecto socioProyecto = _Mapper.Map<SocioProyecto>(request);
            socioProyecto.FechaRegistro = DateTime.Now;
            socioProyecto.UsuarioRegistro = request.Usuario;

            int id = _ISocioProyectoRepository.Insertar(socioProyecto);

            return id;
        }

        public int ActualizarSocioProyecto(RegistrarActualizarSocioProyectoRequestDTO request)
        {
            SocioProyecto socioProyecto = _Mapper.Map<SocioProyecto>(request);
            socioProyecto.FechaUltimaActualizacion = DateTime.Now;
            socioProyecto.UsuarioUltimaActualizacion = request.Usuario;

            int affected = _ISocioProyectoRepository.Actualizar(socioProyecto);


            return affected;
        }

        public IEnumerable<ConsultaSocioProyectoPorSocioIdBE> ConsultarSocioProyectoPorSocioId(ConsultaSocioProyectoPorSocioIdRequestDTO request)
        {
            return _ISocioProyectoRepository.ConsultarSocioProyectoPorSocioId(request.SocioId);
        }

        public ConsultaSocioProyectoPorIdBE ConsultarSocioProyectoPorId(ConsultaSocioProyectoPorIdRequestDTO request)
        {
            ConsultaSocioProyectoPorIdBE consultaSocioProyectoPorIdBE = _ISocioProyectoRepository.ConsultarSocioProyectoPorId(request.SocioProyectoId);
            return consultaSocioProyectoPorIdBE;
        }
    }
}
