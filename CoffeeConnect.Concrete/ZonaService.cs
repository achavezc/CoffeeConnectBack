
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
    public partial class ZonaService : IZonaService
    {
        private readonly IMapper _Mapper;
        private IZonaRepository _IZonaRepository;
        private ICorrelativoRepository _ICorrelativoRepository;

        public ZonaService(IZonaRepository ZonaRepository, ICorrelativoRepository correlativoRepository, IMapper mapper)
        {
            _IZonaRepository = ZonaRepository;

            _ICorrelativoRepository = correlativoRepository;

            _Mapper = mapper;



        }

        public List<ConsultaZonaBE> ConsultarZona(ConsultaZonaRequestDTO request)
        {
           
            var list = _IZonaRepository.ConsultarZona(request);
            return list.ToList();
        }

        public int RegistrarZona(RegistrarActualizarZonaRequestDTO request)
        {
            Zona Zona = _Mapper.Map<Zona>(request);
            Zona.FechaRegistro = DateTime.Now;
            Zona.UsuarioRegistro = request.Usuario;
           

            int affected = _IZonaRepository.Insertar(Zona);

            return affected;
        }

        public int ActualizarZona(RegistrarActualizarZonaRequestDTO request)
        {
            Zona Zona = _Mapper.Map<Zona>(request);
            Zona.FechaUltimaActualizacion = DateTime.Now;
            Zona.UsuarioUltimaActualizacion = request.Usuario;

            int affected = _IZonaRepository.Actualizar(Zona);

            return affected;
        }

        public ConsultaZonaPorIdBE ConsultarZonaPorId(ConsultaZonaPorIdRequestDTO request)
        {
            return _IZonaRepository.ConsultarZonaPorId(request.ZonaId);
        }

      

    }
}
