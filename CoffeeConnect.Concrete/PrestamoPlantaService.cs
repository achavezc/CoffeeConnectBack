
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
    public partial class PrestamoPlantaService : IPrestamoPlantaService
    {
        private readonly IMapper _Mapper;
        private IPrestamoPlantaRepository _IPrestamoPlantaRepository;


        private ICorrelativoRepository _ICorrelativoRepository;

        public IOptions<ParametrosSettings> _ParametrosSettings;

        private IMaestroRepository _IMaestroRepository;

        public PrestamoPlantaService(IPrestamoPlantaRepository PrestamoPlanta, ICorrelativoRepository correlativoRepository,

            IOptions<ParametrosSettings> parametrosSettings, IMapper mapper, IMaestroRepository maestroRepository)
        {
            _IPrestamoPlantaRepository = PrestamoPlanta;
            _ICorrelativoRepository = correlativoRepository;
            _ParametrosSettings = parametrosSettings;
            _Mapper = mapper;
            _IMaestroRepository = maestroRepository;
        }

        public List<ConsultaPrestamoPlantaBE> ConsultarPrestamoPlanta(ConsultaPrestamoPlantaRequestDTO request)
        {

            var list = _IPrestamoPlantaRepository.ConsultarPrestamoPlanta(request);

            return list.ToList();

        }

        //public int AnularPrestamoPlanta(AnularPrestamoPlantaRequestDTO request)
        //{
        //    int affected = _IPrestamoPlantaRepository.ActualizarEstado(request.PrestamoPlantaId, DateTime.Now, request.Usuario, PrestamoPlantaEstados.Anulado);

        //    return affected;
        //}

        public ConsultaPrestamoPlantaPorIdBE ConsultarPrestamoPlantaPorId(ConsultaPrestamoPlantaPorIdRequestDTO request)
        {
             

            ConsultaPrestamoPlantaPorIdBE consultaPrestamoPlantaPorIdBE = _IPrestamoPlantaRepository.ConsultarPrestamoPlantaPorId(request.PrestamoPlantaId);



            return consultaPrestamoPlantaPorIdBE;

        }

        public int RegistrarPrestamoPlanta(RegistrarActualizarPrestamoPlantaRequestDTO request)
        {
            PrestamoPlanta PrestamoPlanta = _Mapper.Map<PrestamoPlanta>(request);


            PrestamoPlanta.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.PrestamoPlanta);



            PrestamoPlanta.EstadoId = PrestamoPlantaEstados.Deuda;
            PrestamoPlanta.FechaRegistro = DateTime.Now;
            PrestamoPlanta.UsuarioRegistro = request.Usuario;

            int PrestamoPlantaId = _IPrestamoPlantaRepository.InsertarPrestamoPlanta(PrestamoPlanta);

            return PrestamoPlantaId;
        }

        public int ActualizarPrestamoPlanta(RegistrarActualizarPrestamoPlantaRequestDTO request)
        {

            PrestamoPlanta PrestamoPlanta = _Mapper.Map<PrestamoPlanta>(request);
            PrestamoPlanta.FechaUltimaActualizacion = DateTime.Now;
            PrestamoPlanta.UsuarioUltimaActualizacion = request.Usuario;

            int affected = _IPrestamoPlantaRepository.Actualizar(PrestamoPlanta);


            return affected;
        }

        public int AnularPrestamoPlanta(PrestamoPlantaAnularRequestDTO request)
        {
            int affected = _IPrestamoPlantaRepository.ActualizarPrestamoPlantaEstado(request.PrestamoPlantaId, DateTime.Now, request.Usuario, PrestamoPlantaEstados.Anulado);

            

            return affected;
        }


    }
}
