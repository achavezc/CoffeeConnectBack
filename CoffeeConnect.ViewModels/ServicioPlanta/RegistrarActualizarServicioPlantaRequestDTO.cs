using System;

namespace CoffeeConnect.DTO
{
	public class RegistrarActualizarServicioPlantaRequestDTO
	{
		#region Properties
		/// <summary>
		/// Gets or sets the ServicioPlantaId value.
		/// </summary>
		public int ServicioPlantaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaId value.
		/// </summary>
		public int EmpresaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaClienteId value.
		/// </summary>
		public int EmpresaClienteId
		{ get; set; }


		public string RazonSocialEmpresaCliente { get; set; }

		public string RucEmpresaCliente { get; set; }
		/// <summary>
		/// Gets or sets the Numero value.
		/// </summary>
		public string Numero
		{ get; set; }

		/// <summary>
		/// Gets or sets the NumeroOperacionRelacionada value.
		/// </summary>
		public string NumeroOperacionRelacionada
		{ get; set; }

		/// <summary>
		/// Gets or sets the TipoServicioId value.
		/// </summary>
		public string TipoServicioId
		{ get; set; }

		/// <summary>
		/// Gets or sets the TipoComprobanteId value.
		/// </summary>
		public string TipoComprobanteId
		{ get; set; }

		/// <summary>
		/// Gets or sets the SerieComprobante value.
		/// </summary>
		public string SerieComprobante
		{ get; set; }

		/// <summary>
		/// Gets or sets the NumeroComprobante value.
		/// </summary>
		public string NumeroComprobante
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaDocumento value.
		/// </summary>
		public DateTime FechaDocumento
		{ get; set; }

		/// <summary>
		/// Gets or sets the SerieDocumento value.
		/// </summary>
		public string SerieDocumento
		{ get; set; }

		/// <summary>
		/// Gets or sets the NumeroDocumento value.
		/// </summary>
		public string NumeroDocumento
		{ get; set; }

		/// <summary>
		/// Gets or sets the UnidadMedidaId value.
		/// </summary>
		public string UnidadMedidaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Cantidad value.
		/// </summary>
		public decimal Cantidad
		{ get; set; }

		/// <summary>
		/// Gets or sets the PrecioUnitario value.
		/// </summary>
		public decimal PrecioUnitario
		{ get; set; }

		/// <summary>
		/// Gets or sets the Importe value.
		/// </summary>
		public decimal Importe
		{ get; set; }

		/// <summary>
		/// Gets or sets the PorcentajeTIRB value.
		/// </summary>
		public decimal? PorcentajeTIRB
		{ get; set; }

		/// <summary>
		/// Gets or sets the MonedaId value.
		/// </summary>
		public string MonedaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the TotalImporte value.
		/// </summary>
		public decimal TotalImporte
		{ get; set; }

		/// <summary>
		/// Gets or sets the Observaciones value.
		/// </summary>
		public string Observaciones
		{ get; set; }

		/// <summary>
		/// Gets or sets the EstadoId value.
		/// </summary>
		public string EstadoId
		{ get; set; }


		public string CodigoCampania
		{ get; set; }


		/// <summary>
		/// Gets or sets the UsuarioRegistro value.
		/// </summary>
		public string Usuario 
		{ get; set; }

		

		#endregion
	}
}
