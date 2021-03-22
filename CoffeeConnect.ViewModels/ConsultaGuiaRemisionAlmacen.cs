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
		public String Numero { get; set; }
		public int EmpresaId { get; set; }
		public String RazonSocialEmpresa { get; set; }
		public String RucEmpresa { get; set; }
		public String AlmacenId { get; set; }
		public String Almacen { get; set; }
		public String MotivoTrasladoId { get; set; }
		public String MotivoTrasladoReferencia { get; set; }
		public String Motivo { get; set; }
		public String Destinatario { get; set; }
		public String RucDestinatario { get; set; }
		public String DireccionPartida { get; set; }
		public String DireccionDestino { get; set; }
		public int EmpresaTransporteId { get; set; }
		public String Transportista { get; set; }
		public String DireccionTransportista { get; set; }
		public String RucTransportista { get; set; }
		public String Conductor { get; set; }
		public String LicenciaConductor { get; set; }
		public String TransporteId { get; set; }
		public String MarcaCarretaId { get; set; }
		public String MarcaCarreta { get; set; }
		public String MarcaTractorId { get; set; }
		public String MarcaTractor { get; set; }
		public String PlacaTractor { get; set; }
		public String PlacaCarreta { get; set; }
		public String NumeroConstanciaMTC { get; set; }
		public String Observacion { get; set; }
		public String CantidadLotes { get; set; }
		public Decimal PromedioPorcentajeRendimiento { get; set; }
		public String CantidadTotal { get; set; }
		public Decimal PesoKilosBrutos { get; set; }
		public String EstadoId { get; set; }
		public DateTime FechaRegistro { get; set; }
		public String UsuarioRegistro { get; set; }
		public DateTime? FechaUltimaActualizacion { get; set; }
		public String UsuarioUltimaActualizacion { get; set; }
		public bool Activo { get; set; }

		public IEnumerable<ConsultaGuiaRemisionAlmacenDetalle> lstConsultaGuiaRemisionAlmacenDetalle { get; set; }

		#endregion

    }
}
