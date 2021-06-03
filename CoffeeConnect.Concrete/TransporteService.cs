using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeConnect.Service
{
    public partial class TransporteService : ITransporteService
    {

        private ITransporteRepository _ITransporteRepository;

        private readonly IMapper _Mapper;

        public TransporteService(ITransporteRepository TransporteRepository, IMapper mapper)
        {
            _ITransporteRepository = TransporteRepository;

            _Mapper = mapper;
        }
        public List<ConsultaTransportePorEmpresaTransporteId> ConsultarTransportePorEmpresaTransporteId(ConsultaTransporteRequestDTO request)
        {
            var lista = _ITransporteRepository.ConsultarTransportePorEmpresaTransporteId(request.EmpresaTransporteId);

            return lista.ToList();
        }

        
        public int RegistrarTransporte(RegistrarActualizarTransporteRequestDTO request)
        {
            Transporte Transporte = _Mapper.Map<Transporte>(request);
            Transporte.FechaRegistro = DateTime.Now;
            Transporte.UsuarioRegistro = request.Usuario;
           

            int affected = _ITransporteRepository.Insertar(Transporte);

            return affected;
        }

        public int ActualizarTransporte(RegistrarActualizarTransporteRequestDTO request)
        {
            Transporte Transporte = _Mapper.Map<Transporte>(request);
            Transporte.FechaUltimaActualizacion = DateTime.Now;
            Transporte.UsuarioUltimaActualizacion = request.Usuario;

            int affected = _ITransporteRepository.Actualizar(Transporte);

            return affected;
        }

        public ConsultaTransportePorIdBE ConsultarTransportePorId(ConsultaTransportePorIdRequestDTO request)
        {
            return _ITransporteRepository.ConsultarTransportePorId(request.TransporteId);
        }

       
    }
}
