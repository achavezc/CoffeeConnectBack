using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
   public class RegistrarNotaSalidaAlmacenPlantaRequestDTO
	{
		public int NotaSalidaAlmacenPlantaId { get; set; }
		public int EmpresaId { get; set; }
		public String AlmacenId { get; set; }
		public String Numero { get; set; }
		public String MotivoSalidaId { get; set; }
        public String MotivoSalidaReferencia { get; set; }

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
        
        public Decimal PesoKilosBrutos { get; set; }

		public Decimal PesoKilosNetos { get; set; }

		public Decimal Tara { get; set; }
		//public Decimal PromedioPorcentajeRendimiento { get; set; }
		public int CantidadTotal { get; set; }
        public String EstadoId { get; set; }
		public String UsuarioNotaSalidaAlmacenPlanta { get; set; }
		//public String Activo { get; set; }
		//public List<NotaSalidaAlmacenDetalleDTO> ListNotaSalidaAlmacenDetalle { get; set; }
		public RegistrarNotaSalidaAlmacenPlantaRequestDTO() {
			//ListNotaSalidaAlmacenDetalle = new List<NotaSalidaAlmacenDetalleDTO>();
		}
	}
}
