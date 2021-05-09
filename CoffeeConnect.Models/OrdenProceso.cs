using System;

namespace CoffeeConnect.Models
{
	public class OrdenProceso
	{
		#region Properties
		/// <summary>
		/// Gets or sets the OrdenProcesoId value.
		/// </summary>
		public int OrdenProcesoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaId value.
		/// </summary>
		public int EmpresaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaProcesadoraId value.
		/// </summary>
		public int EmpresaProcesadoraId
		{ get; set; }

		/// <summary>
		/// Gets or sets the TipoProcesoId value.
		/// </summary>
		public string TipoProcesoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the ContratoId value.
		/// </summary>
		public int ContratoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Numero value.
		/// </summary>
		public string Numero
		{ get; set; }

		/// <summary>
		/// Gets or sets the CantidadSacosUtilizar value.
		/// </summary>
		public decimal CantidadSacosUtilizar
		{ get; set; }

		/// <summary>
		/// Gets or sets the RendimientoEsperadoPorcentaje value.
		/// </summary>
		public decimal RendimientoEsperadoPorcentaje
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaFinProceso value.
		/// </summary>
		public DateTime FechaFinProceso
		{ get; set; }

		/// <summary>
		/// Gets or sets the CantidadContenedores value.
		/// </summary>
		public decimal CantidadContenedores
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
		/// 
		public string NombreArchivo
		{ get; set; }

		public string DescripcionArchivo
		{ get; set; }

		/// <summary>
		/// Gets or sets the PathArchivo value.
		/// </summary>
		public string PathArchivo
		{ get; set; }
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
