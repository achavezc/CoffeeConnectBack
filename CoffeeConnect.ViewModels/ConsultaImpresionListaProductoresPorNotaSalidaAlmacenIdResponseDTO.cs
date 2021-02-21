using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
	public class ConsultaImpresionListaProductoresPorNotaSalidaAlmacenResponseDTO
	{
		public string RazonSocialEmpresa
		{ get; set; }

		public string RucEmpresa
		{ get; set; }

		public string DireccionEmpresa
		{ get; set; }

		public string NumeroNotaSalidaAlmacen
		{ get; set; }

		public DateTime FechaNotaSalidaAlmacen
		{ get; set; }

		public DateTime FechaImpresion
		{ get; set; }

		public List<ConsultaImpresionListaProductoresPorNotaSalidaAlmacenIdBE> ListaProductores
		{ get; set; }
	}
}