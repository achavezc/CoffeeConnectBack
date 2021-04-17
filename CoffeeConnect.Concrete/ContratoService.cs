
using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adjunto;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using CoffeeConnect.Service.Adjunto;
using Core.Common.Domain.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CoffeeConnect.Service
{
    public partial class ContratoService : IContratoService
    {
        private readonly IMapper _Mapper;

        private IContratoRepository _IContratoRepository;

        private ICorrelativoRepository _ICorrelativoRepository;

        public ContratoService(IContratoRepository contratoRepository, ICorrelativoRepository correlativoRepository, IMapper mapper)
        {
            _IContratoRepository = contratoRepository;

            _ICorrelativoRepository = correlativoRepository;

            _Mapper = mapper;



        }

        public List<ConsultaContratoBE> ConsultarContrato(ConsultaContratoRequestDTO request)
        {
            //if (string.IsNullOrEmpty(request.Numero) && string.IsNullOrEmpty(request.Ruc) && string.IsNullOrEmpty(request.RazonSocial))
            //    throw new ResultException(new Result { ErrCode = "01", Message = "Comercial.Cliente.ValidacionSeleccioneMinimoUnFiltro.Label" });


            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Comercial.Contrato.ValidacionRangoFechaMayor2anios.Label" });



            var list = _IContratoRepository.ConsultarContrato(request);

            return list.ToList();
        }

        public int RegistrarContrato(RegistrarActualizarContratoRequestDTO request, IFormFile file)
        {
            var AdjuntoBl = new AdjuntarArchivosBL();
            byte[] fileBytes = null;
            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);
                    // act on the Base64 data
                }
            } 

            Contrato contrato = _Mapper.Map<Contrato>(request);
            contrato.FechaRegistro = DateTime.Now;
            contrato.NombreArchivo = file.FileName;
            contrato.UsuarioRegistro = request.Usuario;
            contrato.Numero = _ICorrelativoRepository.Obtener(null, Documentos.Contrato);

            //Adjuntos
            ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
            {
                filtros = new AdjuntarArchivosDTO()
                {
                    archivoStream = fileBytes,
                    filename = file.FileName,
                }
            });
            contrato.PathArchivo = response.ficheroReal;

            int affected = _IContratoRepository.Insertar(contrato);

            return affected;
        }

        public int ActualizarContrato(RegistrarActualizarContratoRequestDTO request)
        {
            Contrato contrato = _Mapper.Map<Contrato>(request);
            contrato.FechaUltimaActualizacion = DateTime.Now;
            contrato.UsuarioUltimaActualizacion = request.Usuario;

            int affected = _IContratoRepository.Actualizar(contrato);

            return affected;
        }

        public ConsultaContratoPorIdBE ConsultarContratoPorId(ConsultaContratoPorIdRequestDTO request)
        {
            return _IContratoRepository.ConsultarContratoPorId(request.ContratoId);
        }
    }
}
