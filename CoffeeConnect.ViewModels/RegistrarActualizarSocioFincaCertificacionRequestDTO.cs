using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
	public class RegistrarActualizarSocioFincaCertificacionRequestDTO
	{
		public int SocioFincaCertificacionId
		{ get; set; }

		/// <summary>
		/// Gets or sets the SocioFincaId value.
		/// </summary>
		public int SocioFincaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the EntidadCertificadoraId value.
		/// </summary>
		public string EntidadCertificadoraId
		{ get; set; }

		/// <summary>
		/// Gets or sets the TipoCertificacionId value.
		/// </summary>
		public string TipoCertificacionId
		{ get; set; }

		/// <summary>
		/// Gets or sets the VigenciaAnios value.
		/// </summary>

		/// <summary>
		/// Gets or sets the FechaCaducidad value.
		/// </summary>
		public DateTime FechaCaducidad
		{ get; set; }

		public DateTime FechaEmision
		{ get; set; }

		


		/// <summary>
		/// Gets or sets the UsuarioRegistro value.
		/// </summary>
		public string Usuario
		{ get; set; }

		

		/// <summary>
		/// Gets or sets the NombreArchivo value.
		/// </summary>
		public string NombreArchivo
		{ get; set; }

		/// <summary>
		/// Gets or sets the DescripcionArchivo value.
		/// </summary>
		public string DescripcionArchivo
		{ get; set; }

		/// <summary>
		/// Gets or sets the PathArchivo value.
		/// </summary>
		public string PathArchivo
		{ get; set; }

		/// <summary>
		/// Gets or sets the EstadoId value.
		/// </summary>
		public string EstadoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Activo value.
		/// </summary>
	
	}
}
