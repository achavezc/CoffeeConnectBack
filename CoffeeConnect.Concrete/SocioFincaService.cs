
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
    public partial class SocioFincaService : ISocioFincaService
    {
        private readonly IMapper _Mapper;

        private ISocioFincaRepository _ISocioFincaRepository;
      
		


		public SocioFincaService(ISocioFincaRepository socioFincaRepository, IMapper mapper)
        {
            _ISocioFincaRepository = socioFincaRepository;            
			

            _Mapper = mapper;



        }



        //public int RegistrarProductorFinca(RegistrarActualizarProductorFincaRequestDTO request)
        //{
        //    ProductorFinca productorFinca = _Mapper.Map<ProductorFinca>(request);
        //    productorFinca.FechaRegistro = DateTime.Now;
        //    productorFinca.UsuarioRegistro = request.Usuario;
            

        //    int affected = _IProductorRepository.Insertar(productorFinca);

        //    return affected;           
        //}

        //public int ActualizarProductorFinca(RegistrarActualizarProductorFincaRequestDTO request)
        //{
        //    ProductorFinca productorFinca = _Mapper.Map<ProductorFinca>(request);
        //    productorFinca.FechaUltimaActualizacion = DateTime.Now;
        //    productorFinca.UsuarioUltimaActualizacion = request.Usuario;

        //    int affected = _IProductorRepository.Actualizar(productorFinca);

        //    return affected;
        //}

        public IEnumerable<ConsultaSocioFincaPorSocioIdBE> ConsultarSocioFincaPorSocioId(ConsultaSocioFincaPorSocioIdRequestDTO request)
        {
            return _ISocioFincaRepository.ConsultarSocioFincaPorSocioId(request.SocioId);
        }

        public ConsultaSocioFincaPorIdBE ConsultarSocioFincaPorId(ConsultaSocioFincaPorIdRequestDTO request)
        {
            return _ISocioFincaRepository.ConsultarSocioFincaPorId(request.SocioFincaId);
        }

    }
}   
