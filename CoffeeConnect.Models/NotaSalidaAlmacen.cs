using System;

namespace CoffeeConnect.Models
{
	public class NotaSalidaAlmacen
	{
		public int? NotaSalidaAlmacenId { get; set; }
		public int EmpresaId { get; set; }
		public String AlmacenId { get; set; }
		public String Numero { get; set; }
		public String MotivoTrasladoId { get; set; }
		public int EmpresaIdDestino { get; set; }
		public int EmpresaTransporteId { get; set; }
		public int TransporteId { get; set; }
		public String NumeroConstanciaMTC { get; set; }
		public String MarcaTractorId { get; set; }
		public String PlacaTractor { get; set; }
		public String MarcaCarretaId { get; set; }
		public String PlacaCarreta { get; set; }
		public String Conductor { get; set; }
		public String Licencia { get; set; }
		public String Observacion { get; set; }
		public Decimal CantidadLotes { get; set; }
		public Decimal PesoNeto { get; set; }
		public Decimal PromedioRendimientoPorcentaje { get; set; }
		public String MonedaId { get; set; }
		public Decimal PrecioDia { get; set; }
		public Decimal Importe { get; set; }
		public String EstadoId { get; set; }
		public DateTime FechaRegistro { get; set; }
		public String UsuarioRegistro { get; set; }
		public DateTime? FechaUltimaActualizacion { get; set; }
		public String UsuarioUltimaActualizacion { get; set; }
		//public String Activo { get; set; }


	}
}
