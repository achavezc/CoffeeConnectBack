
using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeConnect.Service
{
    public partial class NotaIngresoAlmacenPlantaService : INotaIngresoAlmacenPlantaService
    {
        private readonly IMapper _Mapper;
        private INotaIngresoAlmacenPlantaRepository _INotaIngresoAlmacenPlantaRepository;
        private IControlCalidadPlantaRepository _IControlCalidadPlantaRepository;
        private ICorrelativoRepository _ICorrelativoRepository;
        private INotaSalidaAlmacenPlantaRepository _INotaSalidaAlmacenPlantaRepository;
        private IGuiaRemisionAlmacenPlantaRepository _IGuiaRemisionAlmacenPlantaRepository;
        private INotaIngresoAlmacenPlantaRepository _NotaIngresoAlmacenPlantaRepository;


        public NotaIngresoAlmacenPlantaService(INotaIngresoAlmacenPlantaRepository NotaIngresoAlmacenPlantaRepository, INotaSalidaAlmacenPlantaRepository notaSalidaAlmacenPlantaRepository, INotaIngresoAlmacenPlantaRepository notaIngresoAlmacenPlantaRepository,
            IGuiaRemisionAlmacenPlantaRepository IGuiaRemisionAlmacenPlantaRepository, IMapper mapper, IControlCalidadPlantaRepository controlCalidadPlantaRepository, ICorrelativoRepository correlativoRepository)
        {
            _INotaIngresoAlmacenPlantaRepository = NotaIngresoAlmacenPlantaRepository;
            _INotaSalidaAlmacenPlantaRepository = notaSalidaAlmacenPlantaRepository;
            _IControlCalidadPlantaRepository = controlCalidadPlantaRepository;
            _IGuiaRemisionAlmacenPlantaRepository = IGuiaRemisionAlmacenPlantaRepository;
            _NotaIngresoAlmacenPlantaRepository = notaIngresoAlmacenPlantaRepository;
            _ICorrelativoRepository = correlativoRepository;
            _Mapper = mapper;
        }

        public int Registrar(RegistrarActualizarNotaIngresoAlmacenPlantaRequestDTO request)
        {
            ConsultaControlCalidadPlantaPorIdBE controlCalidadPlanta = _IControlCalidadPlantaRepository.ConsultaControlCalidadPlantaPorId(request.ControlCalidadPlantaId);

            int affected = 1;

            if (controlCalidadPlanta.EstadoCalidadId == ControlCalidadEstados.Analizado)
            {
                string estado = ControlCalidadEstados.Analizado;

                if (request.Cantidad >= controlCalidadPlanta.CantidadControlCalidad - controlCalidadPlanta.CantidadProcesada)
                {
                    estado = ControlCalidadEstados.EnviadoAlmacen;
                }

                _IControlCalidadPlantaRepository.ActualizarCantidadProcesadaEstado(request.ControlCalidadPlantaId, controlCalidadPlanta.CantidadProcesada + request.Cantidad, controlCalidadPlanta.KilosNetosProcesado + request.KilosNetos, DateTime.Now, request.Usuario, estado);

                NotaIngresoAlmacenPlanta NotaIngresoAlmacenPlanta = _Mapper.Map<NotaIngresoAlmacenPlanta>(request);
                NotaIngresoAlmacenPlanta.UsuarioRegistro = request.Usuario;
                NotaIngresoAlmacenPlanta.FechaRegistro = DateTime.Now;
                NotaIngresoAlmacenPlanta.EstadoId = NotaIngresoAlmacenPlantaEstados.Ingresado;
                NotaIngresoAlmacenPlanta.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.NotaIngresoAlmacenPlanta);


                affected = _INotaIngresoAlmacenPlantaRepository.Insertar(NotaIngresoAlmacenPlanta);

                //_INotaIngresoPlantaRepository.ActualizarEstado(request.NotaIngresoPlantaId, DateTime.Now, request.Usuario, NotaIngresoPlantaEstados.EnviadoAlmacen);

            }
            else if (controlCalidadPlanta.EstadoCalidadId == ControlCalidadEstados.Rechazado)
            {
                string estado = ControlCalidadEstados.Rechazado;

                _IControlCalidadPlantaRepository.ActualizarCantidadProcesadaEstado(request.ControlCalidadPlantaId, controlCalidadPlanta.CantidadProcesada + request.Cantidad, controlCalidadPlanta.KilosNetosProcesado + request.KilosNetos, DateTime.Now, request.Usuario, estado);

                NotaIngresoAlmacenPlanta NotaIngresoAlmacenPlanta = _Mapper.Map<NotaIngresoAlmacenPlanta>(request);
                NotaIngresoAlmacenPlanta.UsuarioRegistro = request.Usuario;
                NotaIngresoAlmacenPlanta.FechaRegistro = DateTime.Now;
                NotaIngresoAlmacenPlanta.EstadoId = NotaIngresoAlmacenPlantaEstados.Ingresado;
                NotaIngresoAlmacenPlanta.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.NotaIngresoAlmacenPlanta);


                int notaIngresoAlmacenPlantaId = _INotaIngresoAlmacenPlantaRepository.Insertar(NotaIngresoAlmacenPlanta);

                RegistrarNotaSalidaAlmacenPlantaRequestDTO registrarNotaSalidaAlmacenPlantaRequestDTO = new RegistrarNotaSalidaAlmacenPlantaRequestDTO();

                registrarNotaSalidaAlmacenPlantaRequestDTO.AlmacenId = request.AlmacenId;
                registrarNotaSalidaAlmacenPlantaRequestDTO.EmpresaId = request.EmpresaId;
                registrarNotaSalidaAlmacenPlantaRequestDTO.EmpresaIdDestino = controlCalidadPlanta.EmpresaOrigenId;
                registrarNotaSalidaAlmacenPlantaRequestDTO.MotivoSalidaId = NotaSalidaAlmacenPlantaMotivos.Rechazo;
                registrarNotaSalidaAlmacenPlantaRequestDTO.CantidadTotal = request.Cantidad;
                registrarNotaSalidaAlmacenPlantaRequestDTO.EstadoId = NotaSalidaAlmacenPlantaEstados.Ingresado;
                registrarNotaSalidaAlmacenPlantaRequestDTO.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.NotaSalidaAlmacenPlanta);
                registrarNotaSalidaAlmacenPlantaRequestDTO.Observacion = controlCalidadPlanta.ObservacionAnalisisFisico + " " + controlCalidadPlanta.ObservacionAnalisisSensorial;
                registrarNotaSalidaAlmacenPlantaRequestDTO.PesoKilosBrutos = request.PesoBruto;
                registrarNotaSalidaAlmacenPlantaRequestDTO.PesoKilosNetos = request.KilosNetos;
                registrarNotaSalidaAlmacenPlantaRequestDTO.Tara = request.Tara;
                registrarNotaSalidaAlmacenPlantaRequestDTO.UsuarioNotaSalidaAlmacenPlanta = request.Usuario;
                registrarNotaSalidaAlmacenPlantaRequestDTO.SubProductoId = controlCalidadPlanta.SubProductoId;
                registrarNotaSalidaAlmacenPlantaRequestDTO.ProductoId = controlCalidadPlanta.ProductoId;


                registrarNotaSalidaAlmacenPlantaRequestDTO.ListNotaSalidaAlmacenPlantaDetalle = new List<NotaSalidaAlmacenPlantaDetalleDTO>();


                NotaSalidaAlmacenPlantaDetalleDTO notaSalidaAlmacenPlantaDetalle = new NotaSalidaAlmacenPlantaDetalleDTO();
                notaSalidaAlmacenPlantaDetalle.NotaIngresoAlmacenPlantaId = notaIngresoAlmacenPlantaId;
                notaSalidaAlmacenPlantaDetalle.PesoKilosBrutos = request.PesoBruto;
                notaSalidaAlmacenPlantaDetalle.PesoKilosNetos = request.KilosNetos;
                notaSalidaAlmacenPlantaDetalle.Tara = request.Tara;
                notaSalidaAlmacenPlantaDetalle.TipoId = controlCalidadPlanta.TipoId;
                notaSalidaAlmacenPlantaDetalle.EmpaqueId = controlCalidadPlanta.EmpaqueId;
                notaSalidaAlmacenPlantaDetalle.Cantidad = request.Cantidad;                

                registrarNotaSalidaAlmacenPlantaRequestDTO.ListNotaSalidaAlmacenPlantaDetalle.Add(notaSalidaAlmacenPlantaDetalle);

                this.registrarNotaSalidaAlmacenPlanta(registrarNotaSalidaAlmacenPlantaRequestDTO);

            }

            return affected;
        }


        private int registrarNotaSalidaAlmacenPlanta(RegistrarNotaSalidaAlmacenPlantaRequestDTO request)
        {
            NotaSalidaAlmacenPlanta notaSalidaAlmacen = new NotaSalidaAlmacenPlanta();
            List<NotaSalidaAlmacenPlantaDetalle> lstnotaSalidaAlmacen = new List<NotaSalidaAlmacenPlantaDetalle>();
            int affected = 0;

            List<TablaIdsTipo> notaIngresoIdActualizar = new List<TablaIdsTipo>();

            notaSalidaAlmacen.EmpresaId = request.EmpresaId;
            notaSalidaAlmacen.AlmacenId = request.AlmacenId;
            notaSalidaAlmacen.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.NotaSalidaAlmacenPlanta);
            notaSalidaAlmacen.MotivoSalidaId = request.MotivoSalidaId;
            notaSalidaAlmacen.ProductoId = request.ProductoId;
            notaSalidaAlmacen.SubProductoId = request.SubProductoId;
            notaSalidaAlmacen.MotivoSalidaReferencia = request.MotivoSalidaReferencia;
            notaSalidaAlmacen.EmpresaIdDestino = request.EmpresaIdDestino;
            notaSalidaAlmacen.EmpresaTransporteId = request.EmpresaTransporteId;
            notaSalidaAlmacen.TransporteId = request.TransporteId;
            notaSalidaAlmacen.NumeroConstanciaMTC = request.NumeroConstanciaMTC;
            notaSalidaAlmacen.MarcaTractorId = request.MarcaTractorId;
            notaSalidaAlmacen.PlacaTractor = request.PlacaTractor;
            notaSalidaAlmacen.MarcaCarretaId = request.MarcaCarretaId;
            notaSalidaAlmacen.PlacaCarreta = request.PlacaCarreta;
            notaSalidaAlmacen.Conductor = request.Conductor;
            notaSalidaAlmacen.Licencia = request.Licencia;
            notaSalidaAlmacen.Observacion = request.Observacion;
            //notaSalidaAlmacen.PromedioPorcentajeRendimiento = request.PromedioPorcentajeRendimiento;
            notaSalidaAlmacen.CantidadTotal = request.CantidadTotal;
            notaSalidaAlmacen.PesoKilosBrutos = request.PesoKilosBrutos;
            notaSalidaAlmacen.PesoKilosNetos = request.PesoKilosNetos;
            notaSalidaAlmacen.Tara = request.Tara;

            notaSalidaAlmacen.EstadoId = NotaSalidaAlmacenEstados.Ingresado;
            notaSalidaAlmacen.FechaRegistro = DateTime.Now;
            notaSalidaAlmacen.UsuarioRegistro = request.UsuarioNotaSalidaAlmacenPlanta;

            notaSalidaAlmacen.NotaSalidaAlmacenPlantaId = _INotaSalidaAlmacenPlantaRepository.Insertar(notaSalidaAlmacen);

            if (notaSalidaAlmacen.NotaSalidaAlmacenPlantaId != 0)
            {
                request.ListNotaSalidaAlmacenPlantaDetalle.ForEach(x =>
                {
                    NotaSalidaAlmacenPlantaDetalle obj = new NotaSalidaAlmacenPlantaDetalle();
                    obj.NotaIngresoAlmacenPlantaId = x.NotaIngresoAlmacenPlantaId;
                    obj.NotaSalidaAlmacenPlantaId = notaSalidaAlmacen.NotaSalidaAlmacenPlantaId;
                    obj.EmpaqueId = x.EmpaqueId;
                    obj.TipoId = x.TipoId;
                    obj.Cantidad = x.Cantidad;
                    obj.PesoKilosBrutos = x.PesoKilosBrutos;
                    obj.PesoKilosNetos = x.PesoKilosNetos;
                    obj.Tara = x.Tara;


                    lstnotaSalidaAlmacen.Add(obj);


                    if (x.NotaIngresoAlmacenPlantaId.HasValue)
                    {
                        TablaIdsTipo tablaLoteIdsTipo = new TablaIdsTipo();
                        tablaLoteIdsTipo.Id = x.NotaIngresoAlmacenPlantaId.Value;
                        notaIngresoIdActualizar.Add(tablaLoteIdsTipo);
                    }


                });

                affected = _INotaSalidaAlmacenPlantaRepository.ActualizarNotaSalidaAlmacenPlantaDetalle(lstnotaSalidaAlmacen, notaSalidaAlmacen.NotaSalidaAlmacenPlantaId);

            }

            #region Guia Remision

            /*
            int guiaRemisionAlmacenId;
            //GuiaRemisionAlmacen guiaRemisionAlmacen = new GuiaRemisionAlmacen();

            GuiaRemisionAlmacenPlanta guiaRemisionAlmacen = _Mapper.Map<GuiaRemisionAlmacenPlanta>(notaSalidaAlmacen);
            guiaRemisionAlmacen.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.GuiaRemisionAlmacenPlanta);


            string tipoProduccionId = String.Empty;
            string tipoCertificacionId = String.Empty;

            List<ConsultaNotaSalidaAlmacenPlantaDetallePorIdBE> NotaSalidaDetalle = _INotaSalidaAlmacenPlantaRepository.ConsultarNotaSalidaAlmacenPlantaDetallePorIdBE(notaSalidaAlmacen.NotaSalidaAlmacenPlantaId).ToList();


            if (NotaSalidaDetalle.Count > 0)
            {
                tipoProduccionId = NotaSalidaDetalle[0].TipoProduccionId;
                tipoCertificacionId = NotaSalidaDetalle[0].CertificacionId;

            }

            guiaRemisionAlmacen.TipoProduccionId = ""; ;
            guiaRemisionAlmacen.TipoCertificacionId = "";
            guiaRemisionAlmacen.EstadoId = GuiaRemisionAlmacenEstados.Ingresado;

            guiaRemisionAlmacenId = _IGuiaRemisionAlmacenPlantaRepository.Insertar(guiaRemisionAlmacen);

            if (guiaRemisionAlmacenId != 0)
            {
                List<GuiaRemisionAlmacenPlantaDetalleTipo> listaDetalle = new List<GuiaRemisionAlmacenPlantaDetalleTipo>();
                if (NotaSalidaDetalle.Any())
                {
                    NotaSalidaDetalle.ForEach(x =>
                    {
                        GuiaRemisionAlmacenPlantaDetalleTipo item = _Mapper.Map<GuiaRemisionAlmacenPlantaDetalleTipo>(x);
                        item.GuiaRemisionAlmacenPlantaId = guiaRemisionAlmacenId;
                        item.NotaIngresoAlmacenPlantaId = x.NotaIngresoAlmacenPlantaId;
                        item.NumeroNotaIngresoAlmacenPlanta = x.NumeroNotaIngresoAlmacenPlanta;
                        item.ProductoId = x.ProductoId;
                        item.SubProductoId = x.SubProductoId;
                        item.UnidadMedidaIdPesado = x.UnidadMedidaIdPesado;
                        item.CalidadId = x.CalidadId;
                        item.GradoId = x.GradoId;
                        item.CantidadPesado = x.CantidadPesado;
                        item.CantidadDefectos = x.CantidadDefectos;
                        item.KilosNetosPesado = x.KilosNetosPesado;
                        item.KilosBrutosPesado = x.KilosBrutosPesado;
                        item.TaraPesado = x.TaraPesado;
                        listaDetalle.Add(item);
                    });

                    _IGuiaRemisionAlmacenPlantaRepository.ActualizarGuiaRemisionAlmacenPlantaDetalle(listaDetalle);
                }

            }
            */
            #endregion Guia Remision

            //if (notaIngresoIdActualizar.Count > 0)
            //{
            //    _NotaIngresoAlmacenPlantaRepository.ActualizarEstadoPorIds(notaIngresoIdActualizar, DateTime.Now, request.UsuarioNotaSalidaAlmacenPlanta, NotaIngresoAlmacenPlantaEstados.GeneradoNotaSalida);
            //}

            return affected;
        }

        public List<ConsultaNotaIngresoAlmacenPlantaBE> ConsultarNotaIngresoAlmacenPlanta(ConsultaNotaIngresoAlmacenPlantaRequestDTO request)
        {

            /*if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFin == null || request.FechaFin == DateTime.MinValue || string.IsNullOrEmpty(request.EstadoId))
                throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.NotaCompra.ValidacionSeleccioneMinimoUnFiltro.Label" }); */

            //if (string.IsNullOrEmpty(request.EstadoId))
            //    throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.NotaCompra.ValidacionSeleccioneMinimoUnFiltro.Label" });

            var timeSpan = request.FechaFin - request.FechaInicio;

            /*if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Acopio.NotaCompra.ValidacionRangoFechaMayor2anios.Label" });*/

            var list = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlanta(request);
            return list.ToList(); 
        }

        //public int AnularNotaIngresoAlmacenPlanta(AnularNotaIngresoAlmacenPlantaRequestDTO request)
        //{
        //    ConsultaNotaIngresoAlmacenPlantaPorIdBE consultaNotaIngresoAlmacenPlantaPorIdBE = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaPorId(request.NotaIngresoAlmacenPlantaId);

        //    int affected = 0;

        //    if (consultaNotaIngresoAlmacenPlantaPorIdBE != null)
        //    {
        //        affected = _INotaIngresoAlmacenPlantaRepository.ActualizarEstado(request.NotaIngresoAlmacenPlantaId, DateTime.Now, request.Usuario, LoteEstados.Anulado);

        //        _IGuiaRecepcionMateriaPrimaRepository.ActualizarEstado(consultaNotaIngresoAlmacenPlantaPorIdBE.GuiaRecepcionMateriaPrimaId, DateTime.Now, request.Usuario, GuiaRecepcionMateriaPrimaEstados.Analizado);

        //    }

        //    return affected;
        //}

        public int ActualizarNotaIngresoAlmacenPlanta(ActualizarNotaIngresoAlmacenPlantaRequestDTO request)
        {
            int affected = 0;
            NotaIngresoAlmacenPlanta notaIngresoAlmacenPlanta = new NotaIngresoAlmacenPlanta();
            notaIngresoAlmacenPlanta.NotaIngresoAlmacenPlantaId = request.NotaIngresoAlmacenPlantaId;
            notaIngresoAlmacenPlanta.ControlCalidadPlantaId = request.ControlCalidadPlantaId;
            notaIngresoAlmacenPlanta.AlmacenId = request.AlmacenId;
            notaIngresoAlmacenPlanta.EstadoId = request.EstadoId;
            notaIngresoAlmacenPlanta.TipoId = request.TipoId;
            notaIngresoAlmacenPlanta.EmpaqueId = request.EmpaqueId;
            notaIngresoAlmacenPlanta.Cantidad = request.Cantidad;
            notaIngresoAlmacenPlanta.PesoBruto = request.PesoBruto;
            notaIngresoAlmacenPlanta.Tara = request.Tara;
            notaIngresoAlmacenPlanta.KilosNetos = request.KilosNetos;
            notaIngresoAlmacenPlanta.UsuarioUltimaActualizacion = request.Usuario;
            notaIngresoAlmacenPlanta.FechaUltimaActualizacion = DateTime.Now;


            affected = _INotaIngresoAlmacenPlantaRepository.Actualizar(notaIngresoAlmacenPlanta);



            return affected;
        }

        public ConsultaNotaIngresoAlmacenPlantaPorIdBE ConsultarNotaIngresoAlmacenPlantaPorId(ConsultaNotaIngresoAlmacenPlantaPorIdRequestDTO request)
        {
            ConsultaNotaIngresoAlmacenPlantaPorIdBE consultaNotaIngresoAlmacenPlantaPorIdBE = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaPorId(request.NotaIngresoAlmacenPlantaId);

            if (consultaNotaIngresoAlmacenPlantaPorIdBE != null)
            {
               
                consultaNotaIngresoAlmacenPlantaPorIdBE.AnalisisFisicoColorDetalle = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaAnalisisFisicoColorDetallePorId(consultaNotaIngresoAlmacenPlantaPorIdBE.ControlCalidadPlantaId).ToList();

                consultaNotaIngresoAlmacenPlantaPorIdBE.AnalisisFisicoOlorDetalle = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaAnalisisFisicoOlorDetallePorId(consultaNotaIngresoAlmacenPlantaPorIdBE.ControlCalidadPlantaId).ToList();

                consultaNotaIngresoAlmacenPlantaPorIdBE.AnalisisFisicoDefectoPrimarioDetalle = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaAnalisisFisicoDefectoPrimarioDetallePorId(consultaNotaIngresoAlmacenPlantaPorIdBE.ControlCalidadPlantaId).ToList();

                consultaNotaIngresoAlmacenPlantaPorIdBE.AnalisisFisicoDefectoSecundarioDetalle = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaAnalisisFisicoDefectoSecundarioDetallePorId(consultaNotaIngresoAlmacenPlantaPorIdBE.ControlCalidadPlantaId).ToList();

                consultaNotaIngresoAlmacenPlantaPorIdBE.AnalisisSensorialAtributoDetalle = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaAnalisisSensorialAtributoDetallePorId(consultaNotaIngresoAlmacenPlantaPorIdBE.ControlCalidadPlantaId).ToList();

                consultaNotaIngresoAlmacenPlantaPorIdBE.AnalisisSensorialDefectoDetalle = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaAnalisisSensorialDefectoDetallePorId(consultaNotaIngresoAlmacenPlantaPorIdBE.ControlCalidadPlantaId).ToList();

                consultaNotaIngresoAlmacenPlantaPorIdBE.RegistroTostadoIndicadorDetalle = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaRegistroTostadoIndicadorDetallePorId(consultaNotaIngresoAlmacenPlantaPorIdBE.ControlCalidadPlantaId).ToList();

                
            }

            return consultaNotaIngresoAlmacenPlantaPorIdBE;
        }
    }
}
