using System;

namespace CoffeeConnect.DTO
{
	public class ConsultaTransportePorEmpresaTransporteId
	{
		#region Properties
		/// <summary>
		/// Gets or sets the EmpresaTransporteId value.
		/// </summary>
		/// 

		public int TransporteId
		{ get; set; }


		public int EmpresaTransporteId
		{ get; set; }

		/// <summary>
		/// Gets or sets the RazonSocial value.
		/// </summary>
		public string Propietario
		{ get; set; }

		public string Conductor
		{ get; set; }

		/// <summary>
		/// Gets or sets the Ruc value.
		/// </summary>
		public string Licencia
		{ get; set; }

		/// <summary>
		/// Gets or sets the Direccion value.
		/// </summary>
		public string NumeroConstanciaMTC
		{ get; set; }


		public string MarcaTractorId
		{ get; set; }


		/// <summary>
		/// Gets or sets the TransporteId value.
		/// </summary>
		public string MarcaTractor
		{ get; set; }


		public string PlacaTractor
		{ get; set; }


		/// <summary>
		/// Gets or sets the NumeroConstanciaMTC value.
		/// </summary>
		public string MarcaCarretaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the MarcaTractorId value.
		/// </summary>
		public string MarcaCarreta
		{ get; set; }

		/// <summary>
		/// Gets or sets the MarcaTractor value.
		/// </summary>
		public string PlacaCarreta
		{ get; set; }

		public string ConfiguracionVehicularId
		{ get; set; }
		/// <summary>
		/// Gets or sets the PlacaTractor value.
		/// </summary>
		public string ConfiguracionVehicular
		{ get; set; }

		/// <summary>
		/// Gets or sets the MarcaCarretaId value.
		/// </summary>
		public string EstadoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the MarcaCarreta value.
		/// </summary>
		public string Estado
		{ get; set; }

		

		#endregion
	}
}
