using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
    public class ConsultaGuiaRemisionAlmacen
    {
        #region Properties
        public int GuiaRemisionAlmacenId { get; set; }
        public int NotaSalidaAlmacenId { get; set; }
        public string Numero { get; set; }
        public int EmpresaId { get; set; }
        public string RazonSocialEmpresa { get; set; }
        public string RucEmpresa { get; set; }
        public string AlmacenId { get; set; }
        public string Almacen { get; set; }
        public string Soat { get; set; }
        public string Color { get; set; }
        public string Dni { get; set; }
        public string MotivoTrasladoId { get; set; }
        public string TipoProduccionId { get; set; }
        public string TipoProduccion { get; set; }
        public string TipoCertificacionId { get; set; }
        public string Certificacion { get; set; }
        public string MotivoTrasladoReferencia { get; set; }
        public string Motivo { get; set; }
        public string Destinatario { get; set; }
        public string RucDestinatario { get; set; }
        public string DireccionPartida { get; set; }
        public string DireccionDestino { get; set; }
        public int EmpresaTransporteId { get; set; }
        public string Transportista { get; set; }
        public string DireccionTransportista { get; set; }
        public string RucTransportista { get; set; }
        public string Conductor { get; set; }

        public string Propietario { get; set; }
        public string LicenciaConductor { get; set; }
        public string TransporteId { get; set; }
        public string MarcaCarretaId { get; set; }
        public string MarcaCarreta { get; set; }
        public string MarcaTractorId { get; set; }
        public string MarcaTractor { get; set; }
        public string PlacaTractor { get; set; }
        public string PlacaCarreta { get; set; }
        public string ConfiguracionVehicularId { get; set; }
        public string ConfiguracionVehicular { get; set; }
        public string NumeroConstanciaMTC { get; set; }
        public string Observacion { get; set; }
        public Decimal CantidadLotes { get; set; }
        public Decimal PromedioPorcentajeRendimiento { get; set; }
        public Decimal HumedadPorcentajeAnalisisFisico { get; set; }
        public Decimal CantidadTotal { get; set; }
        public Decimal PesoKilosBrutos { get; set; }


        public string EstadoId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime FechaUltimaActualizacion { get; set; }
        public string UsuarioUltimaActualizacion { get; set; }
        public bool Activo { get; set; }
        public string FechaRegistroString { get; set; }
        public string FechaUltimaActualizacionString { get; set; }
        public IEnumerable<ConsultaGuiaRemisionAlmacenDetalle> lstConsultaGuiaRemisionAlmacenDetalle { get; set; }

        #endregion

    }
}
