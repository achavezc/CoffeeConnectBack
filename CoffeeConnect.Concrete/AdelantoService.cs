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
            GenerarPDFAdelantoResponseDTO response = new GenerarPDFAdelantoResponseDTO();
            response.resultado = _IAdelantoRepository.GenerarPDF(id).ToList();
            return response;
        }

        public int RegistrarAdelanto(RegistrarActualizarAdelantoRequestDTO request)
        {
            Adelanto adelanto = _Mapper.Map<Adelanto>(request);
            adelanto.FechaRegistro = DateTime.Now;
            //Aduana.NombreArchivo = file.FileName;
            adelanto.UsuarioRegistro = request.UsuarioRegistro;
            adelanto.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.Adelanto);

            int id = _IAdelantoRepository.Insertar(adelanto);

            return id;
        }
        public int ActualizarAdelanto(RegistrarActualizarAdelantoRequestDTO request)
        {
            Adelanto adelanto = _Mapper.Map<Adelanto>(request);


            adelanto.FechaUltimaActualizacion = DateTime.Now;
            adelanto.UsuarioUltimaActualizacion = request.UsuarioUltimaActualizacion;
     
            int affected = _IAdelantoRepository.Actualizar(adelanto);

            return affected;
        }

        public ConsultaAdelantoPorIdBE ConsultarAdelantoPorId(ConsultaAdelantoPorIdRequestDTO request)
        {
            ConsultaAdelantoPorIdBE consultaAdelantoPorIdBE = _IAdelantoRepository.ConsultarAdelantoPorId(request.AdelantoId);


            return consultaAdelantoPorIdBE;
        }

        public int AnularAdelanto(AnularAdelantoRequestDTO request)
        {
            int result = 0;
            if (request.AdelantoId > 0)
            {

                result = _IAdelantoRepository.Anular(request.AdelantoId, DateTime.Now, request.Usuario, AdelantoEstados.Anulado);
            }
            return result;
        }


        public int AsociarAdelanto(AsociarAdelantoRequestDTO request)
        {
            int result = 0;
            if (request.AdelantoId > 0)
            {
                request.NotasCompraId.ForEach(z =>
                {   
                    result = _IAdelantoRepository.AsociarNotaCompra(request.AdelantoId, z.Id, DateTime.Now, request.Usuario);
                });
            }
            return result;
        }
    }
}
