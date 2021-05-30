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
    public partial class EmpresaProveedoraAcreedoraService : IEmpresaProveedoraAcreedoraService
    {

        private IEmpresaProveedoraAcreedoraRepository _IEmpresaProveedoraAcreedoraRepository;

        private readonly IMapper _Mapper;

        public EmpresaProveedoraAcreedoraService(IEmpresaProveedoraAcreedoraRepository empresaProveedoraAcreedoraRepository, IMapper mapper)
        {
            _IEmpresaProveedoraAcreedoraRepository = empresaProveedoraAcreedoraRepository;
            _Mapper = mapper;
        }


        public List<ConsultaEmpresaProveedoraAcreedoraBE> ConsultarEmpresaProveedoraAcreedora(ConsultaEmpresaProveedoraAcreedoraRequestDTO request)
        {
            var lista = _IEmpresaProveedoraAcreedoraRepository.ConsultarEmpresaProveedoraAcreedora(request);

            return lista.ToList();
        }

        public int RegistrarEmpresaProveedoraAcreedora(RegistrarActualizarEmpresaProveedoraAcreedoraRequestDTO request)
        {
            EmpresaProveedoraAcreedora empresaProveedoraAcreedora = _Mapper.Map<EmpresaProveedoraAcreedora>(request);
            empresaProveedoraAcreedora.FechaRegistro = DateTime.Now;
            empresaProveedoraAcreedora.UsuarioRegistro = request.Usuario;


            int affected = _IEmpresaProveedoraAcreedoraRepository.Insertar(empresaProveedoraAcreedora);

            return affected;
        }

        public int ActualizarEmpresaProveedoraAcreedora(RegistrarActualizarEmpresaProveedoraAcreedoraRequestDTO request)
        {
            EmpresaProveedoraAcreedora empresaProveedoraAcreedora = _Mapper.Map<EmpresaProveedoraAcreedora>(request);
            empresaProveedoraAcreedora.FechaUltimaActualizacion = DateTime.Now;
            empresaProveedoraAcreedora.UsuarioUltimaActualizacion = request.Usuario;

            int affected = _IEmpresaProveedoraAcreedoraRepository.Actualizar(empresaProveedoraAcreedora);

            return affected;
        }

        public ConsultaEmpresaProveedoraAcreedoraPorIdBE ConsultarEmpresaProveedoraAcreedoraPorId(ConsultaEmpresaProveedoraAcreedoraPorIdRequestDTO request)
        {
            return _IEmpresaProveedoraAcreedoraRepository.ConsultarEmpresaProveedoraAcreedoraPorId(request.EmpresaProveedoraAcreedoraId);
        }

    }
}
