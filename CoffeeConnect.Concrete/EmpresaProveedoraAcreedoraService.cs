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


            int id = _IEmpresaProveedoraAcreedoraRepository.Insertar(empresaProveedoraAcreedora);


            List<EmpresaProveedoraAcreedoraCertificacionTipo> empresaProveedoraAcreedoraCertificacionTipoList = new List<EmpresaProveedoraAcreedoraCertificacionTipo>();

            request.Certificaciones.ForEach(z =>
            {
                EmpresaProveedoraAcreedoraCertificacionTipo item = new EmpresaProveedoraAcreedoraCertificacionTipo();
                item.CodigoCertificacion = z.CodigoCertificacion;
                item.TipoCertificacionId = z.TipoCertificacionId;
                item.EmpresaProveedoraAcreedoraId = id;

                empresaProveedoraAcreedoraCertificacionTipoList.Add(item);
            });


            _IEmpresaProveedoraAcreedoraRepository.ActualizarEmpresaProveedoraAcreedoraCertificacion(empresaProveedoraAcreedoraCertificacionTipoList, id);



            return id;
        }

        public int ActualizarEmpresaProveedoraAcreedora(RegistrarActualizarEmpresaProveedoraAcreedoraRequestDTO request)
        {
            EmpresaProveedoraAcreedora empresaProveedoraAcreedora = _Mapper.Map<EmpresaProveedoraAcreedora>(request);
            empresaProveedoraAcreedora.FechaUltimaActualizacion = DateTime.Now;
            empresaProveedoraAcreedora.UsuarioUltimaActualizacion = request.Usuario;

            int affected = _IEmpresaProveedoraAcreedoraRepository.Actualizar(empresaProveedoraAcreedora);

            List<EmpresaProveedoraAcreedoraCertificacionTipo> empresaProveedoraAcreedoraCertificacionTipoList = new List<EmpresaProveedoraAcreedoraCertificacionTipo>();

            request.Certificaciones.ForEach(z =>
            {
                EmpresaProveedoraAcreedoraCertificacionTipo item = new EmpresaProveedoraAcreedoraCertificacionTipo();
                item.CodigoCertificacion = z.CodigoCertificacion;
                item.TipoCertificacionId = z.TipoCertificacionId;
                item.EmpresaProveedoraAcreedoraId = request.EmpresaProveedoraAcreedoraId;

                empresaProveedoraAcreedoraCertificacionTipoList.Add(item);
            });

            _IEmpresaProveedoraAcreedoraRepository.ActualizarEmpresaProveedoraAcreedoraCertificacion(empresaProveedoraAcreedoraCertificacionTipoList, request.EmpresaProveedoraAcreedoraId);


            return affected;
        }

        public ConsultaEmpresaProveedoraAcreedoraPorIdBE ConsultarEmpresaProveedoraAcreedoraPorId(ConsultaEmpresaProveedoraAcreedoraPorIdRequestDTO request)
        {
            ConsultaEmpresaProveedoraAcreedoraPorIdBE consultaEmpresaProveedoraAcreedoraPorIdBE = _IEmpresaProveedoraAcreedoraRepository.ConsultarEmpresaProveedoraAcreedoraPorId(request.EmpresaProveedoraAcreedoraId);

            consultaEmpresaProveedoraAcreedoraPorIdBE.Certificaciones = _IEmpresaProveedoraAcreedoraRepository.ConsultarEmpresaProveedoraAcreedoraCertificacionPorId(request.EmpresaProveedoraAcreedoraId).ToList();

            return consultaEmpresaProveedoraAcreedoraPorIdBE;
        }


        public ConsultaEmpresaProveedoraAcreedoraPorIdBE ConsultarEmpresaProveedoraAcreedoraCertificacionPorEmpresaProveedoraAcreedoraId(ConsultaEmpresaProveedoraAcreedoraPorIdRequestDTO request)
        {
            ConsultaEmpresaProveedoraAcreedoraPorIdBE consultaEmpresaProveedoraAcreedoraPorIdBE = new ConsultaEmpresaProveedoraAcreedoraPorIdBE();

            consultaEmpresaProveedoraAcreedoraPorIdBE.Certificaciones = _IEmpresaProveedoraAcreedoraRepository.ConsultarEmpresaProveedoraAcreedoraCertificacionPorId(request.EmpresaProveedoraAcreedoraId).ToList();

            
            return consultaEmpresaProveedoraAcreedoraPorIdBE;
        }

    }
}
