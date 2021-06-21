
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
    public partial class DetalleCatalogoService : IDetalleCatalogoService
    {
        private readonly IMapper _Mapper;
        private IDetalleCatalogoRepository _IDetalleCatalogoRepository;
        private ICorrelativoRepository _ICorrelativoRepository;

        public DetalleCatalogoService(IDetalleCatalogoRepository DetalleCatalogoRepository, ICorrelativoRepository correlativoRepository, IMapper mapper)
        {
            _IDetalleCatalogoRepository = DetalleCatalogoRepository;

            _ICorrelativoRepository = correlativoRepository;

            _Mapper = mapper;



        }

        public List<ConsultaDetalleCatalogoBE> ConsultarDetalleCatalogo(ConsultaDetalleCatalogoRequestDTO request)
        {
           
            var list = _IDetalleCatalogoRepository.ConsultarDetalleCatalogo(request);
            return list.ToList();
        }

        public int RegistrarDetalleCatalogo(RegistrarActualizarDetalleCatalogoRequestDTO request)
        {
            DetalleCatalogo DetalleCatalogo = _Mapper.Map<DetalleCatalogo>(request);
            DetalleCatalogo.FechaHoraCreacion = DateTime.Now;
            DetalleCatalogo.UsuarioCreacion = request.Usuario;
           

            int affected = _IDetalleCatalogoRepository.Insertar(DetalleCatalogo);

            return affected;
        }

        public int ActualizarDetalleCatalogo(RegistrarActualizarDetalleCatalogoRequestDTO request)
        {
            DetalleCatalogo DetalleCatalogo = _Mapper.Map<DetalleCatalogo>(request);
            DetalleCatalogo.FechaHoraActualizacion = DateTime.Now;
            DetalleCatalogo.UsuarioActualizacion = request.Usuario;

            int affected = _IDetalleCatalogoRepository.Actualizar(DetalleCatalogo);

            return affected;
        }

        public ConsultaDetalleCatalogoPorIdBE ConsultarDetalleCatalogoPorId(ConsultaDetalleCatalogoPorIdRequestDTO request)
        {
            return _IDetalleCatalogoRepository.ConsultarDetalleCatalogoPorId(request.DetalleCatalogoId);
        }


        public List<ConsultaCatalogoTablasBE> ConsultarCatalogoTablas(ConsultaCatalogoTablasRequestDTO request)
        {

            var list = _IDetalleCatalogoRepository.ConsultarCatalogoTablas();
            return list.ToList();
        }


    }
}
