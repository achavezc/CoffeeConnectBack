using System;

namespace CoffeeConnect.Models
{
	public class AduanaCargamento
	{
		#region Properties
		/// <summary>
		/// Gets or sets the AduanaCargamentoId value.
		/// </summary>
		public int AduanaCargamentoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the AduanaId value.
		/// </summary>
		public int AduanaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Cantidad value.
		/// </summary>
		public decimal Cantidad
		{ get; set; }

		/// <summary>
		/// Gets or sets the PesoPorSacoKilos value.
		/// </summary>
		public decimal PesoPorSacoKilos
		{ get; set; }

		/// <summary>
		/// Gets or sets the TotalKilosNetos value.
		/// </summary>
		public decimal TotalKilosNetos
		{ get; set; }

		/// <summary>
		/// Gets or sets the NumeroContenedorEmbarcar value.
		/// </summary>
		public string NumeroContenedorEmbarcar
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaSalidaPlanta value.
		/// </summary>
		public DateTime? FechaSalidaPlanta
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaZarpeNave value.
		/// </summary>
		public DateTime? FechaZarpeNave
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaFacturacion value.
		/// </summary>
		public DateTime? FechaFacturacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the Puerto value.
		/// </summary>
		public string Puerto
		{ get; set; }

		/// <summary>
		/// Gets or sets the Marca value.
		/// </summary>
		public string Marca
		{ get; set; }

		/// <summary>
		/// Gets or sets the PO value.
		/// </summary>
		public string PO
		{ get; set; }

		/// <summary>
		/// Gets or sets the EstadoSeguimientoId value.
		/// </summary>
		public string EstadoSeguimientoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaEstampado value.
		/// </summary>
		public DateTime? FechaEstampado
		{ get; set; }

		#endregion
	}
}
