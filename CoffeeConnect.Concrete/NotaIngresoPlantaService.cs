
using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using Core.Common.Domain.Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeConnect.Service
{
    public partial class NotaIngresoPlantaService : INotaIngresoPlantaService
    {
        private readonly IMapper _Mapper;
        private INotaIngresoPlantaRepository _INotaIngresoPlantaRepository;

        private IControlCalidadPlantaRepository _IControlCalidadPlantaRepository;
        private ICorrelativoRepository _ICorrelativoRepository;
 
        public IOptions<ParametrosSettings> _ParametrosSettings;
        private IMaestroRepository _IMaestroRepository;

        private INotaIngresoProductoTerminadoAlmacenPlantaRepository _INotaIngresoProductoTerminadoAlmacenPlantaRepository;

        public NotaIngresoPlantaService(INotaIngresoPlantaRepository NotaIngresoPlanta, INotaIngresoProductoTerminadoAlmacenPlantaRepository notaIngresoProductoTerminadoAlmacenPlantaRepository, ICorrelativoRepository correlativoRepository,
        IOptions<ParametrosSettings> parametrosSettings, IMapper mapper, IMaestroRepository maestroRepository, IControlCalidadPlantaRepository controlCalidadRepository)
        {
            _INotaIngresoPlantaRepository = NotaIngresoPlanta;
            _ICorrelativoRepository = correlativoRepository;
            _ParametrosSettings = parametrosSettings;
            _Mapper = mapper;
            _IMaestroRepository = maestroRepository;
            _IControlCalidadPlantaRepository = controlCalidadRepository;
            _INotaIngresoProductoTerminadoAlmacenPlantaRepository = notaIngresoProductoTerminadoAlmacenPlantaRepository;
        }
        
        public List<ConsultaNotaIngresoPlantaBE> ConsultarNotaIngresoPlanta(ConsultaNotaIngresoPlantaRequestDTO request )
        {

            {
                /*
                if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFin == null || request.FechaFin == DateTime.MinValue || string.IsNullOrEmpty(request.EstadoId))
                    throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.NotaIngresoPlanta.ValidacionSeleccioneMinimoUnFiltro.Label" });

                var timeSpan = request.FechaFin - request.FechaInicio;

                if (timeSpan.Days > 730)
                    throw new ResultException(new Result { ErrCode = "02", Message = "Acopio.NotaIngresoPlanta.ValidacionRangoFechaMayor2anios.Label" });
                */

                request.CodigoTipo = TiposCorrelativosPlanta.NotaIngresoPlantaTipo;
                var list = _INotaIngresoPlantaRepository.ConsultarNotaIngresoPlanta(request);
                
                foreach(ConsultaNotaIngresoPlantaBE obj in list)
                {
                    // obtener certificaciones
                    List<ConsultaDetalleTablaBE> lista = _IMaestroRepository.ConsultarDetalleTablaDeTablas(request.EmpresaId, String.Empty).ToList();
                    string[] certificacionesIds = obj.CertificacionId.Split('|');
                    string certificacionLabel = string.Empty;
                    if (certificacionesIds.Length > 0)
                    {
                        List<ConsultaDetalleTablaBE> certificaciones = lista.Where(a => a.CodigoTabla.Trim().Equals("TipoCertificacionPlanta")).ToList();
                        foreach (string certificacionId in certificacionesIds)
                        {
                            ConsultaDetalleTablaBE certificacion = certificaciones.Where(a => a.Codigo == certificacionId).FirstOrDefault();
                            if (certificacion != null)
                            {
                                certificacionLabel = certificacionLabel + certificacion.Label + " ";
                            }
                        }
                    }

                    // obtener certificaciones
                    obj.Certificacion = certificacionLabel;
                }
                return list.ToList();
         
            }
           
       }

        public int AnularNotaIngresoPlanta(AnularNotaIngresoPlantaRequestDTO request)
        {
            int affected = _INotaIngresoPlantaRepository.ActualizarEstado(request.NotaIngresoPlantaId, DateTime.Now, request.Usuario, NotaIngresoPlantaEstados.Anulado);

            return affected;
        }

        public int EnviarAlmacen(EnviarAlmacenNotaIngresoPlantaRequestDTO request)
        {
            int notaIngresoPlantaId = request.NotaIngresoPlantaId;            

            ConsultaNotaIngresoPlantaPorIdBE consultaNotaIngresoPlantaPorIdBE = _INotaIngresoPlantaRepository.ConsultarNotaIngresoPlantaPorId(notaIngresoPlantaId);

            if(consultaNotaIngresoPlantaPorIdBE!=null && consultaNotaIngresoPlantaPorIdBE.NotaIngresoPlantaId !=0)
            {

                List<ConsultaNotaIngresoPlantaDetalle> detalleNotaIngresoPlantaDetalle = _INotaIngresoPlantaRepository.ConsultarNotaIngresoPlantaDetallePorId(notaIngresoPlantaId).ToList();

                if (detalleNotaIngresoPlantaDetalle != null && detalleNotaIngresoPlantaDetalle.Any())
                {
                    foreach (ConsultaNotaIngresoPlantaDetalle detalle in detalleNotaIngresoPlantaDetalle)
                    {
                        NotaIngresoProductoTerminadoAlmacenPlanta notaIngresoProductoTerminadoAlmacenPlanta = new NotaIngresoProductoTerminadoAlmacenPlanta();

                        notaIngresoProductoTerminadoAlmacenPlanta.NotaIngresoPlantaId = notaIngresoPlantaId;
                        notaIngresoProductoTerminadoAlmacenPlanta.Numero = _ICorrelativoRepository.Obtener(consultaNotaIngresoPlantaPorIdBE.EmpresaId, Documentos.NotaIngresoProductoTerminadoAlmacenPlanta);
                        notaIngresoProductoTerminadoAlmacenPlanta.ProductoId = consultaNotaIngresoPlantaPorIdBE.ProductoId;
                        notaIngresoProductoTerminadoAlmacenPlanta.SubProductoId = detalle.SubProductoId;
                        notaIngresoProductoTerminadoAlmacenPlanta.Cantidad = detalle.Cantidad;
                        notaIngresoProductoTerminadoAlmacenPlanta.KilosNetos = detalle.KilosNetos;
                        notaIngresoProductoTerminadoAlmacenPlanta.MotivoIngresoId = consultaNotaIngresoPlantaPorIdBE.MotivoIngresoId; // Liquidacion Proceso
                        notaIngresoProductoTerminadoAlmacenPlanta.TipoId = detalle.TipoId;
                        notaIngresoProductoTerminadoAlmacenPlanta.EmpaqueId = detalle.EmpaqueId;
                        notaIngresoProductoTerminadoAlmacenPlanta.EmpresaId = consultaNotaIngresoPlantaPorIdBE.EmpresaId;
                        notaIngresoProductoTerminadoAlmacenPlanta.EstadoId = NotaIngresoProductoTerminadoAlmacenPlantaEstados.Ingresado;
                        notaIngresoProductoTerminadoAlmacenPlanta.FechaRegistro = DateTime.Now;
                        notaIngresoProductoTerminadoAlmacenPlanta.UsuarioRegistro = request.Usuario;

                        _INotaIngresoProductoTerminadoAlmacenPlantaRepository.Insertar(notaIngresoProductoTerminadoAlmacenPlanta);
                    }
                }
            }          

            

            int affected = _INotaIngresoPlantaRepository.ActualizarEstado(request.NotaIngresoPlantaId, DateTime.Now, request.Usuario, NotaIngresoPlantaEstados.EnviadoAlmacen);

            return affected;
        }

        public ConsultaNotaIngresoPlantaPorIdBE ConsultarNotaIngresoPlantaPorId(ConsultaNotaIngresoPlantaPorIdRequestDTO request)
        {
            int NotaIngresoPlantaId = request.NotaIngresoPlantaId;

            ConsultaNotaIngresoPlantaPorIdBE consultaNotaIngresoPlantaPorIdBE = _INotaIngresoPlantaRepository.ConsultarNotaIngresoPlantaPorId(request.NotaIngresoPlantaId);

            if (consultaNotaIngresoPlantaPorIdBE != null)
            {
                if (consultaNotaIngresoPlantaPorIdBE.EstadoId != NotaIngresoPlantaEstados.Pesado)
                {
                    consultaNotaIngresoPlantaPorIdBE.AnalisisFisicoColorDetalle = _INotaIngresoPlantaRepository.ConsultarNotaIngresoPlantaAnalisisFisicoColorDetallePorId(NotaIngresoPlantaId).ToList();

                    consultaNotaIngresoPlantaPorIdBE.AnalisisFisicoOlorDetalle = _INotaIngresoPlantaRepository.ConsultarNotaIngresoPlantaAnalisisFisicoOlorDetallePorId(NotaIngresoPlantaId).ToList();

                    consultaNotaIngresoPlantaPorIdBE.AnalisisFisicoDefectoPrimarioDetalle = _INotaIngresoPlantaRepository.ConsultarNotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetallePorId(NotaIngresoPlantaId).ToList();

                    consultaNotaIngresoPlantaPorIdBE.AnalisisFisicoDefectoSecundarioDetalle = _INotaIngresoPlantaRepository.ConsultarNotaIngresoPlantaAnalisisFisicoDefectoSecundarioDetallePorId(NotaIngresoPlantaId).ToList();

                    consultaNotaIngresoPlantaPorIdBE.AnalisisSensorialAtributoDetalle = _INotaIngresoPlantaRepository.ConsultarNotaIngresoPlantaAnalisisSensorialAtributoDetallePorId(NotaIngresoPlantaId).ToList();

                    consultaNotaIngresoPlantaPorIdBE.AnalisisSensorialDefectoDetalle = _INotaIngresoPlantaRepository.ConsultarNotaIngresoPlantaAnalisisSensorialDefectoDetallePorId(NotaIngresoPlantaId).ToList();

                    consultaNotaIngresoPlantaPorIdBE.RegistroTostadoIndicadorDetalle = _INotaIngresoPlantaRepository.ConsultarNotaIngresoPlantaRegistroTostadoIndicadorDetallePorId(NotaIngresoPlantaId).ToList();

                }

                IEnumerable<ConsultaNotaIngresoPlantaDetalle> detalle = _INotaIngresoPlantaRepository.ConsultarNotaIngresoPlantaDetallePorId(NotaIngresoPlantaId);

                if(detalle!=null && detalle.Any())
                {
                    consultaNotaIngresoPlantaPorIdBE.Detalle = detalle.ToList();
                }
            }



            return consultaNotaIngresoPlantaPorIdBE;

        }

        public int RegistrarPesadoNotaIngresoPlanta(RegistrarActualizarPesadoNotaIngresoPlantaRequestDTO request)
        {
            NotaIngresoPlanta NotaIngresoPlanta = _Mapper.Map<NotaIngresoPlanta>(request);


            // NotaIngresoPlanta.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.NotaIngresoPlanta);
            NotaIngresoPlanta.Numero = _ICorrelativoRepository.ObtenerCorrelativoNotaIngreso(DateTime.Now.Year.ToString(), TiposCorrelativosPlanta.NotaIngresoPlantaTipo, request.CodigoTipoConcepto);

            decimal kilosNetos = 0;
            decimal kilosBrutos = 0;
            decimal cantidad = 0;
            decimal tara = 0;

            NotaIngresoPlanta.FechaPesado = DateTime.Now;
            NotaIngresoPlanta.EstadoId = NotaIngresoPlantaEstados.Pesado;
            NotaIngresoPlanta.FechaRegistro = DateTime.Now;
            NotaIngresoPlanta.UsuarioRegistro = request.UsuarioPesado;

            if (request.NotaIngresoPlantaDetalle != null && request.NotaIngresoPlantaDetalle.Count > 0)
            {
                foreach (NotaIngresoPlantaDetalle notaIngresoPlantaDetalle in request.NotaIngresoPlantaDetalle)
                {
                    kilosNetos = kilosNetos + notaIngresoPlantaDetalle.KilosNetos;
                    kilosBrutos = kilosBrutos + notaIngresoPlantaDetalle.KilosBrutos;
                    cantidad = cantidad + notaIngresoPlantaDetalle.Cantidad;
                    tara = tara + notaIngresoPlantaDetalle.Tara;
                }
            }

            NotaIngresoPlanta.Cantidad = cantidad;
            NotaIngresoPlanta.KilosNetos = kilosNetos;
            NotaIngresoPlanta.KilosBrutos = kilosBrutos;
            NotaIngresoPlanta.Tara = tara;

            int notaIngresoPlantaId = _INotaIngresoPlantaRepository.InsertarPesado(NotaIngresoPlanta);


            if(request.NotaIngresoPlantaDetalle!=null && request.NotaIngresoPlantaDetalle.Count>0)
            {
                foreach(NotaIngresoPlantaDetalle notaIngresoPlantaDetalle in request.NotaIngresoPlantaDetalle)
                {
                    kilosNetos = kilosNetos + notaIngresoPlantaDetalle.KilosNetos;
                    kilosBrutos = kilosBrutos + notaIngresoPlantaDetalle.KilosBrutos;
                    cantidad = cantidad + notaIngresoPlantaDetalle.Cantidad;

                    notaIngresoPlantaDetalle.NotaIngresoPlantaId= notaIngresoPlantaId;

                    _INotaIngresoPlantaRepository.InsertarNotaIngresoPlantaDetalle(notaIngresoPlantaDetalle);

                }

            }
            return notaIngresoPlantaId;
        }

        public int ActualizarPesadoNotaIngresoPlanta(RegistrarActualizarPesadoNotaIngresoPlantaRequestDTO request)
        {
            NotaIngresoPlanta NotaIngresoPlanta = _Mapper.Map<NotaIngresoPlanta>(request);

            NotaIngresoPlanta.FechaPesado = DateTime.Now;
            NotaIngresoPlanta.UsuarioPesado = request.UsuarioPesado;

            NotaIngresoPlanta.EstadoId = NotaIngresoPlantaEstados.Pesado;
            NotaIngresoPlanta.FechaUltimaActualizacion = DateTime.Now;
            NotaIngresoPlanta.UsuarioUltimaActualizacion = request.UsuarioPesado;


            int affected = _INotaIngresoPlantaRepository.ActualizarPesado(NotaIngresoPlanta);


            return affected;
        }

        public int ActualizarNotaIngresoPlantaAnalisisCalidad(ActualizarNotaIngresoPlantaAnalisisCalidadRequestDTO request)
        {

            NotaIngresoPlanta NotaIngresoPlanta = new NotaIngresoPlanta();
            //para control calidad
            NotaIngresoPlanta.ControlCalidadPlantaId = request.ControlCalidadPlantaId;
            NotaIngresoPlanta.CantidadControlCalidad = request.CantidadControlCalidad;
            NotaIngresoPlanta.PesoBrutoControlCalidad = request.PesoBrutoControlCalidad;
            NotaIngresoPlanta.TaraControlCalidad = request.TaraControlCalidad;
            NotaIngresoPlanta.KilosNetosControlCalidad = request.KilosNetosControlCalidad;
            NotaIngresoPlanta.ControlCalidadTipoId = request.ControlCalidadTipoId;
            NotaIngresoPlanta.ControlCalidadEmpaqueId = request.ControlCalidadEmpaqueId;

            //para control calidad


            NotaIngresoPlanta.NotaIngresoPlantaId = request.NotaIngresoPlantaId;
            NotaIngresoPlanta.ExportableGramosAnalisisFisico = request.ExportableGramosAnalisisFisico;
            NotaIngresoPlanta.ExportablePorcentajeAnalisisFisico = request.ExportablePorcentajeAnalisisFisico;
            NotaIngresoPlanta.DescarteGramosAnalisisFisico = request.DescarteGramosAnalisisFisico;
            NotaIngresoPlanta.DescartePorcentajeAnalisisFisico = request.DescartePorcentajeAnalisisFisico;
            NotaIngresoPlanta.CascarillaGramosAnalisisFisico = request.CascarillaGramosAnalisisFisico;
            NotaIngresoPlanta.CascarillaPorcentajeAnalisisFisico = request.CascarillaPorcentajeAnalisisFisico;
            NotaIngresoPlanta.TotalGramosAnalisisFisico = request.TotalGramosAnalisisFisico;
            NotaIngresoPlanta.TotalPorcentajeAnalisisFisico = request.TotalPorcentajeAnalisisFisico;
            NotaIngresoPlanta.HumedadPorcentajeAnalisisFisico = request.HumedadPorcentajeAnalisisFisico;
            NotaIngresoPlanta.ObservacionAnalisisFisico = request.ObservacionAnalisisFisico;
            NotaIngresoPlanta.UsuarioCalidad = request.UsuarioCalidad;
            NotaIngresoPlanta.ObservacionRegistroTostado = request.ObservacionRegistroTostado;
            NotaIngresoPlanta.ObservacionAnalisisSensorial = request.ObservacionAnalisisSensorial;
            NotaIngresoPlanta.UsuarioCalidad = request.UsuarioCalidad;
            
            
            ConsultaNotaIngresoPlantaPorIdRequestDTO consultaNotaIngresoPlantaPorIdRequestDTO = new ConsultaNotaIngresoPlantaPorIdRequestDTO();
            consultaNotaIngresoPlantaPorIdRequestDTO.NotaIngresoPlantaId = request.NotaIngresoPlantaId;           
            ConsultaNotaIngresoPlantaPorIdBE consultaNotaIngresoPlantaPorIdBE = this.ConsultarNotaIngresoPlantaPorId(consultaNotaIngresoPlantaPorIdRequestDTO);
           
            
            decimal saldoDisponible = consultaNotaIngresoPlantaPorIdBE.Cantidad - consultaNotaIngresoPlantaPorIdBE.CantidadProcesada;
            decimal saldoKilosNetosDisponible = consultaNotaIngresoPlantaPorIdBE.KilosNetos  - consultaNotaIngresoPlantaPorIdBE.KilosNetosProcesado;

            if (saldoDisponible <= request.CantidadControlCalidad && saldoKilosNetosDisponible <= request.KilosNetosControlCalidad)
            {
                NotaIngresoPlanta.EstadoId = NotaIngresoPlantaEstados.Analizado;
            }
            else {
                NotaIngresoPlanta.EstadoId = NotaIngresoPlantaEstados.Pesado;
            }
            NotaIngresoPlanta.FechaCalidad = DateTime.Now;
            NotaIngresoPlanta.Taza = request.Taza;
            NotaIngresoPlanta.Intensidad = request.Intensidad;
            NotaIngresoPlanta.PuntajeFinal = request.PuntajeFinal;
            NotaIngresoPlanta.TazaIntensidad = request.TazaIntensidad;

            decimal totalAnalisisSensorial = 0;

            if (request.AnalisisSensorialAtributoDetalleList.FirstOrDefault() != null)
            {
                List<NotaIngresoPlantaAnalisisSensorialAtributoDetalleTipo> AnalisisSensorialAtributoDetalle = new List<NotaIngresoPlantaAnalisisSensorialAtributoDetalleTipo>();

                request.AnalisisSensorialAtributoDetalleList.ForEach(z =>
                {
                    if (z.Valor.HasValue)
                    {
                        totalAnalisisSensorial = totalAnalisisSensorial + z.Valor.Value;
                    }
                });

            }



            NotaIngresoPlanta.TotalAnalisisSensorial = totalAnalisisSensorial;
            //NotaIngresoPlanta.CantidadProcesada = consultaNotaIngresoPlantaPorIdBE.CantidadProcesada + NotaIngresoPlanta.CantidadControlCalidad;
            //NotaIngresoPlanta.KilosNetosProcesados = consultaNotaIngresoPlantaPorIdBE.KilosNetosProcesado + NotaIngresoPlanta.KilosNetosControlCalidad;

            ControlCalidadPlanta controlCalidadPlanta = _Mapper.Map<ControlCalidadPlanta>(NotaIngresoPlanta);

            int affected2 = _IControlCalidadPlantaRepository.ActualizarControlCalidad(controlCalidadPlanta);
            int affected = _INotaIngresoPlantaRepository.ActualizarAnalisisCalidad(NotaIngresoPlanta);
          

            #region "Analisis Fisico Color"
            if (request.AnalisisFisicoColorDetalleList.FirstOrDefault() != null)
            {

                List<ControlCalidadPlantaAnalisisFisicoColorDetalleTipo > AnalisisFisicoColorDetalleList = new List<ControlCalidadPlantaAnalisisFisicoColorDetalleTipo>();

                request.AnalisisFisicoColorDetalleList.ForEach(z =>
                {
                    ControlCalidadPlantaAnalisisFisicoColorDetalleTipo item = new ControlCalidadPlantaAnalisisFisicoColorDetalleTipo();
                    item.ColorDetalleDescripcion = z.ColorDetalleDescripcion;
                    item.ColorDetalleId = z.ColorDetalleId;
                    item.ControlCalidadPlantaId = request.ControlCalidadPlantaId;
                    item.Valor = z.Valor;
                    AnalisisFisicoColorDetalleList.Add(item);
                });

                affected = _IControlCalidadPlantaRepository.ActualizarControlCalidadPlantaAnalisisFisicoColorDetalle(AnalisisFisicoColorDetalleList, request.ControlCalidadPlantaId);
            }
            #endregion

            #region Analisis Fisico Defecto Primario
            if (request.AnalisisFisicoDefectoPrimarioDetalleList.FirstOrDefault() != null)
            {
                List<ControlCalidadPlantaAnalisisFisicoDefectoPrimarioDetalleTipo> AnalisisFisicoDefectoPrimarioDetalleList = new List<ControlCalidadPlantaAnalisisFisicoDefectoPrimarioDetalleTipo>();

                request.AnalisisFisicoDefectoPrimarioDetalleList.ForEach(z =>
                {
                    ControlCalidadPlantaAnalisisFisicoDefectoPrimarioDetalleTipo item = new ControlCalidadPlantaAnalisisFisicoDefectoPrimarioDetalleTipo();
                    item.DefectoDetalleId = z.DefectoDetalleId;
                    item.DefectoDetalleDescripcion = z.DefectoDetalleDescripcion;
                    item.DefectoDetalleEquivalente = z.DefectoDetalleEquivalente;
                    item.ControlCalidadPlantaId = request.ControlCalidadPlantaId;
                    item.Valor = z.Valor;
                    AnalisisFisicoDefectoPrimarioDetalleList.Add(item);
                });

                affected = _IControlCalidadPlantaRepository.ActualizarControlCalidadPlantaAnalisisFisicoDefectoPrimarioDetalle(AnalisisFisicoDefectoPrimarioDetalleList, request.ControlCalidadPlantaId);
            }
            #endregion

            #region "Analisis Fisico Defecto Secundario Detalle"
            if (request.AnalisisFisicoDefectoSecundarioDetalleList.FirstOrDefault() != null)
            {
                List<ControlCalidadPlantaAnalisisFisicoDefectoSecundarioDetalleTipo> AnalisisFisicoDefectoSecundarioDetalleList = new List<ControlCalidadPlantaAnalisisFisicoDefectoSecundarioDetalleTipo>();

                request.AnalisisFisicoDefectoSecundarioDetalleList.ForEach(z =>
                {
                    ControlCalidadPlantaAnalisisFisicoDefectoSecundarioDetalleTipo item = new ControlCalidadPlantaAnalisisFisicoDefectoSecundarioDetalleTipo();
                    item.DefectoDetalleId = z.DefectoDetalleId;
                    item.DefectoDetalleDescripcion = z.DefectoDetalleDescripcion;
                    item.DefectoDetalleEquivalente = z.DefectoDetalleEquivalente;
                    item.ControlCalidadPlantaId = request.ControlCalidadPlantaId;
                    item.Valor = z.Valor;
                    AnalisisFisicoDefectoSecundarioDetalleList.Add(item);
                });

                affected = _IControlCalidadPlantaRepository.ActualizarControlCalidadPlantaAnalisisFisicoDefectoSecundarioDetalle(AnalisisFisicoDefectoSecundarioDetalleList, request.ControlCalidadPlantaId);
            }
            #endregion

            #region "Analisis Fisico Olor Detalle"
            if (request.AnalisisFisicoOlorDetalleList.FirstOrDefault() != null)
            {
                List<ControlCalidadPlantaAnalisisFisicoOlorDetalleTipo> AnalisisFisicoDefectoSecundarioDetalleList = new List<ControlCalidadPlantaAnalisisFisicoOlorDetalleTipo>();

                request.AnalisisFisicoOlorDetalleList.ForEach(z =>
                {
                    ControlCalidadPlantaAnalisisFisicoOlorDetalleTipo item = new ControlCalidadPlantaAnalisisFisicoOlorDetalleTipo();
                    item.ControlCalidadPlantaId = request.ControlCalidadPlantaId;
                    item.OlorDetalleDescripcion = z.OlorDetalleDescripcion;
                    item.OlorDetalleId = z.OlorDetalleId;
                    item.Valor = z.Valor;
                    AnalisisFisicoDefectoSecundarioDetalleList.Add(item);
                });

                affected = _IControlCalidadPlantaRepository.ActualizarControlCalidadPlantaAnalisisFisicoOlorDetalle(AnalisisFisicoDefectoSecundarioDetalleList, request.ControlCalidadPlantaId);
            }
            #endregion

            #region "Analisis Sensorial Atributo"
            if (request.AnalisisSensorialAtributoDetalleList.FirstOrDefault() != null)
            {
                List<ControlCalidadPlantaAnalisisSensorialAtributoDetalleTipo> AnalisisSensorialAtributoDetalle = new List<ControlCalidadPlantaAnalisisSensorialAtributoDetalleTipo>();

                request.AnalisisSensorialAtributoDetalleList.ForEach(z =>
                {
                    ControlCalidadPlantaAnalisisSensorialAtributoDetalleTipo item = new ControlCalidadPlantaAnalisisSensorialAtributoDetalleTipo();
                    item.ControlCalidadPlantaId = request.ControlCalidadPlantaId;
                    item.AtributoDetalleDescripcion = z.AtributoDetalleDescripcion;
                    item.AtributoDetalleId = z.AtributoDetalleId;
                    item.Valor = z.Valor;
                    AnalisisSensorialAtributoDetalle.Add(item);
                });

                affected = _IControlCalidadPlantaRepository.ActualizarControlCalidadPlantaAnalisisSensorialAtributoDetalle(AnalisisSensorialAtributoDetalle, request.ControlCalidadPlantaId);
            }
            #endregion

            if (request.AnalisisSensorialDefectoDetalleList.FirstOrDefault() != null)
            {
                List<ControlCalidadPlantaAnalisisSensorialDefectoDetalleTipo> AnalisisSensorialDefectoDetalle = new List<ControlCalidadPlantaAnalisisSensorialDefectoDetalleTipo>();

                request.AnalisisSensorialDefectoDetalleList.ForEach(z =>
                {
                    ControlCalidadPlantaAnalisisSensorialDefectoDetalleTipo item = new ControlCalidadPlantaAnalisisSensorialDefectoDetalleTipo();
                    item.ControlCalidadPlantaId = request.ControlCalidadPlantaId;
                    item.DefectoDetalleDescripcion = z.DefectoDetalleDescripcion;
                    item.DefectoDetalleId = z.DefectoDetalleId;

                    item.Valor = z.Valor;
                    AnalisisSensorialDefectoDetalle.Add(item);
                });

                affected = _IControlCalidadPlantaRepository.ActualizarControlCalidadPlantaAnalisisSensorialDefectoDetalle(AnalisisSensorialDefectoDetalle, request.ControlCalidadPlantaId);
            }


            if (request.RegistroTostadoIndicadorDetalleList.FirstOrDefault() != null)
            {
                List<ControlCalidadPlantaRegistroTostadoIndicadorDetalleTipo> RegistroTostadoIndicadorDetalle = new List<ControlCalidadPlantaRegistroTostadoIndicadorDetalleTipo>();

                request.RegistroTostadoIndicadorDetalleList.ForEach(z =>
                {

                    ControlCalidadPlantaRegistroTostadoIndicadorDetalleTipo item = new ControlCalidadPlantaRegistroTostadoIndicadorDetalleTipo();
                    item.ControlCalidadPlantaId = request.ControlCalidadPlantaId;
                    item.IndicadorDetalleDescripcion = z.IndicadorDetalleDescripcion;
                    item.IndicadorDetalleId = z.IndicadorDetalleId;
                    item.Valor = z.Valor;

                    RegistroTostadoIndicadorDetalle.Add(item);
                });

                affected = _IControlCalidadPlantaRepository.ActualizarControlCalidadPlantaRegistroTostadoIndicadorDetalle(RegistroTostadoIndicadorDetalle, request.ControlCalidadPlantaId);
            }

            return affected;
        }


        public GenerarPDFGuiaRemisionResponseDTO GenerarPDFGuiaRemisionPorNotaIngreso(int notaSalidaAlmacenIdId, int empresaId)
        {
             GenerarPDFGuiaRemisionResponseDTO generarPDFGuiaRemisionResponseDTO = new GenerarPDFGuiaRemisionResponseDTO();

            ConsultaNotaIngresoPlantaPorIdBE consultaImpresionGuiaRemision = new ConsultaNotaIngresoPlantaPorIdBE();
            consultaImpresionGuiaRemision = _INotaIngresoPlantaRepository.ConsultarNotaIngresoPlantaPorId(notaSalidaAlmacenIdId);

            if (consultaImpresionGuiaRemision != null)
            {
                GuiaRemisionListaDetalle guiaRemisionListaDetalle = new GuiaRemisionListaDetalle();

                //descripcion = "  " + Convert.ToString(z.CantidadPesado) + " " + Convert.ToString(!string.IsNullOrEmpty(z.UnidadMedida) ? z.UnidadMedida.Trim() : String.Empty) + " Plastico" + "   " + Convert.ToString(!string.IsNullOrEmpty(z.Producto) ? z.Producto.Trim() : String.Empty) + "  " + Convert.ToString(!string.IsNullOrEmpty(z.SubProducto) ? z.SubProducto.Trim() : String.Empty) + "  " + Convert.ToString(!string.IsNullOrEmpty(z.TipoProduccion) ? z.TipoProduccion.Trim() : String.Empty) + "  " + Convert.ToString(!string.IsNullOrEmpty(z.TipoCertificacion) ? z.TipoCertificacion.Trim() : String.Empty);

                // obtener certificaciones
                List<ConsultaDetalleTablaBE> lista = _IMaestroRepository.ConsultarDetalleTablaDeTablas(empresaId, String.Empty).ToList();
                string[] certificacionesIds = consultaImpresionGuiaRemision.CertificacionId.Split('|');
                string certificacionLabel = string.Empty;
                if (certificacionesIds.Length > 0)
                {
                    List<ConsultaDetalleTablaBE> certificaciones = lista.Where(a => a.CodigoTabla.Trim().Equals("TipoCertificacionPlanta")).ToList();
                    foreach (string certificacionId in certificacionesIds)
                    {
                        ConsultaDetalleTablaBE certificacion = certificaciones.Where(a => a.Codigo == certificacionId).FirstOrDefault();
                        if (certificacion != null)
                        {
                            certificacionLabel = certificacionLabel + certificacion.Label + " ";
                        }
                    }
                }

                // obtener certificaciones


                guiaRemisionListaDetalle.TipoEmpaque = consultaImpresionGuiaRemision.TipoEmpaque;
                guiaRemisionListaDetalle.Empaque = consultaImpresionGuiaRemision.Empaque;
                guiaRemisionListaDetalle.Descripcion = consultaImpresionGuiaRemision.Producto + " - " + certificacionLabel;
                guiaRemisionListaDetalle.MontoBruto = consultaImpresionGuiaRemision.KilosBrutos;
                guiaRemisionListaDetalle.PesoNeto = consultaImpresionGuiaRemision.KilosNetos;
                guiaRemisionListaDetalle.Cantidad = consultaImpresionGuiaRemision.Cantidad;
                generarPDFGuiaRemisionResponseDTO.listaDetalleGM.Add(guiaRemisionListaDetalle);
                /*
                List<ConsultaGuiaRemisionAlmacenDetalle> detalleGuiaRemision = new List<ConsultaGuiaRemisionAlmacenDetalle>();// _INotaIngresoPlantaRepository.ConsultaGuiaRemisionAlmacenDetallePorGuiaRemisionAlmacenId(consultaImpresionGuiaRemision.GuiaRemisionAlmacenId).ToList();

                int contador = 1;

                detalleGuiaRemision.ForEach(z =>
                {
                    string descripcion = String.Empty;

                    GuiaRemisionListaDetalle guiaRemisionListaDetalle = new GuiaRemisionListaDetalle();
                    guiaRemisionListaDetalle.correlativo = contador;
                    contador++;
                    descripcion = "  " + Convert.ToString(z.CantidadPesado) + " " + Convert.ToString(!string.IsNullOrEmpty(z.UnidadMedida) ? z.UnidadMedida.Trim() : String.Empty) + " Plastico" + "   " + Convert.ToString(!string.IsNullOrEmpty(z.Producto) ? z.Producto.Trim() : String.Empty) + "  " + Convert.ToString(!string.IsNullOrEmpty(z.SubProducto) ? z.SubProducto.Trim() : String.Empty) + "  " + Convert.ToString(!string.IsNullOrEmpty(z.TipoProduccion) ? z.TipoProduccion.Trim() : String.Empty) + "  " + Convert.ToString(!string.IsNullOrEmpty(z.TipoCertificacion) ? z.TipoCertificacion.Trim() : String.Empty);

                    guiaRemisionListaDetalle.Descripcion = descripcion;
                    guiaRemisionListaDetalle.PesoNeto = z.KilosBrutosPesado;
                    generarPDFGuiaRemisionResponseDTO.listaDetalleGM.Add(guiaRemisionListaDetalle);

                });
                */

                CabeceraGuiaRemision cabeceraGuiaRemision = new CabeceraGuiaRemision();


                cabeceraGuiaRemision.RazonSocial = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.RazonSocial) ? consultaImpresionGuiaRemision.RazonSocial.Trim() : String.Empty;

                cabeceraGuiaRemision.Direccion = consultaImpresionGuiaRemision.DireccionOrganizacion + " - " + 
               consultaImpresionGuiaRemision.Distrito + " - " + consultaImpresionGuiaRemision.Provincia +" - "+consultaImpresionGuiaRemision.Departamento;

                //cabeceraGuiaRemision.Direccion = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.DireccionOrganizacion) ? consultaImpresionGuiaRemision.DireccionOrganizacion.Trim() : String.Empty;

                cabeceraGuiaRemision.DireccionCliente = consultaImpresionGuiaRemision.Direccion;
                cabeceraGuiaRemision.Ruc = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Ruc) ? consultaImpresionGuiaRemision.RucEmpresaTransporte.Trim() : String.Empty;
                //cabeceraGuiaRemision.Almacen = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.almacen) ? consultaImpresionGuiaRemision.Almacen.Trim() : String.Empty;
                cabeceraGuiaRemision.Destinatario = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.RazonSocialOrganizacion) ? consultaImpresionGuiaRemision.RazonSocialOrganizacion.Trim() : String.Empty;
                //cabeceraGuiaRemision.DireccionPartida = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.DireccionPartida) ? consultaImpresionGuiaRemision.DireccionPartida.Trim() : String.Empty;
                //cabeceraGuiaRemision.DireccionDestino = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.DireccionDestino) ? consultaImpresionGuiaRemision.DireccionDestino.Trim() : String.Empty;
                cabeceraGuiaRemision.Certificacion = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.CertificacionId) ? consultaImpresionGuiaRemision.CertificacionId.Trim() : String.Empty;
                cabeceraGuiaRemision.TipoProduccion = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.TipoProduccionId) ? consultaImpresionGuiaRemision.TipoProduccionId.Trim() : String.Empty;
                cabeceraGuiaRemision.NumeroGuiaRemision = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Numero) ? consultaImpresionGuiaRemision.Numero.Trim() : String.Empty;
                cabeceraGuiaRemision.RucDestinatario = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.RucOrganizacion) ? consultaImpresionGuiaRemision.RucOrganizacion.Trim() : String.Empty;
                cabeceraGuiaRemision.FechaEmision = DateTime.Now;
                cabeceraGuiaRemision.FechaEmisionString = DateTime.Now.ToString("dd/MM/yyyy");
                cabeceraGuiaRemision.FechaEntregaTransportista = DateTime.Now;
                cabeceraGuiaRemision.FechaEntregaTransportistaString = DateTime.Now.ToString("dd/MM/yyyy");
                cabeceraGuiaRemision.CGR = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.NumeroGuiaRemision) ? consultaImpresionGuiaRemision.NumeroGuiaRemision.Trim() : String.Empty;
                //cabeceraGuiaRemision.Certificadora = agenciaCertificadora;
                generarPDFGuiaRemisionResponseDTO.Cabecera.Add(cabeceraGuiaRemision);

                GuiaRemisionDetalle guiaRemisionDetalle = new GuiaRemisionDetalle();
                //guiaRemisionDetalle.TotalLotes = consultaImpresionGuiaRemision.CantidadLotes;
                guiaRemisionDetalle.Rendimiento = consultaImpresionGuiaRemision.RendimientoPorcentaje;
                guiaRemisionDetalle.PorcentajeHumedad = consultaImpresionGuiaRemision.HumedadPorcentaje;
                guiaRemisionDetalle.CantidadTotal = consultaImpresionGuiaRemision.Cantidad;
                guiaRemisionDetalle.TotalKGBrutos = consultaImpresionGuiaRemision.KilosBrutos;
                guiaRemisionDetalle.ModalidadTransporte = "TRANSPORTE PRIVADO";
                guiaRemisionDetalle.TipoTraslado = "TRANSPORTE PRIVADO";
                guiaRemisionDetalle.MotivoTraslado = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.MotivoIngreso) ? consultaImpresionGuiaRemision.MotivoIngreso.Trim() : String.Empty;
                //guiaRemisionDetalle.MotivoTrasladoId = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.MotivoTrasladoId) ? consultaImpresionGuiaRemision.MotivoTrasladoId.Trim() : String.Empty;
                //guiaRemisionDetalle.MotivoDetalleTraslado = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.MotivoTrasladoReferencia) ? consultaImpresionGuiaRemision.MotivoTrasladoReferencia.Trim() : String.Empty;
                //guiaRemisionDetalle.PropietarioTransportista = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Propietario) ? consultaImpresionGuiaRemision.Propietario.Trim() : String.Empty;
                //guiaRemisionDetalle.TransportistaDomicilio = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.DireccionTransportista) ? consultaImpresionGuiaRemision.DireccionTransportista.Trim() : String.Empty;
                //guiaRemisionDetalle.TransportistaCodigoVehicular = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.ConfiguracionVehicular) ? consultaImpresionGuiaRemision.ConfiguracionVehicular.Trim() : String.Empty;
                guiaRemisionDetalle.TransportistaMarca = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Marca) ? consultaImpresionGuiaRemision.Marca.Trim() : String.Empty;
                guiaRemisionDetalle.TransportistaRuc = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.RucEmpresaTransporte) ? consultaImpresionGuiaRemision.RucEmpresaTransporte.Trim() : String.Empty;
                guiaRemisionDetalle.PropietarioTransportista = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.RazonEmpresaTransporte) ? consultaImpresionGuiaRemision.RazonEmpresaTransporte.Trim() : String.Empty;
                guiaRemisionDetalle.TransportistaPlaca = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.PlacaTractorEmpresaTransporte) ? consultaImpresionGuiaRemision.PlacaTractorEmpresaTransporte.Trim() : String.Empty;
                guiaRemisionDetalle.TransportistaPlacaCarreta = String.Empty;
                guiaRemisionDetalle.TransportistaConductor = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.ConductorEmpresaTransporte) ? consultaImpresionGuiaRemision.ConductorEmpresaTransporte.Trim() : String.Empty;
                //guiaRemisionDetalle.TransportistaColor = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Color) ? consultaImpresionGuiaRemision.Color.Trim() : String.Empty;
                //guiaRemisionDetalle.TransportistaSoat = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Soat) ? consultaImpresionGuiaRemision.Soat.Trim() : String.Empty;
                //guiaRemisionDetalle.TransportistaDni = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Dni) ? consultaImpresionGuiaRemision.Dni.Trim() : String.Empty;
                //guiaRemisionDetalle.TransportistaColor = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Color) ? consultaImpresionGuiaRemision.Color.Trim() : String.Empty;
                //guiaRemisionDetalle.TransportistaSoat = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Soat) ? consultaImpresionGuiaRemision.Soat.Trim() : String.Empty;
                //guiaRemisionDetalle.TransportistaConstancia = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.NumeroConstanciaMTC) ? consultaImpresionGuiaRemision.NumeroConstanciaMTC.Trim() : String.Empty;
                guiaRemisionDetalle.TransportistaBrevete = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.LicenciaConductorEmpresaTransporte) ? consultaImpresionGuiaRemision.LicenciaConductorEmpresaTransporte.Trim() : String.Empty;
                guiaRemisionDetalle.Observaciones = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.ObservacionPesado) ? consultaImpresionGuiaRemision.ObservacionPesado.Trim() : String.Empty;
                guiaRemisionDetalle.Responsable = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.UsuarioRegistro) ? consultaImpresionGuiaRemision.UsuarioRegistro.Trim() : String.Empty;

                generarPDFGuiaRemisionResponseDTO.detalleGM.Add(guiaRemisionDetalle);
            }
            return generarPDFGuiaRemisionResponseDTO;
        }

    }
}
