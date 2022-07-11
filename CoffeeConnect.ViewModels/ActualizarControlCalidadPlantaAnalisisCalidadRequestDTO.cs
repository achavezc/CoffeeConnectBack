using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
   public  class ActualizarControlCalidadPlantaAnalisisCalidadRequestDTO
    {
		/// <summary>
		/// Gets or sets the GuiaRecepcionMateriaPrimaId value.
		/// </summary>
		public int NotaIngresoPlantaId
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

		public List<ActualizarNotaIngresoPlantaAnalisisFisicoColorDetalleRequestDTO> AnalisisFisicoColorDetalleList { get; set; }

		public List<ActualizarNotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetalleRequestDTO> AnalisisFisicoDefectoPrimarioDetalleList { get; set; }
		public List<ActualizarNotaIngresoPlantaAnalisisFisicoDefectoSecundarioDetalleRequestDTO> AnalisisFisicoDefectoSecundarioDetalleList { get; set; }
		public List<ActualizarNotaIngresoPlantaAnalisisFisicoOlorDetalleRequestDTO> AnalisisFisicoOlorDetalleList { get; set; }
		public List<ActualizarNotaIngresoPlantaAnalisisSensorialAtributoDetalleRequestDTO> AnalisisSensorialAtributoDetalleList { get; set; }
		public List<ActualizarNotaIngresoPlantaAnalisisSensorialDefectoDetalleRequestDTO> AnalisisSensorialDefectoDetalleList { get; set; }

		public List<ActualizarNotaIngresoPlantaRegistroTostadoIndicadorDetalleRequestDTO> RegistroTostadoIndicadorDetalleList { get; set; }
		public decimal TotalAnalisisSensorial { get; set; }
		public decimal Taza { get; set; }
		public decimal Intensidad { get; set; }
		public decimal TazaIntensidad { get; set; }
		public decimal PuntajeFinal { get; set; }


		public ActualizarControlCalidadPlantaAnalisisCalidadRequestDTO()
		{

			AnalisisFisicoColorDetalleList = new List<ActualizarNotaIngresoPlantaAnalisisFisicoColorDetalleRequestDTO>();
			AnalisisFisicoDefectoPrimarioDetalleList = new List<ActualizarNotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetalleRequestDTO>();
			AnalisisFisicoDefectoSecundarioDetalleList = new List<ActualizarNotaIngresoPlantaAnalisisFisicoDefectoSecundarioDetalleRequestDTO>();
			AnalisisFisicoOlorDetalleList = new List<ActualizarNotaIngresoPlantaAnalisisFisicoOlorDetalleRequestDTO>();
			AnalisisSensorialAtributoDetalleList = new List<ActualizarNotaIngresoPlantaAnalisisSensorialAtributoDetalleRequestDTO>();
			AnalisisSensorialDefectoDetalleList = new List<ActualizarNotaIngresoPlantaAnalisisSensorialDefectoDetalleRequestDTO>();
			RegistroTostadoIndicadorDetalleList = new List<ActualizarNotaIngresoPlantaRegistroTostadoIndicadorDetalleRequestDTO>();

		}
	}
}
