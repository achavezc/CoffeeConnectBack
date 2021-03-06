using System;

namespace CoffeeConnect.Models
{
	public class ProductorFinca
	{
		public int ProductorFincaId { get; set; }
		public int ProductorId { get; set; }
		public String Nombre { get; set; }
		public String DepartamentoId { get; set; }
		public String ProvinciaId { get; set; }
		public String DistritoId { get; set; }
		public String ZonaId { get; set; }
		public Decimal Latitud { get; set; }
		public Decimal Longuitud { get; set; }
		public Decimal Altitud { get; set; }
		public String FuenteEnergiaId { get; set; }
		public String FuenteAguaId { get; set; }
		public String InternetId { get; set; }
		public String SenialTelefonicaId { get; set; }
		public String EstablecimientoSaludId { get; set; }
		public String CentroEducativoId { get; set; }
		public String CentroEducativoNivel { get; set; }
		public Decimal TiempoTotalEstablecimientoSalud { get; set; }
		public int CantidadAnimalesMenores { get; set; }
		public String MaterialVivienda { get; set; }
		public String Suelo { get; set; }
		public DateTime FechaRegistro { get; set; }
		public String UsuarioRegistro { get; set; }
		public DateTime FechaUltimaActualizacion { get; set; }
		public String UsuarioUltimaActualizacion { get; set; }
		public String EstadoId { get; set; }
		public bool Activo { get; set; }
	}
}
