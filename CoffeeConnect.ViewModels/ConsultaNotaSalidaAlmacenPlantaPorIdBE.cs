using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
	public class ConsultaNotaSalidaAlmacenPlantaPorIdBE
	{
		#region Properties
	

		public int NotaSalidaAlmacenPlantaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the AlmacenId value.
		/// </summary>
		public string AlmacenId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Almacen value.
		/// </summary>
		public string Almacen
		{ get; set; }

		/// <summary>
		/// Gets or sets the Numero value.
		/// </summary>
		public string Numero
		{ get; set; }

		/// <summary>
		/// Gets or sets the MotivoTrasladoId value.
		/// </summary>
		public string MotivoSalidaId
		{ get; set; }

		public string ConfiguracionVehicularId
		{ get; set; }

		public string ConfiguracionVehicular
		{ get; set; }


	


		/// <summary>
		/// Gets or sets the MotivoTrasladoReferencia value.
		/// </summary>
		public string MotivoSalidaReferencia
		{ get; set; }

		/// <summary>
		/// Gets or sets the Motivo value.
		/// </summary>
		public string Motivo
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaId value.
		/// </summary>
		public int EmpresaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the RazonSocialEmpresa value.
		/// </summary>
		public string RazonSocialEmpresa
		{ get; set; }

		/// <summary>
		/// Gets or sets the RucEmpresa value.
		/// </summary>
		public string RucEmpresa
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaIdDestino value.
		/// </summary>
		public int EmpresaIdDestino
		{ get; set; }

		/// <summary>
		/// Gets or sets the Destinatario value.
		/// </summary>
		public string Destinatario
		{ get; set; }

		/// <summary>
		/// Gets or sets the RucDestinatario value.
		/// </summary>
		public string RucDestinatario
		{ get; set; }

		/// <summary>
		/// Gets or sets the DireccionPartida value.
		/// </summary>
		public string DireccionPartida
		{ get; set; }

		/// <summary>
		/// Gets or sets the DireccionDestino value.
		/// </summary>
		public string DireccionDestino
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaTransporteId value.
		/// </summary>
		public int? EmpresaTransporteId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Transportista value.
		/// </summary>
		public string Transportista
		{ get; set; }

		/// <summary>
		/// Gets or sets the DireccionTransportista value.
		/// </summary>
		public string DireccionTransportista
		{ get; set; }

		/// <summary>
		/// Gets or sets the RucTransportista value.
		/// </summary>
		public string RucTransportista
		{ get; set; }

		/// <summary>
		/// Gets or sets the Conductor value.
		/// </summary>
		public string Conductor
		{ get; set; }

		/// <summary>
		/// Gets or sets the LicenciaConductor value.
		/// </summary>
		public string LicenciaConductor
		{ get; set; }

		/// <summary>
		/// Gets or sets the TransporteId value.
		/// </summary>
		public int? TransporteId
		{ get; set; }

		/// <summary>
		/// Gets or sets the MarcaCarretaId value.
		/// </summary>
		public string MarcaCarretaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the MarcaCarreta value.
		/// </summary>
		public string MarcaCarreta
		{ get; set; }

		/// <summary>
		/// Gets or sets the MarcaTractorId value.
		/// </summary>
		public string MarcaTractorId
		{ get; set; }

		/// <summary>
		/// Gets or sets the MarcaTractor value.
		/// </summary>
		public string MarcaTractor
		{ get; set; }

		/// <summary>
		/// Gets or sets the PlacaTractor value.
		/// </summary>
		public string PlacaTractor
		{ get; set; }

		/// <summary>
		/// Gets or sets the PlacaCarreta value.
		/// </summary>
		public string PlacaCarreta
		{ get; set; }

		/// <summary>
		/// Gets or sets the NumeroConstanciaMTC value.
		/// </summary>
		public string NumeroConstanciaMTC
		{ get; set; }

		/// <summary>
		/// Gets or sets the HumedadPorcentajeAnalisisFisico value.
		/// </summary>
		

		/// <summary>
		/// Gets or sets the Observacion value.
		/// </summary>
		public string Observacion
		{ get; set; }

		

        ///// <summary>
        ///// Gets or sets the PromedioPorcentajeRendimiento value.
        ///// </summary>
        //public decimal PromedioPorcentajeRendimiento
        //{ get; set; }

        ///// <summary>
        ///// Gets or sets the CantidadTotal value.
        ///// </summary>
        public decimal CantidadTotal
        { get; set; }

        ///// <summary>
        ///// Gets or sets the PesoKilosBrutos value.
        ///// </summary>
        public decimal PesoKilosBrutos
        { get; set; }

		public decimal PesoKilosNetos
		{ get; set; }

		/// <summary>
		/// Gets or sets the EstadoId value.
		/// </summary>
		public string EstadoId
		{ get; set; }

		public string Estado
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

		public string UsuarioCalidad
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaUltimaActualizacion value.
		/// </summary>
		public DateTime? FechaCalidad
		{ get; set; }

		


		public IEnumerable<ConsultaNotaSalidaAlmacenPlantaDetallePorIdBE> Detalle
		{ get; set; }



		public String CodigoCampania { get; set; }

		public String CodigoTipoConcepto { get; set; }

		public String Concepto { get; set; }
		#endregion
	}
}
