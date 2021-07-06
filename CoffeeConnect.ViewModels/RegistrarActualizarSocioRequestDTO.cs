using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
	public class RegistrarActualizarSocioRequestDTO
	{
		public int SocioId
		{ get; set; }

		public int EmpresaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the ProductorId value.
		/// </summary>
		public int ProductorId
		{ get; set; }

		
		/// <summary>
		/// Gets or sets the UsuarioRegistro value.
		/// </summary>
		public string Usuario
		{ get; set; }



		/// <summary>
		/// Gets or sets the Activo value.
		/// </summary>
		public string EstadoId
		{ get; set; }
	}
}
