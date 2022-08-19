using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeConnect.Service
{
    public partial class ControlCalidadPlantaService : IControlCalidadPlantaService
    {
        private readonly IMapper _Mapper;
        private IControlCalidadPlantaRepository _IControlCalidadPlantaRepository;
        private ICorrelativoRepository _ICorrelativoRepository;

        public IOptions<ParametrosSettings> _ParametrosSettings;
        private IMaestroRepository _IMaestroRepository;
        public ControlCalidadPlantaService(IControlCalidadPlantaRepository ControlCalidadPlanta, ICorrelativoRepository correlativoRepository,
        IOptions<ParametrosSettings> parametrosSettings, IMapper mapper, IMaestroRepository maestroRepository)
        {
            _IControlCalidadPlantaRepository = ControlCalidadPlanta;
            _ICorrelativoRepository = correlativoRepository;
            _ParametrosSettings = parametrosSettings;
            _Mapper = mapper;
            _IMaestroRepository = maestroRepository;
        }

        public List<ConsultaControlCalidadPlantaBE> ConsultarControlCalidadPlanta(ConsultaControlCalidadPlantaRequestDTO request)
        {

            {
                /*
                if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFin == null || request.FechaFin == DateTime.MinValue || string.IsNullOrEmpty(request.EstadoId))
                    throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.NotaIngresoPlanta.ValidacionSeleccioneMinimoUnFiltro.Label" });

                var timeSpan = request.FechaFin - request.FechaInicio;

                if (timeSpan.Days > 730)
                    throw new ResultException(new Result { ErrCode = "02", Message = "Acopio.NotaIngresoPlanta.ValidacionRangoFechaMayor2anios.Label" });
                */

              //  request.CodigoTipo = Documentos.NotaIngresoPlantaTipo;
                var list = _IControlCalidadPlantaRepository.ConsultarControlCalidadPlanta(request);

                foreach (ConsultaControlCalidadPlantaBE obj in list)
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

        public int AnularControlCalidadPlanta(AnularControlCalidadPlantaRequestDTO request)
        {
            int result = 0;
            if (request.ControlCalidadPlantaId > 0)
            {
                result = _IControlCalidadPlantaRepository.AnularControlCalidadPlanta(request.ControlCalidadPlantaId, DateTime.Now, request.Usuario, OrdenProcesoEstados.Anulado);
            }
            return result;
        }

        public ConsultaControlCalidadPlantaPorIdBE ConsultaControlCalidadPlantaPorId(ConsultaControlCalidadPlantaPorIdRequestDTO request)
        {
            int ControlCalidadPlantaId = request.ControlCalidadPlantaId;

            ConsultaControlCalidadPlantaPorIdBE consultaControlCalidadPlantaPorIdBE = _IControlCalidadPlantaRepository.ConsultaControlCalidadPlantaPorId(request.ControlCalidadPlantaId);

            if (consultaControlCalidadPlantaPorIdBE != null)
            {
               // if (consultaControlCalidadPlantaPorIdBE.EstadoId != NotaIngresoPlantaEstados.Pesado)
                //{
                    consultaControlCalidadPlantaPorIdBE.AnalisisFisicoColorDetalle = _IControlCalidadPlantaRepository.ConsultarControlCalidadPlantaAnalisisFisicoColorDetallePorId(consultaControlCalidadPlantaPorIdBE.NotaIngresoPlantaId).ToList();

                    consultaControlCalidadPlantaPorIdBE.AnalisisFisicoOlorDetalle = _IControlCalidadPlantaRepository.ConsultarControlCalidadPlantaAnalisisFisicoOlorDetallePorId(consultaControlCalidadPlantaPorIdBE.NotaIngresoPlantaId).ToList();

                    consultaControlCalidadPlantaPorIdBE.AnalisisFisicoDefectoPrimarioDetalle = _IControlCalidadPlantaRepository.ConsultarControlCalidadPlantaAnalisisFisicoDefectoPrimarioDetallePorId(consultaControlCalidadPlantaPorIdBE.NotaIngresoPlantaId).ToList();

                    consultaControlCalidadPlantaPorIdBE.AnalisisFisicoDefectoSecundarioDetalle = _IControlCalidadPlantaRepository.ConsultarControlCalidadPlantaAnalisisFisicoDefectoSecundarioDetallePorId(consultaControlCalidadPlantaPorIdBE.NotaIngresoPlantaId).ToList();

                    consultaControlCalidadPlantaPorIdBE.AnalisisSensorialAtributoDetalle = _IControlCalidadPlantaRepository.ConsultarControlCalidadPlantaAnalisisSensorialAtributoDetallePorId(consultaControlCalidadPlantaPorIdBE.NotaIngresoPlantaId).ToList();

                    consultaControlCalidadPlantaPorIdBE.AnalisisSensorialDefectoDetalle = _IControlCalidadPlantaRepository.ConsultarControlCalidadPlantaAnalisisSensorialDefectoDetallePorId(consultaControlCalidadPlantaPorIdBE.NotaIngresoPlantaId).ToList();

                    consultaControlCalidadPlantaPorIdBE.RegistroTostadoIndicadorDetalle = _IControlCalidadPlantaRepository.ConsultarControlCalidadPlantaRegistroTostadoIndicadorDetallePorId(consultaControlCalidadPlantaPorIdBE.NotaIngresoPlantaId).ToList();

                //}
            }



            return consultaControlCalidadPlantaPorIdBE;

        }

        public int RegistrarPesadoControlCalidadPlanta(RegistrarActualizarPesadoControlCalidadPlantaRequestDTO request)
        {
            ControlCalidadPlanta NotaIngresoPlanta = _Mapper.Map<ControlCalidadPlanta>(request);


            // NotaIngresoPlanta.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.NotaIngresoPlanta);
            // NotaIngresoPlanta.Numero = _ICorrelativoRepository.ObtenerCorrelativoNotaIngreso(DateTime.Now.Year.ToString(), Documentos.NotaIngresoPlantaTipo, request.CodigoTipoConcepto);


            // NotaIngresoPlanta.FechaPesado = DateTime.Now;
            // NotaIngresoPlanta.EstadoId = NotaIngresoPlantaEstados.Pesado;
            // NotaIngresoPlanta.FechaRegistro = DateTime.Now;
             NotaIngresoPlanta.UsuarioRegistro = request.UsuarioPesado;
            NotaIngresoPlanta.EstadoCalidadId = ControlCalidadEstados.Analizado;

            int affected = _IControlCalidadPlantaRepository.InsertarPesadoControlCalidadPlanta(NotaIngresoPlanta);

            return affected;
        }

        public int ActualizarPesadoControlCalidadPlanta(RegistrarActualizarPesadoControlCalidadPlantaRequestDTO request)
        {
            ControlCalidadPlanta NotaIngresoPlanta = _Mapper.Map<ControlCalidadPlanta>(request);

            NotaIngresoPlanta.FechaPesado = DateTime.Now;
            NotaIngresoPlanta.UsuarioPesado = request.UsuarioPesado;

            NotaIngresoPlanta.EstadoId = NotaIngresoPlantaEstados.Pesado;
            NotaIngresoPlanta.FechaUltimaActualizacion = DateTime.Now;
            NotaIngresoPlanta.UsuarioUltimaActualizacion = request.UsuarioPesado;


            int affected = _IControlCalidadPlantaRepository.ActualizarPesadoControlCalidadPlanta(NotaIngresoPlanta);


            return affected;
        }


        /// ///////////////////servicio de estados ///////////7

        public int ControlCalidadPlantaActualizarProcesar(RegistrarActualizarEstadoControlCalidadPlantaRequestDTO request)
        {
            ControlCalidadPlanta ControlCalidadPlanta = _Mapper.Map<ControlCalidadPlanta>(request);

    
           // ControlCalidadPlanta.EstadoId = NotaIngresoPlantaEstados.Pesado;
            ControlCalidadPlanta.EstadoCalidadId = ControlCalidadEstados.Procesado;
            ControlCalidadPlanta.FechaUltimaActualizacion = DateTime.Now;
            ControlCalidadPlanta.UsuarioUltimaActualizacion = request.UsuarioUltimaActualizacion;
            ControlCalidadPlanta.ControlCalidadPlantaId = request.ControlCalidadPlantaId;
            ControlCalidadPlanta.NotaIngresoPlantaId = request.NotaIngresoPlantaId;
            ControlCalidadPlanta.CantidadProcesada = request.CantidadProcesada;


            int affected = _IControlCalidadPlantaRepository.ControlCalidadPlantaActualizarProcesar(ControlCalidadPlanta);


            return affected;
        }


        public int ControlCalidadPlantaActualizarEstadoRechazado(RegistrarActualizarEstadoControlCalidadPlantaRequestDTO request)
        {
            ControlCalidadPlanta ControlCalidadPlanta = _Mapper.Map<ControlCalidadPlanta>(request);


            // ControlCalidadPlanta.EstadoId = NotaIngresoPlantaEstados.Pesado;
            ControlCalidadPlanta.EstadoCalidadId = ControlCalidadEstados.Rechazado;
            ControlCalidadPlanta.FechaUltimaActualizacion = DateTime.Now;
            ControlCalidadPlanta.UsuarioUltimaActualizacion = request.UsuarioUltimaActualizacion;
            ControlCalidadPlanta.ControlCalidadPlantaId = request.ControlCalidadPlantaId;
            ControlCalidadPlanta.CantidadControlCalidad = request.CantidadControlCalidad;
            ControlCalidadPlanta.KilosNetosControlCalidad = request.KilosNetosControlCalidad;
            ControlCalidadPlanta.NotaIngresoPlantaId = request.NotaIngresoPlantaId;
           

            int affected = _IControlCalidadPlantaRepository.ControlCalidadPlantaActualizarEstadoRechazado(ControlCalidadPlanta);


            return affected;
        }




        /// ////////////////////////////////



        public int ActualizarControlCalidadPlantaAnalisisCalidad(ActualizarControlCalidadPlantaAnalisisCalidadRequestDTO request)
        {

            ControlCalidadPlanta ControlCalidadPlanta = new ControlCalidadPlanta();

            ControlCalidadPlanta.NotaIngresoPlantaId = request.NotaIngresoPlantaId;
            ControlCalidadPlanta.ExportableGramosAnalisisFisico = request.ExportableGramosAnalisisFisico;
            ControlCalidadPlanta.ExportablePorcentajeAnalisisFisico = request.ExportablePorcentajeAnalisisFisico;
            ControlCalidadPlanta.DescarteGramosAnalisisFisico = request.DescarteGramosAnalisisFisico;
            ControlCalidadPlanta.DescartePorcentajeAnalisisFisico = request.DescartePorcentajeAnalisisFisico;
            ControlCalidadPlanta.CascarillaGramosAnalisisFisico = request.CascarillaGramosAnalisisFisico;
            ControlCalidadPlanta.CascarillaPorcentajeAnalisisFisico = request.CascarillaPorcentajeAnalisisFisico;
            ControlCalidadPlanta.TotalGramosAnalisisFisico = request.TotalGramosAnalisisFisico;
            ControlCalidadPlanta.TotalPorcentajeAnalisisFisico = request.TotalPorcentajeAnalisisFisico;
            ControlCalidadPlanta.HumedadPorcentajeAnalisisFisico = request.HumedadPorcentajeAnalisisFisico;
            ControlCalidadPlanta.ObservacionAnalisisFisico = request.ObservacionAnalisisFisico;
            ControlCalidadPlanta.UsuarioCalidad = request.UsuarioCalidad;
            ControlCalidadPlanta.ObservacionRegistroTostado = request.ObservacionRegistroTostado;
            ControlCalidadPlanta.ObservacionAnalisisSensorial = request.ObservacionAnalisisSensorial;
            ControlCalidadPlanta.UsuarioCalidad = request.UsuarioCalidad;
            ControlCalidadPlanta.EstadoId = NotaIngresoPlantaEstados.Analizado;
            ControlCalidadPlanta.FechaCalidad = DateTime.Now;
            ControlCalidadPlanta.Taza = request.Taza;
            ControlCalidadPlanta.Intensidad = request.Intensidad;
            ControlCalidadPlanta.PuntajeFinal = request.PuntajeFinal;
            ControlCalidadPlanta.TazaIntensidad = request.TazaIntensidad;

            decimal totalAnalisisSensorial = 0;

            if (request.AnalisisSensorialAtributoDetalleList.FirstOrDefault() != null)
            {
                List<ControlCalidadPlantaAnalisisSensorialAtributoDetalleTipo> AnalisisSensorialAtributoDetalle = new List<ControlCalidadPlantaAnalisisSensorialAtributoDetalleTipo>();

                request.AnalisisSensorialAtributoDetalleList.ForEach(z =>
                {
                    if (z.Valor.HasValue)
                    {
                        totalAnalisisSensorial = totalAnalisisSensorial + z.Valor.Value;
                    }
                });

            }



            ControlCalidadPlanta.TotalAnalisisSensorial = totalAnalisisSensorial;

            int affected = _IControlCalidadPlantaRepository.ActualizarAnalisisCalidad(ControlCalidadPlanta);


            #region "Analisis Fisico Color"
            if (request.AnalisisFisicoColorDetalleList.FirstOrDefault() != null)
            {

                List<ControlCalidadPlantaAnalisisFisicoColorDetalleTipo> AnalisisFisicoColorDetalleList = new List<ControlCalidadPlantaAnalisisFisicoColorDetalleTipo>();

                request.AnalisisFisicoColorDetalleList.ForEach(z =>
                {
                    ControlCalidadPlantaAnalisisFisicoColorDetalleTipo item = new ControlCalidadPlantaAnalisisFisicoColorDetalleTipo();
                    item.ColorDetalleDescripcion = z.ColorDetalleDescripcion;
                    item.ColorDetalleId = z.ColorDetalleId;
                    item.NotaIngresoPlantaId = request.NotaIngresoPlantaId;
                    item.Valor = z.Valor;
                    AnalisisFisicoColorDetalleList.Add(item);
                });

                affected = _IControlCalidadPlantaRepository.ActualizarControlCalidadPlantaAnalisisFisicoColorDetalle(AnalisisFisicoColorDetalleList, request.NotaIngresoPlantaId);
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
                    item.NotaIngresoPlantaId = request.NotaIngresoPlantaId;
                    item.Valor = z.Valor;
                    AnalisisFisicoDefectoPrimarioDetalleList.Add(item);
                });

                affected = _IControlCalidadPlantaRepository.ActualizarControlCalidadPlantaAnalisisFisicoDefectoPrimarioDetalle(AnalisisFisicoDefectoPrimarioDetalleList, request.NotaIngresoPlantaId);
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
                    item.NotaIngresoPlantaId = request.NotaIngresoPlantaId;
                    item.Valor = z.Valor;
                    AnalisisFisicoDefectoSecundarioDetalleList.Add(item);
                });

                affected = _IControlCalidadPlantaRepository.ActualizarControlCalidadPlantaAnalisisFisicoDefectoSecundarioDetalle(AnalisisFisicoDefectoSecundarioDetalleList, request.NotaIngresoPlantaId);
            }
            #endregion

            #region "Analisis Fisico Olor Detalle"
            if (request.AnalisisFisicoOlorDetalleList.FirstOrDefault() != null)
            {
                List<ControlCalidadPlantaAnalisisFisicoOlorDetalleTipo> AnalisisFisicoDefectoSecundarioDetalleList = new List<ControlCalidadPlantaAnalisisFisicoOlorDetalleTipo>();

                request.AnalisisFisicoOlorDetalleList.ForEach(z =>
                {
                    ControlCalidadPlantaAnalisisFisicoOlorDetalleTipo item = new ControlCalidadPlantaAnalisisFisicoOlorDetalleTipo();
                    item.NotaIngresoPlantaId = request.NotaIngresoPlantaId;
                    item.OlorDetalleDescripcion = z.OlorDetalleDescripcion;
                    item.OlorDetalleId = z.OlorDetalleId;
                    item.Valor = z.Valor;
                    AnalisisFisicoDefectoSecundarioDetalleList.Add(item);
                });

                affected = _IControlCalidadPlantaRepository.ActualizarControlCalidadPlantaAnalisisFisicoOlorDetalle(AnalisisFisicoDefectoSecundarioDetalleList, request.NotaIngresoPlantaId);
            }
            #endregion

            #region "Analisis Sensorial Atributo"
            if (request.AnalisisSensorialAtributoDetalleList.FirstOrDefault() != null)
            {
                List<ControlCalidadPlantaAnalisisSensorialAtributoDetalleTipo> AnalisisSensorialAtributoDetalle = new List<ControlCalidadPlantaAnalisisSensorialAtributoDetalleTipo>();

                request.AnalisisSensorialAtributoDetalleList.ForEach(z =>
                {
                    ControlCalidadPlantaAnalisisSensorialAtributoDetalleTipo item = new ControlCalidadPlantaAnalisisSensorialAtributoDetalleTipo();
                    item.NotaIngresoPlantaId = request.NotaIngresoPlantaId;
                    item.AtributoDetalleDescripcion = z.AtributoDetalleDescripcion;
                    item.AtributoDetalleId = z.AtributoDetalleId;
                    item.Valor = z.Valor;
                    AnalisisSensorialAtributoDetalle.Add(item);
                });

                affected = _IControlCalidadPlantaRepository.ActualizarControlCalidadPlantaAnalisisSensorialAtributoDetalle(AnalisisSensorialAtributoDetalle, request.NotaIngresoPlantaId);
            }
            #endregion

            if (request.AnalisisSensorialDefectoDetalleList.FirstOrDefault() != null)
            {
                List<ControlCalidadPlantaAnalisisSensorialDefectoDetalleTipo> AnalisisSensorialDefectoDetalle = new List<ControlCalidadPlantaAnalisisSensorialDefectoDetalleTipo>();

                request.AnalisisSensorialDefectoDetalleList.ForEach(z =>
                {
                    ControlCalidadPlantaAnalisisSensorialDefectoDetalleTipo item = new ControlCalidadPlantaAnalisisSensorialDefectoDetalleTipo();
                    item.NotaIngresoPlantaId = request.NotaIngresoPlantaId;
                    item.DefectoDetalleDescripcion = z.DefectoDetalleDescripcion;
                    item.DefectoDetalleId = z.DefectoDetalleId;

                    item.Valor = z.Valor;
                    AnalisisSensorialDefectoDetalle.Add(item);
                });

                affected = _IControlCalidadPlantaRepository.ActualizarControlCalidadPlantaAnalisisSensorialDefectoDetalle(AnalisisSensorialDefectoDetalle, request.NotaIngresoPlantaId);
            }


            if (request.RegistroTostadoIndicadorDetalleList.FirstOrDefault() != null)
            {
                List<ControlCalidadPlantaRegistroTostadoIndicadorDetalleTipo> RegistroTostadoIndicadorDetalle = new List<ControlCalidadPlantaRegistroTostadoIndicadorDetalleTipo>();

                request.RegistroTostadoIndicadorDetalleList.ForEach(z =>
                {

                    ControlCalidadPlantaRegistroTostadoIndicadorDetalleTipo item = new ControlCalidadPlantaRegistroTostadoIndicadorDetalleTipo();
                    item.NotaIngresoPlantaId = request.NotaIngresoPlantaId;
                    item.IndicadorDetalleDescripcion = z.IndicadorDetalleDescripcion;
                    item.IndicadorDetalleId = z.IndicadorDetalleId;
                    item.Valor = z.Valor;

                    RegistroTostadoIndicadorDetalle.Add(item);
                });

                affected = _IControlCalidadPlantaRepository.ActualizarControlCalidadPlantaRegistroTostadoIndicadorDetalle(RegistroTostadoIndicadorDetalle, request.NotaIngresoPlantaId);
            }

            return affected;
        }


        public GenerarPDFGuiaRemisionResponseDTO GenerarPDFGuiaRemisionPorNotaIngreso(int notaSalidaAlmacenIdId, int empresaId)
        {
            GenerarPDFGuiaRemisionResponseDTO generarPDFGuiaRemisionResponseDTO = new GenerarPDFGuiaRemisionResponseDTO();

            ConsultaControlCalidadPlantaPorIdBE consultaImpresionGuiaRemision = new ConsultaControlCalidadPlantaPorIdBE();
            consultaImpresionGuiaRemision = _IControlCalidadPlantaRepository.ConsultaControlCalidadPlantaPorId(notaSalidaAlmacenIdId);

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
               consultaImpresionGuiaRemision.Distrito + " - " + consultaImpresionGuiaRemision.Provincia + " - " + consultaImpresionGuiaRemision.Departamento;

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
