using AutoMapper;
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

        private readonly IMapper _Mapper;
        public CorrelativoPlantaService(ICorrelativoRepository correlativoRepository, IMapper mapper)
        {
           
            _ICorrelativoRepository = correlativoRepository;
            _Mapper = mapper;
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
            var list = listCorrelativos.Select(o => o.Campanha).Distinct();
            
            foreach (var obj in list)
            {
                result.Add(new ConsultaDetalleTablaBE
                {
                    Codigo = obj,
                    Label = obj
                });
            }

            return result;


        }

        public List<ConsultaDetalleTablaBE> obtenerTipo()

        {
            List<ConsultaDetalleTablaBE> result = new List<ConsultaDetalleTablaBE>();
            List<CorrelativoPlanta> listCorrelativos = new List<CorrelativoPlanta>();
            listCorrelativos = _ICorrelativoRepository.ObtenerTipoCorrelativoPlanta().ToList();
          
            foreach (var obj in listCorrelativos)
            {
                result.Add(new ConsultaDetalleTablaBE
                {
                    Codigo = obj.CodigoTipo,
                    Label = obj.Tipo
                });
            }

            return result;


        }

        /////Creando el service para correlativos 

        public List<CorrelativoPlantaBE> ConsultarCorrelativo(ConsultaCorrelativoPlantaRequestDTO request)
        {
            var lista = _ICorrelativoRepository.ConsultarCorrelativo(request);

            return lista.ToList();
        }

        public int RegistrarCorrelativo(RegistrarActualizarCorrelativoPlantaRequestDTO request)
        {
            CorrelativoPlanta correlativo = _Mapper.Map<CorrelativoPlanta>(request);
            correlativo.CorrelativoPlantaId = request.CorrelativoPlantaId;
            correlativo.Campanha = request.Campanha;
            correlativo.CodigoTipo = request.CodigoTipo;
            correlativo.CodigoTipoConcepto = request.CodigoTipoConcepto;
            correlativo.CantidadDigitosPlanta = request.CantidadDigitosPlanta;
            correlativo.Prefijo = request.Prefijo;
            correlativo.Contador = request.Contador;
            correlativo.Tipo = request.Tipo;
            correlativo.Concepto = request.Concepto;
            correlativo.Activo = request.Activo;


            int affected = _ICorrelativoRepository.InsertarCorrelativo(correlativo);

            return affected;
        }
        public int ActualizarCorrelativoPlanta(RegistrarActualizarCorrelativoPlantaRequestDTO request)
        {
            CorrelativoPlanta correlativoActualizar = _Mapper.Map<CorrelativoPlanta>(request);
            correlativoActualizar.CorrelativoPlantaId = request.CorrelativoPlantaId;
            correlativoActualizar.Campanha = request.Campanha;
            correlativoActualizar.CodigoTipo = request.CodigoTipo;
            correlativoActualizar.CodigoTipoConcepto = request.CodigoTipoConcepto;
            correlativoActualizar.CantidadDigitosPlanta = request.CantidadDigitosPlanta;
            correlativoActualizar.Prefijo = request.Prefijo;
            correlativoActualizar.Contador = request.Contador;
            correlativoActualizar.Tipo = request.Tipo;
            correlativoActualizar.Concepto = request.Concepto;
            correlativoActualizar.Activo = request.Activo;


            int affected = _ICorrelativoRepository.ActualizarCorrelativo(correlativoActualizar);

            return affected;
        }

        public CorrelativoPlantaBE ConsultarCorrelativoPlantaPorId(ConsultaCorrelativoPlantaPorIdRequestDTO request)
        {
            return _ICorrelativoRepository.ConsultarCorrelativoPlantaPorId(request.CorrelativoPlantaId);
        }

        ////
    }
}
