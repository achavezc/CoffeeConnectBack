using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
    public class ConsultaLoteBandejaBE
    {
        public ConsultaLoteBandejaBE()
        {
            listaDetalle = new List<LoteDetalleConsulta>();
        }
        public List<LoteDetalleConsulta> listaDetalle { get; set; }
        public int LoteId { get; set; }
        public String Numero { get; set; }
        public String EmpresaId { get; set; }
        public String RazonSocial { get; set; }
        public String Ruc { get; set; }
        public String Direccion { get; set; }
        public String Logo { get; set; }
        public String DepartamentoId { get; set; }
        public String Departamento { get; set; }
        public String ProvinciaId { get; set; }
        public String Provincia { get; set; }
        public String DistritoId { get; set; }
        public String Distrito { get; set; }
        public String EstadoId { get; set; }
        public String Estado { get; set; }
        public String AlmacenId { get; set; }
        public String Almacen { get; set; }
        public String UnidadMedidaId { get; set; }
        public String UnidadMedida { get; set; }
        public Decimal? Cantidad { get; set; }
        public Decimal? TotalKilosNetosPesado { get; set; }
		public Decimal? TotalKilosBrutosPesado { get; set; }
 
        public DateTime FechaRegistro { get; set; }
        public String UsuarioRegistro { get; set; }
        public DateTime? FechaUltimaActualizacion { get; set; }
        public String UsuarioUltimaActualizacion { get; set; }
        public bool Activo { get; set; }


        public string ProductoId
        { get; set; }

        public string SubProductoId
        { get; set; }

        public string SubProducto
        { get; set; }


        public string TipoCertificacionId
        { get; set; }

		public string TipoProduccionId
		{ get; set; }

		public string TipoProduccion
		{ get; set; }

		public string Producto
        { get; set; }


        public string TipoCertificacion
        { get; set; }

		


		public decimal HumedadPorcentajeAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the ExportableGramosAnalisisFisico value.
		/// </summary>
		public decimal ExportableGramosAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the ExportablePorcentajeAnalisisFisico value.
		/// </summary>
		public decimal ExportablePorcentajeAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the DescarteGramosAnalisisFisico value.
		/// </summary>
		public decimal DescarteGramosAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the DescartePorcentajeAnalisisFisico value.
		/// </summary>
		public decimal DescartePorcentajeAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the CascarillaGramosAnalisisFisico value.
		/// </summary>
		public decimal CascarillaGramosAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the CascarillaPorcentajeAnalisisFisico value.
		/// </summary>
		public decimal CascarillaPorcentajeAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the TotalGramosAnalisisFisico value.
		/// </summary>
		public decimal TotalGramosAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the TotalPorcentajeAnalisisFisico value.
		/// </summary>
		public decimal TotalPorcentajeAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the Observacion value.
		/// </summary>
		public string Observacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the ObservacionAnalisisFisico value.
		/// </summary>
		public string ObservacionAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the ObservacionRegistroTostado value.
		/// </summary>
		public string ObservacionRegistroTostado
		{ get; set; }

		/// <summary>
		/// Gets or sets the ObservacionAnalisisSensorial value.
		/// </summary>
		public string ObservacionAnalisisSensorial
		{ get; set; }

		/// <summary>
		/// Gets or sets the TotalAnalisisSensorial value.
		/// </summary>
		public decimal TotalAnalisisSensorial
		{ get; set; }

		/// <summary>
		/// Gets or sets the CantidadLotes value.
		/// </summary>
		public int CantidadLotes
		{ get; set; }

		/// <summary>
		/// Gets or sets the PromedioPorcentajeRendimiento value.
		/// </summary>
		public decimal RendimientoPorcentaje
		{ get; set; }

		public string UsuarioCalidad
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaUltimaActualizacion value.
		/// </summary>
		public DateTime? FechaCalidad
		{ get; set; }

		public IEnumerable<LoteAnalisisFisicoColorDetalle> AnalisisFisicoColorDetalle
        { get; set; }

        public IEnumerable<LoteAnalisisFisicoDefectoPrimarioDetalle> AnalisisFisicoDefectoPrimarioDetalle
        { get; set; }

        public IEnumerable<LoteAnalisisFisicoDefectoSecundarioDetalle> AnalisisFisicoDefectoSecundarioDetalle
        { get; set; }

        public IEnumerable<LoteAnalisisFisicoOlorDetalle> AnalisisFisicoOlorDetalle
        { get; set; }

        public IEnumerable<LoteAnalisisSensorialAtributoDetalle> AnalisisSensorialAtributoDetalle
        { get; set; }

        public IEnumerable<LoteAnalisisSensorialDefectoDetalle> AnalisisSensorialDefectoDetalle
        { get; set; }

        public IEnumerable<LoteRegistroTostadoIndicadorDetalle> RegistroTostadoIndicadorDetalle
        { get; set; }

		public int? ContratoId { get; set; }

		public string NumeroContrato
		{ get; set; }

		public int? ClienteId
		{
			get; set;
		}

		public string Cliente
		{ get; set; }

		public decimal TotalSacos
		{ get; set; }

		public decimal PesoKilos
		{ get; set; }

		public decimal PesoPorSaco
		{ get; set; }

		public string Empaque
		{ get; set; }

	}
}
