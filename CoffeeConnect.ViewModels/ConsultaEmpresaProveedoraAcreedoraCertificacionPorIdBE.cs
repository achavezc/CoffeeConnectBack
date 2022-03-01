using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
   public class ConsultaEmpresaProveedoraAcreedoraCertificacionPorIdBE
	{

		public int EmpresaProveedoraAcreedoraCertificacionId
		{ get; set; }

		public int EmpresaProveedoraAcreedoraId
		{ get; set; }

		/// <summary>
		/// Gets or sets the RazonSocial value.
		/// </summary>
		public string TipoCertificacionId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Ruc value.
		/// </summary>
		public string CodigoCertificacion
		{ get; set; }

		public string Certificacion
		{ get; set; }

		public string EstadoId
		{ get; set; }

		public string Estado
		{ get; set; }

		public DateTime? FechaVigencia
		{ get; set; }
	}
}
