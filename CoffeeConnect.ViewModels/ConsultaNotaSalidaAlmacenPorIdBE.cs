using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
	public class ConsultaNotaSalidaAlmacenPorIdBE
	{		

		#region Properties
		/// <summary>
		/// Gets or sets the NotaSalidaAlmacenId value.
		/// </summary>
		public int NotaSalidaAlmacenId
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
		/// Gets or sets the MotivoTrasladoId value.
		/// </summary>
		public string MotivoTrasladoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaIdDestino value.
		/// </summary>
		public int EmpresaIdDestino
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmpresaTransporteId value.
		/// </summary>
		public int EmpresaTransporteId
		{ get; set; }

		/// <summary>
		/// Gets or sets the TransporteId value.
		/// </summary>
		public int TransporteId
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

		/// <summary>
		/// Gets or sets the Observacion value.
		/// </summary>
		public string Observacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the CantidadLotes value.
		/// </summary>
		public decimal CantidadLotes
		{ get; set; }

		/// <summary>
		/// Gets or sets the PesoNeto value.
		/// </summary>
		public decimal PesoNeto
		{ get; set; }

		/// <summary>
		/// Gets or sets the PromedioRendimientoPorcentaje value.
		/// </summary>
		public decimal PromedioRendimientoPorcentaje
		{ get; set; }

		/// <summary>
		/// Gets or sets the MonedaId value.
		/// </summary>
		public string MonedaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the PrecioDia value.
		/// </summary>
		public decimal PrecioDia
		{ get; set; }

		/// <summary>
		/// Gets or sets the Importe value.
		/// </summary>
		public decimal Importe
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
		public DateTime FechaUltimaActualizacion
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
	

		public List<NotaSalidaAlmacenAnalisisFisicoColorDetalle> AnalisisFisicoColorDetalle
		{ get; set; }

		public List<NotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalle> AnalisisFisicoDefectoPrimarioDetalle
		{ get; set; }

		public List<NotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetalle> AnalisisFisicoDefectoSecundarioDetalle
		{ get; set; }

		public List<NotaSalidaAlmacenAnalisisFisicoOlorDetalle> AnalisisFisicoOlorDetalle
		{ get; set; }

		public List<NotaSalidaAlmacenAnalisisSensorialAtributoDetalle> AnalisisSensorialAtributoDetalle
		{ get; set; }

		public List<NotaSalidaAlmacenAnalisisSensorialDefectoDetalle> AnalisisSensorialDefectoDetalle
		{ get; set; }

		public List<NotaSalidaAlmacenRegistroTostadoIndicadorDetalle> RegistroTostadoIndicadorDetalle
		{ get; set; }



		#endregion
	}
}
