using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adelanto;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using Core.Common.Domain.Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeConnect.Service
{
    public class AdelantoService : IAdelantoService
    {
        private readonly IMapper _Mapper;
        private IAdelantoRepository _IAdelantoRepository;
        private ICorrelativoRepository _ICorrelativoRepository;
        public IOptions<FileServerSettings> _fileServerSettings;

        public AdelantoService(IAdelantoRepository AdelantoRepository, ICorrelativoRepository correlativoRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings)
        {
            _IAdelantoRepository = AdelantoRepository;
            _fileServerSettings = fileServerSettings;
            _ICorrelativoRepository = correlativoRepository;
            _Mapper = mapper;
        }

        public List<ConsultaAdelantoBE> ConsultarAdelanto(ConsultaAdelantoRequestDTO request)
        {
            if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFin == null || request.FechaFin == DateTime.MinValue || string.IsNullOrEmpty(request.EstadoId))
                throw new ResultException(new Result { ErrCode = "01", Message = "Comercial.Cliente.ValidacionSeleccioneMinimoUnFiltro.Label" });

            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Comercial.Aduana.ValidacionRangoFechaMayor2anios.Label" });

            var list = _IAdelantoRepository.ConsultarAdelanto(request);
            return list.ToList();
        }

        public GenerarPDFAdelantoResponseDTO GenerarPDF(int id)
        {
            GenerarPDFAdelantoResponseDTO response = new GenerarPDFAdelantoResponseDTO;
            response.resultado = _IAdelantoRepository.GenerarPDF(id).ToList();
            return response;
        }
    }
}
