using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
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

                guiaRemisionListaDetalle.NumeroLote = z.NumeroLote;
                guiaRemisionListaDetalle.FechaLote = z.FechaLote;
                guiaRemisionListaDetalle.TipoProducto = z.Producto;
                guiaRemisionListaDetalle.UnidadMedida = z.UnidadMedida;
                guiaRemisionListaDetalle.Cantidad = z.CantidadPesado;
                guiaRemisionListaDetalle.PesoBruto = z.KilosBrutosPesado;
                guiaRemisionListaDetalle.HumedadPorcentaje = z.HumedadPorcentaje;
                guiaRemisionListaDetalle.RendimientoPorcentaje = z.RendimientoPorcentaje;

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
            cabeceraGuiaRemision.RazonSocial = consultaImpresionGuiaRemision.RazonSocialEmpresa;
            cabeceraGuiaRemision.Direccion = consultaImpresionGuiaRemision.DireccionPartida;
            cabeceraGuiaRemision.Fecha = consultaImpresionGuiaRemision.FechaRegistro;
            cabeceraGuiaRemision.Ruc = consultaImpresionGuiaRemision.RucEmpresa;
            cabeceraGuiaRemision.Almacen = consultaImpresionGuiaRemision.Almacen;
            cabeceraGuiaRemision.Destinatario = consultaImpresionGuiaRemision.Destinatario;
            cabeceraGuiaRemision.RucDestinatario = consultaImpresionGuiaRemision.RucDestinatario;
            cabeceraGuiaRemision.DireccionPartida = consultaImpresionGuiaRemision.DireccionPartida;
            cabeceraGuiaRemision.DireccionDestino = consultaImpresionGuiaRemision.DireccionDestino;
            cabeceraGuiaRemision.Certificacion = consultaImpresionGuiaRemision.Certificacion;
            cabeceraGuiaRemision.TipoProduccion = consultaImpresionGuiaRemision.TipoProduccion;
            //cabeceraGuiaRemision.Certificadora = agenciaCertificadora;


            generarPDFGuiaRemisionResponseDTO.Cabecera.Add(cabeceraGuiaRemision);


            GuiaRemisionDetalle guiaRemisionDetalle = new GuiaRemisionDetalle();
            guiaRemisionDetalle.TotalLotes = consultaImpresionGuiaRemision.CantidadLotes;
            guiaRemisionDetalle.Rendimiento = consultaImpresionGuiaRemision.PromedioPorcentajeRendimiento;
            guiaRemisionDetalle.PorcentajeHumedad = consultaImpresionGuiaRemision.HumedadPorcentajeAnalisisFisico;
            guiaRemisionDetalle.CantidadTotal = consultaImpresionGuiaRemision.CantidadTotal;
            guiaRemisionDetalle.TotalKGBrutos = consultaImpresionGuiaRemision.PesoKilosBrutos;

            guiaRemisionDetalle.MotivoTraslado = consultaImpresionGuiaRemision.Motivo;
            guiaRemisionDetalle.MotivoTrasladoId = consultaImpresionGuiaRemision.MotivoTrasladoId;
            guiaRemisionDetalle.MotivoDetalleTraslado = consultaImpresionGuiaRemision.MotivoTrasladoReferencia;
            guiaRemisionDetalle.PropietarioTransportista = consultaImpresionGuiaRemision.Transportista;
            guiaRemisionDetalle.TransportistaDomicilio = consultaImpresionGuiaRemision.DireccionTransportista;
            guiaRemisionDetalle.TransportistaCodigoVehicular = consultaImpresionGuiaRemision.ConfiguracionVehicular;
            guiaRemisionDetalle.TransportistaMarca = consultaImpresionGuiaRemision.MarcaTractor;
            guiaRemisionDetalle.TransportistaRUC = consultaImpresionGuiaRemision.RucTransportista;
            guiaRemisionDetalle.TransportistaPlaca = consultaImpresionGuiaRemision.PlacaTractor;
            guiaRemisionDetalle.TransportistaConductor = consultaImpresionGuiaRemision.Conductor;
            guiaRemisionDetalle.TransportistaConstancia = consultaImpresionGuiaRemision.NumeroConstanciaMTC;
            guiaRemisionDetalle.TransportistaBrevete = consultaImpresionGuiaRemision.LicenciaConductor;
            guiaRemisionDetalle.Observaciones = consultaImpresionGuiaRemision.Observacion;
            guiaRemisionDetalle.Responsable = consultaImpresionGuiaRemision.UsuarioRegistro;


            generarPDFGuiaRemisionResponseDTO.detalleGM.Add(guiaRemisionDetalle);


            return generarPDFGuiaRemisionResponseDTO;
        }
    }
}
