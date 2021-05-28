using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeConnect.Service
{
    public partial class GuiaRemisionAlmacenService : IGuiaRemisionAlmacenService
    {
        private readonly IMapper _Mapper;

        private IGuiaRemisionAlmacenRepository _IGuiaRemisionAlmacenRepository;

        public GuiaRemisionAlmacenService(IGuiaRemisionAlmacenRepository IGuiaRemisionAlmacenRepository,
            IMapper mapper)
        {
            _IGuiaRemisionAlmacenRepository = IGuiaRemisionAlmacenRepository;

            _Mapper = mapper;
        }

        public GenerarPDFGuiaRemisionResponseDTO GenerarPDFGuiaRemisionPorNotaSalidaAlmacenId(int notaSalidaAlmacenIdId)
        {
            GenerarPDFGuiaRemisionResponseDTO generarPDFGuiaRemisionResponseDTO = new GenerarPDFGuiaRemisionResponseDTO();

            ConsultaGuiaRemisionAlmacen consultaImpresionGuiaRemision = new ConsultaGuiaRemisionAlmacen();
            consultaImpresionGuiaRemision = _IGuiaRemisionAlmacenRepository.ConsultaGuiaRemisionAlmacenPorNotaSalidaAlmacenId(notaSalidaAlmacenIdId);

            List<ConsultaGuiaRemisionAlmacenDetalle> detalleGuiaRemision = _IGuiaRemisionAlmacenRepository.ConsultaGuiaRemisionAlmacenDetallePorGuiaRemisionAlmacenId(consultaImpresionGuiaRemision.GuiaRemisionAlmacenId).ToList();

            int contador = 1;

            //string[] agenciasTotal= { };
            //string[] certificacionTotal = { };

            detalleGuiaRemision.ForEach(z =>
            {
                GuiaRemisionListaDetalle guiaRemisionListaDetalle = new GuiaRemisionListaDetalle();
                guiaRemisionListaDetalle.correlativo = contador;
                contador++;
                //string[] agencias = z.AgenciaCertificadora.Split("|");
                //string[] certificaciones = z.Certificacion.Split("|");

                //agenciasTotal = agenciasTotal.Concat(agencias).ToArray();
                //certificacionTotal = certificacionTotal.Concat(certificaciones).ToArray();

                guiaRemisionListaDetalle.NumeroLote = z.NumeroLote.Trim();
                guiaRemisionListaDetalle.FechaLote = z.FechaLote;
                guiaRemisionListaDetalle.TipoProducto = z.Producto.Trim();
                guiaRemisionListaDetalle.UnidadMedida = z.UnidadMedida + " Plastico";
                guiaRemisionListaDetalle.Cantidad = z.CantidadPesado;
                guiaRemisionListaDetalle.PesoNeto = z.KilosNetosPesado;
                guiaRemisionListaDetalle.HumedadPorcentaje = z.HumedadPorcentaje;
                guiaRemisionListaDetalle.RendimientoPorcentaje = z.RendimientoPorcentaje;
                guiaRemisionListaDetalle.TipoCertificacion = z.TipoCertificacion.Trim();
                guiaRemisionListaDetalle.TipoProduccion = z.TipoProduccion.Trim();
                guiaRemisionListaDetalle.Producto = z.Producto.Trim();
                guiaRemisionListaDetalle.SubProducto = z.SubProducto.Trim();
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
            cabeceraGuiaRemision.RazonSocial = consultaImpresionGuiaRemision.RazonSocialEmpresa.Trim();
            cabeceraGuiaRemision.Direccion = consultaImpresionGuiaRemision.DireccionPartida.Trim();
            cabeceraGuiaRemision.FechaEmision = DateTime.Now;
            cabeceraGuiaRemision.FechaEntregaTransportista = DateTime.Now;

            cabeceraGuiaRemision.Ruc = consultaImpresionGuiaRemision.RucEmpresa.Trim();
            cabeceraGuiaRemision.Almacen = consultaImpresionGuiaRemision.Almacen.Trim();
            cabeceraGuiaRemision.Destinatario = consultaImpresionGuiaRemision.Destinatario.Trim();
            cabeceraGuiaRemision.RucDestinatario = consultaImpresionGuiaRemision.RucDestinatario.Trim();
            cabeceraGuiaRemision.DireccionPartida = consultaImpresionGuiaRemision.DireccionPartida.Trim();
            cabeceraGuiaRemision.DireccionDestino = consultaImpresionGuiaRemision.DireccionDestino.Trim();
            cabeceraGuiaRemision.Certificacion = consultaImpresionGuiaRemision.Certificacion.Trim();
            cabeceraGuiaRemision.TipoProduccion = consultaImpresionGuiaRemision.TipoProduccion.Trim();
            cabeceraGuiaRemision.NumeroGuiaRemision = consultaImpresionGuiaRemision.Numero.Trim();

            
            //cabeceraGuiaRemision.Certificadora = agenciaCertificadora;


            generarPDFGuiaRemisionResponseDTO.Cabecera.Add(cabeceraGuiaRemision);


            GuiaRemisionDetalle guiaRemisionDetalle = new GuiaRemisionDetalle();
            guiaRemisionDetalle.TotalLotes = consultaImpresionGuiaRemision.CantidadLotes;
            guiaRemisionDetalle.Rendimiento = consultaImpresionGuiaRemision.PromedioPorcentajeRendimiento;
            guiaRemisionDetalle.PorcentajeHumedad = consultaImpresionGuiaRemision.HumedadPorcentajeAnalisisFisico;
            guiaRemisionDetalle.CantidadTotal = consultaImpresionGuiaRemision.CantidadTotal;
            guiaRemisionDetalle.TotalKGBrutos = consultaImpresionGuiaRemision.PesoKilosBrutos;
            guiaRemisionDetalle.ModalidadTransporte = "TRANSPORTE PRIVADO";
            guiaRemisionDetalle.TipoTraslado = "TRANSPORTE PRIVADO";


            guiaRemisionDetalle.MotivoTraslado = consultaImpresionGuiaRemision.Motivo.Trim();
            guiaRemisionDetalle.MotivoTrasladoId = consultaImpresionGuiaRemision.MotivoTrasladoId;
            guiaRemisionDetalle.MotivoDetalleTraslado = consultaImpresionGuiaRemision.MotivoTrasladoReferencia.Trim();
            guiaRemisionDetalle.PropietarioTransportista = consultaImpresionGuiaRemision.Transportista.Trim();
            guiaRemisionDetalle.TransportistaDomicilio = consultaImpresionGuiaRemision.DireccionTransportista.Trim();
            guiaRemisionDetalle.TransportistaCodigoVehicular = consultaImpresionGuiaRemision.ConfiguracionVehicular.Trim();
            guiaRemisionDetalle.TransportistaMarca = consultaImpresionGuiaRemision.MarcaTractor.Trim();
            guiaRemisionDetalle.TransportistaRuc = consultaImpresionGuiaRemision.RucTransportista.Trim();
            guiaRemisionDetalle.TransportistaPlaca = consultaImpresionGuiaRemision.PlacaTractor.Trim();
            guiaRemisionDetalle.TransportistaConductor = consultaImpresionGuiaRemision.Conductor.Trim();

            guiaRemisionDetalle.TransportistaColor = consultaImpresionGuiaRemision.Color.Trim();
            guiaRemisionDetalle.TransportistaSoat = consultaImpresionGuiaRemision.Soat.Trim();
            guiaRemisionDetalle.TransportistaDni = consultaImpresionGuiaRemision.Dni.Trim();


            guiaRemisionDetalle.TransportistaConstancia = consultaImpresionGuiaRemision.NumeroConstanciaMTC.Trim();
            guiaRemisionDetalle.TransportistaBrevete = consultaImpresionGuiaRemision.LicenciaConductor.Trim();
            guiaRemisionDetalle.Observaciones = consultaImpresionGuiaRemision.Observacion.Trim();
            guiaRemisionDetalle.Responsable = consultaImpresionGuiaRemision.UsuarioRegistro.Trim();


            generarPDFGuiaRemisionResponseDTO.detalleGM.Add(guiaRemisionDetalle);


            return generarPDFGuiaRemisionResponseDTO;
        }
    }
}
