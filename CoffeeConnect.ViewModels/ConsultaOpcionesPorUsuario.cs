using System;

namespace CoffeeConnect.DTO
{
	public class ConsultaOpcionesPorUsuario
	{

		public int OpcionId { get; set; }
		public String Codigo { get; set; }
		public String Name { get; set; }
		public String Path { get; set; }
		public String Tittle { get; set; }
		public String Icon { get; set; }
		public String Type { get; set; }
		public int OpcionPadreId { get; set; }		
		public bool Activo { get; set; }

		public bool Escritura { get; set; }

	}
}
