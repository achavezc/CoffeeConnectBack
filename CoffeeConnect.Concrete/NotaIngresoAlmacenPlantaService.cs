
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
            NotaIngresoAlmacenPlanta NotaIngresoAlmacenPlanta = null;
            int notaIngresoAlmacenPlantaId =0;

            if (controlCalidadPlanta.EstadoCalidadId == ControlCalidadEstados.Analizado)
            {
                string estado = ControlCalidadEstados.Analizado;

                if (request.Cantidad >= controlCalidadPlanta.CantidadControlCalidad - controlCalidadPlanta.CantidadProcesada)
                {
                    estado = ControlCalidadEstados.EnviadoAlmacen;
                }

                _IControlCalidadPlantaRepository.ActualizarCantidadProcesadaEstado(request.ControlCalidadPlantaId, controlCalidadPlanta.CantidadProcesada + request.Cantidad, controlCalidadPlanta.KilosNetosProcesado + request.KilosNetos, DateTime.Now, request.Usuario, estado);

                NotaIngresoAlmacenPlanta = _Mapper.Map<NotaIngresoAlmacenPlanta>(request);
                NotaIngresoAlmacenPlanta.UsuarioRegistro = request.Usuario;
                NotaIngresoAlmacenPlanta.FechaRegistro = DateTime.Now;
                NotaIngresoAlmacenPlanta.EstadoId = NotaIngresoAlmacenPlantaEstados.Ingresado;
                NotaIngresoAlmacenPlanta.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.NotaIngresoAlmacenPlanta);


                notaIngresoAlmacenPlantaId = _INotaIngresoAlmacenPlantaRepository.Insertar(NotaIngresoAlmacenPlanta);

                //_INotaIngresoPlantaRepository.ActualizarEstado(request.NotaIngresoPlantaId, DateTime.Now, request.Usuario, NotaIngresoPlantaEstados.EnviadoAlmacen);

            }
            else if (controlCalidadPlanta.EstadoCalidadId == ControlCalidadEstados.Rechazado)
            {
                string estado = ControlCalidadEstados.EnviadoAlmacen;

                _IControlCalidadPlantaRepository.ActualizarCantidadProcesadaEstado(request.ControlCalidadPlantaId, controlCalidadPlanta.CantidadProcesada + request.Cantidad, controlCalidadPlanta.KilosNetosProcesado + request.KilosNetos, DateTime.Now, request.Usuario, estado);

                NotaIngresoAlmacenPlanta = _Mapper.Map<NotaIngresoAlmacenPlanta>(request);
                NotaIngresoAlmacenPlanta.UsuarioRegistro = request.Usuario;
                NotaIngresoAlmacenPlanta.FechaRegistro = DateTime.Now;
                NotaIngresoAlmacenPlanta.EstadoId = NotaIngresoAlmacenPlantaEstados.Procesado;
                NotaIngresoAlmacenPlanta.KilosNetosOrdenProceso = controlCalidadPlanta.KilosNetosControlCalidad;
                NotaIngresoAlmacenPlanta.CantidadOrdenProceso = controlCalidadPlanta.CantidadControlCalidad;

                NotaIngresoAlmacenPlanta.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.NotaIngresoAlmacenPlanta);


                notaIngresoAlmacenPlantaId = _INotaIngresoAlmacenPlantaRepository.Insertar(NotaIngresoAlmacenPlanta);

                #region Nota Salida Almacen

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
                notaSalidaAlmacenPlantaDetalle.KilosBrutos = request.PesoBruto;
                notaSalidaAlmacenPlantaDetalle.KilosNetos = request.KilosNetos;
                notaSalidaAlmacenPlantaDetalle.Tara = request.Tara;
                notaSalidaAlmacenPlantaDetalle.AlmacenId = request.AlmacenId;                
                notaSalidaAlmacenPlantaDetalle.TipoId = controlCalidadPlanta.TipoId;
                notaSalidaAlmacenPlantaDetalle.EmpaqueId = controlCalidadPlanta.EmpaqueId;
                notaSalidaAlmacenPlantaDetalle.Cantidad = request.Cantidad;                

                registrarNotaSalidaAlmacenPlantaRequestDTO.ListNotaSalidaAlmacenPlantaDetalle.Add(notaSalidaAlmacenPlantaDetalle);

                this.registrarNotaSalidaAlmacenPlanta(registrarNotaSalidaAlmacenPlantaRequestDTO);

                #endregion Nota Salida Almacen

            }

            #region Detalle 

            if (controlCalidadPlanta != null)
            {
                
                controlCalidadPlanta.AnalisisFisicoColorDetalle = _IControlCalidadPlantaRepository.ConsultarControlCalidadPlantaAnalisisFisicoColorDetallePorId(controlCalidadPlanta.ControlCalidadPlantaId).ToList();

                controlCalidadPlanta.AnalisisFisicoOlorDetalle = _IControlCalidadPlantaRepository.ConsultarControlCalidadPlantaAnalisisFisicoOlorDetallePorId(controlCalidadPlanta.ControlCalidadPlantaId).ToList();

                controlCalidadPlanta.AnalisisFisicoDefectoPrimarioDetalle = _IControlCalidadPlantaRepository.ConsultarControlCalidadPlantaAnalisisFisicoDefectoPrimarioDetallePorId(controlCalidadPlanta.ControlCalidadPlantaId).ToList();

                controlCalidadPlanta.AnalisisFisicoDefectoSecundarioDetalle = _IControlCalidadPlantaRepository.ConsultarControlCalidadPlantaAnalisisFisicoDefectoSecundarioDetallePorId(controlCalidadPlanta.ControlCalidadPlantaId).ToList();

                controlCalidadPlanta.AnalisisSensorialAtributoDetalle = _IControlCalidadPlantaRepository.ConsultarControlCalidadPlantaAnalisisSensorialAtributoDetallePorId(controlCalidadPlanta.ControlCalidadPlantaId).ToList();

                controlCalidadPlanta.AnalisisSensorialDefectoDetalle = _IControlCalidadPlantaRepository.ConsultarControlCalidadPlantaAnalisisSensorialDefectoDetallePorId(controlCalidadPlanta.ControlCalidadPlantaId).ToList();

                controlCalidadPlanta.RegistroTostadoIndicadorDetalle = _IControlCalidadPlantaRepository.ConsultarControlCalidadPlantaRegistroTostadoIndicadorDetallePorId(controlCalidadPlanta.ControlCalidadPlantaId).ToList();


                #region "Analisis Fisico Color"
                if (controlCalidadPlanta.AnalisisFisicoColorDetalle.FirstOrDefault() != null)
                {

                    List<NotaIngresoAlmacenPlantaAnalisisFisicoColorDetalleTipo> AnalisisFisicoColorDetalleList = new List<NotaIngresoAlmacenPlantaAnalisisFisicoColorDetalleTipo>();

                    controlCalidadPlanta.AnalisisFisicoColorDetalle.ForEach(z =>
                    {
                        NotaIngresoAlmacenPlantaAnalisisFisicoColorDetalleTipo item = new NotaIngresoAlmacenPlantaAnalisisFisicoColorDetalleTipo();
                        item.ColorDetalleDescripcion = z.ColorDetalleDescripcion;
                        item.ColorDetalleId = z.ColorDetalleId;
                        item.NotaIngresoAlmacenPlantaId = notaIngresoAlmacenPlantaId;
                        item.Valor = z.Valor;
                        AnalisisFisicoColorDetalleList.Add(item);
                    });

                    affected = _NotaIngresoAlmacenPlantaRepository.ActualizarNotaIngresoAlmacenPlantaAnalisisFisicoColorDetalle(AnalisisFisicoColorDetalleList, notaIngresoAlmacenPlantaId);
                }
                #endregion

                #region Analisis Fisico Defecto Primario
                if (controlCalidadPlanta.AnalisisFisicoDefectoPrimarioDetalle.FirstOrDefault() != null)
                {
                    List<NotaIngresoAlmacenPlantaAnalisisFisicoDefectoPrimarioDetalleTipo> AnalisisFisicoDefectoPrimarioDetalleList = new List<NotaIngresoAlmacenPlantaAnalisisFisicoDefectoPrimarioDetalleTipo>();

                    controlCalidadPlanta.AnalisisFisicoDefectoPrimarioDetalle.ForEach(z =>
                    {
                        NotaIngresoAlmacenPlantaAnalisisFisicoDefectoPrimarioDetalleTipo item = new NotaIngresoAlmacenPlantaAnalisisFisicoDefectoPrimarioDetalleTipo();
                        item.DefectoDetalleId = z.DefectoDetalleId;
                        item.DefectoDetalleDescripcion = z.DefectoDetalleDescripcion;
                        item.DefectoDetalleEquivalente = z.DefectoDetalleEquivalente;
                        item.NotaIngresoAlmacenPlantaId = notaIngresoAlmacenPlantaId;
                        item.Valor = z.Valor;
                        AnalisisFisicoDefectoPrimarioDetalleList.Add(item);
                    });

                    affected = _INotaIngresoAlmacenPlantaRepository.ActualizarNotaIngresoAlmacenPlantaAnalisisFisicoDefectoPrimarioDetalle(AnalisisFisicoDefectoPrimarioDetalleList, notaIngresoAlmacenPlantaId);
                }
                #endregion

                #region "Analisis Fisico Defecto Secundario Detalle"
                if (controlCalidadPlanta.AnalisisFisicoDefectoSecundarioDetalle.FirstOrDefault() != null)
                {
                    List<NotaIngresoAlmacenPlantaAnalisisFisicoDefectoSecundarioDetalleTipo> AnalisisFisicoDefectoSecundarioDetalleList = new List<NotaIngresoAlmacenPlantaAnalisisFisicoDefectoSecundarioDetalleTipo>();

                    controlCalidadPlanta.AnalisisFisicoDefectoSecundarioDetalle.ForEach(z =>
                    {
                        NotaIngresoAlmacenPlantaAnalisisFisicoDefectoSecundarioDetalleTipo item = new NotaIngresoAlmacenPlantaAnalisisFisicoDefectoSecundarioDetalleTipo();
                        item.DefectoDetalleId = z.DefectoDetalleId;
                        item.DefectoDetalleDescripcion = z.DefectoDetalleDescripcion;
                        item.DefectoDetalleEquivalente = z.DefectoDetalleEquivalente;
                        item.NotaIngresoAlmacenPlantaId = notaIngresoAlmacenPlantaId;
                        item.Valor = z.Valor;
                        AnalisisFisicoDefectoSecundarioDetalleList.Add(item);
                    });

                    affected = _INotaIngresoAlmacenPlantaRepository.ActualizarNotaIngresoAlmacenPlantaAnalisisFisicoDefectoSecundarioDetalle(AnalisisFisicoDefectoSecundarioDetalleList, notaIngresoAlmacenPlantaId);
                }
                #endregion

                #region "Analisis Fisico Olor Detalle"
                if (controlCalidadPlanta.AnalisisFisicoOlorDetalle.FirstOrDefault() != null)
                {
                    List<NotaIngresoAlmacenPlantaAnalisisFisicoOlorDetalleTipo> AnalisisFisicoDefectoSecundarioDetalleList = new List<NotaIngresoAlmacenPlantaAnalisisFisicoOlorDetalleTipo>();

                    controlCalidadPlanta.AnalisisFisicoOlorDetalle.ForEach(z =>
                    {
                        NotaIngresoAlmacenPlantaAnalisisFisicoOlorDetalleTipo item = new NotaIngresoAlmacenPlantaAnalisisFisicoOlorDetalleTipo();
                        item.NotaIngresoAlmacenPlantaId = notaIngresoAlmacenPlantaId;
                        item.OlorDetalleDescripcion = z.OlorDetalleDescripcion;
                        item.OlorDetalleId = z.OlorDetalleId;
                        item.Valor = z.Valor;
                        AnalisisFisicoDefectoSecundarioDetalleList.Add(item);
                    });

                    affected = _INotaIngresoAlmacenPlantaRepository.ActualizarNotaIngresoAlmacenPlantaAnalisisFisicoOlorDetalle(AnalisisFisicoDefectoSecundarioDetalleList, notaIngresoAlmacenPlantaId);
                }
                #endregion

                #region "Analisis Sensorial Atributo"
                if (controlCalidadPlanta.AnalisisSensorialAtributoDetalle.FirstOrDefault() != null)
                {
                    List<NotaIngresoAlmacenPlantaAnalisisSensorialAtributoDetalleTipo> AnalisisSensorialAtributoDetalle = new List<NotaIngresoAlmacenPlantaAnalisisSensorialAtributoDetalleTipo>();

                    controlCalidadPlanta.AnalisisSensorialAtributoDetalle.ForEach(z =>
                    {
                        NotaIngresoAlmacenPlantaAnalisisSensorialAtributoDetalleTipo item = new NotaIngresoAlmacenPlantaAnalisisSensorialAtributoDetalleTipo();
                        item.NotaIngresoAlmacenPlantaId = notaIngresoAlmacenPlantaId;
                        item.AtributoDetalleDescripcion = z.AtributoDetalleDescripcion;
                        item.AtributoDetalleId = z.AtributoDetalleId;
                        item.Valor = z.Valor;
                        AnalisisSensorialAtributoDetalle.Add(item);
                    });

                    affected = _INotaIngresoAlmacenPlantaRepository.ActualizarNotaIngresoAlmacenPlantaAnalisisSensorialAtributoDetalle(AnalisisSensorialAtributoDetalle, notaIngresoAlmacenPlantaId);
                }
                #endregion

                #region AnalisisSensorialDefectoDetalle

                if (controlCalidadPlanta.AnalisisSensorialDefectoDetalle.FirstOrDefault() != null)
                {
                    List<NotaIngresoAlmacenPlantaAnalisisSensorialDefectoDetalleTipo> AnalisisSensorialDefectoDetalle = new List<NotaIngresoAlmacenPlantaAnalisisSensorialDefectoDetalleTipo>();

                    controlCalidadPlanta.AnalisisSensorialDefectoDetalle.ForEach(z =>
                    {
                        NotaIngresoAlmacenPlantaAnalisisSensorialDefectoDetalleTipo item = new NotaIngresoAlmacenPlantaAnalisisSensorialDefectoDetalleTipo();
                        item.NotaIngresoAlmacenPlantaId = notaIngresoAlmacenPlantaId;
                        item.DefectoDetalleDescripcion = z.DefectoDetalleDescripcion;
                        item.DefectoDetalleId = z.DefectoDetalleId;

                        item.Valor = z.Valor;
                        AnalisisSensorialDefectoDetalle.Add(item);
                    });

                    affected = _INotaIngresoAlmacenPlantaRepository.ActualizarNotaIngresoAlmacenPlantaAnalisisSensorialDefectoDetalle(AnalisisSensorialDefectoDetalle, notaIngresoAlmacenPlantaId);
                }

                #endregion AnalisisSensorialDefectoDetalle

                #region RegistroTostadoIndicadorDetalle

                if (controlCalidadPlanta.RegistroTostadoIndicadorDetalle.FirstOrDefault() != null)
                {
                    List<NotaIngresoAlmacenPlantaRegistroTostadoIndicadorDetalleTipo> RegistroTostadoIndicadorDetalle = new List<NotaIngresoAlmacenPlantaRegistroTostadoIndicadorDetalleTipo>();

                    controlCalidadPlanta.RegistroTostadoIndicadorDetalle.ForEach(z =>
                    {

                        NotaIngresoAlmacenPlantaRegistroTostadoIndicadorDetalleTipo item = new NotaIngresoAlmacenPlantaRegistroTostadoIndicadorDetalleTipo();
                        item.NotaIngresoAlmacenPlantaId = notaIngresoAlmacenPlantaId;
                        item.IndicadorDetalleDescripcion = z.IndicadorDetalleDescripcion;
                        item.IndicadorDetalleId = z.IndicadorDetalleId;
                        item.Valor = z.Valor;

                        RegistroTostadoIndicadorDetalle.Add(item);
                    });

                    affected = _INotaIngresoAlmacenPlantaRepository.ActualizarNotaIngresoAlmacenPlantaRegistroTostadoIndicadorDetalle(RegistroTostadoIndicadorDetalle, notaIngresoAlmacenPlantaId);
                }

                #endregion RegistroTostadoIndicadorDetalle

            }



            #endregion Detalle


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
                    NotaSalidaAlmacenPlantaDetalle notaSalidaAlmacenPlantaDetalle = new NotaSalidaAlmacenPlantaDetalle();
                    notaSalidaAlmacenPlantaDetalle.NotaIngresoAlmacenPlantaId = x.NotaIngresoAlmacenPlantaId;
                    notaSalidaAlmacenPlantaDetalle.NotaSalidaAlmacenPlantaId = notaSalidaAlmacen.NotaSalidaAlmacenPlantaId;
                    notaSalidaAlmacenPlantaDetalle.EmpaqueId = x.EmpaqueId;
                    notaSalidaAlmacenPlantaDetalle.TipoId = x.TipoId;
                    notaSalidaAlmacenPlantaDetalle.ProductoId = request.ProductoId;
                    notaSalidaAlmacenPlantaDetalle.SubProductoId = request.SubProductoId;
                    notaSalidaAlmacenPlantaDetalle.Cantidad = x.Cantidad;
                    notaSalidaAlmacenPlantaDetalle.KilosBrutos = x.KilosBrutos;
                    notaSalidaAlmacenPlantaDetalle.KilosNetos = x.KilosNetos;
                    notaSalidaAlmacenPlantaDetalle.Tara = x.Tara;


                    //lstnotaSalidaAlmacen.Add(obj);

                    _INotaSalidaAlmacenPlantaRepository.InsertarNotaSalidaAlmacenPlantaDetalle(notaSalidaAlmacenPlantaDetalle);


                    if (x.NotaIngresoAlmacenPlantaId.HasValue)
                    {
                        TablaIdsTipo tablaLoteIdsTipo = new TablaIdsTipo();
                        tablaLoteIdsTipo.Id = x.NotaIngresoAlmacenPlantaId.Value;
                        notaIngresoIdActualizar.Add(tablaLoteIdsTipo);
                    }


                });

                //affected = _INotaSalidaAlmacenPlantaRepository.ActualizarNotaSalidaAlmacenPlantaDetalle(lstnotaSalidaAlmacen, notaSalidaAlmacen.NotaSalidaAlmacenPlantaId);

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
               
                consultaNotaIngresoAlmacenPlantaPorIdBE.AnalisisFisicoColorDetalle = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaAnalisisFisicoColorDetallePorId(consultaNotaIngresoAlmacenPlantaPorIdBE.NotaIngresoAlmacenPlantaId).ToList();

                consultaNotaIngresoAlmacenPlantaPorIdBE.AnalisisFisicoOlorDetalle = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaAnalisisFisicoOlorDetallePorId(consultaNotaIngresoAlmacenPlantaPorIdBE.NotaIngresoAlmacenPlantaId).ToList();

                consultaNotaIngresoAlmacenPlantaPorIdBE.AnalisisFisicoDefectoPrimarioDetalle = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaAnalisisFisicoDefectoPrimarioDetallePorId(consultaNotaIngresoAlmacenPlantaPorIdBE.NotaIngresoAlmacenPlantaId).ToList();

                consultaNotaIngresoAlmacenPlantaPorIdBE.AnalisisFisicoDefectoSecundarioDetalle = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaAnalisisFisicoDefectoSecundarioDetallePorId(consultaNotaIngresoAlmacenPlantaPorIdBE.NotaIngresoAlmacenPlantaId).ToList();

                consultaNotaIngresoAlmacenPlantaPorIdBE.AnalisisSensorialAtributoDetalle = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaAnalisisSensorialAtributoDetallePorId(consultaNotaIngresoAlmacenPlantaPorIdBE.NotaIngresoAlmacenPlantaId).ToList();

                consultaNotaIngresoAlmacenPlantaPorIdBE.AnalisisSensorialDefectoDetalle = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaAnalisisSensorialDefectoDetallePorId(consultaNotaIngresoAlmacenPlantaPorIdBE.NotaIngresoAlmacenPlantaId).ToList();

                consultaNotaIngresoAlmacenPlantaPorIdBE.RegistroTostadoIndicadorDetalle = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaRegistroTostadoIndicadorDetallePorId(consultaNotaIngresoAlmacenPlantaPorIdBE.NotaIngresoAlmacenPlantaId).ToList();

                
            }

            return consultaNotaIngresoAlmacenPlantaPorIdBE;
        }


        public int AnularNotaIngresoAlmacenPlanta(AnularNotaIngresoAlmacenPlantaRequestDTO request)
        {
            int affected = 0;

            ConsultaNotaIngresoAlmacenPlantaPorIdBE consultaNotaIngresoAlmacenPlantaPorIdBE = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaPorId(request.NotaIngresoAlmacenPlantaId);

            if(consultaNotaIngresoAlmacenPlantaPorIdBE!=null)
            {
                ConsultaControlCalidadPlantaPorIdBE controlCalidadPlanta = _IControlCalidadPlantaRepository.ConsultaControlCalidadPlantaPorId(consultaNotaIngresoAlmacenPlantaPorIdBE.ControlCalidadPlantaId);

                string controlCalidadPlantaEstadoId = String.Empty;
                                

                if (controlCalidadPlanta.EstadoCalidadId == ControlCalidadEstados.EnviadoAlmacen)
                {
                    controlCalidadPlantaEstadoId = ControlCalidadEstados.Analizado;
                }

                _INotaIngresoAlmacenPlantaRepository.ActualizarEstado(request.NotaIngresoAlmacenPlantaId, DateTime.Now, request.Usuario, NotaIngresoAlmacenPlantaEstados.Anulado);

                _IControlCalidadPlantaRepository.ActualizarCantidadProcesadaEstado(controlCalidadPlanta.ControlCalidadPlantaId, controlCalidadPlanta.CantidadProcesada - consultaNotaIngresoAlmacenPlantaPorIdBE.Cantidad.Value, controlCalidadPlanta.KilosNetosProcesado - consultaNotaIngresoAlmacenPlantaPorIdBE.KilosNetos.Value, DateTime.Now, request.Usuario, controlCalidadPlantaEstadoId);

            }          

            return affected;
        }
    }
}
