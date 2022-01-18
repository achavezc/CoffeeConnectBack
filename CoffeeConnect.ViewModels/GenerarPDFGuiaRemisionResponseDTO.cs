using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
    public class GenerarPDFGuiaRemisionResponseDTO
    {
        public GenerarPDFGuiaRemisionResponseDTO()
        {
            Result = new Result();
            Cabecera = new List<CabeceraGuiaRemision>();
            listaDetalleGM = new List<GuiaRemisionListaDetalle>();
            detalleGM = new List<GuiaRemisionDetalle>();
        }

        public Result Result { get; set; }
        public IList<CabeceraGuiaRemision> Cabecera { get; set; }
        public IList<GuiaRemisionListaDetalle> listaDetalleGM { get; set; }
        public IList<GuiaRemisionDetalle> detalleGM { get; set; }
    }

    public class CabeceraGuiaRemision
    {
        public string RazonSocial { get; set; }
        public string NumeroGuiaRemision { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaEmision { get; set; }
        public string FechaEmisionString { get; set; }
        public DateTime FechaEntregaTransportista { get; set; }
        public string FechaEntregaTransportistaString { get; set; }
        public string Ruc { get; set; }
        public string Almacen { get; set; }
        public string Destinatario { get; set; }
        public string RucDestinatario { get; set; }
        public string DireccionPartida { get; set; }
        public string DireccionDestino { get; set; }
        public string Certificacion { get; set; }
        public string TipoProduccion { get; set; }
        public string CGR { get; set; }
    }

    public class GuiaRemisionListaDetalle
    {
        public int correlativo { get; set; }
        public string NumeroLote { get; set; }
        public DateTime FechaLote { get; set; }
        public string FechaLoteString { get; set; }
        public string TipoProducto { get; set; }

        public string Descripcion { get; set; }

        public string TipoCertificacion { get; set; }
        public string TipoProduccion { get; set; }
        public string UnidadMedida { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PesoNeto { get; set; }
        public decimal HumedadPorcentaje { get; set; }
        public decimal RendimientoPorcentaje { get; set; }
        public string Producto { get; set; }
        public string SubProducto { get; set; }

        public string Empaque { get; set; }
        public string TipoEmpaque { get; set; }
        public decimal MontoBruto { get; set; }
    }

    public class GuiaRemisionDetalle
    {
        public decimal TotalLotes { get; set; }
        public decimal Rendimiento { get; set; }
        public decimal PorcentajeHumedad { get; set; }
        public decimal CantidadTotal { get; set; }
        public decimal TotalKGBrutos { get; set; }
        public string MotivoTraslado { get; set; }
        public string MotivoTrasladoId { get; set; }
        public string ModalidadTransporte { get; set; }
        public string TipoTraslado { get; set; }
        public string MotivoDetalleTraslado { get; set; }
        public string PropietarioTransportista { get; set; }
        public string TransportistaDomicilio { get; set; }
        public string TransportistaRazonSocial { get; set; }
        public string TransportistaCodigoVehicular { get; set; }
        public string TransportistaMarca { get; set; }
        public string TransportistaRuc { get; set; }
        public string TransportistaPlaca { get; set; }
        public string TransportistaPlacaCarreta { get; set; }
        public string TransportistaColor { get; set; }
        public String TransportistaDni { get; set; }
        public string TransportistaSoat { get; set; }
        public string TransportistaConductor { get; set; }
        public string TransportistaConstancia { get; set; }
        public string TransportistaBrevete { get; set; }
        public string Observaciones { get; set; }
        public string Responsable { get; set; }
    }
}
