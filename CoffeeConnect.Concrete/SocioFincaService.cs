
using AutoMapper;
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
    public partial class SocioFincaService : ISocioFincaService
    {
        private readonly IMapper _Mapper;

        private ISocioFincaRepository _ISocioFincaRepository;
      
		


		public SocioFincaService(ISocioFincaRepository socioFincaRepository, IMapper mapper)
        {
            _ISocioFincaRepository = socioFincaRepository;            
			

            _Mapper = mapper;



        }



        public int RegistrarSocioFinca(RegistrarActualizarSocioFincaRequestDTO request)
        {
            SocioFinca socioFinca = _Mapper.Map<SocioFinca>(request);
            socioFinca.FechaRegistro = DateTime.Now;
            socioFinca.UsuarioRegistro = request.Usuario;


            int affected = _ISocioFincaRepository.Insertar(socioFinca);

            return affected;
        }

        public int ActualizarSocioFinca(RegistrarActualizarSocioFincaRequestDTO request)
        {
            SocioFinca socioFinca = _Mapper.Map<SocioFinca>(request);
            socioFinca.FechaUltimaActualizacion = DateTime.Now;
            socioFinca.UsuarioUltimaActualizacion = request.Usuario;

            int affected = _ISocioFincaRepository.Actualizar(socioFinca);

            return affected;
        }

        public IEnumerable<ConsultaSocioFincaPorSocioIdBE> ConsultarSocioFincaPorSocioId(ConsultaSocioFincaPorSocioIdRequestDTO request)
        {
            return _ISocioFincaRepository.ConsultarSocioFincaPorSocioId(request.SocioId);
        }

        public ConsultaSocioFincaPorIdBE ConsultarSocioFincaPorId(ConsultaSocioFincaPorIdRequestDTO request)
        {
            return _ISocioFincaRepository.ConsultarSocioFincaPorId(request.SocioFincaId);
        }

    }
}   
