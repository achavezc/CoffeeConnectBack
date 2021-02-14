
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeConnect.Service
{
    public partial class GuiaRecepcionMateriaPrimaService : IGuiaRecepcionMateriaPrimaService
    {
       
        private IGuiaRecepcionMateriaPrimaRepository _IGuiaRecepcionMateriaPrimaRepository;

        private INotaCompraRepository _INotaCompraRepository;

        public GuiaRecepcionMateriaPrimaService(IGuiaRecepcionMateriaPrimaRepository guiaRecepcionMateriaPrima, INotaCompraRepository notaCompraRepository)
        {
            _IGuiaRecepcionMateriaPrimaRepository = guiaRecepcionMateriaPrima;
            _INotaCompraRepository = notaCompraRepository;
        }
        public List<ConsultaGuiaRecepcionMateriaPrimaBE> ConsultarGuiaRecepcionMateriaPrima(ConsultaGuiaRecepcionMateriaPrimaRequestDTO request)       
        {           
            if (string.IsNullOrEmpty(request.Numero) && string.IsNullOrEmpty(request.NumeroDocumento) && string.IsNullOrEmpty(request.CodigoSocio) && string.IsNullOrEmpty(request.NombreRazonSocial)) 
                throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.GuiaRecepcionMateriaPrima.ValidacionSeleccioneMinimoUnFiltro.Label" });

          
            var timeSpan = request.FechaFin - request.FechaInicio;

            if(timeSpan.Days>730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Acopio.GuiaRecepcionMateriaPrima.ValidacionRangoFechaMayor2anios.Label" });

           

            var list = _IGuiaRecepcionMateriaPrimaRepository.ConsultarGuiaRecepcionMateriaPrima(request);
            
            return list.ToList();
        }

       
        public int AnularGuiaRecepcionMateriaPrima(AnularGuiaRecepcionMateriaPrimaRequestDTO request)
        {
            int affected = _IGuiaRecepcionMateriaPrimaRepository.AnularGuiaRecepcionMateriaPrima(request.GuiaRecepcionMateriaPrimaId,DateTime.Now,request.Usuario, GuiaRecepcionMateriaPrimaEstados.Anulado);

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
            
            consultaGuiaRecepcionMateriaPrimaPorIdBE.AnalisisFisicoColorDetalle = _IGuiaRecepcionMateriaPrimaRepository.ConsultarGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetallePorId(guiaRecepcionMateriaPrimaId).ToList();

            consultaGuiaRecepcionMateriaPrimaPorIdBE.AnalisisFisicoOlorDetalle = _IGuiaRecepcionMateriaPrimaRepository.ConsultarGuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetallePorId(guiaRecepcionMateriaPrimaId).ToList();

            consultaGuiaRecepcionMateriaPrimaPorIdBE.AnalisisFisicoDefectoPrimarioDetalle = _IGuiaRecepcionMateriaPrimaRepository.ConsultarGuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetallePorId(guiaRecepcionMateriaPrimaId).ToList();

            consultaGuiaRecepcionMateriaPrimaPorIdBE.AnalisisFisicoDefectoSecundarioDetalle = _IGuiaRecepcionMateriaPrimaRepository.ConsultarGuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetallePorId(guiaRecepcionMateriaPrimaId).ToList();

            consultaGuiaRecepcionMateriaPrimaPorIdBE.AnalisisSensorialAtributoDetalle = _IGuiaRecepcionMateriaPrimaRepository.ConsultarGuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetallePorId(guiaRecepcionMateriaPrimaId).ToList();

            consultaGuiaRecepcionMateriaPrimaPorIdBE.AnalisisSensorialDefectoDetalle = _IGuiaRecepcionMateriaPrimaRepository.ConsultarGuiaRecepcionMateriaPrimaAnalisisSensorialDefectoDetallePorId(guiaRecepcionMateriaPrimaId).ToList();

            consultaGuiaRecepcionMateriaPrimaPorIdBE.RegistroTostadoIndicadorDetalle = _IGuiaRecepcionMateriaPrimaRepository.ConsultarGuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetallePorId(guiaRecepcionMateriaPrimaId).ToList();

            ConsultaNotaCompraPorGuiaRecepcionMateriaPrimaIdBE consultaNotaCompraPorGuiaRecepcionMateriaPrimaIdBE = _INotaCompraRepository.ConsultarNotaCompraPorGuiaRecepcionMateriaPrimaId(guiaRecepcionMateriaPrimaId);



            return consultaGuiaRecepcionMateriaPrimaPorIdBE;

        }

        public int RegistrarGuiaRecepcionMateriaPrima(RegistrarGuiaRecepcionMateriaPrimaRequestDTO request)
        {
            GuiaRecepcionMateriaPrima guiaRecepcionMateriaPrima = new GuiaRecepcionMateriaPrima();
            
            guiaRecepcionMateriaPrima.EmpresaId = request.EmpresaId;
            guiaRecepcionMateriaPrima.Numero = request.Numero;
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
            guiaRecepcionMateriaPrima.EstadoId = GuiaRecepcionMateriaPrimaEstados.Pesado;
            guiaRecepcionMateriaPrima.FechaRegistro = DateTime.Now;
            guiaRecepcionMateriaPrima.UsuarioRegistro = request.UsuarioPesado;  

            int affected = _IGuiaRecepcionMateriaPrimaRepository.Insert(guiaRecepcionMateriaPrima);

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
            guiaRecepcionMateriaPrima.UsuarioCalidad = request.UsuarioCalidad;
            guiaRecepcionMateriaPrima.EstadoId = GuiaRecepcionMateriaPrimaEstados.Analizado;
            guiaRecepcionMateriaPrima.FechaCalidad = DateTime.Now;
         

            int affected = _IGuiaRecepcionMateriaPrimaRepository.ActualizarAnalisisCalidad(guiaRecepcionMateriaPrima);

            if (request.AnalisisFisicoColorDetalleList.FirstOrDefault() != null) {

                List<GuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleTipo> AnalisisFisicoColorDetalleList = new List<GuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleTipo>();

                request.AnalisisFisicoColorDetalleList.ForEach(z => {
                    GuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleTipo item = new GuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleTipo();
                    item.ColorDetalleDescripcion = z.ColorDetalleDescripcion;
                    item.ColorDetalleId = z.ColorDetalleId;
                    item.GuiaRecepcionMateriaPrimaId = z.GuiaRecepcionMateriaPrimaId;
                    item.Valor = z.Valor;
                    AnalisisFisicoColorDetalleList.Add(item);
                });

                affected = _IGuiaRecepcionMateriaPrimaRepository.ActualizarGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalle(AnalisisFisicoColorDetalleList, request.GuiaRecepcionMateriaPrimaId);
            }

            if (request.AnalisisFisicoDefectoPrimarioDetalleList.FirstOrDefault() != null)
            {
                List<GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetalleTipo> AnalisisFisicoDefectoPrimarioDetalleList = new List<GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetalleTipo>();

                request.AnalisisFisicoDefectoPrimarioDetalleList.ForEach(z => {
                    GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetalleTipo item = new GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetalleTipo();
                    item.DefectoDetalleId = z.DefectoDetalleId;
                    item.DefectoDetalleDescripcion = z.DefectoDetalleDescripcion;
                    item.DefectoDetalleEquivalente = z.DefectoDetalleEquivalente;
                    item.GuiaRecepcionMateriaPrimaId = z.GuiaRecepcionMateriaPrimaId;
                    item.Valor = z.Valor;
                    AnalisisFisicoDefectoPrimarioDetalleList.Add(item);
                });

                affected = _IGuiaRecepcionMateriaPrimaRepository.ActualizarGuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetalle(AnalisisFisicoDefectoPrimarioDetalleList, request.GuiaRecepcionMateriaPrimaId);
            }

            if (request.AnalisisFisicoDefectoSecundarioDetalleList.FirstOrDefault() != null)
            {
                List<GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetalleTipo> AnalisisFisicoDefectoSecundarioDetalleList = new List<GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetalleTipo>();

                request.AnalisisFisicoDefectoSecundarioDetalleList.ForEach(z => {
                    GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetalleTipo item = new GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetalleTipo();
                    item.DefectoDetalleId = z.DefectoDetalleId;
                    item.DefectoDetalleDescripcion = z.DefectoDetalleDescripcion;
                    item.DefectoDetalleEquivalente = z.DefectoDetalleEquivalente;
                    item.GuiaRecepcionMateriaPrimaId = z.GuiaRecepcionMateriaPrimaId;
                    item.Valor = z.Valor;
                    AnalisisFisicoDefectoSecundarioDetalleList.Add(item);
                });

                affected = _IGuiaRecepcionMateriaPrimaRepository.ActualizarGuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetalle(AnalisisFisicoDefectoSecundarioDetalleList, request.GuiaRecepcionMateriaPrimaId);
            }
            if (request.AnalisisFisicoOlorDetalleList.FirstOrDefault() != null)
            {
                List<GuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalleTipo> AnalisisFisicoDefectoSecundarioDetalleList = new List<GuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalleTipo>();

                request.AnalisisFisicoOlorDetalleList.ForEach(z => {
                    GuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalleTipo item = new GuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalleTipo();
                    item.GuiaRecepcionMateriaPrimaId = z.GuiaRecepcionMateriaPrimaId;
                    item.OlorDetalleDescripcion = z.OlorDetalleDescripcion;
                    item.OlorDetalleId = z.OlorDetalleId;
                    item.Valor = z.Valor;
                    AnalisisFisicoDefectoSecundarioDetalleList.Add(item);
                });

                affected = _IGuiaRecepcionMateriaPrimaRepository.ActualizarGuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalle(AnalisisFisicoDefectoSecundarioDetalleList, request.GuiaRecepcionMateriaPrimaId);
            }
            if (request.AnalisisSensorialAtributoDetalleList.FirstOrDefault() != null)
            {
                List<GuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalleTipo> AnalisisSensorialAtributoDetalle = new List<GuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalleTipo>();

                request.AnalisisSensorialAtributoDetalleList.ForEach(z => {
                    GuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalleTipo item = new GuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalleTipo();
                    item.GuiaRecepcionMateriaPrimaId = z.GuiaRecepcionMateriaPrimaId;
                    item.AtributoDetalleDescripcion = z.AtributoDetalleDescripcion;
                    item.AtributoDetalleId = z.AtributoDetalleId;
                    item.Valor = z.Valor;
                    AnalisisSensorialAtributoDetalle.Add(item);
                });

                affected = _IGuiaRecepcionMateriaPrimaRepository.ActualizarGuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalle(AnalisisSensorialAtributoDetalle, request.GuiaRecepcionMateriaPrimaId);
            }
            if (request.RegistroTostadoIndicadorDetalleList.FirstOrDefault() != null)
            {
                List<GuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetalleTipo> RegistroTostadoIndicadorDetalle = new List<GuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetalleTipo>();

                request.RegistroTostadoIndicadorDetalleList.ForEach(z => {
                    
                    GuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetalleTipo item = new GuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetalleTipo();
                    item.GuiaRecepcionMateriaPrimaId = z.GuiaRecepcionMateriaPrimaId;
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
