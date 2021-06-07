
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
    public partial class DiagnosticoService : IDiagnosticoService
    {

        private readonly IMapper _Mapper;

        private IDiagnosticoRepository _IDiagnosticoRepository;
        

        private ICorrelativoRepository _ICorrelativoRepository;

        public DiagnosticoService(IDiagnosticoRepository DiagnosticoRepository, ICorrelativoRepository correlativoRepository, IMapper mapper)
        {
            _IDiagnosticoRepository = DiagnosticoRepository;          
            _ICorrelativoRepository = correlativoRepository;
            _Mapper = mapper;
        }

        public int ActualizarDiagnostico(RegistrarActualizarDiagnosticoRequestDTO request)
        {
            Diagnostico Diagnostico = _Mapper.Map<Diagnostico>(request);
            Diagnostico.FechaUltimaActualizacion = DateTime.Now;
            Diagnostico.UsuarioUltimaActualizacion = request.Usuario;

            int affected = _IDiagnosticoRepository.Actualizar(Diagnostico);

            if (request.DiagnosticoCostoProduccionList.FirstOrDefault() != null)
            {
                request.DiagnosticoCostoProduccionList.ForEach(z =>
                {
                    z.DiagnosticoId = request.DiagnosticoId;
                });

                _IDiagnosticoRepository.ActualizarDiagnosticoCostoProduccion(request.DiagnosticoCostoProduccionList, request.DiagnosticoId);
            }

            if (request.DiagnosticoDatosCampoList.FirstOrDefault() != null)
            {
                request.DiagnosticoDatosCampoList.ForEach(z =>
                {
                    z.DiagnosticoId = request.DiagnosticoId;
                });

                _IDiagnosticoRepository.ActualizarDiagnosticoDatosCampo(request.DiagnosticoDatosCampoList, request.DiagnosticoId);
            }

            if (request.DiagnosticoInfraestructuraList.FirstOrDefault() != null)
            {
                request.DiagnosticoInfraestructuraList.ForEach(z =>
                {
                    z.DiagnosticoId = request.DiagnosticoId;
                });

                _IDiagnosticoRepository.ActualizarDiagnosticoInfraestructura(request.DiagnosticoInfraestructuraList, request.DiagnosticoId);
            }

            

            return affected;
        }

       

        public int RegistrarDiagnostico(RegistrarActualizarDiagnosticoRequestDTO request)
        {
            Diagnostico Diagnostico = _Mapper.Map<Diagnostico>(request);
            Diagnostico.FechaRegistro = DateTime.Now;
            Diagnostico.UsuarioRegistro = request.Usuario;
            Diagnostico.Numero = _ICorrelativoRepository.Obtener(null, Documentos.Diagnostico);


            int DiagnosticoId = _IDiagnosticoRepository.Insertar(Diagnostico);

            if (request.DiagnosticoCostoProduccionList.FirstOrDefault() != null)
            {                
                request.DiagnosticoCostoProduccionList.ForEach(z =>
                {
                    z.DiagnosticoId = DiagnosticoId;
                });

               _IDiagnosticoRepository.ActualizarDiagnosticoCostoProduccion(request.DiagnosticoCostoProduccionList, DiagnosticoId);
            }

            if (request.DiagnosticoDatosCampoList.FirstOrDefault() != null)
            {
                request.DiagnosticoDatosCampoList.ForEach(z =>
                {
                    z.DiagnosticoId = DiagnosticoId;
                });

                _IDiagnosticoRepository.ActualizarDiagnosticoDatosCampo(request.DiagnosticoDatosCampoList, DiagnosticoId);
            }

            if (request.DiagnosticoInfraestructuraList.FirstOrDefault() != null)
            {
                request.DiagnosticoInfraestructuraList.ForEach(z =>
                {
                    z.DiagnosticoId = DiagnosticoId;
                });

                _IDiagnosticoRepository.ActualizarDiagnosticoInfraestructura(request.DiagnosticoInfraestructuraList, DiagnosticoId);
            }

           



            return DiagnosticoId;
        }

        public List<ConsultaDiagnosticoBE> ConsultarDiagnostico(ConsultaDiagnosticoRequestDTO request)
        {
            //if (string.IsNullOrEmpty(request.Numero) && string.IsNullOrEmpty(request.Ruc) && string.IsNullOrEmpty(request.RazonSocial))
            //    throw new ResultException(new Result { ErrCode = "01", Message = "Comercial.Diagnostico.ValidacionSeleccioneMinimoUnFiltro.Label" });


            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Comercial.Diagnostico.ValidacionRangoFechaMayor2anios.Label" });



            var list = _IDiagnosticoRepository.ConsultarDiagnostico(request);

            return list.ToList();
        }

        public ConsultaDiagnosticoPorIdBE ConsultarDiagnosticoPorId(ConsultaDiagnosticoPorIdRequestDTO request)
        {
            ConsultaDiagnosticoPorIdBE consultaDiagnosticoPorIdBE = _IDiagnosticoRepository.ConsultarDiagnosticoPorId(request.DiagnosticoId);



            consultaDiagnosticoPorIdBE.DiagnosticoInfraestructura = _IDiagnosticoRepository.ConsultarDiagnosticoInfraestructuraPorId(request.DiagnosticoId).ToList();
            consultaDiagnosticoPorIdBE.DiagnosticoDatosCampo = _IDiagnosticoRepository.ConsultarDiagnosticoDatosCampoPorId(request.DiagnosticoId).ToList();
            consultaDiagnosticoPorIdBE.DiagnosticoInfraestructura = _IDiagnosticoRepository.ConsultarDiagnosticoInfraestructuraPorId(request.DiagnosticoId).ToList();
          
            return consultaDiagnosticoPorIdBE;
        }

    }
}
