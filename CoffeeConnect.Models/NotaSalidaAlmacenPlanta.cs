using System;

namespace CoffeeConnect.Models
{
	public class NotaSalidaAlmacenPlanta
	{
		#region Properties
		/// <summary>
		/// Gets or sets the NotaSalidaAlmacenPlantaId value.
		/// </summary>
		public int NotaSalidaAlmacenPlantaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaId value.
		/// </summary>
		public int EmpresaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the AlmacenId value.
		/// </summary>
		public string AlmacenId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Numero value.
		/// </summary>
		public string Numero
		{ get; set; }

		/// <summary>
		/// Gets or sets the MotivoSalidaId value.
		/// </summary>
		public string MotivoSalidaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the MotivoSalidaReferencia value.
		/// </summary>
		public string MotivoSalidaReferencia
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaIdDestino value.
		/// </summary>
		public int EmpresaIdDestino
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaTransporteId value.
		/// </summary>
		public int? EmpresaTransporteId
		{ get; set; }

		/// <summary>
		/// Gets or sets the TransporteId value.
		/// </summary>
		public int? TransporteId
		{ get; set; }

		/// <summary>
		/// Gets or sets the NumeroConstanciaMTC value.
		/// </summary>
		public string NumeroConstanciaMTC
		{ get; set; }

		/// <summary>
		/// Gets or sets the MarcaTractorId value.
		/// </summary>
		public string MarcaTractorId
		{ get; set; }

		/// <summary>
		/// Gets or sets the PlacaTractor value.
		/// </summary>
		public string PlacaTractor
		{ get; set; }

		/// <summary>
		/// Gets or sets the MarcaCarretaId value.
		/// </summary>
		public string MarcaCarretaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the PlacaCarreta value.
		/// </summary>
		public string PlacaCarreta
		{ get; set; }

		/// <summary>
		/// Gets or sets the Conductor value.
		/// </summary>
		public string Conductor
		{ get; set; }

		/// <summary>
		/// Gets or sets the Licencia value.
		/// </summary>
		public string Licencia
		{ get; set; }

		public string ProductoId
		{ get; set; }

		public string SubProductoId

		{ get; set; }

		/// <summary>
		/// Gets or sets the CantidadTotal value.
		/// </summary>
		public decimal CantidadTotal
		{ get; set; }

		/// <summary>
		/// Gets or sets the PesoKilosBrutos value.
		/// </summary>
		public decimal PesoKilosBrutos
		{ get; set; }

		/// <summary>
		/// Gets or sets the PesoKilosNetos value.
		/// </summary>
		public decimal PesoKilosNetos
		{ get; set; }

		/// <summary>
		/// Gets or sets the Tara value.
		/// </summary>
		public decimal Tara
		{ get; set; }

		/// <summary>
		/// Gets or sets the Observacion value.
		/// </summary>
		public string Observacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the EstadoId value.
		/// </summary>
		public string EstadoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaRegistro value.
		/// </summary>
		public DateTime FechaRegistro
		{ get; set; }

		/// <summary>
		/// Gets or sets the UsuarioRegistro value.
		/// </summary>
		public string UsuarioRegistro
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaUltimaActualizacion value.
		/// </summary>
		public DateTime? FechaUltimaActualizacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the UsuarioUltimaActualizacion value.
		/// </summary>
		public string UsuarioUltimaActualizacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the Activo value.
		/// </summary>
		public bool Activo
		{ get; set; }


		public String CodigoCampania { get; set; }

		public String CodigoTipoConcepto { get; set; }



		#endregion
	}
}
