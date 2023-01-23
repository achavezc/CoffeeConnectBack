using AutoMapper;
using CoffeeConnect.DTO;
 
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
        private IServicioPlantaRepository _IServicioPlantaRepository;
        public IOptions<FileServerSettings> _fileServerSettings;
        private ICorrelativoRepository _ICorrelativoRepository;
        private IMaestroRepository _IMaestroRepository;
      




        public PagoServicioPlantaService(IPagoServicioPlantaRepository PagoServicioPlantaRepository, IServicioPlantaRepository ServicioPlanta, ICorrelativoRepository correlativoRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings, IMaestroRepository maestroRepository)
        {
            _IPagoServicioPlantaRepository = PagoServicioPlantaRepository;
            _IServicioPlantaRepository = ServicioPlanta;
            _Mapper = mapper;
            _fileServerSettings = fileServerSettings;
            _ICorrelativoRepository = correlativoRepository;
            _IMaestroRepository = maestroRepository;
        }

        public int AnularPagoServicioPlanta(PagoServicioPlantaAnularRequestDTO request)
        {
            int affected = _IPagoServicioPlantaRepository.AnularPagoServicioPlanta(request.PagoServicioPlantaId, DateTime.Now, request.Usuario, PagoServicioPlantaEstados.Anulado, request.ObservacionAnulacion);

            _IServicioPlantaRepository.ActualizarServicioPlantaEstadoMontos(request.ServicioPlantaId, DateTime.Now, request.Usuario, ServicioPlantaEstados.Deuda, request.Importe);
            //List<NotaSalidaAlmacenDetalle> notaSalidaAlmacenDetalle = _INotaSalidaAlmacenPlantaRepository.ConsultarNotaSalidaAlmacenDetallePorId(request.NotaSalidaAlmacenId).ToList();

            //notaSalidaAlmacenDetalle.ForEach(notaSalidaDetalle =>
            //{
            //    _LoteRepository.ActualizarEstado(notaSalidaDetalle.LoteId, DateTime.Now, request.Usuario, LoteEstados.Analizado);
            //});

            return affected;
        }

        public List<ConsultaPagoServicioPlantaBE> ConsultarPagoServicioPlanta(ConsultaPagoServicioPlantaRequestDTO request)
        {
            var list = _IPagoServicioPlantaRepository.ConsultarPagoServicioPlanta(request);            

            return list.ToList();
        }

        public int RegistrarPagoServicioPlanta(RegistrarActualizarPagoServicioPlantaRequestDTO request)
        {
            PagoServicioPlanta pagoServicioPlanta = _Mapper.Map<PagoServicioPlanta>(request);

            pagoServicioPlanta.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.PagoServicioPlanta);

            ///////////////////////////////////////////////////////////////7777////////////////////////////////////////////

            ConsultaServicioPlantaPorIdBE servicioPlanta = _IServicioPlantaRepository.ConsultarServicioPlantaPorId(pagoServicioPlanta.ServicioPlantaId);

            // ServicioPlanta servicioTotalInmporte = _Mapper.Map<ServicioPlanta>(ServicioPlanta2.ServicioPlantaId);
            var servicioActualizarTotalImporteProcesado = new ServicioActualizarTotalImporteProcesado();

            servicioActualizarTotalImporteProcesado.ServicioPlantaId = servicioPlanta.ServicioPlantaId;
            string estadoId = ServicioPlantaEstados.Deuda;
            //if(ServicioPlanta.TotalImporteProcesado >= )
            if ( servicioPlanta.TotalImporteProcesado != null)
            {
                servicioActualizarTotalImporteProcesado.TotalImporteProcesado = servicioPlanta.TotalImporteProcesado.Value + request.Importe;
            }
            else
            {
                servicioActualizarTotalImporteProcesado.TotalImporteProcesado = request.Importe;
            }

            decimal total = 0;

            if (servicioPlanta.TotalImporte != null)
            {
                total = servicioPlanta.TotalImporte.Value - servicioActualizarTotalImporteProcesado.TotalImporteProcesado;
            }
            else{
                total = servicioActualizarTotalImporteProcesado.TotalImporteProcesado;
            }



            //var to decimal = servicioPlanta.TotalImporte - servicioActualizarTotalImporteProcesado.TotalImporteProcesado

            if (total == 0 )
            {
                estadoId = ServicioPlantaEstados.Cancelado;
            }
            servicioActualizarTotalImporteProcesado.EstadoId = estadoId;// ServicioPlantaEstados.Cancelado;
            servicioActualizarTotalImporteProcesado.FechaUltimaActualizacion = DateTime.Now;
            servicioActualizarTotalImporteProcesado.UsuarioUltimaActualizacion = request.Usuario;


            _IServicioPlantaRepository.ServicioActualizarTotalImporteProcesado(servicioActualizarTotalImporteProcesado);

          


            pagoServicioPlanta.EstadoId = PagoServicioPlantaEstados.Registrado;
            pagoServicioPlanta.FechaRegistro = DateTime.Now;
            pagoServicioPlanta.UsuarioRegistro = request.Usuario; 

            int notaIngresoPlantaId = _IPagoServicioPlantaRepository.Insertar(pagoServicioPlanta); 

             
            return notaIngresoPlantaId;
        }

        public ConsultaPagoServicioPlantaPorIdBE ConsultarPagoServicioPlantaPorId(ConsultaPagoServicioPlantaPorIdRequestDTO request)
        {
            return _IPagoServicioPlantaRepository.ConsultarPagoServicioPlantaPorId(request.PagoServicioPlantaId);
        }

        public int ActualizarPagoServicioPlanta(RegistrarActualizarPagoServicioPlantaRequestDTO request)
        {
            int affected = 0;

            PagoServicioPlanta pagoServicioPlanta = _Mapper.Map<PagoServicioPlanta>(request);

            
            
            pagoServicioPlanta.FechaUltimaActualizacion = DateTime.Now;
            pagoServicioPlanta.UsuarioUltimaActualizacion = request.Usuario;

            affected = _IPagoServicioPlantaRepository.Actualizar(pagoServicioPlanta);



            return affected;
        }

       
    }
}
