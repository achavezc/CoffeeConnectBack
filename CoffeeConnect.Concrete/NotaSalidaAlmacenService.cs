
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

       		
			
        
        public int RegistrarNotaCompra(RegistrarActualizarNotaCompraRequestDTO request)
        {
            NotaCompra notaCompra = new NotaCompra();

            notaCompra.GuiaRecepcionMateriaPrimaId = request.GuiaRecepcionMateriaPrimaId;
            notaCompra.EmpresaId = request.EmpresaId;
            notaCompra.Numero = request.Numero;
            notaCompra.UnidadMedidaIdPesado = request.UnidadMedidaIdPesado;
            notaCompra.CantidadPesado = request.CantidadPesado;
            notaCompra.KilosBrutosPesado = request.KilosBrutosPesado;
            notaCompra.TaraPesado = request.TaraPesado;
            notaCompra.KilosNetosPesado = request.KilosNetosPesado;
            notaCompra.DescuentoPorHumedad = request.DescuentoPorHumedad;
            notaCompra.KilosNetosDescontar = request.KilosNetosDescontar;
            notaCompra.KilosNetosPagar = request.KilosNetosPagar;
            notaCompra.QQ55 = request.QQ55;
            
            notaCompra.TipoId = request.TipoId;
            notaCompra.PrecioGuardado = request.PrecioGuardado;
            notaCompra.PrecioPagado = request.PrecioPagado;
            notaCompra.Importe = request.Importe;
            notaCompra.EstadoId = NotaCompraEstados.PorLiquidar;          
            notaCompra.FechaRegistro = DateTime.Now;
            notaCompra.UsuarioRegistro = request.UsuarioNotaCompra;  

            int affected = _INotaSalidaAlmacenRepository.Insertar(notaCompra);

            return affected;
        }

        public int ActualizarNotaCompra(RegistrarActualizarNotaCompraRequestDTO request)
        {
            NotaCompra notaCompra = new NotaCompra();

            notaCompra.GuiaRecepcionMateriaPrimaId = request.GuiaRecepcionMateriaPrimaId;
            notaCompra.NotaCompraId = request.NotaCompraId;
            notaCompra.EmpresaId = request.EmpresaId;
            notaCompra.Numero = request.Numero;
            notaCompra.UnidadMedidaIdPesado = request.UnidadMedidaIdPesado;
            notaCompra.CantidadPesado = request.CantidadPesado;
            notaCompra.KilosBrutosPesado = request.KilosBrutosPesado;
            notaCompra.TaraPesado = request.TaraPesado;
            notaCompra.KilosNetosPesado = request.KilosNetosPesado;
            notaCompra.DescuentoPorHumedad = request.DescuentoPorHumedad;
            notaCompra.KilosNetosDescontar = request.KilosNetosDescontar;
            notaCompra.KilosNetosPagar = request.KilosNetosPagar;
            notaCompra.QQ55 = request.QQ55;
            
            notaCompra.TipoId = request.TipoId;
            notaCompra.PrecioGuardado = request.PrecioGuardado;
            notaCompra.PrecioPagado = request.PrecioPagado;
            notaCompra.Importe = request.Importe;
            notaCompra.EstadoId = NotaCompraEstados.PorLiquidar;
            notaCompra.FechaUltimaActualizacion = DateTime.Now;
            notaCompra.UsuarioUltimaActualizacion = request.UsuarioNotaCompra;

            int affected = _INotaSalidaAlmacenRepository.Actualizar(notaCompra);

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

            }



            return notaSalidaAlmacenPorIdBE;

        }


    }
}
