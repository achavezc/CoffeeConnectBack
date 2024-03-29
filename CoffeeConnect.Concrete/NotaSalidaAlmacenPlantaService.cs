﻿using AutoMapper;
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
    public partial class NotaSalidaAlmacenPlantaService : INotaSalidaAlmacenPlantaService
    {
        private readonly IMapper _Mapper;
        private INotaSalidaAlmacenPlantaRepository _INotaSalidaAlmacenPlantaRepository;
        
        private IUsersRepository _UsersRepository;
        private IEmpresaRepository _EmpresaRepository;
        private ICorrelativoRepository _ICorrelativoRepository;
        private IGuiaRemisionAlmacenPlantaRepository _IGuiaRemisionAlmacenPlantaRepository;
        private INotaIngresoAlmacenPlantaRepository _NotaIngresoAlmacenPlantaRepository;
        private INotaIngresoProductoTerminadoAlmacenPlantaRepository _INotaIngresoProductoTerminadoAlmacenPlantaRepository;

        public NotaSalidaAlmacenPlantaService(INotaSalidaAlmacenPlantaRepository notaSalidaAlmacenPlantaRepository, INotaIngresoProductoTerminadoAlmacenPlantaRepository NotaIngresoProductoTerminadoAlmacenPlanta, IUsersRepository usersRepository,
            IEmpresaRepository empresaRepository, INotaIngresoAlmacenPlantaRepository notaIngresoAlmacenPlantaRepository, ICorrelativoRepository ICorrelativoRepository,
            IGuiaRemisionAlmacenPlantaRepository IGuiaRemisionAlmacenPlantaRepository,
            IMapper mapper)
        {
            _INotaSalidaAlmacenPlantaRepository = notaSalidaAlmacenPlantaRepository;

            _UsersRepository = usersRepository;

            _EmpresaRepository = empresaRepository;

            _INotaIngresoProductoTerminadoAlmacenPlantaRepository = NotaIngresoProductoTerminadoAlmacenPlanta;


            _NotaIngresoAlmacenPlantaRepository = notaIngresoAlmacenPlantaRepository;

            _ICorrelativoRepository = ICorrelativoRepository;

            _IGuiaRemisionAlmacenPlantaRepository = IGuiaRemisionAlmacenPlantaRepository;

            _Mapper = mapper;
        }

        public int RegistrarNotaSalidaAlmacenPlanta(RegistrarNotaSalidaAlmacenPlantaRequestDTO request)
        {
            NotaSalidaAlmacenPlanta notaSalidaAlmacen = new NotaSalidaAlmacenPlanta();
            List<NotaSalidaAlmacenPlantaDetalle> lstnotaSalidaAlmacen = new List<NotaSalidaAlmacenPlantaDetalle>();
            int affected = 0;

            List<TablaIdsTipo> notaIngresoIdActualizar = new List<TablaIdsTipo>();

            notaSalidaAlmacen.EmpresaId = request.EmpresaId;
            notaSalidaAlmacen.AlmacenId = request.AlmacenId;
            //notaSalidaAlmacen.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.NotaSalidaAlmacenPlanta);

            notaSalidaAlmacen.Numero = _ICorrelativoRepository.ObtenerCorrelativoNotaIngreso(DateTime.Now.Year.ToString(), TiposCorrelativosPlanta.NotaSalidaPlantaTipo, request.CodigoTipoConcepto);

            notaSalidaAlmacen.MotivoSalidaId = request.MotivoSalidaId;
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
            notaSalidaAlmacen.CodigoTipoConcepto = request.CodigoTipoConcepto;
            notaSalidaAlmacen.CodigoCampania = request.CodigoCampania;

            notaSalidaAlmacen.EstadoId = NotaSalidaAlmacenEstados.Ingresado;
            notaSalidaAlmacen.FechaRegistro = DateTime.Now;
            notaSalidaAlmacen.UsuarioRegistro = request.UsuarioNotaSalidaAlmacenPlanta;

            notaSalidaAlmacen.NotaSalidaAlmacenPlantaId = _INotaSalidaAlmacenPlantaRepository.Insertar(notaSalidaAlmacen);

            if (notaSalidaAlmacen.NotaSalidaAlmacenPlantaId != 0)
            {
                request.ListNotaSalidaAlmacenPlantaDetalle.ForEach(x =>
                {
                    int notaIngresoProductoTerminadoAlmacenPlantaId = x.NotaIngresoProductoTerminadoAlmacenPlantaId.Value;

                    ConsultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE notaIngresoProductoTerminadoAlmacenPlanta = _INotaIngresoProductoTerminadoAlmacenPlantaRepository.ConsultarNotaIngresoProductoTerminadoAlmacenPlantaPorId(notaIngresoProductoTerminadoAlmacenPlantaId);

                    if (notaIngresoProductoTerminadoAlmacenPlanta != null)
                    {
                        NotaSalidaAlmacenPlantaDetalle notaSalidaAlmacenPlantaDetalle = new NotaSalidaAlmacenPlantaDetalle();
                        notaSalidaAlmacenPlantaDetalle.NotaIngresoProductoTerminadoAlmacenPlantaId = notaIngresoProductoTerminadoAlmacenPlantaId;
                        notaSalidaAlmacenPlantaDetalle.NotaSalidaAlmacenPlantaId = notaSalidaAlmacen.NotaSalidaAlmacenPlantaId;
                        notaSalidaAlmacenPlantaDetalle.ProductoId = notaIngresoProductoTerminadoAlmacenPlanta.ProductoId;
                        notaSalidaAlmacenPlantaDetalle.SubProductoId = notaIngresoProductoTerminadoAlmacenPlanta.SubProductoId;
                        notaSalidaAlmacenPlantaDetalle.EmpaqueId = notaIngresoProductoTerminadoAlmacenPlanta.EmpaqueId;
                        notaSalidaAlmacenPlantaDetalle.TipoId = notaIngresoProductoTerminadoAlmacenPlanta.TipoId;
                        notaSalidaAlmacenPlantaDetalle.Cantidad = x.Cantidad;
                        notaSalidaAlmacenPlantaDetalle.KilosBrutos = x.KilosBrutos;
                        notaSalidaAlmacenPlantaDetalle.KilosNetos = x.KilosNetos;
                        notaSalidaAlmacenPlantaDetalle.Tara = x.Tara;
                        notaSalidaAlmacenPlantaDetalle.Numero = x.Numero;


                        //lstnotaSalidaAlmacen.Add(obj);

                        _INotaSalidaAlmacenPlantaRepository.InsertarNotaSalidaAlmacenPlantaDetalle(notaSalidaAlmacenPlantaDetalle);


                        decimal cantidadDisponible = notaIngresoProductoTerminadoAlmacenPlanta.CantidadDisponible;


                        string estado = NotaIngresoProductoTerminadoAlmacenPlantaEstados.Ingresado;

                        if (x.Cantidad >= cantidadDisponible)
                        {
                            estado = NotaIngresoProductoTerminadoAlmacenPlantaEstados.Consumido;
                        }

                        _INotaIngresoProductoTerminadoAlmacenPlantaRepository.ActualizarCantidadSalidaAlmacenEstado(notaIngresoProductoTerminadoAlmacenPlantaId, notaIngresoProductoTerminadoAlmacenPlanta.CantidadSalidaAlmacen + notaSalidaAlmacenPlantaDetalle.Cantidad, notaIngresoProductoTerminadoAlmacenPlanta.KilosNetosSalidaAlmacen + notaSalidaAlmacenPlantaDetalle.KilosNetos, DateTime.Now, request.UsuarioNotaSalidaAlmacenPlanta, estado);

                    }


                    if (x.NotaIngresoAlmacenPlantaId.HasValue)
                    {
                        TablaIdsTipo tablaLoteIdsTipo = new TablaIdsTipo();
                        tablaLoteIdsTipo.Id = x.NotaIngresoAlmacenPlantaId.Value;
                        notaIngresoIdActualizar.Add(tablaLoteIdsTipo);
                    }
                    

                });

                //ed = _INotaSalidaAlmacenPlantaRepository.ActualizarNotaSalidaAlmacenPlantaDetalle(lstnotaSalidaAlmacen, notaSalidaAlmacen.NotaSalidaAlmacenPlantaId);
                
            }

            /*

            #region Guia Remision

            

            int guiaRemisionAlmacenId;
            //GuiaRemisionAlmacen guiaRemisionAlmacen = new GuiaRemisionAlmacen();

            GuiaRemisionAlmacenPlanta guiaRemisionAlmacen = _Mapper.Map<GuiaRemisionAlmacenPlanta>(notaSalidaAlmacen);
            guiaRemisionAlmacen.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.GuiaRemisionAlmacenPlanta);


            string tipoProduccionId = String.Empty;
            string tipoCertificacionId = String.Empty;

            List<ConsultaNotaSalidaAlmacenPlantaDetallePorIdBE> NotaSalidaDetalle = _INotaSalidaAlmacenPlantaRepository.ConsultarNotaSalidaAlmacenPlantaDetallePorIdBE(notaSalidaAlmacen.NotaSalidaAlmacenPlantaId).ToList();


            ////if (NotaSalidaDetalle.Count > 0)
            ////{
            ////    tipoProduccionId = NotaSalidaDetalle[0].TipoProduccionId;
            ////    tipoCertificacionId = NotaSalidaDetalle[0].CertificacionId;

            ////}

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
                        
                        
                        //item.NumeroNotaIngresoAlmacenPlanta = x.NumeroNotaIngresoAlmacenPlanta;
                        //item.ProductoId = x.ProductoId;
                        //item.SubProductoId = x.SubProductoId;
                        //item.UnidadMedidaIdPesado = x.UnidadMedidaIdPesado;
                        //item.CalidadId = x.CalidadId;
                        //item.GradoId = x.GradoId;
                        //item.CantidadPesado = x.CantidadPesado;
                        //item.CantidadDefectos = x.CantidadDefectos;
                        //item.KilosNetosPesado = x.KilosNetosPesado;
                        //item.KilosBrutosPesado = x.KilosBrutosPesado;
                        //item.TaraPesado = x.TaraPesado;


                        listaDetalle.Add(item);
                    });

                    _IGuiaRemisionAlmacenPlantaRepository.ActualizarGuiaRemisionAlmacenPlantaDetalle(listaDetalle);
                }

            }

            #endregion Guia Remision

            if (notaIngresoIdActualizar.Count > 0)
            {
                _NotaIngresoAlmacenPlantaRepository.ActualizarEstadoPorIds(notaIngresoIdActualizar, DateTime.Now, request.UsuarioNotaSalidaAlmacenPlanta, NotaIngresoAlmacenPlantaEstados.GeneradoNotaSalida);
            }

            */
            return affected;
        }

        public int ActualizarNotaSalidaAlmacenPlanta(RegistrarNotaSalidaAlmacenPlantaRequestDTO request)
        {
            NotaSalidaAlmacenPlanta notaSalidaAlmacen = new NotaSalidaAlmacenPlanta();
            List<NotaSalidaAlmacenPlantaDetalle> lstnotaSalidaAlmacen = new List<NotaSalidaAlmacenPlantaDetalle>();
            int affected = 0;
            List<TablaIdsTipo> notaIngresoIdActualizar = new List<TablaIdsTipo>();


            notaSalidaAlmacen.NotaSalidaAlmacenPlantaId = request.NotaSalidaAlmacenPlantaId;
            notaSalidaAlmacen.EmpresaId = request.EmpresaId;
            notaSalidaAlmacen.AlmacenId = request.AlmacenId;
            notaSalidaAlmacen.Numero = request.Numero;
            notaSalidaAlmacen.MotivoSalidaId = request.MotivoSalidaId;
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
            notaSalidaAlmacen.CodigoTipoConcepto = request.CodigoTipoConcepto;
            notaSalidaAlmacen.CodigoCampania = request.CodigoCampania;

            //notaSalidaAlmacen.EstadoId = request.EstadoId;
            notaSalidaAlmacen.FechaUltimaActualizacion = DateTime.Now;
            notaSalidaAlmacen.UsuarioUltimaActualizacion = request.UsuarioNotaSalidaAlmacenPlanta;
           

            affected = _INotaSalidaAlmacenPlantaRepository.Actualizar(notaSalidaAlmacen);

            if(request.MotivoSalidaId != NotaSalidaAlmacenPlantaMotivos.Rechazo)
            {
                _INotaSalidaAlmacenPlantaRepository.EliminarNotaSalidaAlmacenPlantaDetalle(notaSalidaAlmacen.NotaSalidaAlmacenPlantaId);

                request.ListNotaSalidaAlmacenPlantaDetalle.ForEach(x =>
                {
                    int notaIngresoProductoTerminadoAlmacenPlantaId = x.NotaIngresoProductoTerminadoAlmacenPlantaId.Value;

                    ConsultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE notaIngresoProductoTerminadoAlmacenPlanta = _INotaIngresoProductoTerminadoAlmacenPlantaRepository.ConsultarNotaIngresoProductoTerminadoAlmacenPlantaPorId(notaIngresoProductoTerminadoAlmacenPlantaId);

                    if (notaIngresoProductoTerminadoAlmacenPlanta != null)
                    {
                        NotaSalidaAlmacenPlantaDetalle notaSalidaAlmacenPlantaDetalle = new NotaSalidaAlmacenPlantaDetalle();
                        notaSalidaAlmacenPlantaDetalle.NotaIngresoProductoTerminadoAlmacenPlantaId = notaIngresoProductoTerminadoAlmacenPlantaId;
                        notaSalidaAlmacenPlantaDetalle.NotaSalidaAlmacenPlantaId = notaSalidaAlmacen.NotaSalidaAlmacenPlantaId;
                        notaSalidaAlmacenPlantaDetalle.ProductoId = notaIngresoProductoTerminadoAlmacenPlanta.ProductoId;
                        notaSalidaAlmacenPlantaDetalle.SubProductoId = notaIngresoProductoTerminadoAlmacenPlanta.SubProductoId;
                        notaSalidaAlmacenPlantaDetalle.EmpaqueId = notaIngresoProductoTerminadoAlmacenPlanta.EmpaqueId;
                        notaSalidaAlmacenPlantaDetalle.TipoId = notaIngresoProductoTerminadoAlmacenPlanta.TipoId;
                        notaSalidaAlmacenPlantaDetalle.Cantidad = x.Cantidad;
                        notaSalidaAlmacenPlantaDetalle.KilosBrutos = x.KilosBrutos;
                        notaSalidaAlmacenPlantaDetalle.KilosNetos = x.KilosNetos;
                        notaSalidaAlmacenPlantaDetalle.Tara = x.Tara;
                        notaSalidaAlmacenPlantaDetalle.Numero = x.Numero;

                        //lstnotaSalidaAlmacen.Add(obj);

                        _INotaSalidaAlmacenPlantaRepository.InsertarNotaSalidaAlmacenPlantaDetalle(notaSalidaAlmacenPlantaDetalle);

                        //decimal cantidadDisponible = notaIngresoProductoTerminadoAlmacenPlanta.CantidadDisponible;

                        //string estado = NotaIngresoProductoTerminadoAlmacenPlantaEstados.Ingresado;

                        //if (x.Cantidad >= cantidadDisponible)
                        //{
                        //    estado = NotaIngresoProductoTerminadoAlmacenPlantaEstados.Consumido;
                        //}

                        //_INotaIngresoProductoTerminadoAlmacenPlantaRepository.ActualizarCantidadSalidaAlmacenEstado(notaIngresoProductoTerminadoAlmacenPlantaId, notaIngresoProductoTerminadoAlmacenPlanta.CantidadSalidaAlmacen + notaSalidaAlmacenPlantaDetalle.Cantidad, notaIngresoProductoTerminadoAlmacenPlanta.KilosNetosSalidaAlmacen + notaSalidaAlmacenPlantaDetalle.KilosNetos, DateTime.Now, request.UsuarioNotaSalidaAlmacenPlanta, estado);

                    }

                    if (x.NotaIngresoAlmacenPlantaId.HasValue)
                    {
                        TablaIdsTipo tablaLoteIdsTipo = new TablaIdsTipo();
                        tablaLoteIdsTipo.Id = x.NotaIngresoAlmacenPlantaId.Value;
                        notaIngresoIdActualizar.Add(tablaLoteIdsTipo);
                    }

                });
            }




           



            #region Guia Remision

            int guiaRemisionAlmacenId;
            //GuiaRemisionAlmacen guiaRemisionAlmacen = new GuiaRemisionAlmacen();

            GuiaRemisionAlmacenPlanta guiaRemisionAlmacen = _Mapper.Map<GuiaRemisionAlmacenPlanta>(notaSalidaAlmacen);
            ConsultaGuiaRemisionAlmacenPlanta guiaRemisionPivot = _IGuiaRemisionAlmacenPlantaRepository.ConsultaGuiaRemisionAlmacenPlantaPorNotaSalidaAlmacenPlantaId(notaSalidaAlmacen.NotaSalidaAlmacenPlantaId);

            

            string tipoProduccionId = String.Empty;
            string tipoCertificacionId = String.Empty;

            List<ConsultaNotaSalidaAlmacenPlantaDetallePorIdBE> NotaSalidaDetalle = _INotaSalidaAlmacenPlantaRepository.ConsultarNotaSalidaAlmacenPlantaDetallePorIdBE(notaSalidaAlmacen.NotaSalidaAlmacenPlantaId).ToList();


            //if (NotaSalidaDetalle.Count > 0)
            //{
            //    tipoProduccionId = NotaSalidaDetalle[0].TipoProduccionId;
            //    tipoCertificacionId = NotaSalidaDetalle[0].CertificacionId;

            //}

            guiaRemisionAlmacen.TipoProduccionId = tipoProduccionId;
            guiaRemisionAlmacen.TipoCertificacionId = tipoCertificacionId;

            if (guiaRemisionPivot == null)
            {
                guiaRemisionAlmacen.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.GuiaRemisionAlmacenPlanta);

                guiaRemisionAlmacen.FechaRegistro = DateTime.Now;
                guiaRemisionAlmacen.UsuarioRegistro = request.UsuarioNotaSalidaAlmacenPlanta;
                guiaRemisionAlmacen.EstadoId = GuiaRemisionAlmacenPlantaEstados.Ingresado;
                guiaRemisionAlmacenId = _IGuiaRemisionAlmacenPlantaRepository.Insertar(guiaRemisionAlmacen);
            }
            else
            {
                guiaRemisionAlmacen.FechaUltimaActualizacion = DateTime.Now;
                guiaRemisionAlmacen.UsuarioUltimaActualizacion = request.UsuarioNotaSalidaAlmacenPlanta;

                _IGuiaRemisionAlmacenPlantaRepository.Actualizar(guiaRemisionAlmacen);

                guiaRemisionAlmacenId = guiaRemisionPivot.GuiaRemisionAlmacenPlantaId;
            }


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

                        //item.NumeroNotaIngresoAlmacenPlanta = x.NumeroNotaIngresoAlmacenPlanta;
                        //item.ProductoId = x.ProductoId;
                        //item.SubProductoId = x.SubProductoId;
                        //item.UnidadMedidaIdPesado = x.UnidadMedidaIdPesado;
                        //item.CalidadId = x.CalidadId;
                        //item.GradoId = x.GradoId;
                        //item.CantidadPesado = x.CantidadPesado;
                        //item.CantidadDefectos = x.CantidadDefectos;
                        //item.KilosNetosPesado = x.KilosNetosPesado;
                        //item.KilosBrutosPesado = x.KilosBrutosPesado;
                        //item.TaraPesado = x.TaraPesado;


                        listaDetalle.Add(item);


                        


                    });

                    _IGuiaRemisionAlmacenPlantaRepository.ActualizarGuiaRemisionAlmacenPlantaDetalle(listaDetalle);
                }

            }

           

            #endregion

            return affected;
        }

        public List<ConsultaNotaSalidaAlmacenPlantaBE> ConsultarNotaSalidaAlmacenPlanta(ConsultaNotaSalidaAlmacenPlantaRequestDTO request)
        {
          /*  if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFin == null || request.FechaFin == DateTime.MinValue)
                throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.NotaIngresoPlanta.ValidacionSeleccioneMinimoUnFiltro.Label" });*/

            var list = _INotaSalidaAlmacenPlantaRepository.ConsultarNotaSalidaAlmacenPlanta(request);

            return list.ToList();
        }

        public int AnularNotaSalidaAlmacenPlanta(AnularNotaSalidaAlmacenPlantaRequestDTO request)
        {
            int affected = _INotaSalidaAlmacenPlantaRepository.ActualizarEstado(request.NotaSalidaAlmacenPlantaId, DateTime.Now, request.Usuario, NotaSalidaAlmacenPlantaEstados.Anulado);

            //List<NotaSalidaAlmacenDetalle> notaSalidaAlmacenDetalle = _INotaSalidaAlmacenPlantaRepository.ConsultarNotaSalidaAlmacenDetallePorId(request.NotaSalidaAlmacenId).ToList();

            //notaSalidaAlmacenDetalle.ForEach(notaSalidaDetalle =>
            //{
            //    _LoteRepository.ActualizarEstado(notaSalidaDetalle.LoteId, DateTime.Now, request.Usuario, LoteEstados.Analizado);
            //});

            return affected;
        }

        public ConsultaNotaSalidaAlmacenPlantaPorIdBE ConsultarNotaSalidaAlmacenPlantaPorId(ConsultaNotaSalidaAlmacenPlantaPorIdRequestDTO request)
        {
            ConsultaNotaSalidaAlmacenPlantaPorIdBE notaSalidaAlmacenPorIdBE = _INotaSalidaAlmacenPlantaRepository.ConsultarNotaSalidaAlmacenPlantaPorId(request.NotaSalidaAlmacenPlantaId);

            if (notaSalidaAlmacenPorIdBE != null)
            {

                notaSalidaAlmacenPorIdBE.Detalle = _INotaSalidaAlmacenPlantaRepository.ConsultarNotaSalidaAlmacenPlantaDetallePorIdBE(request.NotaSalidaAlmacenPlantaId);

            }
            return notaSalidaAlmacenPorIdBE;

        }

        public GenerarPDFNotaSalidaAlmacenPlantaResponseDTO GenerarPDFNotaSalidaAlmacenPlanta(int notaSalidaAlmacenIdId, int empresaId)
        {
            GenerarPDFNotaSalidaAlmacenPlantaResponseDTO generarPDFNotaSalidaAlmacenPlantaResponseDTO = new GenerarPDFNotaSalidaAlmacenPlantaResponseDTO();

            ConsultaNotaSalidaAlmacenPlantaPorIdBE consultaImpresionNotaSalidaAlmacenPlanta = new ConsultaNotaSalidaAlmacenPlantaPorIdBE();
            consultaImpresionNotaSalidaAlmacenPlanta = _INotaSalidaAlmacenPlantaRepository.ConsultarNotaSalidaAlmacenPlantaPorId(notaSalidaAlmacenIdId);

            if (consultaImpresionNotaSalidaAlmacenPlanta != null)
            {

                IEnumerable<ConsultaNotaSalidaAlmacenPlantaDetallePorIdBE> detalle = _INotaSalidaAlmacenPlantaRepository.ConsultarNotaSalidaAlmacenPlantaDetallePorIdBE(notaSalidaAlmacenIdId);
                foreach (ConsultaNotaSalidaAlmacenPlantaDetallePorIdBE notaSalidadAlmacenPlantaDetalle in detalle)
                {
                    NotaSalidaAlmacenPlantaListaDetallePDF notaSalidaAlmacenPlantaListaDetalle1 = new NotaSalidaAlmacenPlantaListaDetallePDF();
                    notaSalidaAlmacenPlantaListaDetalle1.TipoEmpaque = notaSalidadAlmacenPlantaDetalle.TipoEmpaque;
                    notaSalidaAlmacenPlantaListaDetalle1.Empaque = notaSalidadAlmacenPlantaDetalle.Empaque;
                    notaSalidaAlmacenPlantaListaDetalle1.Descripcion = notaSalidadAlmacenPlantaDetalle.SubProducto;
                    notaSalidaAlmacenPlantaListaDetalle1.MontoBruto = notaSalidadAlmacenPlantaDetalle.KilosBrutos;
                    notaSalidaAlmacenPlantaListaDetalle1.PesoNeto = notaSalidadAlmacenPlantaDetalle.KilosNetos;
                    notaSalidaAlmacenPlantaListaDetalle1.Cantidad = notaSalidadAlmacenPlantaDetalle.Cantidad;
                    generarPDFNotaSalidaAlmacenPlantaResponseDTO.listaDetalleGM.Add(notaSalidaAlmacenPlantaListaDetalle1);
                }


                CabeceraNotaSalidaAlmacenPlantaPDF cabeceraNotaSalidaAlmacenPlanta = new CabeceraNotaSalidaAlmacenPlantaPDF();

                cabeceraNotaSalidaAlmacenPlanta.RazonSocial = !string.IsNullOrEmpty(consultaImpresionNotaSalidaAlmacenPlanta.RazonSocialEmpresa) ? consultaImpresionNotaSalidaAlmacenPlanta.RazonSocialEmpresa.Trim() : String.Empty;

                cabeceraNotaSalidaAlmacenPlanta.Direccion = consultaImpresionNotaSalidaAlmacenPlanta.DireccionPartida + " - " +
               consultaImpresionNotaSalidaAlmacenPlanta.Departamento + " - " + consultaImpresionNotaSalidaAlmacenPlanta.Provincia + " - " + consultaImpresionNotaSalidaAlmacenPlanta.Distrito;

                //cabeceraGuiaRemision.Direccion = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.DireccionOrganizacion) ? consultaImpresionGuiaRemision.DireccionOrganizacion.Trim() : String.Empty;

                cabeceraNotaSalidaAlmacenPlanta.DireccionCliente = consultaImpresionNotaSalidaAlmacenPlanta.DireccionDestino;
                cabeceraNotaSalidaAlmacenPlanta.Ruc = !string.IsNullOrEmpty(consultaImpresionNotaSalidaAlmacenPlanta.RucEmpresa) ? consultaImpresionNotaSalidaAlmacenPlanta.RucEmpresa.Trim() : String.Empty;
                //cabeceraGuiaRemision.Almacen = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.almacen) ? consultaImpresionGuiaRemision.Almacen.Trim() : String.Empty;
                cabeceraNotaSalidaAlmacenPlanta.Destinatario = !string.IsNullOrEmpty(consultaImpresionNotaSalidaAlmacenPlanta.Destinatario) ? consultaImpresionNotaSalidaAlmacenPlanta.Destinatario.Trim() : String.Empty;
                //cabeceraGuiaRemision.DireccionPartida = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.DireccionPartida) ? consultaImpresionGuiaRemision.DireccionPartida.Trim() : String.Empty;
                cabeceraNotaSalidaAlmacenPlanta.DireccionDestino = !string.IsNullOrEmpty(consultaImpresionNotaSalidaAlmacenPlanta.DireccionDestino) ? consultaImpresionNotaSalidaAlmacenPlanta.DireccionDestino.Trim() : String.Empty;
                cabeceraNotaSalidaAlmacenPlanta.Certificacion = "";// !string.IsNullOrEmpty(consultaImpresionNotaSalidaAlmacenPlanta.CertificacionId) ? consultaImpresionNotaSalidaAlmacenPlanta.CertificacionId.Trim() : String.Empty;
                cabeceraNotaSalidaAlmacenPlanta.TipoProduccion = "";// !string.IsNullOrEmpty(consultaImpresionNotaSalidaAlmacenPlanta.TipoProduccionId) ? consultaImpresionNotaSalidaAlmacenPlanta.TipoProduccionId.Trim() : String.Empty;
                cabeceraNotaSalidaAlmacenPlanta.NumeroGuiaRemision = !string.IsNullOrEmpty(consultaImpresionNotaSalidaAlmacenPlanta.Numero) ? consultaImpresionNotaSalidaAlmacenPlanta.Numero.Trim() : String.Empty;
                cabeceraNotaSalidaAlmacenPlanta.RucDestinatario = !string.IsNullOrEmpty(consultaImpresionNotaSalidaAlmacenPlanta.RucDestinatario) ? consultaImpresionNotaSalidaAlmacenPlanta.RucDestinatario.Trim() : String.Empty;
                cabeceraNotaSalidaAlmacenPlanta.FechaEmision = DateTime.Now;
                cabeceraNotaSalidaAlmacenPlanta.FechaEmisionString = consultaImpresionNotaSalidaAlmacenPlanta.FechaRegistro.ToString("dd/MM/yyyy");
                cabeceraNotaSalidaAlmacenPlanta.FechaEntregaTransportista = DateTime.Now;
                cabeceraNotaSalidaAlmacenPlanta.FechaEntregaTransportistaString = DateTime.Now.ToString("dd/MM/yyyy");
                cabeceraNotaSalidaAlmacenPlanta.CGR = "";// !string.IsNullOrEmpty(consultaImpresionNotaSalidaAlmacenPlanta.NumeroGuiaRemision) ? consultaImpresionNotaSalidaAlmacenPlanta.NumeroGuiaRemision.Trim() : String.Empty;
                //cabeceraGuiaRemision.Certificadora = agenciaCertificadora;
                generarPDFNotaSalidaAlmacenPlantaResponseDTO.Cabecera.Add(cabeceraNotaSalidaAlmacenPlanta);

                NotaSalidaAlmacenPlantaDetallePDF notaSalidaAlmacenPlantaDetalle = new NotaSalidaAlmacenPlantaDetallePDF();
                //guiaRemisionDetalle.TotalLotes = consultaImpresionGuiaRemision.CantidadLotes;
                notaSalidaAlmacenPlantaDetalle.Rendimiento = 0;// consultaImpresionNotaSalidaAlmacenPlanta.RendimientoPorcentaje;
                notaSalidaAlmacenPlantaDetalle.PorcentajeHumedad = 0;// consultaImpresionNotaSalidaAlmacenPlanta.HumedadPorcentaje;
                notaSalidaAlmacenPlantaDetalle.CantidadTotal = 0;// consultaImpresionNotaSalidaAlmacenPlanta.Cantidad;
                notaSalidaAlmacenPlantaDetalle.TotalKGBrutos = 0;//consultaImpresionNotaSalidaAlmacenPlanta.KilosBrutos;
                notaSalidaAlmacenPlantaDetalle.ModalidadTransporte = "TRANSPORTE PRIVADO";
                notaSalidaAlmacenPlantaDetalle.TipoTraslado = "TRANSPORTE PRIVADO";
                notaSalidaAlmacenPlantaDetalle.MotivoTraslado = !string.IsNullOrEmpty(consultaImpresionNotaSalidaAlmacenPlanta.Motivo) ? consultaImpresionNotaSalidaAlmacenPlanta.Motivo.Trim() : String.Empty;
                //guiaRemisionDetalle.MotivoTrasladoId = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.MotivoTrasladoId) ? consultaImpresionGuiaRemision.MotivoTrasladoId.Trim() : String.Empty;
                //guiaRemisionDetalle.MotivoDetalleTraslado = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.MotivoTrasladoReferencia) ? consultaImpresionGuiaRemision.MotivoTrasladoReferencia.Trim() : String.Empty;
                //guiaRemisionDetalle.PropietarioTransportista = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Propietario) ? consultaImpresionGuiaRemision.Propietario.Trim() : String.Empty;
                //guiaRemisionDetalle.TransportistaDomicilio = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.DireccionTransportista) ? consultaImpresionGuiaRemision.DireccionTransportista.Trim() : String.Empty;
                //guiaRemisionDetalle.TransportistaCodigoVehicular = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.ConfiguracionVehicular) ? consultaImpresionGuiaRemision.ConfiguracionVehicular.Trim() : String.Empty;
                notaSalidaAlmacenPlantaDetalle.TransportistaMarca = !string.IsNullOrEmpty(consultaImpresionNotaSalidaAlmacenPlanta.MarcaTractor) ? consultaImpresionNotaSalidaAlmacenPlanta.MarcaTractor.Trim() : String.Empty;
                notaSalidaAlmacenPlantaDetalle.TransportistaRuc = !string.IsNullOrEmpty(consultaImpresionNotaSalidaAlmacenPlanta.RucTransportista) ? consultaImpresionNotaSalidaAlmacenPlanta.RucTransportista.Trim() : String.Empty;
                notaSalidaAlmacenPlantaDetalle.PropietarioTransportista = !string.IsNullOrEmpty(consultaImpresionNotaSalidaAlmacenPlanta.Transportista) ? consultaImpresionNotaSalidaAlmacenPlanta.Transportista.Trim() : String.Empty;
                notaSalidaAlmacenPlantaDetalle.TransportistaPlaca = !string.IsNullOrEmpty(consultaImpresionNotaSalidaAlmacenPlanta.PlacaTractor) ? consultaImpresionNotaSalidaAlmacenPlanta.PlacaTractor.Trim() : String.Empty;
                notaSalidaAlmacenPlantaDetalle.TransportistaPlacaCarreta = String.Empty;
                notaSalidaAlmacenPlantaDetalle.TransportistaConductor = !string.IsNullOrEmpty(consultaImpresionNotaSalidaAlmacenPlanta.Conductor) ? consultaImpresionNotaSalidaAlmacenPlanta.Conductor.Trim() : String.Empty;
                //guiaRemisionDetalle.TransportistaColor = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Color) ? consultaImpresionGuiaRemision.Color.Trim() : String.Empty;
                //guiaRemisionDetalle.TransportistaSoat = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Soat) ? consultaImpresionGuiaRemision.Soat.Trim() : String.Empty;
                //guiaRemisionDetalle.TransportistaDni = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Dni) ? consultaImpresionGuiaRemision.Dni.Trim() : String.Empty;
                //guiaRemisionDetalle.TransportistaColor = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Color) ? consultaImpresionGuiaRemision.Color.Trim() : String.Empty;
                //guiaRemisionDetalle.TransportistaSoat = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Soat) ? consultaImpresionGuiaRemision.Soat.Trim() : String.Empty;
                //guiaRemisionDetalle.TransportistaConstancia = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.NumeroConstanciaMTC) ? consultaImpresionGuiaRemision.NumeroConstanciaMTC.Trim() : String.Empty;
                notaSalidaAlmacenPlantaDetalle.TransportistaConstancia = !string.IsNullOrEmpty(consultaImpresionNotaSalidaAlmacenPlanta.NumeroConstanciaMTC) ? consultaImpresionNotaSalidaAlmacenPlanta.NumeroConstanciaMTC.Trim() : String.Empty;
                notaSalidaAlmacenPlantaDetalle.TransportistaMarcaPlaca = (!string.IsNullOrEmpty(consultaImpresionNotaSalidaAlmacenPlanta.MarcaTractor) ? consultaImpresionNotaSalidaAlmacenPlanta.MarcaTractor.Trim() : String.Empty) + "/" + (!string.IsNullOrEmpty(consultaImpresionNotaSalidaAlmacenPlanta.PlacaTractor) ? consultaImpresionNotaSalidaAlmacenPlanta.PlacaTractor.Trim() : String.Empty);

                
                notaSalidaAlmacenPlantaDetalle.TransportistaBrevete = !string.IsNullOrEmpty(consultaImpresionNotaSalidaAlmacenPlanta.LicenciaConductor) ? consultaImpresionNotaSalidaAlmacenPlanta.LicenciaConductor.Trim() : String.Empty;

                //string motivo = !string.IsNullOrEmpty(consultaImpresionNotaSalidaAlmacenPlanta.MotivoIngreso) ? consultaImpresionNotaSalidaAlmacenPlanta.MotivoIngreso.Trim() : String.Empty;
                string observacion = !string.IsNullOrEmpty(consultaImpresionNotaSalidaAlmacenPlanta.Observacion) ? consultaImpresionNotaSalidaAlmacenPlanta.Observacion.Trim() : String.Empty;

                notaSalidaAlmacenPlantaDetalle.Observaciones = notaSalidaAlmacenPlantaDetalle.MotivoTraslado + " " + observacion;
                notaSalidaAlmacenPlantaDetalle.Responsable = !string.IsNullOrEmpty(consultaImpresionNotaSalidaAlmacenPlanta.UsuarioRegistro) ? consultaImpresionNotaSalidaAlmacenPlanta.UsuarioRegistro.Trim() : String.Empty;

                generarPDFNotaSalidaAlmacenPlantaResponseDTO.detalleGM.Add(notaSalidaAlmacenPlantaDetalle);
            }
            return generarPDFNotaSalidaAlmacenPlantaResponseDTO;
        }


    }
}
