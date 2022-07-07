using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeConnect.Service
{
    public class CorrelativoPlantaService : ICorrelativoPlantaService
    {

        private ICorrelativoRepository _ICorrelativoRepository;

        public CorrelativoPlantaService(ICorrelativoRepository correlativoRepository)
        {
           
            _ICorrelativoRepository = correlativoRepository;
        }


        public List<ConsultaDetalleTablaBE> obtenerConceptos(string codigoTipo)

        { 
            List<ConsultaDetalleTablaBE> result = new List<ConsultaDetalleTablaBE>();
            List<CorrelativoPlanta> listCorrelativos = new List<CorrelativoPlanta> ();
            listCorrelativos = _ICorrelativoRepository.ObtenerCorrelativoPlanta(codigoTipo).ToList();

            foreach(var obj in listCorrelativos)
            {
                result.Add(new ConsultaDetalleTablaBE
                {
                    Codigo = obj.CodigoTipoConcepto,
                    Label = obj.Concepto
                }) ;
            }

            return result;

         }
        public List<ConsultaDetalleTablaBE> obtenerCampanias(string codigoTipo)

        {
            List<ConsultaDetalleTablaBE> result = new List<ConsultaDetalleTablaBE>();
            List<CorrelativoPlanta> listCorrelativos = new List<CorrelativoPlanta>();
            listCorrelativos = _ICorrelativoRepository.ObtenerCorrelativoPlanta(codigoTipo).ToList();
            listCorrelativos.Select(o => o.Campanha).Distinct().ToList();
            foreach (var obj in listCorrelativos)
            {
                result.Add(new ConsultaDetalleTablaBE
                {
                    Codigo = obj.Campanha,
                    Label = obj.Campanha
                });
            }

            return result;


        }
    }
}
