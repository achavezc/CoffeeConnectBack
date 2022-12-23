using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adjunto;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using CoffeeConnect.Service.Adjunto;
using Core.Common.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CoffeeConnect.Service
{
    public partial class PagoServicioPlantaService : IPagoServicioPlantaService
    {
        private readonly IMapper _Mapper;
        private IPagoServicioPlantaRepository _IPagoServicioPlantaRepository;
        public IOptions<FileServerSettings> _fileServerSettings;
        private ICorrelativoRepository _ICorrelativoRepository;
        private IMaestroRepository _IMaestroRepository;
      




        public PagoServicioPlantaService(IPagoServicioPlantaRepository PagoServicioPlantaRepository,ICorrelativoRepository correlativoRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings, IMaestroRepository maestroRepository)
        {
            _IPagoServicioPlantaRepository = PagoServicioPlantaRepository;
            
            _Mapper = mapper;
            _fileServerSettings = fileServerSettings;
            _ICorrelativoRepository = correlativoRepository;
            _IMaestroRepository = maestroRepository;
        }

        public List<ConsultaPagoServicioPlantaBE> ConsultarPagoServicioPlanta(ConsultaPagoServicioPlantaRequestDTO request)
        {
            var list = _IPagoServicioPlantaRepository.ConsultarPagoServicioPlanta(request);            

            return list.ToList();
        }

       
    }
}
