
using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using Core.Common.Domain.Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeConnect.Service
{
    public partial class ServicioPlantaService : IServicioPlantaService
    {
        private readonly IMapper _Mapper;
        private IServicioPlantaRepository _IServicioPlantaRepository;


        private ICorrelativoRepository _ICorrelativoRepository;

        public IOptions<ParametrosSettings> _ParametrosSettings;

        private IMaestroRepository _IMaestroRepository;

        public ServicioPlantaService(IServicioPlantaRepository ServicioPlanta, ICorrelativoRepository correlativoRepository,

            IOptions<ParametrosSettings> parametrosSettings, IMapper mapper, IMaestroRepository maestroRepository)
        {
            _IServicioPlantaRepository = ServicioPlanta;
            _ICorrelativoRepository = correlativoRepository;
            _ParametrosSettings = parametrosSettings;
            _Mapper = mapper;
            _IMaestroRepository = maestroRepository;
        }

        public List<ConsultaServicioPlantaBE> ConsultarServicioPlanta(ConsultaServicioPlantaRequestDTO request)
        {

            var list = _IServicioPlantaRepository.ConsultarServicioPlanta(request);

            return list.ToList();

        }

        //public int AnularServicioPlanta(AnularServicioPlantaRequestDTO request)
        //{
        //    int affected = _IServicioPlantaRepository.ActualizarEstado(request.ServicioPlantaId, DateTime.Now, request.Usuario, ServicioPlantaEstados.Anulado);

        //    return affected;
        //}

        public ConsultaServicioPlantaPorIdBE ConsultarServicioPlantaPorId(ConsultaServicioPlantaPorIdRequestDTO request)
        {
             

            ConsultaServicioPlantaPorIdBE consultaServicioPlantaPorIdBE = _IServicioPlantaRepository.ConsultarServicioPlantaPorId(request.ServicioPlantaId);



            return consultaServicioPlantaPorIdBE;

        }

        public int RegistrarServicioPlanta(RegistrarActualizarServicioPlantaRequestDTO request)
        {
            ServicioPlanta ServicioPlanta = _Mapper.Map<ServicioPlanta>(request);


            ServicioPlanta.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.ServicioPlanta);



            ServicioPlanta.EstadoId = ServicioPlantaEstados.Deuda;
            ServicioPlanta.FechaRegistro = DateTime.Now;
            ServicioPlanta.UsuarioRegistro = request.Usuario;

            int ServicioPlantaId = _IServicioPlantaRepository.InsertarServicioPlanta(ServicioPlanta);

            return ServicioPlantaId;
        }

        //public int ActualizarServicioPlanta(ActualizarServicioPlantaRequestDTO request)
        //{



        //    int affected = _IServicioPlantaRepository.Actualizar(request.ServicioPlantaId,request.AlmacenId, DateTime.Now,request.Usuario);


        //    return affected;
        //}

    }
}
