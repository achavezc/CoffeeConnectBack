using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Service
{
    public class PrecioDiaRendimientoService: IPrecioDiaRendimientoService
    {
        private readonly IMapper _Mapper;
        private IPrecioDiaRendimientoRepository _IPrecioDiaRendimientoRepository;
        private ICorrelativoRepository _ICorrelativoRepository;
        public IOptions<FileServerSettings> _fileServerSettings;

        public PrecioDiaRendimientoService(IPrecioDiaRendimientoRepository PrecioDiaRendimientoRepository, ICorrelativoRepository correlativoRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings)
        {
            _IPrecioDiaRendimientoRepository = PrecioDiaRendimientoRepository;
            _fileServerSettings = fileServerSettings;
            _ICorrelativoRepository = correlativoRepository;
            _Mapper = mapper;
        }

        public int RegistrarPrecioDiaRendimiento(RegistrarActualizarPrecioDiaRendimientoRequestDTO request)
        {
            int id = 0;
            id = _IPrecioDiaRendimientoRepository.RegistrarPrecioDiaRendimiento(request);
            return id;
        }
    }
}
