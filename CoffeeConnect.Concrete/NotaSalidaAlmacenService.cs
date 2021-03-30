using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using Core.Common.Domain.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeConnect.Service
{
    public partial class NotaSalidaAlmacenService : INotaSalidaAlmacenService
    {
        private readonly IMapper _Mapper;

        private INotaSalidaAlmacenRepository _INotaSalidaAlmacenRepository;

        private ILoteRepository _LoteRepository;

        private IUsersRepository _UsersRepository;

        private IEmpresaRepository _EmpresaRepository;
        private ICorrelativoRepository _ICorrelativoRepository;

        private IGuiaRemisionAlmacenRepository _IGuiaRemisionAlmacenRepository;


        public NotaSalidaAlmacenService(INotaSalidaAlmacenRepository notaSalidaAlmacenRepository, IUsersRepository usersRepository,
            IEmpresaRepository empresaRepository, ILoteRepository loteRepository, ICorrelativoRepository ICorrelativoRepository,
            IGuiaRemisionAlmacenRepository IGuiaRemisionAlmacenRepository,
            IMapper mapper)
        {
            _INotaSalidaAlmacenRepository = notaSalidaAlmacenRepository;

            _UsersRepository = usersRepository;

            _EmpresaRepository = empresaRepository;

            _LoteRepository = loteRepository;

            _ICorrelativoRepository = ICorrelativoRepository;

            _IGuiaRemisionAlmacenRepository = IGuiaRemisionAlmacenRepository;

            _Mapper = mapper;
        }




        public int RegistrarNotaSalidaAlmacen(RegistrarNotaSalidaAlmacenRequestDTO request)
        {
            NotaSalidaAlmacen notaSalidaAlmacen = new NotaSalidaAlmacen();
            List<NotaSalidaAlmacenDetalle> lstnotaSalidaAlmacen = new List<NotaSalidaAlmacenDetalle>();
            int affected = 0;

            
            notaSalidaAlmacen.EmpresaId = request.EmpresaId;
            notaSalidaAlmacen.AlmacenId = request.AlmacenId;
            notaSalidaAlmacen.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.NotaSalidaAlmacen);
            notaSalidaAlmacen.MotivoTrasladoId = request.MotivoTrasladoId;
            notaSalidaAlmacen.MotivoTrasladoReferencia = request.MotivoTrasladoReferencia;
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
            notaSalidaAlmacen.CantidadLotes = request.CantidadLotes;
            notaSalidaAlmacen.PromedioPorcentajeRendimiento = request.PromedioPorcentajeRendimiento;
            notaSalidaAlmacen.CantidadTotal = request.CantidadTotal;
            notaSalidaAlmacen.PesoKilosBrutos = request.PesoKilosBrutos;
            
            
            notaSalidaAlmacen.EstadoId = NotaSalidaAlmacenEstados.Ingresado;          
            notaSalidaAlmacen.FechaRegistro = DateTime.Now;
            notaSalidaAlmacen.UsuarioRegistro = request.UsuarioNotaSalidaAlmacen;

            notaSalidaAlmacen.NotaSalidaAlmacenId = _INotaSalidaAlmacenRepository.Insertar(notaSalidaAlmacen);
            
            


            if (notaSalidaAlmacen.NotaSalidaAlmacenId != 0) {
                request.ListNotaSalidaAlmacenDetalle.ForEach(x => {
                    NotaSalidaAlmacenDetalle obj = new NotaSalidaAlmacenDetalle();
                    obj.LoteId = x.LoteId;                   
                    obj.NotaSalidaAlmacenId = notaSalidaAlmacen.NotaSalidaAlmacenId;

                    lstnotaSalidaAlmacen.Add(obj);
                });

                affected = _INotaSalidaAlmacenRepository.ActualizarNotaSalidaAlmacenDetalle(lstnotaSalidaAlmacen, notaSalidaAlmacen.NotaSalidaAlmacenId);

            }
           

            #region Guia Remision
            int guiaRemisionAlmacenId;
            //GuiaRemisionAlmacen guiaRemisionAlmacen = new GuiaRemisionAlmacen();

            GuiaRemisionAlmacen guiaRemisionAlmacen = _Mapper.Map<GuiaRemisionAlmacen>(notaSalidaAlmacen);
            guiaRemisionAlmacen.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.GuiaRemisionAlmacen);

            #region comentado
            //guiaRemisionAlmacen.NotaSalidaAlmacenId = notaSalidaAlmacen.NotaSalidaAlmacenId;
            //guiaRemisionAlmacen.AlmacenId = notaSalidaAlmacen.AlmacenId;
            //guiaRemisionAlmacen.CantidadLotes = notaSalidaAlmacen.CantidadLotes;
            //guiaRemisionAlmacen.CantidadTotal = notaSalidaAlmacen.CantidadTotal;
            //guiaRemisionAlmacen.Conductor = notaSalidaAlmacen.Conductor;
            //guiaRemisionAlmacen.EmpresaId = notaSalidaAlmacen.EmpresaId;
            //guiaRemisionAlmacen.EmpresaIdDestino = notaSalidaAlmacen.EmpresaIdDestino;
            //guiaRemisionAlmacen.EmpresaTransporteId = notaSalidaAlmacen.EmpresaTransporteId;
            //guiaRemisionAlmacen.EstadoId = notaSalidaAlmacen.EstadoId;
            //guiaRemisionAlmacen.FechaRegistro= DateTime.Now;
            //guiaRemisionAlmacen.Licencia = notaSalidaAlmacen.Licencia;
            //guiaRemisionAlmacen.MarcaCarretaId = notaSalidaAlmacen.MarcaCarretaId;
            //guiaRemisionAlmacen.MarcaTractorId = notaSalidaAlmacen.MarcaTractorId;
            //guiaRemisionAlmacen.MotivoTrasladoId = notaSalidaAlmacen.MotivoTrasladoId;
            //guiaRemisionAlmacen.MotivoTrasladoReferencia = notaSalidaAlmacen.MotivoTrasladoReferencia;
            //guiaRemisionAlmacen.PesoKilosBrutos = notaSalidaAlmacen.PesoKilosBrutos;
            //guiaRemisionAlmacen.PlacaCarreta = notaSalidaAlmacen.PlacaCarreta;
            //guiaRemisionAlmacen.PlacaTractor = notaSalidaAlmacen.PlacaTractor;
            //guiaRemisionAlmacen.PromedioPorcentajeRendimiento = notaSalidaAlmacen.PromedioPorcentajeRendimiento;
            //guiaRemisionAlmacen.TransporteId = notaSalidaAlmacen.TransporteId;
            //guiaRemisionAlmacen.UsuarioRegistro = notaSalidaAlmacen.UsuarioRegistro;
            #endregion


            guiaRemisionAlmacenId = _IGuiaRemisionAlmacenRepository.Insertar(guiaRemisionAlmacen);

            if (guiaRemisionAlmacenId != 0)
            {
                List<ConsultaNotaSalidaAlmacenLotesDetallePorIdBE> NotaSalidaDetalle = _INotaSalidaAlmacenRepository.ConsultarNotaSalidaAlmacenLotesDetallePorIdBE(notaSalidaAlmacen.NotaSalidaAlmacenId).ToList();
                List<GuiaRemisionAlmacenDetalleTipo> listaDetalle = new List<GuiaRemisionAlmacenDetalleTipo>();
                if (NotaSalidaDetalle.Any())
                {
                    NotaSalidaDetalle.ForEach(x =>
                    {
                        GuiaRemisionAlmacenDetalleTipo item = _Mapper.Map<GuiaRemisionAlmacenDetalleTipo>(x);
                        item.GuiaRemisionAlmacenId = guiaRemisionAlmacenId;
                        item.NumeroNotaIngreso = x.NumeroNotaIngresoAlmacen;

                        listaDetalle.Add(item);
                    });

                    _IGuiaRemisionAlmacenRepository.ActualizarGuiaRemisionAlmacenDetalle(listaDetalle);
                }

            }


            #endregion

            return affected;
        }

        public int ActualizarNotaSalidaAlmacen(RegistrarNotaSalidaAlmacenRequestDTO request)
        {
            NotaSalidaAlmacen notaSalidaAlmacen = new NotaSalidaAlmacen();
            List<NotaSalidaAlmacenDetalle> lstnotaSalidaAlmacen = new List<NotaSalidaAlmacenDetalle>();
            int affected = 0;

            notaSalidaAlmacen.NotaSalidaAlmacenId = request.NotaSalidaAlmacenId;
            notaSalidaAlmacen.EmpresaId = request.EmpresaId;
            notaSalidaAlmacen.AlmacenId = request.AlmacenId;
            notaSalidaAlmacen.Numero = request.Numero;
            notaSalidaAlmacen.MotivoTrasladoId = request.MotivoTrasladoId;
            notaSalidaAlmacen.MotivoTrasladoReferencia = request.MotivoTrasladoReferencia;
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
            notaSalidaAlmacen.CantidadLotes = request.CantidadLotes;
            notaSalidaAlmacen.PromedioPorcentajeRendimiento = request.PromedioPorcentajeRendimiento;
            notaSalidaAlmacen.CantidadTotal = request.CantidadTotal;
            notaSalidaAlmacen.PesoKilosBrutos = request.PesoKilosBrutos;

            //notaSalidaAlmacen.EstadoId = request.EstadoId;
            notaSalidaAlmacen.FechaUltimaActualizacion = DateTime.Now;
            notaSalidaAlmacen.UsuarioUltimaActualizacion = request.UsuarioNotaSalidaAlmacen;
            

            affected = _INotaSalidaAlmacenRepository.Actualizar(notaSalidaAlmacen);
            
            if (affected != 0)
            {
                request.ListNotaSalidaAlmacenDetalle.ForEach(x => {
                    NotaSalidaAlmacenDetalle obj = new NotaSalidaAlmacenDetalle();
                    obj.LoteId = x.LoteId;
                    obj.NotaSalidaAlmacenDetalleId = x.NotaSalidaAlmacenDetalleId;
                    obj.NotaSalidaAlmacenId = request.NotaSalidaAlmacenId;

                    lstnotaSalidaAlmacen.Add(obj);
                });

                affected = _INotaSalidaAlmacenRepository.ActualizarNotaSalidaAlmacenDetalle(lstnotaSalidaAlmacen, request.NotaSalidaAlmacenId);
              }

            #region Guia Remision
            int guiaRemisionAlmacenId;
            //GuiaRemisionAlmacen guiaRemisionAlmacen = new GuiaRemisionAlmacen();

            GuiaRemisionAlmacen guiaRemisionAlmacen = _Mapper.Map<GuiaRemisionAlmacen>(notaSalidaAlmacen);
            ConsultaGuiaRemisionAlmacen guiaRemisionPivot = _IGuiaRemisionAlmacenRepository.ConsultaGuiaRemisionAlmacenPorNotaSalidaAlmacenId(notaSalidaAlmacen.NotaSalidaAlmacenId);

            if (guiaRemisionPivot == null)
            {
                guiaRemisionAlmacen.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.GuiaRemisionAlmacen);

                guiaRemisionAlmacen.FechaRegistro = DateTime.Now;
                guiaRemisionAlmacen.UsuarioRegistro = request.UsuarioNotaSalidaAlmacen;

                guiaRemisionAlmacenId = _IGuiaRemisionAlmacenRepository.Insertar(guiaRemisionAlmacen);
            }
            else
            {
                guiaRemisionAlmacen.FechaUltimaActualizacion = DateTime.Now;
                guiaRemisionAlmacen.UsuarioUltimaActualizacion = request.UsuarioNotaSalidaAlmacen;

                _IGuiaRemisionAlmacenRepository.Actualizar(guiaRemisionAlmacen);

                guiaRemisionAlmacenId = guiaRemisionPivot.GuiaRemisionAlmacenId;
            }
            

            if (guiaRemisionAlmacenId != 0)
            {
                List<ConsultaNotaSalidaAlmacenLotesDetallePorIdBE> NotaSalidaDetalle = _INotaSalidaAlmacenRepository.ConsultarNotaSalidaAlmacenLotesDetallePorIdBE(notaSalidaAlmacen.NotaSalidaAlmacenId).ToList();
                List<GuiaRemisionAlmacenDetalleTipo> listaDetalle = new List<GuiaRemisionAlmacenDetalleTipo>();
                if (NotaSalidaDetalle.Any())
                {
                    NotaSalidaDetalle.ForEach(x =>
                    {
                        GuiaRemisionAlmacenDetalleTipo item = _Mapper.Map<GuiaRemisionAlmacenDetalleTipo>(x);
                        item.GuiaRemisionAlmacenId = guiaRemisionAlmacenId;
                        item.NumeroNotaIngreso = x.NumeroNotaIngresoAlmacen;

                        listaDetalle.Add(item);
                    });

                    _IGuiaRemisionAlmacenRepository.ActualizarGuiaRemisionAlmacenDetalle(listaDetalle);
                }

            }


            #endregion

            return affected;
        }


      

        public List<ConsultaNotaSalidaAlmacenBE> ConsultarNotaSalidaAlmacen(ConsultaNotaSalidaAlmacenRequestDTO request)
        {
            //if (string.IsNullOrEmpty(request.Numero) 
            //    && string.IsNullOrEmpty(request.NumeroGuiaRecepcion) 
            //    && string.IsNullOrEmpty(request.NumeroDocumento) 
            //    && string.IsNullOrEmpty(request.CodigoSocio) 
            //    && string.IsNullOrEmpty(request.NombreRazonSocial))
            //    throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.NotaCompra.ValidacionSeleccioneMinimoUnFiltro.Label" });


            //var timeSpan = request.FechaFin - request.FechaInicio;

            //if (timeSpan.Days > 730)
            //    throw new ResultException(new Result { ErrCode = "02", Message = "Acopio.NotaCompra.ValidacionRangoFechaMayor2anios.Label" });



            var list = _INotaSalidaAlmacenRepository.ConsultarNotaSalidaAlmacen(request);

            return list.ToList();
        }

        public ConsultaImpresionListaProductoresPorNotaSalidaAlmacenResponseDTO ConsultarImpresionListaProductoresPorNotaSalidaAlmacen(int notaSalidaAlmacenId)
        {   

            ConsultaImpresionListaProductoresPorNotaSalidaAlmacenResponseDTO consultaImpresionListaProductoresPorNotaSalidaAlmacenResponseDTO = new ConsultaImpresionListaProductoresPorNotaSalidaAlmacenResponseDTO();

            ConsultaNotaSalidaAlmacenPorIdBE notaSalidaAlmacenPorIdBE =  _INotaSalidaAlmacenRepository.ConsultarNotaSalidaAlmacenPorId(notaSalidaAlmacenId);

            if(notaSalidaAlmacenPorIdBE!=null)
            {
                consultaImpresionListaProductoresPorNotaSalidaAlmacenResponseDTO.FechaNotaSalidaAlmacen = notaSalidaAlmacenPorIdBE.FechaRegistro;
                consultaImpresionListaProductoresPorNotaSalidaAlmacenResponseDTO.NumeroNotaSalidaAlmacen = notaSalidaAlmacenPorIdBE.Numero;
                consultaImpresionListaProductoresPorNotaSalidaAlmacenResponseDTO.UsuarioNotaSalidaAlmacen = notaSalidaAlmacenPorIdBE.UsuarioRegistro;

                Empresa empresa = _EmpresaRepository.ObtenerEmpresaPorId(notaSalidaAlmacenPorIdBE.EmpresaId);

                if (empresa != null)
                {
                    consultaImpresionListaProductoresPorNotaSalidaAlmacenResponseDTO.RazonSocialEmpresa = empresa.RazonSocial;
                    consultaImpresionListaProductoresPorNotaSalidaAlmacenResponseDTO.RucEmpresa = empresa.Ruc;
                    consultaImpresionListaProductoresPorNotaSalidaAlmacenResponseDTO.DireccionEmpresa = empresa.Direccion;
                }

                consultaImpresionListaProductoresPorNotaSalidaAlmacenResponseDTO.ListaProductores = _INotaSalidaAlmacenRepository.ConsultarImpresionListaProductoresPorNotaSalida(notaSalidaAlmacenId).ToList();
            }
            

            return consultaImpresionListaProductoresPorNotaSalidaAlmacenResponseDTO;
        }

        public int AnularNotaSalidaAlmacen(AnularNotaSalidaAlmacenRequestDTO request)
        {
            int affected = _INotaSalidaAlmacenRepository.ActualizarEstado(request.NotaSalidaAlmacenId, DateTime.Now, request.Usuario, NotaSalidaAlmacenEstados.Anulado);

            List<NotaSalidaAlmacenDetalle> notaSalidaAlmacenDetalle = _INotaSalidaAlmacenRepository.ConsultarNotaSalidaAlmacenDetallePorId(request.NotaSalidaAlmacenId).ToList();

            notaSalidaAlmacenDetalle.ForEach(notaSalidaDetalle =>
            {
                _LoteRepository.ActualizarEstado(notaSalidaDetalle.LoteId, DateTime.Now, request.Usuario, LoteEstados.Ingresado);
            });

            return affected;
        }

        public ConsultaNotaSalidaAlmacenPorIdBE ConsultarNotaSalidaAlmacenPorId(ConsultaNotaSalidaAlmacenPorIdRequestDTO request)
        {
            ConsultaNotaSalidaAlmacenPorIdBE notaSalidaAlmacenPorIdBE = _INotaSalidaAlmacenRepository.ConsultarNotaSalidaAlmacenPorId(request.NotaSalidaAlmacenId);

            if (notaSalidaAlmacenPorIdBE != null)
            {
                notaSalidaAlmacenPorIdBE.AnalisisFisicoColorDetalle = _INotaSalidaAlmacenRepository.ConsultarNotaSalidaAlmacenAnalisisFisicoColorDetallePorId(request.NotaSalidaAlmacenId);
                notaSalidaAlmacenPorIdBE.AnalisisFisicoDefectoPrimarioDetalle = _INotaSalidaAlmacenRepository.ConsultarNotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetallePorId(request.NotaSalidaAlmacenId);
                notaSalidaAlmacenPorIdBE.AnalisisFisicoDefectoSecundarioDetalle = _INotaSalidaAlmacenRepository.ConsultarNotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetallePorId(request.NotaSalidaAlmacenId);
                notaSalidaAlmacenPorIdBE.AnalisisFisicoOlorDetalle = _INotaSalidaAlmacenRepository.ConsultarNotaSalidaAlmacenAnalisisFisicoOlorDetallePorId(request.NotaSalidaAlmacenId);
                notaSalidaAlmacenPorIdBE.AnalisisSensorialAtributoDetalle = _INotaSalidaAlmacenRepository.ConsultarNotaSalidaAlmacenAnalisisSensorialAtributoDetallePorId(request.NotaSalidaAlmacenId);
                notaSalidaAlmacenPorIdBE.AnalisisSensorialDefectoDetalle = _INotaSalidaAlmacenRepository.ConsultarNotaSalidaAlmacenAnalisisSensorialDefectoDetallePorId(request.NotaSalidaAlmacenId);
                notaSalidaAlmacenPorIdBE.DetalleLotes = _INotaSalidaAlmacenRepository.ConsultarNotaSalidaAlmacenLotesDetallePorIdBE(request.NotaSalidaAlmacenId);
                notaSalidaAlmacenPorIdBE.Detalle = _INotaSalidaAlmacenRepository.ConsultarNotaSalidaAlmacenDetallePorId(request.NotaSalidaAlmacenId).ToList();
                notaSalidaAlmacenPorIdBE.RegistroTostadoIndicadorDetalle = _INotaSalidaAlmacenRepository.ConsultarNotaSalidaAlmacenRegistroTostadoIndicadorDetallePorId(request.NotaSalidaAlmacenId).ToList();
                


            }



            return notaSalidaAlmacenPorIdBE;

        }

        //public int ActualizarNotaSalidaAlmacenDetalle(RegistrarNotaSalidaAlmacenDetalleRequestDTO request)
        //{
        //    List<NotaSalidaAlmacenDetalle> lstnotaSalidaAlmacen = new List<NotaSalidaAlmacenDetalle>();

        //    request.ListNotaSalidaAlmacenDetalle.ForEach(x => {
        //        NotaSalidaAlmacenDetalle obj = new NotaSalidaAlmacenDetalle();
        //        obj.LoteId = x.LoteId;
        //        obj.NotaSalidaAlmacenDetalleId = x.NotaSalidaAlmacenDetalleId;
        //        obj.NotaSalidaAlmacenId = x.NotaSalidaAlmacenId;

        //        lstnotaSalidaAlmacen.Add(obj);
        //    });


        //    int affected = _INotaSalidaAlmacenRepository.ActualizarNotaSalidaAlmacenDetalle(lstnotaSalidaAlmacen,request.NotaSalidaAlmacenId);

        //    return affected;
        //}


        public int ActualizarNotaSalidaAlmacenAnalisisCalidad(ActualizarNotaSalidaAnalisisCalidadRequestDTO request)
        {
            NotaSalidaAlmacen notaSalidaAlmacen = new NotaSalidaAlmacen();

            notaSalidaAlmacen.NotaSalidaAlmacenId = request.NotaSalidaAlmacenId;
            notaSalidaAlmacen.ExportableGramosAnalisisFisico = request.ExportableGramosAnalisisFisico;
            notaSalidaAlmacen.ExportablePorcentajeAnalisisFisico = request.ExportablePorcentajeAnalisisFisico;
            notaSalidaAlmacen.DescarteGramosAnalisisFisico = request.DescarteGramosAnalisisFisico;
            notaSalidaAlmacen.DescartePorcentajeAnalisisFisico = request.DescartePorcentajeAnalisisFisico;
            notaSalidaAlmacen.CascarillaGramosAnalisisFisico = request.CascarillaGramosAnalisisFisico;
            notaSalidaAlmacen.CascarillaPorcentajeAnalisisFisico = request.CascarillaPorcentajeAnalisisFisico;
            notaSalidaAlmacen.TotalGramosAnalisisFisico = request.TotalGramosAnalisisFisico;
            notaSalidaAlmacen.TotalPorcentajeAnalisisFisico = request.TotalPorcentajeAnalisisFisico;
            notaSalidaAlmacen.HumedadPorcentajeAnalisisFisico = request.HumedadPorcentajeAnalisisFisico;
            notaSalidaAlmacen.ObservacionAnalisisFisico = request.ObservacionAnalisisFisico;
            notaSalidaAlmacen.UsuarioCalidad = request.UsuarioCalidad;
            notaSalidaAlmacen.ObservacionRegistroTostado = request.ObservacionRegistroTostado;
            notaSalidaAlmacen.ObservacionAnalisisSensorial = request.ObservacionAnalisisSensorial;
            notaSalidaAlmacen.TotalAnalisisSensorial = request.TotalAnalisisSensorial;
            notaSalidaAlmacen.UsuarioCalidad = request.UsuarioCalidad;
            notaSalidaAlmacen.EstadoId = NotaSalidaAlmacenEstados.Analizado;
            notaSalidaAlmacen.FechaCalidad = DateTime.Now;


            int affected = _INotaSalidaAlmacenRepository.ActualizarNotaSalidaAlmacenAnalisisCalidad(notaSalidaAlmacen);

            ConsultaGuiaRemisionAlmacen guiaRemisionPivot = _IGuiaRemisionAlmacenRepository.ConsultaGuiaRemisionAlmacenPorNotaSalidaAlmacenId(notaSalidaAlmacen.NotaSalidaAlmacenId);

            if (guiaRemisionPivot == null)
            {
                GuiaRemisionAlmacen guiaRemisionAlmacen = new GuiaRemisionAlmacen();
                guiaRemisionAlmacen.FechaUltimaActualizacion = DateTime.Now;
                guiaRemisionAlmacen.UsuarioUltimaActualizacion = request.UsuarioCalidad;
                guiaRemisionAlmacen.HumedadPorcentajeAnalisisFisico = request.HumedadPorcentajeAnalisisFisico;
                guiaRemisionAlmacen.GuiaRemisionId = guiaRemisionPivot.GuiaRemisionAlmacenId;
                _IGuiaRemisionAlmacenRepository.ActualizarDatosCalidad(guiaRemisionAlmacen);
            }
                


             

            #region "Analisis Fisico Color"
            if (request.AnalisisFisicoColorDetalleList.FirstOrDefault() != null)
            {

                List<NotaSalidaAlmacenAnalisisFisicoColorDetalleTipo> AnalisisFisicoColorDetalleList = new List<NotaSalidaAlmacenAnalisisFisicoColorDetalleTipo>();

                request.AnalisisFisicoColorDetalleList.ForEach(z => {
                    NotaSalidaAlmacenAnalisisFisicoColorDetalleTipo item = new NotaSalidaAlmacenAnalisisFisicoColorDetalleTipo();
                    item.ColorDetalleDescripcion = z.ColorDetalleDescripcion;
                    item.ColorDetalleId = z.ColorDetalleId;
                    item.NotaSalidaAlmacenId = request.NotaSalidaAlmacenId;
                    item.Valor = z.Valor;
                    AnalisisFisicoColorDetalleList.Add(item);
                });

                affected = _INotaSalidaAlmacenRepository.ActualizarNotaSalidaAlmacenAnalisisFisicoColorDetalle(AnalisisFisicoColorDetalleList, request.NotaSalidaAlmacenId);
            }
            #endregion

            #region Analisis Fisico Defecto Primario
            if (request.AnalisisFisicoDefectoPrimarioDetalleList.FirstOrDefault() != null)
            {
                List<NotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalleTipo> AnalisisFisicoDefectoPrimarioDetalleList = new List<NotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalleTipo>();

                request.AnalisisFisicoDefectoPrimarioDetalleList.ForEach(z => {
                    NotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalleTipo item = new NotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalleTipo();
                    item.DefectoDetalleId = z.DefectoDetalleId;
                    item.DefectoDetalleDescripcion = z.DefectoDetalleDescripcion;
                    item.DefectoDetalleEquivalente = z.DefectoDetalleEquivalente;
                    item.NotaSalidaAlmacenId = request.NotaSalidaAlmacenId;
                    item.Valor = z.Valor;
                    AnalisisFisicoDefectoPrimarioDetalleList.Add(item);
                });

                affected = _INotaSalidaAlmacenRepository.ActualizarNotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalle(AnalisisFisicoDefectoPrimarioDetalleList, request.NotaSalidaAlmacenId);
            }
            #endregion

            #region "Analisis Fisico Defecto Secundario Detalle"
            if (request.AnalisisFisicoDefectoSecundarioDetalleList.FirstOrDefault() != null)
            {
                List<NotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetalleTipo> AnalisisFisicoDefectoSecundarioDetalleList = new List<NotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetalleTipo>();

                request.AnalisisFisicoDefectoSecundarioDetalleList.ForEach(z => {
                    NotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetalleTipo item = new NotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetalleTipo();
                    item.DefectoDetalleId = z.DefectoDetalleId;
                    item.DefectoDetalleDescripcion = z.DefectoDetalleDescripcion;
                    item.DefectoDetalleEquivalente = z.DefectoDetalleEquivalente;
                    item.NotaSalidaAlmacenId = request.NotaSalidaAlmacenId;
                    item.Valor = z.Valor;
                    AnalisisFisicoDefectoSecundarioDetalleList.Add(item);
                });

                affected = _INotaSalidaAlmacenRepository.ActualizarNotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetalle(AnalisisFisicoDefectoSecundarioDetalleList, request.NotaSalidaAlmacenId);
            }
            #endregion

            #region "Analisis Fisico Olor Detalle"
            if (request.AnalisisFisicoOlorDetalleList.FirstOrDefault() != null)
            {
                List<NotaSalidaAlmacenAnalisisFisicoOlorDetalleTipo> AnalisisFisicoDefectoSecundarioDetalleList = new List<NotaSalidaAlmacenAnalisisFisicoOlorDetalleTipo>();

                request.AnalisisFisicoOlorDetalleList.ForEach(z => {
                    NotaSalidaAlmacenAnalisisFisicoOlorDetalleTipo item = new NotaSalidaAlmacenAnalisisFisicoOlorDetalleTipo();
                    item.NotaSalidaAlmacenId = request.NotaSalidaAlmacenId;
                    item.OlorDetalleDescripcion = z.OlorDetalleDescripcion;
                    item.OlorDetalleId = z.OlorDetalleId;
                    item.Valor = z.Valor;
                    AnalisisFisicoDefectoSecundarioDetalleList.Add(item);
                });

                affected = _INotaSalidaAlmacenRepository.ActualizarNotaSalidaAlmacenAnalisisFisicoOlorDetalle(AnalisisFisicoDefectoSecundarioDetalleList, request.NotaSalidaAlmacenId);
            }
            #endregion

            #region "Analisis Sensorial Atributo"
            if (request.AnalisisSensorialAtributoDetalleList.FirstOrDefault() != null)
            {
                List<NotaSalidaAlmacenAnalisisSensorialAtributoDetalleTipo> AnalisisSensorialAtributoDetalle = new List<NotaSalidaAlmacenAnalisisSensorialAtributoDetalleTipo>();

                request.AnalisisSensorialAtributoDetalleList.ForEach(z => {
                    NotaSalidaAlmacenAnalisisSensorialAtributoDetalleTipo item = new NotaSalidaAlmacenAnalisisSensorialAtributoDetalleTipo();
                    item.NotaSalidaAlmacenId = request.NotaSalidaAlmacenId;
                    item.AtributoDetalleDescripcion = z.AtributoDetalleDescripcion;
                    item.AtributoDetalleId = z.AtributoDetalleId;
                    item.Valor = z.Valor;
                    AnalisisSensorialAtributoDetalle.Add(item);
                });

                affected = _INotaSalidaAlmacenRepository.ActualizarNotaSalidaAlmacenAnalisisSensorialAtributoDetalle(AnalisisSensorialAtributoDetalle, request.NotaSalidaAlmacenId);
            }
            #endregion

            if (request.AnalisisSensorialDefectoDetalleList.FirstOrDefault() != null)
            {
                List<NotaSalidaAlmacenAnalisisSensorialDefectoDetalleTipo> AnalisisSensorialDefectoDetalle = new List<NotaSalidaAlmacenAnalisisSensorialDefectoDetalleTipo>();

                request.AnalisisSensorialDefectoDetalleList.ForEach(z => {
                    NotaSalidaAlmacenAnalisisSensorialDefectoDetalleTipo item = new NotaSalidaAlmacenAnalisisSensorialDefectoDetalleTipo();
                    item.NotaSalidaAlmacenId = request.NotaSalidaAlmacenId;
                    item.DefectoDetalleDescripcion = z.DefectoDetalleDescripcion;
                    item.DefectoDetalleId = z.DefectoDetalleId;

                    item.Valor = z.Valor;
                    AnalisisSensorialDefectoDetalle.Add(item);
                });

                affected = _INotaSalidaAlmacenRepository.ActualizarNotaSalidaAlmacenAnalisisSensorialDefectoDetalle(AnalisisSensorialDefectoDetalle, request.NotaSalidaAlmacenId);
            }


            if (request.RegistroTostadoIndicadorDetalleList.FirstOrDefault() != null)
            {
                List<NotaSalidaAlmacenRegistroTostadoIndicadorDetalleTipo> RegistroTostadoIndicadorDetalle = new List<NotaSalidaAlmacenRegistroTostadoIndicadorDetalleTipo>();

                request.RegistroTostadoIndicadorDetalleList.ForEach(z => {

                    NotaSalidaAlmacenRegistroTostadoIndicadorDetalleTipo item = new NotaSalidaAlmacenRegistroTostadoIndicadorDetalleTipo();
                    item.NotaSalidaAlmacenId = request.NotaSalidaAlmacenId;
                    item.IndicadorDetalleDescripcion = z.IndicadorDetalleDescripcion;
                    item.IndicadorDetalleId = z.IndicadorDetalleId;
                    item.Valor = z.Valor;

                    RegistroTostadoIndicadorDetalle.Add(item);
                });

                affected = _INotaSalidaAlmacenRepository.ActualizarNotaSalidaAlmacenRegistroTostadoIndicadorDetalle(RegistroTostadoIndicadorDetalle, request.NotaSalidaAlmacenId);
            }

            return affected;
        }

        public ConsultaGuiaRemisionAlmacen ConsultarImpresionGuiaRemisionAlmacen(int notaSalidaAlmacenId)
        {

            ConsultaGuiaRemisionAlmacen consultaImpresionGuiaRemision = new ConsultaGuiaRemisionAlmacen();
            consultaImpresionGuiaRemision = _IGuiaRemisionAlmacenRepository.ConsultaGuiaRemisionAlmacenPorNotaSalidaAlmacenId(notaSalidaAlmacenId);
            if (consultaImpresionGuiaRemision != null)
            {
                consultaImpresionGuiaRemision.lstConsultaGuiaRemisionAlmacenDetalle = _IGuiaRemisionAlmacenRepository.ConsultaGuiaRemisionAlmacenDetallePorGuiaRemisionAlmacenId(consultaImpresionGuiaRemision.GuiaRemisionAlmacenId);
            }

            return consultaImpresionGuiaRemision;
        }


    }
}
