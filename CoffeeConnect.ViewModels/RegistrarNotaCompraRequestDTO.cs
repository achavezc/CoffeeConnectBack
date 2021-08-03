using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
   public class RegistrarActualizarNotaCompraRequestDTO
	{
		public int NotaCompraId
		{ get; set; }

		public int GuiaRecepcionMateriaPrimaId
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
		/// Gets or sets the UnidadMedidaIdPesado value.
		/// </summary>
		public string UnidadMedidaIdPesado
		{ get; set; }

		/// <summary>
		/// Gets or sets the CantidadPesado value.
		/// </summary>
		public decimal CantidadPesado
		{ get; set; }

		/// <summary>
		/// Gets or sets the KilosBrutosPesado value.
		/// </summary>
		public decimal KilosBrutosPesado
		{ get; set; }

		/// <summary>
		/// Gets or sets the TaraPesado value.
		/// </summary>
		public decimal TaraPesado
		{ get; set; }

		/// <summary>
		/// Gets or sets the KilosNetosPesado value.
		/// </summary>
		public decimal KilosNetosPesado
		{ get; set; }

		/// <summary>
		/// Gets or sets the DescuentoPorHumedad value.
		/// </summary>
		public decimal DescuentoPorHumedad
		{ get; set; }

		/// <summary>
		/// Gets or sets the KilosNetosDescontar value.
		/// </summary>
		public decimal KilosNetosDescontar
		{ get; set; }

		/// <summary>
		/// Gets or sets the KilosNetosPagar value.
		/// </summary>
		public decimal KilosNetosPagar
		{ get; set; }

		/// <summary>
		/// Gets or sets the QQ55 value.
		/// </summary>
		public decimal QQ55
		{ get; set; }

		/// <summary>
		/// Gets or sets the ExportableGramosAnalisisFisico value.
		/// </summary>
		public decimal ExportableGramosAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the DescarteGramosAnalisisFisico value.
		/// </summary>
		public decimal DescarteGramosAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the CascarillaGramosAnalisisFisico value.
		/// </summary>
		public decimal CascarillaGramosAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the TotalGramosAnalisisFisico value.
		/// </summary>
		public decimal TotalGramosAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the HumedadPorcentajeAnalisisFisico value.
		/// </summary>
		public decimal HumedadPorcentajeAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the TipoId value.
		/// </summary>
		public string TipoId
		{ get; set; }


		public string MonedaId
		{ get; set; }
		

		/// <summary>
		/// Gets or sets the PrecioDia value.
		/// </summary>
		public decimal? PrecioGuardado
		{ get; set; }

		public decimal? PrecioPagado
		{ get; set; }

		/// <summary>
		/// Gets or sets the Importe value.
		/// </summary>
		public decimal? Importe
		{ get; set; }
	

		/// <summary>
		/// Gets or sets the UsuarioRegistro value.
		/// </summary>
		public string UsuarioNotaCompra
		{ get; set; }

		public string Observaciones 
		{ get; set; }
        public int ValorId { get; set; }
    }
}
