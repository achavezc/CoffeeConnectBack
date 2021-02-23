
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
    public partial class ProductorService : IProductorService
	{
       
        private IProductorRepository _IProductorRepository;
      
		private ICorrelativoRepository _ICorrelativoRepository;


		public ProductorService(IProductorRepository productorRepository, ICorrelativoRepository correlativoRepository)
        {
			_IProductorRepository = productorRepository;
            
			_ICorrelativoRepository = correlativoRepository;
		}

		


		public List<ConsultaProductorBE> ConsultarProductor(ConsultaProductorRequestDTO request)
		{
			if (string.IsNullOrEmpty(request.Numero) && string.IsNullOrEmpty(request.NumeroDocumento) && string.IsNullOrEmpty(request.NombreRazonSocial))
				throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.NotaCompra.ValidacionSeleccioneMinimoUnFiltro.Label" });


			var timeSpan = request.FechaFin - request.FechaInicio;

			if (timeSpan.Days > 730)
				throw new ResultException(new Result { ErrCode = "02", Message = "Acopio.NotaCompra.ValidacionRangoFechaMayor2anios.Label" });



			var list = _IProductorRepository.ConsultarProductor(request);

			return list.ToList();
		}

		
	}
}
