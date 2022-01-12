
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
        private ICorrelativoRepository _ICorrelativoRepository;
        public IOptions<ParametrosSettings> _ParametrosSettings;

        public NotaIngresoPlantaService(INotaIngresoPlantaRepository NotaIngresoPlanta, ICorrelativoRepository correlativoRepository, IOptions<ParametrosSettings> parametrosSettings, IMapper mapper)
        {
            _INotaIngresoPlantaRepository = NotaIngresoPlanta;
            _ICorrelativoRepository = correlativoRepository;
            _ParametrosSettings = parametrosSettings;
            _Mapper = mapper;
        }
        
        public List<ConsultaNotaIngresoPlantaBE> ConsultarNotaIngresoPlanta(ConsultaNotaIngresoPlantaRequestDTO request)
        {
            if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFin == null || request.FechaFin == DateTime.MinValue || string.IsNullOrEmpty(request.EstadoId))
                throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.NotaIngresoPlanta.ValidacionSeleccioneMinimoUnFiltro.Label" });

            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Acopio.NotaIngresoPlanta.ValidacionRangoFechaMayor2anios.Label" });

            var list = _INotaIngresoPlantaRepository.ConsultarNotaIngresoPlanta(request);
            return list.ToList();
        }

        public int AnularNotaIngresoPlanta(AnularNotaIngresoPlantaRequestDTO request)
        {
            int affected = _INotaIngresoPlantaRepository.ActualizarEstado(request.NotaIngresoPlantaId, DateTime.Now, request.Usuario, NotaIngresoPlantaEstados.Anulado);

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
            }



            return consultaNotaIngresoPlantaPorIdBE;

        }

        public int RegistrarPesadoNotaIngresoPlanta(RegistrarActualizarPesadoNotaIngresoPlantaRequestDTO request)
        {
            NotaIngresoPlanta NotaIngresoPlanta = _Mapper.Map<NotaIngresoPlanta>(request);


            NotaIngresoPlanta.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.NotaIngresoPlanta);

            NotaIngresoPlanta.FechaPesado = DateTime.Now;
            NotaIngresoPlanta.EstadoId = NotaIngresoPlantaEstados.Pesado;
            NotaIngresoPlanta.FechaRegistro = DateTime.Now;
            NotaIngresoPlanta.UsuarioRegistro = request.UsuarioPesado;


            int affected = _INotaIngresoPlantaRepository.InsertarPesado(NotaIngresoPlanta);

            return affected;
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
            NotaIngresoPlanta.EstadoId = NotaIngresoPlantaEstados.Analizado;
            NotaIngresoPlanta.FechaCalidad = DateTime.Now;

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

            int affected = _INotaIngresoPlantaRepository.ActualizarAnalisisCalidad(NotaIngresoPlanta);


            #region "Analisis Fisico Color"
            if (request.AnalisisFisicoColorDetalleList.FirstOrDefault() != null)
            {

                List<NotaIngresoPlantaAnalisisFisicoColorDetalleTipo> AnalisisFisicoColorDetalleList = new List<NotaIngresoPlantaAnalisisFisicoColorDetalleTipo>();

                request.AnalisisFisicoColorDetalleList.ForEach(z =>
                {
                    NotaIngresoPlantaAnalisisFisicoColorDetalleTipo item = new NotaIngresoPlantaAnalisisFisicoColorDetalleTipo();
                    item.ColorDetalleDescripcion = z.ColorDetalleDescripcion;
                    item.ColorDetalleId = z.ColorDetalleId;
                    item.NotaIngresoPlantaId = request.NotaIngresoPlantaId;
                    item.Valor = z.Valor;
                    AnalisisFisicoColorDetalleList.Add(item);
                });

                affected = _INotaIngresoPlantaRepository.ActualizarNotaIngresoPlantaAnalisisFisicoColorDetalle(AnalisisFisicoColorDetalleList, request.NotaIngresoPlantaId);
            }
            #endregion

            #region Analisis Fisico Defecto Primario
            if (request.AnalisisFisicoDefectoPrimarioDetalleList.FirstOrDefault() != null)
            {
                List<NotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetalleTipo> AnalisisFisicoDefectoPrimarioDetalleList = new List<NotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetalleTipo>();

                request.AnalisisFisicoDefectoPrimarioDetalleList.ForEach(z =>
                {
                    NotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetalleTipo item = new NotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetalleTipo();
                    item.DefectoDetalleId = z.DefectoDetalleId;
                    item.DefectoDetalleDescripcion = z.DefectoDetalleDescripcion;
                    item.DefectoDetalleEquivalente = z.DefectoDetalleEquivalente;
                    item.NotaIngresoPlantaId = request.NotaIngresoPlantaId;
                    item.Valor = z.Valor;
                    AnalisisFisicoDefectoPrimarioDetalleList.Add(item);
                });

                affected = _INotaIngresoPlantaRepository.ActualizarNotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetalle(AnalisisFisicoDefectoPrimarioDetalleList, request.NotaIngresoPlantaId);
            }
            #endregion

            #region "Analisis Fisico Defecto Secundario Detalle"
            if (request.AnalisisFisicoDefectoSecundarioDetalleList.FirstOrDefault() != null)
            {
                List<NotaIngresoPlantaAnalisisFisicoDefectoSecundarioDetalleTipo> AnalisisFisicoDefectoSecundarioDetalleList = new List<NotaIngresoPlantaAnalisisFisicoDefectoSecundarioDetalleTipo>();

                request.AnalisisFisicoDefectoSecundarioDetalleList.ForEach(z =>
                {
                    NotaIngresoPlantaAnalisisFisicoDefectoSecundarioDetalleTipo item = new NotaIngresoPlantaAnalisisFisicoDefectoSecundarioDetalleTipo();
                    item.DefectoDetalleId = z.DefectoDetalleId;
                    item.DefectoDetalleDescripcion = z.DefectoDetalleDescripcion;
                    item.DefectoDetalleEquivalente = z.DefectoDetalleEquivalente;
                    item.NotaIngresoPlantaId = request.NotaIngresoPlantaId;
                    item.Valor = z.Valor;
                    AnalisisFisicoDefectoSecundarioDetalleList.Add(item);
                });

                affected = _INotaIngresoPlantaRepository.ActualizarNotaIngresoPlantaAnalisisFisicoDefectoSecundarioDetalle(AnalisisFisicoDefectoSecundarioDetalleList, request.NotaIngresoPlantaId);
            }
            #endregion

            #region "Analisis Fisico Olor Detalle"
            if (request.AnalisisFisicoOlorDetalleList.FirstOrDefault() != null)
            {
                List<NotaIngresoPlantaAnalisisFisicoOlorDetalleTipo> AnalisisFisicoDefectoSecundarioDetalleList = new List<NotaIngresoPlantaAnalisisFisicoOlorDetalleTipo>();

                request.AnalisisFisicoOlorDetalleList.ForEach(z =>
                {
                    NotaIngresoPlantaAnalisisFisicoOlorDetalleTipo item = new NotaIngresoPlantaAnalisisFisicoOlorDetalleTipo();
                    item.NotaIngresoPlantaId = request.NotaIngresoPlantaId;
                    item.OlorDetalleDescripcion = z.OlorDetalleDescripcion;
                    item.OlorDetalleId = z.OlorDetalleId;
                    item.Valor = z.Valor;
                    AnalisisFisicoDefectoSecundarioDetalleList.Add(item);
                });

                affected = _INotaIngresoPlantaRepository.ActualizarNotaIngresoPlantaAnalisisFisicoOlorDetalle(AnalisisFisicoDefectoSecundarioDetalleList, request.NotaIngresoPlantaId);
            }
            #endregion

            #region "Analisis Sensorial Atributo"
            if (request.AnalisisSensorialAtributoDetalleList.FirstOrDefault() != null)
            {
                List<NotaIngresoPlantaAnalisisSensorialAtributoDetalleTipo> AnalisisSensorialAtributoDetalle = new List<NotaIngresoPlantaAnalisisSensorialAtributoDetalleTipo>();

                request.AnalisisSensorialAtributoDetalleList.ForEach(z =>
                {
                    NotaIngresoPlantaAnalisisSensorialAtributoDetalleTipo item = new NotaIngresoPlantaAnalisisSensorialAtributoDetalleTipo();
                    item.NotaIngresoPlantaId = request.NotaIngresoPlantaId;
                    item.AtributoDetalleDescripcion = z.AtributoDetalleDescripcion;
                    item.AtributoDetalleId = z.AtributoDetalleId;
                    item.Valor = z.Valor;
                    AnalisisSensorialAtributoDetalle.Add(item);
                });

                affected = _INotaIngresoPlantaRepository.ActualizarNotaIngresoPlantaAnalisisSensorialAtributoDetalle(AnalisisSensorialAtributoDetalle, request.NotaIngresoPlantaId);
            }
            #endregion

            if (request.AnalisisSensorialDefectoDetalleList.FirstOrDefault() != null)
            {
                List<NotaIngresoPlantaAnalisisSensorialDefectoDetalleTipo> AnalisisSensorialDefectoDetalle = new List<NotaIngresoPlantaAnalisisSensorialDefectoDetalleTipo>();

                request.AnalisisSensorialDefectoDetalleList.ForEach(z =>
                {
                    NotaIngresoPlantaAnalisisSensorialDefectoDetalleTipo item = new NotaIngresoPlantaAnalisisSensorialDefectoDetalleTipo();
                    item.NotaIngresoPlantaId = request.NotaIngresoPlantaId;
                    item.DefectoDetalleDescripcion = z.DefectoDetalleDescripcion;
                    item.DefectoDetalleId = z.DefectoDetalleId;

                    item.Valor = z.Valor;
                    AnalisisSensorialDefectoDetalle.Add(item);
                });

                affected = _INotaIngresoPlantaRepository.ActualizarNotaIngresoPlantaAnalisisSensorialDefectoDetalle(AnalisisSensorialDefectoDetalle, request.NotaIngresoPlantaId);
            }


            if (request.RegistroTostadoIndicadorDetalleList.FirstOrDefault() != null)
            {
                List<NotaIngresoPlantaRegistroTostadoIndicadorDetalleTipo> RegistroTostadoIndicadorDetalle = new List<NotaIngresoPlantaRegistroTostadoIndicadorDetalleTipo>();

                request.RegistroTostadoIndicadorDetalleList.ForEach(z =>
                {

                    NotaIngresoPlantaRegistroTostadoIndicadorDetalleTipo item = new NotaIngresoPlantaRegistroTostadoIndicadorDetalleTipo();
                    item.NotaIngresoPlantaId = request.NotaIngresoPlantaId;
                    item.IndicadorDetalleDescripcion = z.IndicadorDetalleDescripcion;
                    item.IndicadorDetalleId = z.IndicadorDetalleId;
                    item.Valor = z.Valor;

                    RegistroTostadoIndicadorDetalle.Add(item);
                });

                affected = _INotaIngresoPlantaRepository.ActualizarNotaIngresoPlantaRegistroTostadoIndicadorDetalle(RegistroTostadoIndicadorDetalle, request.NotaIngresoPlantaId);
            }

            return affected;
        }


        public GenerarPDFGuiaRemisionResponseDTO GenerarPDFGuiaRemisionPorNotaIngreso(int notaSalidaAlmacenIdId)
        {
            GenerarPDFGuiaRemisionResponseDTO generarPDFGuiaRemisionResponseDTO = new GenerarPDFGuiaRemisionResponseDTO();

            ConsultaNotaIngresoPlantaPorIdBE consultaImpresionGuiaRemision = new ConsultaNotaIngresoPlantaPorIdBE();
            consultaImpresionGuiaRemision = _INotaIngresoPlantaRepository.ConsultarNotaIngresoPlantaPorId(notaSalidaAlmacenIdId);

            if (consultaImpresionGuiaRemision != null)
            {
                List<ConsultaGuiaRemisionAlmacenDetalle> detalleGuiaRemision = new List<ConsultaGuiaRemisionAlmacenDetalle>();// _INotaIngresoPlantaRepository.ConsultaGuiaRemisionAlmacenDetallePorGuiaRemisionAlmacenId(consultaImpresionGuiaRemision.GuiaRemisionAlmacenId).ToList();

                int contador = 1;

                //string[] agenciasTotal= { };
                //string[] certificacionTotal = { };

                detalleGuiaRemision.ForEach(z =>
                {
                    string descripcion = String.Empty;

                    // ="	  " & CStr(Sum(Fields!Cantidad.Value, "dsGRListaDetalle")) & "	" & Trim(First(Fields!UnidadMedida.Value, "dsGRListaDetalle")) & "	   " & Trim(First(Fields!Producto.Value, "dsGRListaDetalle")) & "	" & First(Fields!SubProducto.Value, "dsGRListaDetalle") & " " & First(Fields!TipoProduccion.Value, "dsGRListaDetalle") & "	" & First(Fields!TipoCertificacion.Value, "dsGRListaDetalle")

                    GuiaRemisionListaDetalle guiaRemisionListaDetalle = new GuiaRemisionListaDetalle();
                    guiaRemisionListaDetalle.correlativo = contador;
                    contador++;
                    //string[] agencias = z.AgenciaCertificadora.Split("|");
                    //string[] certificaciones = z.Certificacion.Split("|");

                    //agenciasTotal = agenciasTotal.Concat(agencias).ToArray();
                    //certificacionTotal = certificacionTotal.Concat(certificaciones).ToArray();

                    //guiaRemisionListaDetalle.NumeroLote = z.NumeroLote.Trim();
                    //guiaRemisionListaDetalle.FechaLoteString = z.FechaLoteString;
                    //guiaRemisionListaDetalle.TipoProducto = z.Producto.Trim();

                    descripcion = "  " + Convert.ToString(z.CantidadPesado) + " " + Convert.ToString(!string.IsNullOrEmpty(z.UnidadMedida) ? z.UnidadMedida.Trim() : String.Empty) + " Plastico" + "   " + Convert.ToString(!string.IsNullOrEmpty(z.Producto) ? z.Producto.Trim() : String.Empty) + "  " + Convert.ToString(!string.IsNullOrEmpty(z.SubProducto) ? z.SubProducto.Trim() : String.Empty) + "  " + Convert.ToString(!string.IsNullOrEmpty(z.TipoProduccion) ? z.TipoProduccion.Trim() : String.Empty) + "  " + Convert.ToString(!string.IsNullOrEmpty(z.TipoCertificacion) ? z.TipoCertificacion.Trim() : String.Empty);

                    //guiaRemisionListaDetalle.TipoProducto = !string.IsNullOrEmpty(z.Producto) ? z.Producto.Trim() : String.Empty;

                    //guiaRemisionListaDetalle.UnidadMedida = z.UnidadMedida + " Plastico";
                    //guiaRemisionListaDetalle.UnidadMedida = !string.IsNullOrEmpty(z.UnidadMedida) ? z.UnidadMedida.Trim() : String.Empty + " Plastico";

                    guiaRemisionListaDetalle.Descripcion = descripcion;

                    //guiaRemisionListaDetalle.Cantidad = z.CantidadPesado;
                    guiaRemisionListaDetalle.PesoNeto = z.KilosBrutosPesado;
                    //guiaRemisionListaDetalle.HumedadPorcentaje = z.HumedadPorcentaje;
                    //guiaRemisionListaDetalle.RendimientoPorcentaje = z.RendimientoPorcentaje;
                    //guiaRemisionListaDetalle.TipoCertificacion = z.TipoCertificacion.Trim();
                    //guiaRemisionListaDetalle.TipoCertificacion = !string.IsNullOrEmpty(z.TipoCertificacion) ? z.TipoCertificacion.Trim() : String.Empty;

                    //guiaRemisionListaDetalle.TipoProduccion = z.TipoProduccion.Trim();
                    //guiaRemisionListaDetalle.TipoProduccion = !string.IsNullOrEmpty(z.TipoProduccion) ? z.TipoProduccion.Trim() : String.Empty;

                    //guiaRemisionListaDetalle.Producto = z.Producto.Trim();
                    //guiaRemisionListaDetalle.Producto = !string.IsNullOrEmpty(z.Producto) ? z.Producto.Trim() : String.Empty;

                    //guiaRemisionListaDetalle.SubProducto = z.SubProducto.Trim();
                    //guiaRemisionListaDetalle.SubProducto = !string.IsNullOrEmpty(z.SubProducto) ? z.SubProducto.Trim() : String.Empty;



                    generarPDFGuiaRemisionResponseDTO.listaDetalleGM.Add(guiaRemisionListaDetalle);

                });

                //agenciasTotal = agenciasTotal.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                //certificacionTotal = certificacionTotal.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

                //agenciasTotal = agenciasTotal.Distinct().ToArray();

                //certificacionTotal = certificacionTotal.Distinct().ToArray();

                //string separator = ", ";

                //string agenciaCertificadora = string.Join(separator, agenciasTotal);
                //string certificacion = string.Join(separator, certificacionTotal);


                CabeceraGuiaRemision cabeceraGuiaRemision = new CabeceraGuiaRemision();


                cabeceraGuiaRemision.RazonSocial = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.RazonSocial) ? consultaImpresionGuiaRemision.RazonSocial.Trim() : String.Empty;
                cabeceraGuiaRemision.Direccion = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Direccion) ? consultaImpresionGuiaRemision.Direccion.Trim() : String.Empty;
                cabeceraGuiaRemision.Ruc = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Ruc) ? consultaImpresionGuiaRemision.RucEmpresaTransporte.Trim() : String.Empty;
                //cabeceraGuiaRemision.Almacen = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.almacen) ? consultaImpresionGuiaRemision.Almacen.Trim() : String.Empty;
                cabeceraGuiaRemision.Destinatario = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.RazonSocial) ? consultaImpresionGuiaRemision.RazonSocial.Trim() : String.Empty;
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
                guiaRemisionDetalle.MotivoTraslado = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.MotivoIngresoId) ? consultaImpresionGuiaRemision.MotivoIngresoId.Trim() : String.Empty;
                //guiaRemisionDetalle.MotivoTrasladoId = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.MotivoTrasladoId) ? consultaImpresionGuiaRemision.MotivoTrasladoId.Trim() : String.Empty;
                //guiaRemisionDetalle.MotivoDetalleTraslado = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.MotivoTrasladoReferencia) ? consultaImpresionGuiaRemision.MotivoTrasladoReferencia.Trim() : String.Empty;
                //guiaRemisionDetalle.PropietarioTransportista = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Propietario) ? consultaImpresionGuiaRemision.Propietario.Trim() : String.Empty;
                //guiaRemisionDetalle.TransportistaDomicilio = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.DireccionTransportista) ? consultaImpresionGuiaRemision.DireccionTransportista.Trim() : String.Empty;
                //guiaRemisionDetalle.TransportistaCodigoVehicular = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.ConfiguracionVehicular) ? consultaImpresionGuiaRemision.ConfiguracionVehicular.Trim() : String.Empty;
                //guiaRemisionDetalle.TransportistaMarca = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.MarcaTractor) ? consultaImpresionGuiaRemision.MarcaTractor.Trim() : String.Empty;
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
