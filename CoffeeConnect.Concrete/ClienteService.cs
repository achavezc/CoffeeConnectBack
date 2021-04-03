
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
    public partial class ClienteService : IClienteService
    {
        private readonly IMapper _Mapper;

        private IClienteRepository _IClienteRepository;
      
		private ICorrelativoRepository _ICorrelativoRepository;


		public ClienteService(IClienteRepository clienteRepository, ICorrelativoRepository correlativoRepository, IMapper mapper)
        {
            _IClienteRepository = clienteRepository;
            
			_ICorrelativoRepository = correlativoRepository;

            _Mapper = mapper;



        }


        public List<ConsultaClienteBE> ConsultarCliente(ConsultaClienteRequestDTO request)
		{
			//if (string.IsNullOrEmpty(request.Numero) && string.IsNullOrEmpty(request.NumeroDocumento) && string.IsNullOrEmpty(request.NombreRazonSocial))
			//	throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.NotaCompra.ValidacionSeleccioneMinimoUnFiltro.Label" });


			var timeSpan = request.FechaFin - request.FechaInicio;

			if (timeSpan.Days > 730)
				throw new ResultException(new Result { ErrCode = "02", Message = "Acopio.NotaCompra.ValidacionRangoFechaMayor2anios.Label" });



			var list = _IClienteRepository.ConsultarCliente(request);

			return list.ToList();
		}

        //public int RegistrarProductor(RegistrarActualizarProductorRequestDTO request)
        //{
        //    Productor productor = _Mapper.Map<Productor>(request);
        //    productor.FechaRegistro = DateTime.Now;
        //    productor.UsuarioRegistro = request.Usuario;
        //    productor.Numero = _ICorrelativoRepository.Obtener(null, Documentos.Productor);

        //    int affected = _IProductorRepository.Insertar(productor);

        //    return affected;           
        //}

        //public int ActualizarProductor(RegistrarActualizarProductorRequestDTO request)
        //{
        //    Productor productor = _Mapper.Map<Productor>(request);
        //    productor.FechaUltimaActualizacion = DateTime.Now;
        //    productor.UsuarioUltimaActualizacion = request.Usuario;

        //    int affected = _IProductorRepository.Actualizar(productor);

        //    return affected;
        //}

        //public ConsultaProductorIdBE ConsultarProductorId(ConsultaProductorIdRequestDTO request)
        //{
        //    return _IProductorRepository.ConsultarProductorId(request.ProductorId);
        //}

    }
}   
