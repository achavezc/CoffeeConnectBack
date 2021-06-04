
using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeConnect.Service
{
    public partial class InspeccionInternaService : IInspeccionInternaService
    {

        private readonly IMapper _Mapper;

        private IInspeccionInternaRepository _IInspeccionInternaRepository;
        

        private ICorrelativoRepository _ICorrelativoRepository;

        public InspeccionInternaService(IInspeccionInternaRepository inspeccionInternaRepository, ICorrelativoRepository correlativoRepository, IMapper mapper)
        {
            _IInspeccionInternaRepository = inspeccionInternaRepository;          
            _ICorrelativoRepository = correlativoRepository;
            _Mapper = mapper;
        }

        public int ActualizarInspeccionInterna(RegistrarActualizarInspeccionInternaRequestDTO request)
        {
            InspeccionInterna inspeccionInterna = _Mapper.Map<InspeccionInterna>(request);
            inspeccionInterna.FechaUltimaActualizacion = DateTime.Now;
            inspeccionInterna.UsuarioUltimaActualizacion = request.Usuario;

            int affected = _IInspeccionInternaRepository.Actualizar(inspeccionInterna);

            if (request.InspeccionInternaNormaList.FirstOrDefault() != null)
            {
                request.InspeccionInternaNormaList.ForEach(z =>
                {
                    z.InspeccionInternaId = request.InspeccionInternaId;
                });

                _IInspeccionInternaRepository.ActualizarInspeccionInternaNormas(request.InspeccionInternaNormaList, request.InspeccionInternaId);
            }

            if (request.InspeccionInternaParcelaList.FirstOrDefault() != null)
            {
                request.InspeccionInternaParcelaList.ForEach(z =>
                {
                    z.InspeccionInternaId = request.InspeccionInternaId;
                });

                _IInspeccionInternaRepository.ActualizarInspeccionInternaParcela(request.InspeccionInternaParcelaList, request.InspeccionInternaId);
            }

            if (request.InspeccionInternaLevantamientoNoConformidadList.FirstOrDefault() != null)
            {
                request.InspeccionInternaLevantamientoNoConformidadList.ForEach(z =>
                {
                    z.InspeccionInternaId = request.InspeccionInternaId;
                });

                _IInspeccionInternaRepository.ActualizarInspeccionInternaLevantamientoNoConformidad(request.InspeccionInternaLevantamientoNoConformidadList, request.InspeccionInternaId);
            }

            if (request.InspeccionInternaNoConformidadList.FirstOrDefault() != null)
            {
                request.InspeccionInternaNoConformidadList.ForEach(z =>
                {
                    z.InspeccionInternaId = request.InspeccionInternaId;
                });

                _IInspeccionInternaRepository.ActualizarInspeccionInternaNoConformidad(request.InspeccionInternaNoConformidadList, request.InspeccionInternaId);
            }

            return affected;
        }

       

        public int RegistrarInspeccionInterna(RegistrarActualizarInspeccionInternaRequestDTO request)
        {
            InspeccionInterna inspeccionInterna = _Mapper.Map<InspeccionInterna>(request);
            inspeccionInterna.FechaRegistro = DateTime.Now;
            inspeccionInterna.UsuarioRegistro = request.Usuario;
            inspeccionInterna.Numero = _ICorrelativoRepository.Obtener(null, Documentos.InspeccionInterna);


            int inspeccionInternaId = _IInspeccionInternaRepository.Insertar(inspeccionInterna);

            if (request.InspeccionInternaNormaList.FirstOrDefault() != null)
            {                
                request.InspeccionInternaNormaList.ForEach(z =>
                {
                    z.InspeccionInternaId = inspeccionInternaId;
                });

               _IInspeccionInternaRepository.ActualizarInspeccionInternaNormas(request.InspeccionInternaNormaList, inspeccionInternaId);
            }

            if (request.InspeccionInternaParcelaList.FirstOrDefault() != null)
            {
                request.InspeccionInternaParcelaList.ForEach(z =>
                {
                    z.InspeccionInternaId = inspeccionInternaId;
                });

                _IInspeccionInternaRepository.ActualizarInspeccionInternaParcela(request.InspeccionInternaParcelaList, inspeccionInternaId);
            }

            if (request.InspeccionInternaLevantamientoNoConformidadList.FirstOrDefault() != null)
            {
                request.InspeccionInternaLevantamientoNoConformidadList.ForEach(z =>
                {
                    z.InspeccionInternaId = inspeccionInternaId;
                });

                _IInspeccionInternaRepository.ActualizarInspeccionInternaLevantamientoNoConformidad(request.InspeccionInternaLevantamientoNoConformidadList, inspeccionInternaId);
            }

            if (request.InspeccionInternaNoConformidadList.FirstOrDefault() != null)
            {
                request.InspeccionInternaNoConformidadList.ForEach(z =>
                {
                    z.InspeccionInternaId = inspeccionInternaId;
                });

                _IInspeccionInternaRepository.ActualizarInspeccionInternaNoConformidad(request.InspeccionInternaNoConformidadList, inspeccionInternaId);
            }



            return inspeccionInternaId;
        }

        public List<ConsultaInspeccionInternaBE> ConsultarInspeccionInterna(ConsultaInspeccionInternaRequestDTO request)
        {
            //if (string.IsNullOrEmpty(request.Numero) && string.IsNullOrEmpty(request.Ruc) && string.IsNullOrEmpty(request.RazonSocial))
            //    throw new ResultException(new Result { ErrCode = "01", Message = "Comercial.InspeccionInterna.ValidacionSeleccioneMinimoUnFiltro.Label" });


            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Comercial.InspeccionInterna.ValidacionRangoFechaMayor2anios.Label" });



            var list = _IInspeccionInternaRepository.ConsultarInspeccionInterna(request);

            return list.ToList();
        }

        public ConsultaInspeccionInternaPorIdBE ConsultarInspeccionInternaPorId(ConsultaInspeccionInternaPorIdRequestDTO request)
        {
            ConsultaInspeccionInternaPorIdBE consultaInspeccionInternaPorIdBE = _IInspeccionInternaRepository.ConsultarInspeccionInternaPorId(request.InspeccionInternaId);



            consultaInspeccionInternaPorIdBE.InspeccionInternaParcela = _IInspeccionInternaRepository.ConsultarInspeccionInternaParcelaPorId(request.InspeccionInternaId).ToList();
            consultaInspeccionInternaPorIdBE.InspeccionInternaNoConformidad = _IInspeccionInternaRepository.ConsultarInspeccionInternaNoConformidadPorId(request.InspeccionInternaId).ToList();
            consultaInspeccionInternaPorIdBE.InspeccionInternaLevantamientoNoConformidad = _IInspeccionInternaRepository.ConsultarInspeccionInternaLevantamientoNoConformidadPorId(request.InspeccionInternaId).ToList();
            consultaInspeccionInternaPorIdBE.InspeccionInternaNorma = _IInspeccionInternaRepository.ConsultarInspeccionInternaNormasPorId(request.InspeccionInternaId).ToList();

            return consultaInspeccionInternaPorIdBE;
        }

    }
}
