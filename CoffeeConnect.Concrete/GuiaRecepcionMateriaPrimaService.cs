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
        public List<ConsultaGuiaRecepcionMateriaPrimaBE> ConsultarGuiaRecepcionMateriaPrima(ConsultaGuiaRecepcionMateriaPrimaRequestDTO consultaGuiaRecepcionMateriaPrimaRequestDTO)       
        {
            //if (string.IsNullOrEmpty(consultaGuiaRemisionRequestDTO.NumeroDocumento) && string.IsNullOrEmpty(consultaGuiaRemisionRequestDTO.NumeroDocumento))
            //    throw new ResultException(new Result { ErrCode = "-20", Message = "Especifique un Número de BL o Contenedor" });

            var guiaGuiaRecepcionMateriaPrimaList = _IGuiaRecepcionMateriaPrimaRepository.ConsultarGuiaRecepcionMateriaPrima(consultaGuiaRecepcionMateriaPrimaRequestDTO);
            
            return guiaGuiaRecepcionMateriaPrimaList.ToList();
        }

       
        public int AnularGuiaRecepcionMateriaPrima(AnularGuiaRecepcionMateriaPrimaRequestDTO request)
        {
            int affected = _IGuiaRecepcionMateriaPrimaRepository.AnularGuiaRecepcionMateriaPrima(request.GuiaRecepcionMateriaPrimaId,DateTime.Now,request.Usuario, GuiaRecepcionMateriaPrimaEstados.Anulado);

            return affected;
        }


    }
}
