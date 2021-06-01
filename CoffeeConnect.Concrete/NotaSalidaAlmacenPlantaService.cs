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

        private ILoteRepository _LoteRepository;

        private IUsersRepository _UsersRepository;

        private IEmpresaRepository _EmpresaRepository;
        private ICorrelativoRepository _ICorrelativoRepository;

        private IGuiaRemisionAlmacenRepository _IGuiaRemisionAlmacenRepository;


        public NotaSalidaAlmacenPlantaService(INotaSalidaAlmacenPlantaRepository notaSalidaAlmacenPlantaRepository, IUsersRepository usersRepository,
            IEmpresaRepository empresaRepository, ILoteRepository loteRepository, ICorrelativoRepository ICorrelativoRepository,
            IGuiaRemisionAlmacenRepository IGuiaRemisionAlmacenRepository,
            IMapper mapper)
        {
            _INotaSalidaAlmacenPlantaRepository = notaSalidaAlmacenPlantaRepository;

            _UsersRepository = usersRepository;

            _EmpresaRepository = empresaRepository;

            _LoteRepository = loteRepository;

            _ICorrelativoRepository = ICorrelativoRepository;

            _IGuiaRemisionAlmacenRepository = IGuiaRemisionAlmacenRepository;

            _Mapper = mapper;
        }




        public int RegistrarNotaSalidaAlmacenPlanta(RegistrarNotaSalidaAlmacenPlantaRequestDTO request)
        {
            NotaSalidaAlmacenPlanta notaSalidaAlmacen = new NotaSalidaAlmacenPlanta();
            List<NotaSalidaAlmacenDetalle> lstnotaSalidaAlmacen = new List<NotaSalidaAlmacenDetalle>();
            int affected = 0;

            List<TablaIdsTipo> loteIdActualizar = new List<TablaIdsTipo>();

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






            return affected;
        }

        public int ActualizarNotaSalidaAlmacenPlanta(RegistrarNotaSalidaAlmacenPlantaRequestDTO request)
        {
            NotaSalidaAlmacenPlanta notaSalidaAlmacen = new NotaSalidaAlmacenPlanta();
            List<NotaSalidaAlmacenDetalle> lstnotaSalidaAlmacen = new List<NotaSalidaAlmacenDetalle>();
            int affected = 0;
            List<TablaIdsTipo> loteIdActualizar = new List<TablaIdsTipo>();


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


            affected = _INotaSalidaAlmacenPlantaRepository.Actualizar(notaSalidaAlmacen);





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

            //if (notaSalidaAlmacenPorIdBE != null)
            //{

            //    notaSalidaAlmacenPorIdBE.DetalleLotes = _INotaSalidaAlmacenPlantaRepository.ConsultarNotaSalidaAlmacenPlantaLotesDetallePorIdBE(request.NotaSalidaAlmacenId);


            //}



            return notaSalidaAlmacenPorIdBE;

        }

        
    }
}
