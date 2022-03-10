using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Anticipo;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using Core.Common.Domain.Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeConnect.Service
{
    public class AnticipoService : IAnticipoService
    {
        private readonly IMapper _Mapper;
        private IAnticipoRepository _IAnticipoRepository;
        private ICorrelativoRepository _ICorrelativoRepository;
        public IOptions<FileServerSettings> _fileServerSettings;

        public AnticipoService(IAnticipoRepository AnticipoRepository, ICorrelativoRepository correlativoRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings)
        {
            _IAnticipoRepository = AnticipoRepository;
            _fileServerSettings = fileServerSettings;
            _ICorrelativoRepository = correlativoRepository;
            _Mapper = mapper;
        }

        public List<ConsultaAnticipoBE> ConsultarAnticipo(ConsultaAnticipoRequestDTO request)
        {
            if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFin == null || request.FechaFin == DateTime.MinValue || string.IsNullOrEmpty(request.EstadoId))
                throw new ResultException(new Result { ErrCode = "01", Message = "Comercial.Cliente.ValidacionSeleccioneMinimoUnFiltro.Label" });

            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Comercial.Aduana.ValidacionRangoFechaMayor2anios.Label" });

            var list = _IAnticipoRepository.ConsultarAnticipo(request);
            return list.ToList();
        }

        public GenerarPDFAnticipoResponseDTO GenerarPDF(int id)
        {
            GenerarPDFAnticipoResponseDTO response = new GenerarPDFAnticipoResponseDTO();
            response.resultado = _IAnticipoRepository.GenerarPDF(id).ToList();
            return response;
        }

        public int RegistrarAnticipo(RegistrarActualizarAnticipoRequestDTO request)
        {
            Anticipo Anticipo = _Mapper.Map<Anticipo>(request);
            Anticipo.FechaRegistro = DateTime.Now;
            //Aduana.NombreArchivo = file.FileName;
            Anticipo.UsuarioRegistro = request.UsuarioRegistro;
            Anticipo.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.Anticipo);

            int id = _IAnticipoRepository.Insertar(Anticipo);

            return id;
        }
        public int ActualizarAnticipo(RegistrarActualizarAnticipoRequestDTO request)
        {
            Anticipo Anticipo = _Mapper.Map<Anticipo>(request);


            Anticipo.FechaUltimaActualizacion = DateTime.Now;
            Anticipo.UsuarioUltimaActualizacion = request.UsuarioUltimaActualizacion;
     
            int affected = _IAnticipoRepository.Actualizar(Anticipo);

            return affected;
        }

        public ConsultaAnticipoPorIdBE ConsultarAnticipoPorId(ConsultaAnticipoPorIdRequestDTO request)
        {
            ConsultaAnticipoPorIdBE consultaAnticipoPorIdBE = _IAnticipoRepository.ConsultarAnticipoPorId(request.AnticipoId);


            return consultaAnticipoPorIdBE;
        }

        public int AnularAnticipo(AnularAnticipoRequestDTO request)
        {
            int result = 0;
            if (request.AnticipoId > 0)
            {

                result = _IAnticipoRepository.Anular(request.AnticipoId, DateTime.Now, request.Usuario, AnticipoEstados.Anulado);
            }
            return result;
        }


        public int AsociarAnticipo(AsociarAnticipoRequestDTO request)
        {
            int result = 0;
            if (request.AnticipoId > 0)
            {
                request.NotasIngresoPlantaId.ForEach(z =>
                {   
                    result = _IAnticipoRepository.AsociarNotaIngresoPlanta(request.AnticipoId, z.Id, DateTime.Now, request.Usuario);
                });
            }
            return result;
        }
    }
}
