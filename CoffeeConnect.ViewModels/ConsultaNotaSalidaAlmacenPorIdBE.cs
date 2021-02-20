using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
	public class ConsultaNotaSalidaAlmacenPorIdBE
	{
		#region Properties

		public int NotaSalidaAlmacenId { get; set; }
		public int EmpresaId { get; set; }
		public String AlmacenId { get; set; }
		public String Numero { get; set; }
		public String MotivoTrasladoId { get; set; }
		public int EmpresaIdDestino { get; set; }
		public int EmpresaTransporteId { get; set; }
		public int TransporteId { get; set; }
		public String NumeroConstanciaMTC { get; set; }
		public String MarcaTractorId { get; set; }
		public String PlacaTractor { get; set; }
		public String MarcaCarretaId { get; set; }
		public String PlacaCarreta { get; set; }
		public String Conductor { get; set; }
		public String Licencia { get; set; }
		public String Observacion { get; set; }
		public String CantidadLotes { get; set; }
		public decimal PesoNeto { get; set; }
		public String EstadoId { get; set; }
		public DateTime FechaRegistro { get; set; }
		public String UsuarioRegistro { get; set; }
		public DateTime FechaUltimaActualizacion { get; set; }
		public String UsuarioUltimaActualizacion { get; set; }
		public bool Activo { get; set; }

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
