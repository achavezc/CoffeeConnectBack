
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
    public partial class NotaIngresoProductoTerminadoAlmacenPlantaService : INotaIngresoProductoTerminadoAlmacenPlantaService
    {
        private readonly IMapper _Mapper;
        private INotaIngresoProductoTerminadoAlmacenPlantaRepository _INotaIngresoProductoTerminadoAlmacenPlantaRepository;


        private ICorrelativoRepository _ICorrelativoRepository;

        public IOptions<ParametrosSettings> _ParametrosSettings;

        private IMaestroRepository _IMaestroRepository;

        public NotaIngresoProductoTerminadoAlmacenPlantaService(INotaIngresoProductoTerminadoAlmacenPlantaRepository NotaIngresoProductoTerminadoAlmacenPlanta, ICorrelativoRepository correlativoRepository,

            IOptions<ParametrosSettings> parametrosSettings, IMapper mapper, IMaestroRepository maestroRepository)
        {
            _INotaIngresoProductoTerminadoAlmacenPlantaRepository = NotaIngresoProductoTerminadoAlmacenPlanta;
            _ICorrelativoRepository = correlativoRepository;
            _ParametrosSettings = parametrosSettings;
            _Mapper = mapper;
            _IMaestroRepository = maestroRepository;
        }

        public List<ConsultaNotaIngresoProductoTerminadoAlmacenPlantaBE> ConsultarNotaIngresoProductoTerminadoAlmacenPlanta(ConsultaNotaIngresoProductoTerminadoAlmacenPlantaRequestDTO request)
        {

            var list = _INotaIngresoProductoTerminadoAlmacenPlantaRepository.ConsultarNotaIngresoProductoTerminadoAlmacenPlanta(request);

            return list.ToList();

        }

        public int AnularNotaIngresoProductoTerminadoAlmacenPlanta(AnularNotaIngresoProductoTerminadoAlmacenPlantaRequestDTO request)
        {
            int affected = _INotaIngresoProductoTerminadoAlmacenPlantaRepository.ActualizarEstado(request.NotaIngresoProductoTerminadoAlmacenPlantaId, DateTime.Now, request.Usuario, NotaIngresoProductoTerminadoAlmacenPlantaEstados.Anulado);

            return affected;
        }

        public ConsultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE ConsultarNotaIngresoProductoTerminadoAlmacenPlantaPorId(ConsultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdRequestDTO request)
        {
            int NotaIngresoProductoTerminadoAlmacenPlantaId = request.NotaIngresoProductoTerminadoAlmacenPlantaId;

            ConsultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE consultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE = _INotaIngresoProductoTerminadoAlmacenPlantaRepository.ConsultarNotaIngresoProductoTerminadoAlmacenPlantaPorId(request.NotaIngresoProductoTerminadoAlmacenPlantaId);



            return consultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE;

        }

        public int RegistrarNotaIngresoProductoTerminadoAlmacenPlanta(RegistrarActualizarNotaIngresoProductoTerminadoAlmacenPlantaRequestDTO request)
        {
            NotaIngresoProductoTerminadoAlmacenPlanta NotaIngresoProductoTerminadoAlmacenPlanta = _Mapper.Map<NotaIngresoProductoTerminadoAlmacenPlanta>(request);


            NotaIngresoProductoTerminadoAlmacenPlanta.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.NotaIngresoProductoTerminadoAlmacenPlanta);



            NotaIngresoProductoTerminadoAlmacenPlanta.EstadoId = NotaIngresoProductoTerminadoAlmacenPlantaEstados.Ingresado;
            NotaIngresoProductoTerminadoAlmacenPlanta.FechaRegistro = DateTime.Now;
            NotaIngresoProductoTerminadoAlmacenPlanta.UsuarioRegistro = request.Usuario;

            int notaIngresoProductoTerminadoAlmacenPlantaId = _INotaIngresoProductoTerminadoAlmacenPlantaRepository.Insertar(NotaIngresoProductoTerminadoAlmacenPlanta);

            return notaIngresoProductoTerminadoAlmacenPlantaId;
        }

        public int ActualizarNotaIngresoProductoTerminadoAlmacenPlanta(RegistrarActualizarNotaIngresoProductoTerminadoAlmacenPlantaRequestDTO request)
        {
            NotaIngresoProductoTerminadoAlmacenPlanta NotaIngresoProductoTerminadoAlmacenPlanta = _Mapper.Map<NotaIngresoProductoTerminadoAlmacenPlanta>(request);


            NotaIngresoProductoTerminadoAlmacenPlanta.FechaUltimaActualizacion = DateTime.Now;
            NotaIngresoProductoTerminadoAlmacenPlanta.UsuarioUltimaActualizacion = request.Usuario;


            int affected = _INotaIngresoProductoTerminadoAlmacenPlantaRepository.Actualizar(NotaIngresoProductoTerminadoAlmacenPlanta);


            return affected;
        }
 
    }
}
