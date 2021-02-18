using System;

namespace CoffeeConnect.DTO
{
	public class ConsultaLoteBE
	{
		#region Properties
		/// <summary>
		/// Gets or sets the LoteId value.
		/// </summary>
		public int LoteId
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaId value.
		/// </summary>
		public int EmpresaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Numero value.
		/// </summary>
		public string Numero
		{ get; set; }

		/// <summary>
		/// Gets or sets the EstadoId value.
		/// </summary>
		public string EstadoId
		{ get; set; }

		public string Estado
		{ get; set; }

		/// <summary>
		/// Gets or sets the AlmacenId value.
		/// </summary>
		public string AlmacenId
		{ get; set; }

		public string Almacen
		{ get; set; }

		/// <summary>
		/// Gets or sets the TotalKilosNetosPesado value.
		/// </summary>
		public decimal TotalKilosNetosPesado
		{ get; set; }

		/// <summary>
		/// Gets or sets the PromedioRendimientoPorcentaje value.
		/// </summary>
		public decimal PromedioRendimientoPorcentaje
		{ get; set; }

		/// <summary>
		/// Gets or sets the PromedioHumedadPorcentaje value.
		/// </summary>
		public decimal PromedioHumedadPorcentaje
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

		#endregion
	}
}
