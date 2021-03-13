
using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeConnect.Service
{
    public partial class ProductorFincaService : IProductorFincaService
    {
        private readonly IMapper _Mapper;

        private IProductorFincaRepository _IProductorRepository;
      
		private ICorrelativoRepository _ICorrelativoRepository;


		public ProductorFincaService(IProductorFincaRepository productorRepository, ICorrelativoRepository correlativoRepository, IMapper mapper)
        {
			_IProductorRepository = productorRepository;
            
			_ICorrelativoRepository = correlativoRepository;

            _Mapper = mapper;



        }



        public int RegistrarProductorFinca(RegistrarActualizarProductorFincaRequestDTO request)
        {
            ProductorFinca productorFinca = _Mapper.Map<ProductorFinca>(request);
            productorFinca.FechaRegistro = DateTime.Now;
            productorFinca.UsuarioRegistro = request.Usuario;
            

            int affected = _IProductorRepository.Insertar(productorFinca);

            return affected;           
        }

        public int ActualizarProductorFinca(RegistrarActualizarProductorFincaRequestDTO request)
        {
            ProductorFinca productorFinca = _Mapper.Map<ProductorFinca>(request);
            productorFinca.FechaUltimaActualizacion = DateTime.Now;
            productorFinca.UsuarioUltimaActualizacion = request.Usuario;

            int affected = _IProductorRepository.Actualizar(productorFinca);

            return affected;
        }

        public IEnumerable<ConsultaProductorFincaProductorIdBE> ConsultarProductorFincaPorProductorId(ConsultaProductorFincaProductorIdRequestDTO request)
        {
            return _IProductorRepository.ConsultarProductorFincaPorProductorId(request.ProductorId);
        }

        public ConsultaProductorFincaPorIdBE ConsultarProductorFincaPorId(ConsultaProductorFincaPorIdRequestDTO request)
        {
            return _IProductorRepository.ConsultarProductorFincaPorId(request.ProductorFincaId);
        }

    }
}   
