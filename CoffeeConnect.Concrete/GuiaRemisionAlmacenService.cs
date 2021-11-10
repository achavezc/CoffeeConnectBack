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

            if (consultaImpresionGuiaRemision != null)
            {
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

                    //guiaRemisionListaDetalle.NumeroLote = z.NumeroLote.Trim();
                    //guiaRemisionListaDetalle.FechaLoteString = z.FechaLoteString;
                    //guiaRemisionListaDetalle.TipoProducto = z.Producto.Trim();
                    guiaRemisionListaDetalle.TipoProducto = !string.IsNullOrEmpty(z.Producto) ? z.Producto.Trim() : String.Empty;


                    //guiaRemisionListaDetalle.UnidadMedida = z.UnidadMedida + " Plastico";
                    guiaRemisionListaDetalle.UnidadMedida = !string.IsNullOrEmpty(z.UnidadMedida) ? z.UnidadMedida.Trim() : String.Empty + " Plastico";



                    guiaRemisionListaDetalle.Cantidad = z.CantidadPesado;
                    guiaRemisionListaDetalle.PesoNeto = z.KilosBrutosPesado;
                    //guiaRemisionListaDetalle.HumedadPorcentaje = z.HumedadPorcentaje;
                    //guiaRemisionListaDetalle.RendimientoPorcentaje = z.RendimientoPorcentaje;
                    //guiaRemisionListaDetalle.TipoCertificacion = z.TipoCertificacion.Trim();
                    guiaRemisionListaDetalle.TipoCertificacion = !string.IsNullOrEmpty(z.TipoCertificacion) ? z.TipoCertificacion.Trim() : String.Empty;

                    //guiaRemisionListaDetalle.TipoProduccion = z.TipoProduccion.Trim();
                    guiaRemisionListaDetalle.TipoProduccion = !string.IsNullOrEmpty(z.TipoProduccion) ? z.TipoProduccion.Trim() : String.Empty;

                    //guiaRemisionListaDetalle.Producto = z.Producto.Trim();
                    guiaRemisionListaDetalle.Producto = !string.IsNullOrEmpty(z.Producto) ? z.Producto.Trim() : String.Empty;

                    //guiaRemisionListaDetalle.SubProducto = z.SubProducto.Trim();
                    guiaRemisionListaDetalle.SubProducto = !string.IsNullOrEmpty(z.SubProducto) ? z.SubProducto.Trim() : String.Empty;



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


                cabeceraGuiaRemision.RazonSocial = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.RazonSocialEmpresa) ? consultaImpresionGuiaRemision.RazonSocialEmpresa.Trim() : String.Empty;
                cabeceraGuiaRemision.Direccion = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.DireccionPartida) ? consultaImpresionGuiaRemision.DireccionPartida.Trim() : String.Empty;
                cabeceraGuiaRemision.Ruc = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.RucEmpresa) ? consultaImpresionGuiaRemision.RucEmpresa.Trim() : String.Empty;
                cabeceraGuiaRemision.Almacen = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Almacen) ? consultaImpresionGuiaRemision.Almacen.Trim() : String.Empty;
                cabeceraGuiaRemision.Destinatario = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Destinatario) ? consultaImpresionGuiaRemision.Destinatario.Trim() : String.Empty;
                cabeceraGuiaRemision.DireccionPartida = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.DireccionPartida) ? consultaImpresionGuiaRemision.DireccionPartida.Trim() : String.Empty;
                cabeceraGuiaRemision.DireccionDestino = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.DireccionDestino) ? consultaImpresionGuiaRemision.DireccionDestino.Trim() : String.Empty;
                cabeceraGuiaRemision.Certificacion = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Certificacion) ? consultaImpresionGuiaRemision.Certificacion.Trim() : String.Empty;
                cabeceraGuiaRemision.TipoProduccion = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.TipoProduccion) ? consultaImpresionGuiaRemision.TipoProduccion.Trim() : String.Empty;
                cabeceraGuiaRemision.NumeroGuiaRemision = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Numero) ? consultaImpresionGuiaRemision.Numero.Trim() : String.Empty;
                cabeceraGuiaRemision.RucDestinatario = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.RucDestinatario) ? consultaImpresionGuiaRemision.RucDestinatario.Trim() : String.Empty;
                cabeceraGuiaRemision.FechaEmision = DateTime.Now;
                cabeceraGuiaRemision.FechaEmisionString = DateTime.Now.ToString("dd/MM/yyyy");
                cabeceraGuiaRemision.FechaEntregaTransportista = DateTime.Now;
                cabeceraGuiaRemision.FechaEntregaTransportistaString = DateTime.Now.ToString("dd/MM/yyyy");

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
                guiaRemisionDetalle.MotivoTraslado = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Motivo) ? consultaImpresionGuiaRemision.Motivo.Trim() : String.Empty;
                guiaRemisionDetalle.MotivoTrasladoId = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.MotivoTrasladoId) ? consultaImpresionGuiaRemision.MotivoTrasladoId.Trim() : String.Empty;
                guiaRemisionDetalle.MotivoDetalleTraslado = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.MotivoTrasladoReferencia) ? consultaImpresionGuiaRemision.MotivoTrasladoReferencia.Trim() : String.Empty;
                guiaRemisionDetalle.PropietarioTransportista = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Propietario) ? consultaImpresionGuiaRemision.Propietario.Trim() : String.Empty;
                guiaRemisionDetalle.TransportistaDomicilio = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.DireccionTransportista) ? consultaImpresionGuiaRemision.DireccionTransportista.Trim() : String.Empty;
                guiaRemisionDetalle.TransportistaCodigoVehicular = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.ConfiguracionVehicular) ? consultaImpresionGuiaRemision.ConfiguracionVehicular.Trim() : String.Empty;
                guiaRemisionDetalle.TransportistaMarca = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.MarcaTractor) ? consultaImpresionGuiaRemision.MarcaTractor.Trim() : String.Empty;
                guiaRemisionDetalle.TransportistaRuc = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.RucTransportista) ? consultaImpresionGuiaRemision.RucTransportista.Trim() : String.Empty;
                guiaRemisionDetalle.TransportistaRazonSocial = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Transportista) ? consultaImpresionGuiaRemision.Transportista.Trim() : String.Empty;
                guiaRemisionDetalle.TransportistaPlaca = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.PlacaTractor) ? consultaImpresionGuiaRemision.PlacaTractor.Trim() : String.Empty;
                guiaRemisionDetalle.TransportistaPlacaCarreta = String.Empty;
                guiaRemisionDetalle.TransportistaConductor = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Conductor) ? consultaImpresionGuiaRemision.Conductor.Trim() : String.Empty;
                guiaRemisionDetalle.TransportistaColor = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Color) ? consultaImpresionGuiaRemision.Color.Trim() : String.Empty;
                guiaRemisionDetalle.TransportistaSoat = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Soat) ? consultaImpresionGuiaRemision.Soat.Trim() : String.Empty;
                guiaRemisionDetalle.TransportistaDni = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Dni) ? consultaImpresionGuiaRemision.Dni.Trim() : String.Empty;
                guiaRemisionDetalle.TransportistaColor = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Color) ? consultaImpresionGuiaRemision.Color.Trim() : String.Empty;
                guiaRemisionDetalle.TransportistaSoat = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Soat) ? consultaImpresionGuiaRemision.Soat.Trim() : String.Empty;
                guiaRemisionDetalle.TransportistaConstancia = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.NumeroConstanciaMTC) ? consultaImpresionGuiaRemision.NumeroConstanciaMTC.Trim() : String.Empty;
                guiaRemisionDetalle.TransportistaBrevete = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.LicenciaConductor) ? consultaImpresionGuiaRemision.LicenciaConductor.Trim() : String.Empty;
                guiaRemisionDetalle.Observaciones = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.Observacion) ? consultaImpresionGuiaRemision.Observacion.Trim() : String.Empty;
                guiaRemisionDetalle.Responsable = !string.IsNullOrEmpty(consultaImpresionGuiaRemision.UsuarioRegistro) ? consultaImpresionGuiaRemision.UsuarioRegistro.Trim() : String.Empty;

                generarPDFGuiaRemisionResponseDTO.detalleGM.Add(guiaRemisionDetalle);
            }
            return generarPDFGuiaRemisionResponseDTO;
        }
    }
}
