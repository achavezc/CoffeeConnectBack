
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
            throw new NotImplementedException();
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
            return _IInspeccionInternaRepository.ConsultarInspeccionInternaPorId(request.InspeccionInternaId);
        }

    }
}
