
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



        public int RegistrarProductor(RegistrarActualizarProductorRequestDTO request)
        {
            Productor productor = _Mapper.Map<Productor>(request);
            productor.FechaRegistro = DateTime.Now;
            productor.UsuarioRegistro = request.Usuario;
            productor.Numero = _ICorrelativoRepository.Obtener(null, Documentos.Productor);

            int affected = _IProductorRepository.Insertar(productor);

            return affected;           
        }

        public int ActualizarProductor(RegistrarActualizarProductorRequestDTO request)
        {
            Productor productor = _Mapper.Map<Productor>(request);
            productor.FechaUltimaActualizacion = DateTime.Now;
            productor.UsuarioUltimaActualizacion = request.Usuario;

            int affected = _IProductorRepository.Actualizar(productor);

            return affected;
        }

        public IEnumerable<ConsultaProductorFincaProductorIdBE> ConsultarProductorFincaIdProductor(ConsultaProductorFincaProductorIdRequestDTO request)
        {
            return _IProductorRepository.ConsultarProductorFincaIdProductor(request.ProductorId);
        }

    }
}   
