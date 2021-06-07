using System;

namespace CoffeeConnect.DTO
{
	public class ConsultaInspeccionInternaBE
	{
		#region Properties
		/// <summary>
		/// Gets or sets the InspeccionInternaId value.
		/// </summary>
		public int InspeccionInternaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Numero value.
		/// </summary>
		public string Numero
		{ get; set; }
        public int SocioFincaId { get; set; }
        public int SocioId { get; set; }
        public int ProductorFincaId { get; set; }
        /// </summary>
        public string EstadoId
		{ get; set; }

		public string Estado
		{ get; set; }

		public DateTime FechaRegistro
		{ get; set; }


		#endregion
	}
}
