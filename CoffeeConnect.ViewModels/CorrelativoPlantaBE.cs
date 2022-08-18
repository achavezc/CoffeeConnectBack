using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
	public class CorrelativoPlantaBE
	{
		public int CorrelativoPlantaId { get; set; }
      public  string Campanha { get; set; }
		public string CodigoTipo { get; set; }
		public string CodigoTipoConcepto { get; set; }
		public int CantidadDigitosPlanta { get; set; }
		public string Prefijo { get; set; }
		public string Contador { get; set; }
		public string Tipo { get; set; }
		public string Concepto { get; set; }
		public bool Activo { get; set; }
	}
}
