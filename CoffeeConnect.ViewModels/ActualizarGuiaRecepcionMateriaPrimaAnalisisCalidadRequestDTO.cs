using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
   public class ActualizarGuiaRecepcionMateriaPrimaAnalisisCalidadRequestDTO
	{
		/// <summary>
		/// Gets or sets the GuiaRecepcionMateriaPrimaId value.
		/// </summary>
		public int GuiaRecepcionMateriaPrimaId
		{ get; set; }

		
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
		/// Gets or sets the HumedadPorcentajeAnalisisFisico value.
		/// </summary>
		public decimal HumedadPorcentajeAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the ObservacionAnalisisFisico value.
		/// </summary>
		public string ObservacionAnalisisFisico
		{ get; set; }

		
		/// <summary>
		/// Gets or sets the UsuarioCalidad value.
		/// </summary>
		public string UsuarioCalidad
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

        public List<ActualizarGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleRequestDTO> AnalisisFisicoColorDetalleList { get; set; }

        public List<ActualizarGuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetalleRequestDTO>  AnalisisFisicoDefectoPrimarioDetalleList{ get; set; }
		public List<ActualizarGuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetalleRequestDTO> AnalisisFisicoDefectoSecundarioDetalleList { get; set; }
		public List<ActualizarGuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalleRequestDTO> AnalisisFisicoOlorDetalleList { get; set; }
		public List<ActualizarGuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalleRequestDTO> AnalisisSensorialAtributoDetalleList { get; set; }
		public List<ActualizarGuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetalleRequestDTO> RegistroTostadoIndicadorDetalleList { get; set; }

		public ActualizarGuiaRecepcionMateriaPrimaAnalisisCalidadRequestDTO() {

			AnalisisFisicoColorDetalleList = new List<ActualizarGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleRequestDTO>();
			AnalisisFisicoDefectoPrimarioDetalleList = new List<ActualizarGuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetalleRequestDTO>();
			AnalisisFisicoDefectoSecundarioDetalleList = new List<ActualizarGuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetalleRequestDTO>();
			AnalisisFisicoOlorDetalleList = new List<ActualizarGuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalleRequestDTO>();
			AnalisisSensorialAtributoDetalleList = new List<ActualizarGuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalleRequestDTO>();
			RegistroTostadoIndicadorDetalleList = new List<ActualizarGuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetalleRequestDTO>();

		}

	}
}
