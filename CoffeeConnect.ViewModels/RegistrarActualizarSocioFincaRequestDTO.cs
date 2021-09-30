using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
	public class RegistrarActualizarSocioFincaRequestDTO
	{
		#region Properties

		public int SocioFincaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the SocioId value.
		/// </summary>
		public int SocioId
		{ get; set; }

		/// <summary>
		/// Gets or sets the ProductorFincaId value.
		/// </summary>
		public int ProductorFincaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the ViasAccesoCentroAcopio value.
		/// </summary>
		public string ViasAccesoCentroAcopio
		{ get; set; }

		/// <summary>
		/// Gets or sets the DistanciaKilometrosCentroAcopio value.
		/// </summary>
		public decimal? DistanciaKilometrosCentroAcopio
		{ get; set; }

		/// <summary>
		/// Gets or sets the TiempoTotalFincaCentroAcopio value.
		/// </summary>
		public decimal? TiempoTotalFincaCentroAcopio
		{ get; set; }

		/// <summary>
		/// Gets or sets the MedioTransporte value.
		/// </summary>
		public string MedioTransporte
		{ get; set; }

		/// <summary>
		/// Gets or sets the Cultivo value.
		/// </summary>
		public string Cultivo
		{ get; set; }

		/// <summary>
		/// Gets or sets the Precipitacion value.
		/// </summary>
		public string Precipitacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the CantidadPersonalCosecha value.
		/// </summary>
		public int? CantidadPersonalCosecha
		{ get; set; }




		/// <summary>
		/// Gets or sets the UsuarioUltimaActualizacion value.
		/// </summary>
		public string Usuario
		{ get; set; }

		/// <summary>
		/// Gets or sets the EstadoId value.
		/// </summary>
		public string EstadoId
		{ get; set; }
		public decimal? AreaTotal
		{ get; set; }

		/// <summary>
		/// Gets or sets the AreaCafeEnProduccion value.
		/// </summary>
		public decimal? AreaCafeEnProduccion
		{ get; set; }

		/// <summary>
		/// Gets or sets the Crecimiento value.
		/// </summary>
		public decimal? Crecimiento
		{ get; set; }

		/// <summary>
		/// Gets or sets the Bosque value.
		/// </summary>
		public decimal? Bosque
		{ get; set; }

		/// <summary>
		/// Gets or sets the Purma value.
		/// </summary>
		public decimal? Purma
		{ get; set; }

		/// <summary>
		/// Gets or sets the PanLlevar value.
		/// </summary>
		public decimal? PanLlevar
		{ get; set; }

		/// <summary>
		/// Gets or sets the Vivienda value.
		/// </summary>
		public decimal? Vivienda
		{ get; set; }


		public List<ActualizarFincaEstimadoRequestDTO> FincaEstimado { get; set; }


		#endregion
	}
}
