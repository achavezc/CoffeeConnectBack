using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using Core.Common.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeConnect.Service
{
    public partial class MaestroService : IMaestroService
    {
       
        private IMaestroRepository _IMaestroRepository;
       
        public MaestroService(IMaestroRepository maestroRepository)
        {
            _IMaestroRepository = maestroRepository;          
        }
        public List<ConsultaDetalleTablaBE> ConsultarDetalleTablaDeTablas(int empresaId)       
        {            
            var lista = _IMaestroRepository.ConsultarDetalleTablaDeTablas(empresaId);
            
            return lista.ToList();
        }


        

        
    }
}
