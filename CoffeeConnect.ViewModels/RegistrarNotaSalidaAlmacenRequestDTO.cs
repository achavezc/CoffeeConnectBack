using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
   public class RegistrarNotaSalidaAlmacenRequestDTO
	{
		public int NotaSalidaAlmacenId { get; set; }
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
		public int CantidadLotes { get; set; }
		public Decimal PesoKilosBrutos { get; set; }
		public Decimal PromedioPorcentajeRendimiento { get; set; }
		
		public String EstadoId { get; set; }
		public String UsuarioNotaSalidaAlmacen { get; set; }
		//public String Activo { get; set; }
		public List<NotaSalidaAlmacenDetalleDTO> ListNotaSalidaAlmacenDetalle { get; set; }
		public RegistrarNotaSalidaAlmacenRequestDTO() {
			ListNotaSalidaAlmacenDetalle = new List<NotaSalidaAlmacenDetalleDTO>();
		}
	}
}
