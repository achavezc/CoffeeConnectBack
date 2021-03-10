
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
       
        private INotaSalidaAlmacenRepository _INotaSalidaAlmacenRepository;

        private ILoteRepository _LoteRepository;

        private IUsersRepository _UsersRepository;

        private IEmpresaRepository _EmpresaRepository;

        public NotaSalidaAlmacenService(INotaSalidaAlmacenRepository notaSalidaAlmacenRepository, IUsersRepository usersRepository, IEmpresaRepository empresaRepository, ILoteRepository loteRepository)
        {
            _INotaSalidaAlmacenRepository = notaSalidaAlmacenRepository;

            _UsersRepository = usersRepository;

            _EmpresaRepository = empresaRepository;

            _LoteRepository = loteRepository;
        }

       		
			
        
        public int RegistrarNotaSalidaAlmacen(RegistrarNotaSalidaAlmacenRequestDTO request)
        {
            NotaSalidaAlmacen notaSalidaAlmacen = new NotaSalidaAlmacen();
            List<NotaSalidaAlmacenDetalle> lstnotaSalidaAlmacen = new List<NotaSalidaAlmacenDetalle>();
            int affected = 0;

            notaSalidaAlmacen.NotaSalidaAlmacenId = request.NotaSalidaAlmacenId;
            notaSalidaAlmacen.EmpresaId = request.EmpresaId;
            notaSalidaAlmacen.AlmacenId = request.AlmacenId;
            notaSalidaAlmacen.Numero = request.Numero;
            notaSalidaAlmacen.MotivoTrasladoId = request.MotivoTrasladoId;
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
            notaSalidaAlmacen.PesoNeto = request.PesoNeto;
            notaSalidaAlmacen.PromedioRendimientoPorcentaje = request.PromedioRendimientoPorcentaje;
            notaSalidaAlmacen.MonedaId = request.MonedaId;
            notaSalidaAlmacen.PrecioDia = request.PrecioDia;
            notaSalidaAlmacen.Importe = request.Importe;
            notaSalidaAlmacen.EstadoId = NotaSalidaAlmacenEstados.Ingresado;          
            notaSalidaAlmacen.FechaRegistro = DateTime.Now;
            notaSalidaAlmacen.UsuarioRegistro = request.UsuarioNotaSalidaAlmacen;  

            affected = _INotaSalidaAlmacenRepository.Insertar(notaSalidaAlmacen);
            notaSalidaAlmacen.NotaSalidaAlmacenId = request.NotaSalidaAlmacenId = affected;
            


            if (affected != 0) {
                request.ListNotaSalidaAlmacenDetalle.ForEach(x => {
                    NotaSalidaAlmacenDetalle obj = new NotaSalidaAlmacenDetalle();
                    obj.LoteId = x.LoteId;
                    obj.NotaSalidaAlmacenDetalleId = x.NotaSalidaAlmacenDetalleId;
                    obj.NotaSalidaAlmacenId = request.NotaSalidaAlmacenId;

                    lstnotaSalidaAlmacen.Add(obj);
                });

                affected = _INotaSalidaAlmacenRepository.ActualizarNotaSalidaAlmacenDetalle(lstnotaSalidaAlmacen, request.NotaSalidaAlmacenId);

            }

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
            notaSalidaAlmacen.PesoNeto = request.PesoNeto;
            notaSalidaAlmacen.PromedioRendimientoPorcentaje = request.PromedioRendimientoPorcentaje;
            notaSalidaAlmacen.MonedaId = request.MonedaId;
            notaSalidaAlmacen.PrecioDia = request.PrecioDia;
            notaSalidaAlmacen.Importe = request.Importe;
            notaSalidaAlmacen.EstadoId = request.EstadoId;
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
                notaSalidaAlmacenPorIdBE.DetalleLotes = _INotaSalidaAlmacenRepository.ConsultarNotaSalidaAlmacenDetalleLotesPorId(request.NotaSalidaAlmacenId);

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


    }
}
