
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
    public partial class UbigeoService : IUbigeoService
    {
        private readonly IMapper _Mapper;
        private IUbigeoRepository _IUbigeoRepository;
        private ICorrelativoRepository _ICorrelativoRepository;

        public UbigeoService(IUbigeoRepository UbigeoRepository, ICorrelativoRepository correlativoRepository, IMapper mapper)
        {
            _IUbigeoRepository = UbigeoRepository;

            _ICorrelativoRepository = correlativoRepository;

            _Mapper = mapper;



        }

        public List<ConsultaUbigeoBE> ConsultarUbigeoPorCodigoPais(ConsultaUbigeoPorCodigoPaisRequestDTO request)
        {
           
            var list = _IUbigeoRepository.ConsultarUbigeoPorCodigoPais(request);
            return list.ToList();
        }

        public int RegistrarUbigeo(RegistrarActualizarUbigeoRequestDTO request)
        {
            Ubigeo Ubigeo = _Mapper.Map<Ubigeo>(request);
            Ubigeo.FechaHoraCreacion = DateTime.Now;
            Ubigeo.UsuarioCreacion = request.Usuario;
            Ubigeo.Codigo = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.UbigeoCiudad);

            int affected = _IUbigeoRepository.Insertar(Ubigeo);

            return affected;
        }

        public int ActualizarUbigeo(RegistrarActualizarUbigeoRequestDTO request)
        {
            Ubigeo Ubigeo = _Mapper.Map<Ubigeo>(request);
            Ubigeo.FechaHoraActualizacion = DateTime.Now;
            Ubigeo.UsuarioActualizacion = request.Usuario;

            int affected = _IUbigeoRepository.Actualizar(Ubigeo);

            return affected;
        }

        public ConsultaUbigeoPorIdBE ConsultarUbigeoPorId(ConsultaUbigeoPorIdRequestDTO request)
        {
            return _IUbigeoRepository.ConsultarUbigeoPorId(request.UbigeoId);
        }

        

    }
}
