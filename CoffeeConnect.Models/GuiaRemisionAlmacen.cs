using System;

namespace CoffeeConnect.Models
{
	public class GuiaRemisionAlmacen
	{
		#region Properties
		public int? GuiaRemisionId { get; set; }
		public int NotaSalidaAlmacenId { get; set; }
		public String Numero { get; set; }
		public int EmpresaId { get; set; }
		public String AlmacenId { get; set; }
		public String MotivoTrasladoId { get; set; }
		public String MotivoTrasladoReferencia { get; set; }
		public int EmpresaIdDestino { get; set; }
		public int EmpresaTransporteId { get; set; }
		public int TransporteId { get; set; }
		public String MarcaTractorId { get; set; }

		public String TipoProduccionId { get; set; }

		public String TipoCertificacionId { get; set; }


		public String PlacaTractor { get; set; }
		public String MarcaCarretaId { get; set; }
		public String PlacaCarreta { get; set; }
		public String Conductor { get; set; }
		public String Licencia { get; set; }
		public int CantidadLotes { get; set; }
		public Decimal PromedioPorcentajeRendimiento { get; set; }

		public Decimal HumedadPorcentajeAnalisisFisico { get; set; }

		

		public string NumeroConstanciaMTC
		{ get; set; }

		public int CantidadTotal { get; set; }
		public Decimal PesoKilosBrutos { get; set; }
		public String EstadoId { get; set; }
		public DateTime FechaRegistro { get; set; }
		public String UsuarioRegistro { get; set; }
		public DateTime? FechaUltimaActualizacion { get; set; }
		public String UsuarioUltimaActualizacion { get; set; }

		#endregion
	}
}
