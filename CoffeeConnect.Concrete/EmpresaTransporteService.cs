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
    public partial class EmpresaTransporteService : IEmpresaTransporteService
    {

        private IEmpresaTransporteRepository _IEmpresaTransporteRepository;

        private readonly IMapper _Mapper;

        public EmpresaTransporteService(IEmpresaTransporteRepository empresaTransporteRepository, IMapper mapper)
        {
            _IEmpresaTransporteRepository = empresaTransporteRepository;

            _Mapper = mapper;
        }
        public List<EmpresaTransporteBE> ConsultarEmpresaTransporte(int empresaId)
        {
            var lista = _IEmpresaTransporteRepository.ConsultarEmpresaTransporte(empresaId);

            return lista.ToList();
        }

        public List<ConsultaTransportistaBE> ConsultarTransportista(ConsultaTransportistaRequestDTO request)
        {
            var lista = _IEmpresaTransporteRepository.ConsultarTransportista(request);

            return lista.ToList();
        }

        public int RegistrarEmpresaTransporte(RegistrarActualizarEmpresaTransporteRequestDTO request)
        {
            EmpresaTransporte empresaTransporte = _Mapper.Map<EmpresaTransporte>(request);
            empresaTransporte.FechaRegistro = DateTime.Now;
            empresaTransporte.UsuarioRegistro = request.Usuario;
           

            int affected = _IEmpresaTransporteRepository.Insertar(empresaTransporte);

            return affected;
        }

        public int ActualizarEmpresaTransporte(RegistrarActualizarEmpresaTransporteRequestDTO request)
        {
            EmpresaTransporte empresaTransporte = _Mapper.Map<EmpresaTransporte>(request);
            empresaTransporte.FechaUltimaActualizacion = DateTime.Now;
            empresaTransporte.UsuarioUltimaActualizacion = request.Usuario;

            int affected = _IEmpresaTransporteRepository.Actualizar(empresaTransporte);

            return affected;
        }

        public ConsultaEmpresaTransportePorIdBE ConsultarEmpresaTransportePorId(ConsultaEmpresaTransportePorIdRequestDTO request)
        {
            return _IEmpresaTransporteRepository.ConsultarEmpresaTransportePorId(request.EmpresaTransporteId);
        }

    }
}
