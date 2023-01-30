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
    public partial class DevolucionPrestamoPlantaService : IDevolucionPrestamoPlantaService
    {
        private readonly IMapper _Mapper;
        private IDevolucionPrestamoPlantaRepository _IDevolucionPrestamoPlantaRepository;
        private IPrestamoPlantaRepository _IPrestamoPlantaRepository;
        public IOptions<FileServerSettings> _fileServerSettings;
        private ICorrelativoRepository _ICorrelativoRepository;
        private IMaestroRepository _IMaestroRepository;
      




        public DevolucionPrestamoPlantaService(IDevolucionPrestamoPlantaRepository DevolucionPrestamoPlantaRepository, IPrestamoPlantaRepository PrestamoPlantaRepository, ICorrelativoRepository correlativoRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings, IMaestroRepository maestroRepository)
        {
            _IDevolucionPrestamoPlantaRepository = DevolucionPrestamoPlantaRepository;
            _IPrestamoPlantaRepository = PrestamoPlantaRepository;
            _Mapper = mapper;
            _fileServerSettings = fileServerSettings;
            _ICorrelativoRepository = correlativoRepository;
            _IMaestroRepository = maestroRepository;
        }

        public int AnularDevolucionPrestamoPlanta(DevolucionPrestamoPlantaAnularRequestDTO request)
        {
            int affected = _IDevolucionPrestamoPlantaRepository.AnularDevolucionPrestamoPlanta(request.DevolucionPrestamoPlantaId, DateTime.Now, request.Usuario, DevolucionPrestamoPlantaEstados.Anulado, request.ObservacionAnulacion);

            _IPrestamoPlantaRepository.ActualizarPrestamoPlantaEstadoMontos(request.PrestamoPlantaId, DateTime.Now, request.Usuario, PrestamoPlantaEstados.Deuda, request.Importe);
            //List<NotaSalidaAlmacenDetalle> notaSalidaAlmacenDetalle = _INotaSalidaAlmacenPlantaRepository.ConsultarNotaSalidaAlmacenDetallePorId(request.NotaSalidaAlmacenId).ToList();

            //notaSalidaAlmacenDetalle.ForEach(notaSalidaDetalle =>
            //{
            //    _LoteRepository.ActualizarEstado(notaSalidaDetalle.LoteId, DateTime.Now, request.Usuario, LoteEstados.Analizado);
            //});

            return affected;
        }

        public List<ConsultaDevolucionPrestamoPlantaBE> ConsultarDevolucionPrestamoPlanta(ConsultaDevolucionPrestamoPlantaRequestDTO request)
        {
            var list = _IDevolucionPrestamoPlantaRepository.ConsultarDevolucionPrestamoPlanta(request);            

            return list.ToList();
        }

        public int RegistrarDevolucionPrestamoPlanta(RegistrarActualizarDevolucionPrestamoPlantaRequestDTO request)
        {
            DevolucionPrestamoPlanta DevolucionPrestamoPlanta = _Mapper.Map<DevolucionPrestamoPlanta>(request);

            DevolucionPrestamoPlanta.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.DevolucionPrestamoPlanta);

            ///////////////////////////////////////////////////////////////7777////////////////////////////////////////////

            ConsultaPrestamoPlantaPorIdBE prestamoPlanta = _IPrestamoPlantaRepository.ConsultarPrestamoPlantaPorId(DevolucionPrestamoPlanta.PrestamoPlantaId);

            // ServicioPlanta servicioTotalInmporte = _Mapper.Map<ServicioPlanta>(ServicioPlanta2.ServicioPlantaId);
            var prestamoPlantaActualizarImporteProcesado = new PrestamoPlantaActualizarImporteProcesado();

            prestamoPlantaActualizarImporteProcesado.PrestamoPlantaId = prestamoPlanta.PrestamoPlantaId;
            string estadoId = ServicioPlantaEstados.Deuda;
            
            if (prestamoPlanta.ImporteProcesado == 0)
            {
                prestamoPlantaActualizarImporteProcesado.ImporteProcesado = prestamoPlanta.ImporteProcesado + request.Importe;
            }
            else
            {
                prestamoPlantaActualizarImporteProcesado.ImporteProcesado = request.Importe;
            }

            decimal total;

            if (prestamoPlanta.Importe != 0)
            {
                total = prestamoPlanta.Importe - prestamoPlantaActualizarImporteProcesado.ImporteProcesado;
            }
            else{
                total = prestamoPlantaActualizarImporteProcesado.ImporteProcesado;
            }

            if (prestamoPlantaActualizarImporteProcesado.ImporteProcesado > prestamoPlanta.Importe)
            {
                return 0;
            }
            


            //var to decimal = servicioPlanta.TotalImporte - servicioActualizarTotalImporteProcesado.TotalImporteProcesado

            if (total == 0 )
            {
                estadoId = ServicioPlantaEstados.Cancelado;
            }
            prestamoPlantaActualizarImporteProcesado.EstadoId = estadoId;// ServicioPlantaEstados.Cancelado;
            prestamoPlantaActualizarImporteProcesado.FechaUltimaActualizacion = DateTime.Now;
            prestamoPlantaActualizarImporteProcesado.UsuarioUltimaActualizacion = request.Usuario;


            _IPrestamoPlantaRepository.PrestamoPlantaActualizarImporteProcesado(prestamoPlantaActualizarImporteProcesado);

          


            DevolucionPrestamoPlanta.EstadoId = DevolucionPrestamoPlantaEstados.Registrado;
            DevolucionPrestamoPlanta.FechaRegistro = DateTime.Now;
            DevolucionPrestamoPlanta.UsuarioRegistro = request.Usuario; 

            int notaIngresoPlantaId = _IDevolucionPrestamoPlantaRepository.Insertar(DevolucionPrestamoPlanta); 

             
            return notaIngresoPlantaId;
        }

        public ConsultaDevolucionPrestamoPlantaPorIdBE ConsultarDevolucionPrestamoPlantaPorId(ConsultaDevolucionPrestamoPlantaPorIdRequestDTO request)
        {
            return _IDevolucionPrestamoPlantaRepository.ConsultarDevolucionPrestamoPlantaPorId(request.DevolucionPrestamoPlantaId);
        }

        public int ActualizarDevolucionPrestamoPlanta(RegistrarActualizarDevolucionPrestamoPlantaRequestDTO request)
        {
            int affected = 0;

            DevolucionPrestamoPlanta DevolucionPrestamoPlanta = _Mapper.Map<DevolucionPrestamoPlanta>(request);

            
            
            DevolucionPrestamoPlanta.FechaUltimaActualizacion = DateTime.Now;
            DevolucionPrestamoPlanta.UsuarioUltimaActualizacion = request.Usuario;

            affected = _IDevolucionPrestamoPlantaRepository.Actualizar(DevolucionPrestamoPlanta);



            return affected;
        }

       
    }
}
