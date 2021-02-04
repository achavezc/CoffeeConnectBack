using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeConnect.Service
{
    public partial class GuiaRecepcionMateriaPrimaService : IGuiaRecepcionMateriaPrimaService
    {
       
        private IGuiaRecepcionMateriaPrimaRepository _IGuiaRecepcionMateriaPrimaRepository;
       
        public GuiaRecepcionMateriaPrimaService(IGuiaRecepcionMateriaPrimaRepository guiaRecepcionMateriaPrima)
        {
            _IGuiaRecepcionMateriaPrimaRepository = guiaRecepcionMateriaPrima;          
        }
        public List<ConsultaGuiaRecepcionMateriaPrimaBE> ConsultarGuiaRecepcionMateriaPrima(ConsultaGuiaRecepcionMateriaPrimaRequestDTO request)       
        {
            //if (string.IsNullOrEmpty(consultaGuiaRemisionRequestDTO.NumeroDocumento) && string.IsNullOrEmpty(consultaGuiaRemisionRequestDTO.NumeroDocumento))
            //    throw new ResultException(new Result { ErrCode = "-20", Message = "Especifique un Número de BL o Contenedor" });

            if (string.IsNullOrEmpty(request.Numero) && string.IsNullOrEmpty(request.NumeroDocumento) && string.IsNullOrEmpty(request.CodigoSocio) && string.IsNullOrEmpty(request.NombreRazonSocial)) 
                throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.GuiaRecepcionMateriaPrima.ValidacionSeleccioneMinimoUnFiltro.Label" });

          
            var timeSpan = request.FechaFin - request.FechaInicio;

            if(timeSpan.Days>730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Acopio.GuiaRecepcionMateriaPrima.ValidacionRangoFechaMayor2anios.Label" });



            if (string.IsNullOrEmpty(request.Numero) && string.IsNullOrEmpty(request.NumeroDocumento) && string.IsNullOrEmpty(request.CodigoSocio) && string.IsNullOrEmpty(request.NombreRazonSocial))
                throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.GuiaRecepcionMateriaPrima.ValidacionSeleccioneMinimoUnFiltro.Label" });



            var list = _IGuiaRecepcionMateriaPrimaRepository.ConsultarGuiaRecepcionMateriaPrima(request);
            
            return list.ToList();
        }

       
        public int AnularGuiaRecepcionMateriaPrima(AnularGuiaRecepcionMateriaPrimaRequestDTO request)
        {
            int affected = _IGuiaRecepcionMateriaPrimaRepository.AnularGuiaRecepcionMateriaPrima(request.GuiaRecepcionMateriaPrimaId,DateTime.Now,request.Usuario, GuiaRecepcionMateriaPrimaEstados.Anulado);

            return affected;
        }


        public ConsultaGuiaRecepcionMateriaPrimaPorIdBE ConsultarGuiaRecepcionMateriaPrimaPorId(ConsultaGuiaRecepcionMateriaPrimaPorIdRequestDTO request)
        {
            return _IGuiaRecepcionMateriaPrimaRepository.ConsultarGuiaRecepcionMateriaPrimaPorId(request.GuiaRecepcionMateriaPrimaId);            
        }


    }
}
