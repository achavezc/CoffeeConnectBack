using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeConnect.Service
{
    public partial class NotaSalidaAlmacenPlantaService : INotaSalidaAlmacenPlantaService
    {
        private readonly IMapper _Mapper;

        private INotaSalidaAlmacenPlantaRepository _INotaSalidaAlmacenPlantaRepository;

        private INotaIngresoAlmacenPlantaRepository _NotaIngresoAlmacenPlantaRepository;

        private IUsersRepository _UsersRepository;

        private IEmpresaRepository _EmpresaRepository;
        private ICorrelativoRepository _ICorrelativoRepository;

        private IGuiaRemisionAlmacenPlantaRepository _IGuiaRemisionAlmacenPlantaRepository;


        public NotaSalidaAlmacenPlantaService(INotaSalidaAlmacenPlantaRepository notaSalidaAlmacenPlantaRepository, IUsersRepository usersRepository,
            IEmpresaRepository empresaRepository, INotaIngresoAlmacenPlantaRepository notaIngresoAlmacenPlantaRepository, ICorrelativoRepository ICorrelativoRepository,
            IGuiaRemisionAlmacenPlantaRepository IGuiaRemisionAlmacenPlantaRepository,
            IMapper mapper)
        {
            _INotaSalidaAlmacenPlantaRepository = notaSalidaAlmacenPlantaRepository;

            _UsersRepository = usersRepository;

            _EmpresaRepository = empresaRepository;

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
            notaSalidaAlmacen.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.NotaSalidaAlmacenPlanta);
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

                    lstnotaSalidaAlmacen.Add(obj);


                    TablaIdsTipo tablaLoteIdsTipo = new TablaIdsTipo();
                    tablaLoteIdsTipo.Id = x.NotaIngresoAlmacenPlantaId;
                    notaIngresoIdActualizar.Add(tablaLoteIdsTipo);

                });

                affected = _INotaSalidaAlmacenPlantaRepository.ActualizarNotaSalidaAlmacenPlantaDetalle(lstnotaSalidaAlmacen, notaSalidaAlmacen.NotaSalidaAlmacenPlantaId);


                _NotaIngresoAlmacenPlantaRepository.ActualizarEstadoPorIds(notaIngresoIdActualizar, DateTime.Now, request.UsuarioNotaSalidaAlmacenPlanta, NotaIngresoAlmacenPlantaEstados.GeneradoNotaSalida);
            }


            int guiaRemisionAlmacenId;
            //GuiaRemisionAlmacen guiaRemisionAlmacen = new GuiaRemisionAlmacen();

            GuiaRemisionAlmacenPlanta guiaRemisionAlmacen = _Mapper.Map<GuiaRemisionAlmacenPlanta>(notaSalidaAlmacen);
            guiaRemisionAlmacen.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.GuiaRemisionAlmacenPlanta);

            

           

            string tipoProduccionId = String.Empty;
            string tipoCertificacionId = String.Empty;

            //List<ConsultaNotaSalidaAlmacenLotesDetallePorIdBE> NotaSalidaDetalle = _INotaSalidaAlmacenPlantaRepository.ConsultarNotaSalidaAlmacenLotesDetallePorIdBE(notaSalidaAlmacen.NotaSalidaAlmacenId).ToList();


            //if (NotaSalidaDetalle.Count > 0)
            //{
            //    tipoProduccionId = NotaSalidaDetalle[0].TipoProduccionId;
            //    tipoCertificacionId = NotaSalidaDetalle[0].TipoCertificacionId;

            //}

            guiaRemisionAlmacen.TipoProduccionId = ""; ;
            guiaRemisionAlmacen.TipoCertificacionId = "";


            guiaRemisionAlmacenId = _IGuiaRemisionAlmacenPlantaRepository.Insertar(guiaRemisionAlmacen);

            //if (guiaRemisionAlmacenId != 0)
            //{
            //    List<GuiaRemisionAlmacenDetalleTipo> listaDetalle = new List<GuiaRemisionAlmacenDetalleTipo>();
            //    if (NotaSalidaDetalle.Any())
            //    {
            //        NotaSalidaDetalle.ForEach(x =>
            //        {
            //            GuiaRemisionAlmacenDetalleTipo item = _Mapper.Map<GuiaRemisionAlmacenDetalleTipo>(x);
            //            item.GuiaRemisionAlmacenId = guiaRemisionAlmacenId;
            //            item.FechaLote = x.FechaRegistro;
            //            item.UnidadMedidaIdPesado = x.UnidadMedidaId;
            //            item.ProductoId = x.ProductoId;
            //            item.SubProductoId = x.SubProductoId;
            //            item.NumeroLote = x.NumeroLote;
            //            item.CantidadPesado = x.Cantidad;
            //            item.KilosNetosPesado = x.TotalKilosNetosPesado;
            //            item.KilosBrutosPesado = x.TotalKilosBrutosPesado;
            //            item.RendimientoPorcentaje = x.RendimientoPorcentaje;
            //            item.HumedadPorcentaje = x.HumedadPorcentajeAnalisisFisico;
            //            item.TipoProduccionId = x.TipoProduccionId;
            //            item.TipoCertificacionId = x.TipoCertificacionId;
            //            listaDetalle.Add(item);
            //        });

            //        _IGuiaRemisionAlmacenRepository.ActualizarGuiaRemisionAlmacenDetalle(listaDetalle);
            //    }

            //}

            _NotaIngresoAlmacenPlantaRepository.ActualizarEstadoPorIds(notaIngresoIdActualizar, DateTime.Now, request.UsuarioNotaSalidaAlmacenPlanta, NotaIngresoAlmacenPlantaEstados.GeneradoNotaSalida);

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

            //notaSalidaAlmacen.EstadoId = request.EstadoId;
            notaSalidaAlmacen.FechaUltimaActualizacion = DateTime.Now;
            notaSalidaAlmacen.UsuarioUltimaActualizacion = request.UsuarioNotaSalidaAlmacenPlanta;


            notaSalidaAlmacen.NotaSalidaAlmacenPlantaId = _INotaSalidaAlmacenPlantaRepository.Actualizar(notaSalidaAlmacen);


            if (notaSalidaAlmacen.NotaSalidaAlmacenPlantaId != 0)
            {
                request.ListNotaSalidaAlmacenPlantaDetalle.ForEach(x =>
                {
                    NotaSalidaAlmacenPlantaDetalle obj = new NotaSalidaAlmacenPlantaDetalle();
                    obj.NotaIngresoAlmacenPlantaId = x.NotaIngresoAlmacenPlantaId;
                    obj.NotaSalidaAlmacenPlantaId = notaSalidaAlmacen.NotaSalidaAlmacenPlantaId;

                    lstnotaSalidaAlmacen.Add(obj);


                    TablaIdsTipo tablaLoteIdsTipo = new TablaIdsTipo();
                    tablaLoteIdsTipo.Id = x.NotaIngresoAlmacenPlantaId;
                    notaIngresoIdActualizar.Add(tablaLoteIdsTipo);

                });

                affected = _INotaSalidaAlmacenPlantaRepository.ActualizarNotaSalidaAlmacenPlantaDetalle(lstnotaSalidaAlmacen, notaSalidaAlmacen.NotaSalidaAlmacenPlantaId);


                _NotaIngresoAlmacenPlantaRepository.ActualizarEstadoPorIds(notaIngresoIdActualizar, DateTime.Now, request.UsuarioNotaSalidaAlmacenPlanta, NotaIngresoAlmacenPlantaEstados.GeneradoNotaSalida);
            }


            return affected;
        }


        public List<ConsultaNotaSalidaAlmacenPlantaBE> ConsultarNotaSalidaAlmacenPlanta(ConsultaNotaSalidaAlmacenPlantaRequestDTO request)
        {
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

        
    }
}
