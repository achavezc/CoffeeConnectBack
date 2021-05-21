
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
    public partial class ProductoPrecioDiaService : IProductoPrecioDiaService
    {
        private readonly IMapper _Mapper;

        private IProductoPrecioDiaRepository _IProductoPrecioDiaRepository;

        private ICorrelativoRepository _ICorrelativoRepository;

        public ProductoPrecioDiaService(IProductoPrecioDiaRepository ProductoPrecioDiaRepository, ICorrelativoRepository correlativoRepository, IMapper mapper)
        {
            _IProductoPrecioDiaRepository = ProductoPrecioDiaRepository;

            _ICorrelativoRepository = correlativoRepository;

            _Mapper = mapper;



        }

        public List<ConsultaProductoPrecioDiaBE> ConsultarProductoPrecioDia(ConsultaProductoPrecioDiaRequestDTO request)
        {
            //if (string.IsNullOrEmpty(request.Numero) && string.IsNullOrEmpty(request.Ruc) && string.IsNullOrEmpty(request.RazonSocial))
            //    throw new ResultException(new Result { ErrCode = "01", Message = "Comercial.ProductoPrecioDia.ValidacionSeleccioneMinimoUnFiltro.Label" });


            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Comercial.ProductoPrecioDia.ValidacionRangoFechaMayor2anios.Label" });



            var list = _IProductoPrecioDiaRepository.ConsultarProductoPrecioDia(request);

            return list.ToList();
        }

        public int RegistrarProductoPrecioDia(RegistrarActualizarProductoPrecioDiaRequestDTO request)
        {
            ProductoPrecioDia ProductoPrecioDia = _Mapper.Map<ProductoPrecioDia>(request);
            ProductoPrecioDia.FechaRegistro = DateTime.Now;
            ProductoPrecioDia.UsuarioRegistro = request.Usuario;
           

            int affected = _IProductoPrecioDiaRepository.Insertar(ProductoPrecioDia);

            return affected;
        }

        public int ActualizarProductoPrecioDia(RegistrarActualizarProductoPrecioDiaRequestDTO request)
        {
            ProductoPrecioDia ProductoPrecioDia = _Mapper.Map<ProductoPrecioDia>(request);
            ProductoPrecioDia.FechaUltimaActualizacion = DateTime.Now;
            ProductoPrecioDia.UsuarioUltimaActualizacion = request.Usuario;

            int affected = _IProductoPrecioDiaRepository.Actualizar(ProductoPrecioDia);

            return affected;
        }

        public ConsultaProductoPrecioDiaPorIdBE ConsultarProductoPrecioDiaPorId(ConsultaProductoPrecioDiaPorIdRequestDTO request)
        {
            return _IProductoPrecioDiaRepository.ConsultarProductoPrecioDiaPorId(request.ProductoPrecioDiaId);
        }

    }
}
