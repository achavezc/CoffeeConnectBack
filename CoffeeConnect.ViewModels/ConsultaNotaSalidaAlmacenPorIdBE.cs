using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
	public class ConsultaNotaSalidaAlmacenPorIdBE
	{

		#region Properties



		public int NotaSalidaAlmacenId { set; get; }
		public int EmpresaId { set; get; }
		public String AlmacenId { set; get; }
		public String Almacen { set; get; }
		public String Numero { set; get; }
		public String MotivoTrasladoId { set; get; }
		public String Motivo { set; get; }
		public int EmpresaIdDestino { set; get; }
		public String Destinatario { set; get; }
		public String RucDestinatario    {set;get;}
	public String DireccionPartida { set; get; }
	public String DireccionDestino { set; get; }
	public int TransporteId { set; get; }
	public int EmpresaTransporteId { set; get; }
	public String Transportista { set; get; }
	public String DireccionTransportista { set; get; }
	public String RucTransportista { set; get; }
	public String Conductor { set; get; }
	public String LicenciaConductor { set; get; }
	public String MarcaCarretaId { set; get; }
	public String MarcaCarreta { set; get; }
	public String MarcaTractorId { set; get; }
	public String MarcaTractor { set; get; }
	public String PlacaTractor { set; get; }
	public String PlacaCarreta { set; get; }
	public String NumeroConstanciaMTC { set; get; }
	public String Observacion { set; get; }
	public Decimal CantidadLotes { set; get; }
	public Decimal PesoNeto { set; get; }
	public Decimal PromedioRendimientoPorcentaje { set; get; }
	public String MonedaId { set; get; }
	public Decimal PrecioDia { set; get; }
	public Decimal Importe { set; get; }
	public String EstadoId { set; get; }
	public DateTime FechaRegistro { set; get; }
	public String UsuarioRegistro { set; get; }
	public DateTime FechaUltimaActualizacion { set; get; }
	public String UsuarioUltimaActualizacion { set; get; }
	public bool Activo { set; get; }

		public ConsultaNotaSalidaAlmacenPorIdBE() {
			
		}


	    public IEnumerable<NotaSalidaAlmacenAnalisisFisicoColorDetalle> AnalisisFisicoColorDetalle
		{ get; set; }

		public IEnumerable<NotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalle> AnalisisFisicoDefectoPrimarioDetalle
		{ get; set; }

		public IEnumerable<NotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetalle> AnalisisFisicoDefectoSecundarioDetalle
		{ get; set; }

		public IEnumerable<NotaSalidaAlmacenAnalisisFisicoOlorDetalle> AnalisisFisicoOlorDetalle
		{ get; set; }

		public IEnumerable<NotaSalidaAlmacenAnalisisSensorialAtributoDetalle> AnalisisSensorialAtributoDetalle
		{ get; set; }

		public IEnumerable<NotaSalidaAlmacenAnalisisSensorialDefectoDetalle> AnalisisSensorialDefectoDetalle
		{ get; set; }

		public IEnumerable<NotaSalidaAlmacenRegistroTostadoIndicadorDetalle> RegistroTostadoIndicadorDetalle
		{ get; set; }

		public IEnumerable<NotaSalidaAlmacenDetalleLotes> DetalleLotes
		{ get; set; }

		#endregion
	}
}
