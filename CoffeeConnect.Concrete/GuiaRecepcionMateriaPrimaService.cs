
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
    public partial class GuiaRecepcionMateriaPrimaService : IGuiaRecepcionMateriaPrimaService
    {
        private IGuiaRecepcionMateriaPrimaRepository _IGuiaRecepcionMateriaPrimaRepository;
        private INotaCompraRepository _INotaCompraRepository;
        private ISocioFincaRepository _ISocioFincaRepository;
        private ICorrelativoRepository _ICorrelativoRepository;
        public IOptions<ParametrosSettings> _ParametrosSettings;
        private IContratoRepository _IContratoRepository;

        public GuiaRecepcionMateriaPrimaService(IGuiaRecepcionMateriaPrimaRepository guiaRecepcionMateriaPrima, ISocioFincaRepository socioFincaRepository, INotaCompraRepository notaCompraRepository, ICorrelativoRepository correlativoRepository, IContratoRepository contratoRepository, IOptions<ParametrosSettings> parametrosSettings)
        {
            _IGuiaRecepcionMateriaPrimaRepository = guiaRecepcionMateriaPrima;
            _INotaCompraRepository = notaCompraRepository;
            _ISocioFincaRepository = socioFincaRepository;
            _ICorrelativoRepository = correlativoRepository;
            _IContratoRepository = contratoRepository;
            _ParametrosSettings = parametrosSettings;
        }
        public List<ConsultaGuiaRecepcionMateriaPrimaBE> ConsultarGuiaRecepcionMateriaPrima(ConsultaGuiaRecepcionMateriaPrimaRequestDTO request)
        {
            if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFin == null || request.FechaFin == DateTime.MinValue || string.IsNullOrEmpty(request.EstadoId))
            {
                throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.GuiaRecepcionMateriaPrima.ValidacionSeleccioneMinimoUnFiltro.Label" });
            }

            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
            {
                throw new ResultException(new Result { ErrCode = "02", Message = "Acopio.GuiaRecepcionMateriaPrima.ValidacionRangoFechaMayor2anios.Label" });
            }

            var list = _IGuiaRecepcionMateriaPrimaRepository.ConsultarGuiaRecepcionMateriaPrima(request);
            return list.ToList();
        }

        public int AnularGuiaRecepcionMateriaPrima(AnularGuiaRecepcionMateriaPrimaRequestDTO request)
        {

            ConsultaGuiaRecepcionMateriaPrimaPorIdBE consultaGuiaRecepcionMateriaPrimaPorIdBE = _IGuiaRecepcionMateriaPrimaRepository.ConsultarGuiaRecepcionMateriaPrimaPorId(request.GuiaRecepcionMateriaPrimaId);
            int contratoId = consultaGuiaRecepcionMateriaPrimaPorIdBE.ContratoAsignadoId;

            ConsultaContratoPorIdBE consultaContratoPorIdBE = _IContratoRepository.ConsultarContratoPorId(contratoId);

            if(consultaContratoPorIdBE.EstadoId == ContratoEstados.Completado)
            {
                //throw new ResultException(new Result { ErrCode = "04", Message = "Acopio.GuiaRecepcionMateriaPrima.ContratoCompletado.Label" });
                throw new ResultException(new Result { ErrCode = "04", Message = "No se puede anular una guía con contrato asignado completado." });
            }
            else if (consultaContratoPorIdBE.EstadoId == ContratoEstados.Asignado)
            {
                decimal kilosNetosPesado = consultaGuiaRecepcionMateriaPrimaPorIdBE.KilosNetosPesado;

                _IContratoRepository.ActualizarSaldoPendienteAsignacionAcopio(contratoId, kilosNetosPesado * (-1));
            }


            int affected = _IGuiaRecepcionMateriaPrimaRepository.AnularGuiaRecepcionMateriaPrima(request.GuiaRecepcionMateriaPrimaId, DateTime.Now, request.Usuario, GuiaRecepcionMateriaPrimaEstados.Anulado);

            string productoIdCafePergamino = _ParametrosSettings.Value.ProductoIdCafePergamino;
            string subProductoIdCafeSeco = _ParametrosSettings.Value.SubProductoIdCafeSeco;

            
           

            if (consultaGuiaRecepcionMateriaPrimaPorIdBE.ProductoId == productoIdCafePergamino && consultaGuiaRecepcionMateriaPrimaPorIdBE.SubProductoId == subProductoIdCafeSeco && consultaGuiaRecepcionMateriaPrimaPorIdBE.SocioFincaCertificacion != String.Empty)
            {
                List<ConsultaSocioFincaEstimadoPorSocioFincaIdBE> fincaEstimados = _ISocioFincaRepository.ConsultarSocioFincaEstimadoPorSocioFincaId(consultaGuiaRecepcionMateriaPrimaPorIdBE.SocioFincaId.Value).ToList();

                if (fincaEstimados.Count > 0)
                {
                    int anioActual = DateTime.Now.Year;

                    ConsultaSocioFincaEstimadoPorSocioFincaIdBE fincaEstima = null;

                    fincaEstima = fincaEstimados.Where(x => x.Anio == anioActual).FirstOrDefault();

                    if (fincaEstima != null)
                    {
                        _ISocioFincaRepository.ActualizarSocioFincaEstimadoConsumido(fincaEstima.SocioFincaEstimadoId, consultaGuiaRecepcionMateriaPrimaPorIdBE.KilosBrutosPesado * -1);
                    }
                }
            }

            return affected;
        }

        //public int EnviarGuardiolaGuiaRecepcionMateriaPrima(EnviarGuardiolaGuiaRecepcionMateriaPrimaRequestDTO request)
        //{
        //    int affected = _IGuiaRecepcionMateriaPrimaRepository.EnviarGuardiolaGuiaRecepcionMateriaPrima(request.GuiaRecepcionMateriaPrimaId, DateTime.Now, request.Usuario, GuiaRecepcionMateriaPrimaEstados.EnviadoGuardiola);

        //    return affected;
        //}
        
        public ConsultaGuiaRecepcionMateriaPrimaPorIdBE ConsultarGuiaRecepcionMateriaPrimaPorId(ConsultaGuiaRecepcionMateriaPrimaPorIdRequestDTO request)
        {
            int guiaRecepcionMateriaPrimaId = request.GuiaRecepcionMateriaPrimaId;

            ConsultaGuiaRecepcionMateriaPrimaPorIdBE consultaGuiaRecepcionMateriaPrimaPorIdBE = _IGuiaRecepcionMateriaPrimaRepository.ConsultarGuiaRecepcionMateriaPrimaPorId(request.GuiaRecepcionMateriaPrimaId);

            if (consultaGuiaRecepcionMateriaPrimaPorIdBE != null)
            {
                if (consultaGuiaRecepcionMateriaPrimaPorIdBE.EstadoId != GuiaRecepcionMateriaPrimaEstados.Pesado)
                {
                    consultaGuiaRecepcionMateriaPrimaPorIdBE.AnalisisFisicoColorDetalle = _IGuiaRecepcionMateriaPrimaRepository.ConsultarGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetallePorId(guiaRecepcionMateriaPrimaId).ToList();

                    consultaGuiaRecepcionMateriaPrimaPorIdBE.AnalisisFisicoOlorDetalle = _IGuiaRecepcionMateriaPrimaRepository.ConsultarGuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetallePorId(guiaRecepcionMateriaPrimaId).ToList();

                    consultaGuiaRecepcionMateriaPrimaPorIdBE.AnalisisFisicoDefectoPrimarioDetalle = _IGuiaRecepcionMateriaPrimaRepository.ConsultarGuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetallePorId(guiaRecepcionMateriaPrimaId).ToList();

                    consultaGuiaRecepcionMateriaPrimaPorIdBE.AnalisisFisicoDefectoSecundarioDetalle = _IGuiaRecepcionMateriaPrimaRepository.ConsultarGuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetallePorId(guiaRecepcionMateriaPrimaId).ToList();

                    consultaGuiaRecepcionMateriaPrimaPorIdBE.AnalisisSensorialAtributoDetalle = _IGuiaRecepcionMateriaPrimaRepository.ConsultarGuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetallePorId(guiaRecepcionMateriaPrimaId).ToList();

                    consultaGuiaRecepcionMateriaPrimaPorIdBE.AnalisisSensorialDefectoDetalle = _IGuiaRecepcionMateriaPrimaRepository.ConsultarGuiaRecepcionMateriaPrimaAnalisisSensorialDefectoDetallePorId(guiaRecepcionMateriaPrimaId).ToList();

                    consultaGuiaRecepcionMateriaPrimaPorIdBE.RegistroTostadoIndicadorDetalle = _IGuiaRecepcionMateriaPrimaRepository.ConsultarGuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetallePorId(guiaRecepcionMateriaPrimaId).ToList();



                    consultaGuiaRecepcionMateriaPrimaPorIdBE.NotaCompra = _INotaCompraRepository.ConsultarNotaCompraPorGuiaRecepcionMateriaPrimaId(guiaRecepcionMateriaPrimaId);



                }
            }



            return consultaGuiaRecepcionMateriaPrimaPorIdBE;

        }

        public int RegistrarPesadoGuiaRecepcionMateriaPrima(RegistrarActualizarPesadoGuiaRecepcionMateriaPrimaRequestDTO request)
        {

            ConsultaContratoAsignado consultaContratoAsignado = _IContratoRepository.ConsultarContratoAsignado(request.EmpresaId, ContratoEstados.Asignado);

            if(consultaContratoAsignado==null || consultaContratoAsignado.SaldoPendienteKGPergaminoAsignacion==0)
            {
                throw new ResultException(new Result { ErrCode = "03", Message = "Acopio.GuiaRecepcionMateriaPrima.ValidacionContratoNoAsignado.Label" });
            }

            decimal kilosNetosPesado = request.KilosBrutosPesado - request.TaraPesado;

            if (kilosNetosPesado > consultaContratoAsignado.SaldoPendienteKGPergaminoAsignacion)
            {
                throw new ResultException(new Result { ErrCode = "04", Message = "Acopio.GuiaRecepcionMateriaPrima.ValidacionKilosNetosPesadoMayorContratoNoAsignado.Label" });
            }




            GuiaRecepcionMateriaPrima guiaRecepcionMateriaPrima = new GuiaRecepcionMateriaPrima();

            guiaRecepcionMateriaPrima.EmpresaId = request.EmpresaId;
            guiaRecepcionMateriaPrima.NumeroReferencia = request.NumeroReferencia;
            guiaRecepcionMateriaPrima.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.GuiaRecepcion);
            guiaRecepcionMateriaPrima.TipoProvedorId = request.TipoProvedorId;
            guiaRecepcionMateriaPrima.SocioId = request.SocioId;
            guiaRecepcionMateriaPrima.TerceroId = request.TerceroId;
            guiaRecepcionMateriaPrima.IntermediarioId = request.IntermediarioId;
            guiaRecepcionMateriaPrima.ProductoId = request.ProductoId;
            guiaRecepcionMateriaPrima.SubProductoId = request.SubProductoId;
            guiaRecepcionMateriaPrima.FechaCosecha = request.FechaCosecha;
            guiaRecepcionMateriaPrima.FechaPesado = DateTime.Now;
            guiaRecepcionMateriaPrima.UsuarioPesado = request.UsuarioPesado;
            guiaRecepcionMateriaPrima.UnidadMedidaIdPesado = request.UnidadMedidaIdPesado;
            guiaRecepcionMateriaPrima.CantidadPesado = request.CantidadPesado;
            guiaRecepcionMateriaPrima.KilosBrutosPesado = request.KilosBrutosPesado;
            guiaRecepcionMateriaPrima.TaraPesado = request.TaraPesado;
            guiaRecepcionMateriaPrima.ObservacionPesado = request.ObservacionPesado;
            guiaRecepcionMateriaPrima.SocioFincaId = request.SocioFincaId;
            guiaRecepcionMateriaPrima.SocioFincaCertificacion = request.SocioFincaCertificacion;
            guiaRecepcionMateriaPrima.IntermediarioFinca = request.IntermediarioFinca;
            guiaRecepcionMateriaPrima.TerceroFincaId = request.TerceroFincaId;
            guiaRecepcionMateriaPrima.TipoProduccionId = request.TipoProduccionId;
            guiaRecepcionMateriaPrima.EstadoId = GuiaRecepcionMateriaPrimaEstados.Pesado;
            guiaRecepcionMateriaPrima.FechaRegistro = DateTime.Now;
            guiaRecepcionMateriaPrima.UsuarioRegistro = request.UsuarioPesado;
            guiaRecepcionMateriaPrima.KilosNetosPesado = kilosNetosPesado;
            guiaRecepcionMateriaPrima.ContratoAsignadoId = consultaContratoAsignado.ContratoId;

            string productoIdCafePergamino = _ParametrosSettings.Value.ProductoIdCafePergamino;
            string subProductoIdCafeSeco = _ParametrosSettings.Value.SubProductoIdCafeSeco;



            int affected = _IGuiaRecepcionMateriaPrimaRepository.InsertarPesado(guiaRecepcionMateriaPrima);

            if (request.ProductoId == productoIdCafePergamino && request.SubProductoId == subProductoIdCafeSeco && request.SocioFincaCertificacion != String.Empty)
            {
                List<ConsultaSocioFincaEstimadoPorSocioFincaIdBE> fincaEstimados = _ISocioFincaRepository.ConsultarSocioFincaEstimadoPorSocioFincaId(request.SocioFincaId.Value).ToList();

                if (fincaEstimados.Count > 0)
                {
                    int anioActual = DateTime.Now.Year;

                    ConsultaSocioFincaEstimadoPorSocioFincaIdBE fincaEstima = null;

                    fincaEstima = fincaEstimados.Where(x => x.Anio == anioActual).FirstOrDefault();

                    if (fincaEstima != null)
                    {
                        fincaEstima.SaldoPendiente = fincaEstima.Estimado - fincaEstima.Consumido;

                        if (fincaEstima.SaldoPendiente > 0)
                        {
                            _ISocioFincaRepository.ActualizarSocioFincaEstimadoConsumido(fincaEstima.SocioFincaEstimadoId, request.KilosBrutosPesado);
                        }
                    }
                }
            }

            _IContratoRepository.ActualizarSaldoPendienteAsignacionAcopio(consultaContratoAsignado.ContratoId, kilosNetosPesado);

            if((consultaContratoAsignado.SaldoPendienteKGPergaminoAsignacion - kilosNetosPesado)==0)
            {
                _IContratoRepository.ActualizarEstado(consultaContratoAsignado.ContratoId, DateTime.Now, request.UsuarioPesado, ContratoEstados.Completado);

            }




            return affected;
        }

        public int ActualizarPesadoGuiaRecepcionMateriaPrima(RegistrarActualizarPesadoGuiaRecepcionMateriaPrimaRequestDTO request)
        {
            GuiaRecepcionMateriaPrima guiaRecepcionMateriaPrima = new GuiaRecepcionMateriaPrima();

            decimal kilosNetosPesado = request.KilosBrutosPesado - request.TaraPesado;


            guiaRecepcionMateriaPrima.GuiaRecepcionMateriaPrimaId = request.GuiaRecepcionMateriaPrimaId;
            guiaRecepcionMateriaPrima.EmpresaId = request.EmpresaId;
            guiaRecepcionMateriaPrima.TipoProvedorId = request.TipoProvedorId;
            guiaRecepcionMateriaPrima.NumeroReferencia = request.NumeroReferencia;
            guiaRecepcionMateriaPrima.SocioId = request.SocioId;
            guiaRecepcionMateriaPrima.TerceroId = request.TerceroId;
            guiaRecepcionMateriaPrima.IntermediarioId = request.IntermediarioId;
            guiaRecepcionMateriaPrima.ProductoId = request.ProductoId;
            guiaRecepcionMateriaPrima.SubProductoId = request.SubProductoId;
            guiaRecepcionMateriaPrima.FechaCosecha = request.FechaCosecha;
            guiaRecepcionMateriaPrima.FechaPesado = DateTime.Now;
            guiaRecepcionMateriaPrima.UsuarioPesado = request.UsuarioPesado;
            guiaRecepcionMateriaPrima.UnidadMedidaIdPesado = request.UnidadMedidaIdPesado;
            guiaRecepcionMateriaPrima.CantidadPesado = request.CantidadPesado;
            guiaRecepcionMateriaPrima.KilosBrutosPesado = request.KilosBrutosPesado;
            guiaRecepcionMateriaPrima.KilosNetosPesado = kilosNetosPesado;

            guiaRecepcionMateriaPrima.TaraPesado = request.TaraPesado;
            guiaRecepcionMateriaPrima.ObservacionPesado = request.ObservacionPesado;
            guiaRecepcionMateriaPrima.SocioFincaId = request.SocioFincaId;
            guiaRecepcionMateriaPrima.SocioFincaCertificacion = request.SocioFincaCertificacion;
            guiaRecepcionMateriaPrima.IntermediarioFinca = request.IntermediarioFinca;
            guiaRecepcionMateriaPrima.TerceroFincaId = request.TerceroFincaId;
            guiaRecepcionMateriaPrima.TipoProduccionId = request.TipoProduccionId;
            guiaRecepcionMateriaPrima.EstadoId = GuiaRecepcionMateriaPrimaEstados.Pesado;
            guiaRecepcionMateriaPrima.FechaUltimaActualizacion = DateTime.Now;
            guiaRecepcionMateriaPrima.UsuarioUltimaActualizacion = request.UsuarioPesado;



            string productoIdCafePergamino = _ParametrosSettings.Value.ProductoIdCafePergamino;
            string subProductoIdCafeSeco = _ParametrosSettings.Value.SubProductoIdCafeSeco;

            ConsultaGuiaRecepcionMateriaPrimaPorIdBE consultaGuiaRecepcionMateriaPrimaPorIdBE = _IGuiaRecepcionMateriaPrimaRepository.ConsultarGuiaRecepcionMateriaPrimaPorId(guiaRecepcionMateriaPrima.GuiaRecepcionMateriaPrimaId);

            int affected = _IGuiaRecepcionMateriaPrimaRepository.ActualizarPesado(guiaRecepcionMateriaPrima);

            if (consultaGuiaRecepcionMateriaPrimaPorIdBE.ProductoId == productoIdCafePergamino && consultaGuiaRecepcionMateriaPrimaPorIdBE.SubProductoId == subProductoIdCafeSeco && consultaGuiaRecepcionMateriaPrimaPorIdBE.SocioFincaCertificacion != String.Empty)
            {
                List<ConsultaSocioFincaEstimadoPorSocioFincaIdBE> fincaEstimados = _ISocioFincaRepository.ConsultarSocioFincaEstimadoPorSocioFincaId(consultaGuiaRecepcionMateriaPrimaPorIdBE.SocioFincaId.Value).ToList();

                if (fincaEstimados.Count > 0)
                {
                    int anioActual = DateTime.Now.Year;

                    ConsultaSocioFincaEstimadoPorSocioFincaIdBE fincaEstima = null;

                    fincaEstima = fincaEstimados.Where(x => x.Anio == anioActual).FirstOrDefault();

                    if (fincaEstima != null)
                    {
                        _ISocioFincaRepository.ActualizarSocioFincaEstimadoConsumido(fincaEstima.SocioFincaEstimadoId, consultaGuiaRecepcionMateriaPrimaPorIdBE.KilosBrutosPesado * -1);
                    }
                }
            }

            if (request.ProductoId == productoIdCafePergamino && request.SubProductoId == subProductoIdCafeSeco && request.SocioFincaCertificacion != String.Empty)
            {
                List<ConsultaSocioFincaEstimadoPorSocioFincaIdBE> fincaEstimados = _ISocioFincaRepository.ConsultarSocioFincaEstimadoPorSocioFincaId(request.SocioFincaId.Value).ToList();

                if (fincaEstimados.Count > 0)
                {
                    int anioActual = DateTime.Now.Year;

                    ConsultaSocioFincaEstimadoPorSocioFincaIdBE fincaEstima = null;

                    fincaEstima = fincaEstimados.Where(x => x.Anio == anioActual).FirstOrDefault();

                    if (fincaEstima != null)
                    {
                        _ISocioFincaRepository.ActualizarSocioFincaEstimadoConsumido(fincaEstima.SocioFincaEstimadoId, request.KilosBrutosPesado);
                    }
                }
            }



            return affected;
        }


        public int ActualizarGuiaRecepcionMateriaPrimaAnalisisCalidad(ActualizarGuiaRecepcionMateriaPrimaAnalisisCalidadRequestDTO request)
        {

            GuiaRecepcionMateriaPrima guiaRecepcionMateriaPrima = new GuiaRecepcionMateriaPrima();

            guiaRecepcionMateriaPrima.GuiaRecepcionMateriaPrimaId = request.GuiaRecepcionMateriaPrimaId;
            guiaRecepcionMateriaPrima.ExportableGramosAnalisisFisico = request.ExportableGramosAnalisisFisico;
            guiaRecepcionMateriaPrima.ExportablePorcentajeAnalisisFisico = request.ExportablePorcentajeAnalisisFisico;
            guiaRecepcionMateriaPrima.DescarteGramosAnalisisFisico = request.DescarteGramosAnalisisFisico;
            guiaRecepcionMateriaPrima.DescartePorcentajeAnalisisFisico = request.DescartePorcentajeAnalisisFisico;
            guiaRecepcionMateriaPrima.CascarillaGramosAnalisisFisico = request.CascarillaGramosAnalisisFisico;
            guiaRecepcionMateriaPrima.CascarillaPorcentajeAnalisisFisico = request.CascarillaPorcentajeAnalisisFisico;
            guiaRecepcionMateriaPrima.TotalGramosAnalisisFisico = request.TotalGramosAnalisisFisico;
            guiaRecepcionMateriaPrima.TotalPorcentajeAnalisisFisico = request.TotalPorcentajeAnalisisFisico;
            guiaRecepcionMateriaPrima.HumedadPorcentajeAnalisisFisico = request.HumedadPorcentajeAnalisisFisico;
            guiaRecepcionMateriaPrima.ObservacionAnalisisFisico = request.ObservacionAnalisisFisico;
            guiaRecepcionMateriaPrima.UsuarioCalidad = request.UsuarioCalidad;
            guiaRecepcionMateriaPrima.ObservacionRegistroTostado = request.ObservacionRegistroTostado;
            guiaRecepcionMateriaPrima.ObservacionAnalisisSensorial = request.ObservacionAnalisisSensorial;
            guiaRecepcionMateriaPrima.DefectosTasaAnalisisSensorial = request.DefectosTasaAnalisisSensorial ;
            guiaRecepcionMateriaPrima.DefectosIntensidadAnalisisSensorial = request.DefectosIntensidadAnalisisSensorial;
            guiaRecepcionMateriaPrima.UsuarioCalidad = request.UsuarioCalidad;
            guiaRecepcionMateriaPrima.EstadoId = GuiaRecepcionMateriaPrimaEstados.Analizado;
            guiaRecepcionMateriaPrima.FechaCalidad = DateTime.Now;

            decimal subTotalAnalisisSensorial = 0;

            if (request.AnalisisSensorialAtributoDetalleList.FirstOrDefault() != null)
            {
                List<GuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalleTipo> AnalisisSensorialAtributoDetalle = new List<GuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalleTipo>();

                request.AnalisisSensorialAtributoDetalleList.ForEach(z =>
                {
                    if (z.Valor.HasValue)
                    {
                        subTotalAnalisisSensorial = subTotalAnalisisSensorial + z.Valor.Value;
                    }
                });

            }



            guiaRecepcionMateriaPrima.SubTotalAnalisisSensorial = subTotalAnalisisSensorial;

            guiaRecepcionMateriaPrima.TotalAnalisisSensorial = subTotalAnalisisSensorial - (guiaRecepcionMateriaPrima.DefectosTasaAnalisisSensorial * guiaRecepcionMateriaPrima.DefectosIntensidadAnalisisSensorial);

            int affected = _IGuiaRecepcionMateriaPrimaRepository.ActualizarAnalisisCalidad(guiaRecepcionMateriaPrima);


            #region "Analisis Fisico Color"
            if (request.AnalisisFisicoColorDetalleList.FirstOrDefault() != null)
            {

                List<GuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleTipo> AnalisisFisicoColorDetalleList = new List<GuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleTipo>();

                request.AnalisisFisicoColorDetalleList.ForEach(z =>
                {
                    GuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleTipo item = new GuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleTipo();
                    item.ColorDetalleDescripcion = z.ColorDetalleDescripcion;
                    item.ColorDetalleId = z.ColorDetalleId;
                    item.GuiaRecepcionMateriaPrimaId = request.GuiaRecepcionMateriaPrimaId;
                    item.Valor = z.Valor;
                    AnalisisFisicoColorDetalleList.Add(item);
                });

                affected = _IGuiaRecepcionMateriaPrimaRepository.ActualizarGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalle(AnalisisFisicoColorDetalleList, request.GuiaRecepcionMateriaPrimaId);
            }
            #endregion

            #region Analisis Fisico Defecto Primario
            if (request.AnalisisFisicoDefectoPrimarioDetalleList.FirstOrDefault() != null)
            {
                List<GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetalleTipo> AnalisisFisicoDefectoPrimarioDetalleList = new List<GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetalleTipo>();

                request.AnalisisFisicoDefectoPrimarioDetalleList.ForEach(z =>
                {
                    GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetalleTipo item = new GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetalleTipo();
                    item.DefectoDetalleId = z.DefectoDetalleId;
                    item.DefectoDetalleDescripcion = z.DefectoDetalleDescripcion;
                    item.DefectoDetalleEquivalente = z.DefectoDetalleEquivalente;
                    item.GuiaRecepcionMateriaPrimaId = request.GuiaRecepcionMateriaPrimaId;
                    item.Valor = z.Valor;
                    AnalisisFisicoDefectoPrimarioDetalleList.Add(item);
                });

                affected = _IGuiaRecepcionMateriaPrimaRepository.ActualizarGuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetalle(AnalisisFisicoDefectoPrimarioDetalleList, request.GuiaRecepcionMateriaPrimaId);
            }
            #endregion

            #region "Analisis Fisico Defecto Secundario Detalle"
            if (request.AnalisisFisicoDefectoSecundarioDetalleList.FirstOrDefault() != null)
            {
                List<GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetalleTipo> AnalisisFisicoDefectoSecundarioDetalleList = new List<GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetalleTipo>();

                request.AnalisisFisicoDefectoSecundarioDetalleList.ForEach(z =>
                {
                    GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetalleTipo item = new GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetalleTipo();
                    item.DefectoDetalleId = z.DefectoDetalleId;
                    item.DefectoDetalleDescripcion = z.DefectoDetalleDescripcion;
                    item.DefectoDetalleEquivalente = z.DefectoDetalleEquivalente;
                    item.GuiaRecepcionMateriaPrimaId = request.GuiaRecepcionMateriaPrimaId;
                    item.Valor = z.Valor;
                    AnalisisFisicoDefectoSecundarioDetalleList.Add(item);
                });

                affected = _IGuiaRecepcionMateriaPrimaRepository.ActualizarGuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetalle(AnalisisFisicoDefectoSecundarioDetalleList, request.GuiaRecepcionMateriaPrimaId);
            }
            #endregion

            #region "Analisis Fisico Olor Detalle"
            if (request.AnalisisFisicoOlorDetalleList.FirstOrDefault() != null)
            {
                List<GuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalleTipo> AnalisisFisicoDefectoSecundarioDetalleList = new List<GuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalleTipo>();

                request.AnalisisFisicoOlorDetalleList.ForEach(z =>
                {
                    GuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalleTipo item = new GuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalleTipo();
                    item.GuiaRecepcionMateriaPrimaId = request.GuiaRecepcionMateriaPrimaId;
                    item.OlorDetalleDescripcion = z.OlorDetalleDescripcion;
                    item.OlorDetalleId = z.OlorDetalleId;
                    item.Valor = z.Valor;
                    AnalisisFisicoDefectoSecundarioDetalleList.Add(item);
                });

                affected = _IGuiaRecepcionMateriaPrimaRepository.ActualizarGuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalle(AnalisisFisicoDefectoSecundarioDetalleList, request.GuiaRecepcionMateriaPrimaId);
            }
            #endregion

            #region "Analisis Sensorial Atributo"
            if (request.AnalisisSensorialAtributoDetalleList.FirstOrDefault() != null)
            {
                List<GuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalleTipo> AnalisisSensorialAtributoDetalle = new List<GuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalleTipo>();

                request.AnalisisSensorialAtributoDetalleList.ForEach(z =>
                {
                    GuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalleTipo item = new GuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalleTipo();
                    item.GuiaRecepcionMateriaPrimaId = request.GuiaRecepcionMateriaPrimaId;
                    item.AtributoDetalleDescripcion = z.AtributoDetalleDescripcion;
                    item.AtributoDetalleId = z.AtributoDetalleId;
                    item.Valor = z.Valor;
                    AnalisisSensorialAtributoDetalle.Add(item);
                });

                affected = _IGuiaRecepcionMateriaPrimaRepository.ActualizarGuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalle(AnalisisSensorialAtributoDetalle, request.GuiaRecepcionMateriaPrimaId);
            }
            #endregion

            if (request.AnalisisSensorialDefectoDetalleList.FirstOrDefault() != null)
            {
                List<GuiaRecepcionMateriaPrimaAnalisisSensorialDefectoDetalleTipo> AnalisisSensorialDefectoDetalle = new List<GuiaRecepcionMateriaPrimaAnalisisSensorialDefectoDetalleTipo>();

                request.AnalisisSensorialDefectoDetalleList.ForEach(z =>
                {
                    GuiaRecepcionMateriaPrimaAnalisisSensorialDefectoDetalleTipo item = new GuiaRecepcionMateriaPrimaAnalisisSensorialDefectoDetalleTipo();
                    item.GuiaRecepcionMateriaPrimaId = request.GuiaRecepcionMateriaPrimaId;
                    item.DefectoDetalleDescripcion = z.DefectoDetalleDescripcion;
                    item.DefectoDetalleId = z.DefectoDetalleId;

                    item.Valor = z.Valor;
                    AnalisisSensorialDefectoDetalle.Add(item);
                });

                affected = _IGuiaRecepcionMateriaPrimaRepository.ActualizarGuiaRecepcionMateriaPrimaAnalisisSensorialDefectoDetalle(AnalisisSensorialDefectoDetalle, request.GuiaRecepcionMateriaPrimaId);
            }


            if (request.RegistroTostadoIndicadorDetalleList.FirstOrDefault() != null)
            {
                List<GuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetalleTipo> RegistroTostadoIndicadorDetalle = new List<GuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetalleTipo>();

                request.RegistroTostadoIndicadorDetalleList.ForEach(z =>
                {

                    GuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetalleTipo item = new GuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetalleTipo();
                    item.GuiaRecepcionMateriaPrimaId = request.GuiaRecepcionMateriaPrimaId;
                    item.IndicadorDetalleDescripcion = z.IndicadorDetalleDescripcion;
                    item.IndicadorDetalleId = z.IndicadorDetalleId;
                    item.Valor = z.Valor;

                    RegistroTostadoIndicadorDetalle.Add(item);
                });

                affected = _IGuiaRecepcionMateriaPrimaRepository.ActualizarGuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetalle(RegistroTostadoIndicadorDetalle, request.GuiaRecepcionMateriaPrimaId);
            }

            return affected;
        }

    }
}
