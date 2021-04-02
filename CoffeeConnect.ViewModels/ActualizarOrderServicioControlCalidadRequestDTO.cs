using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
   public class ActualizarOrderServicioControlCalidadRequestDTO
	{
		/// <summary>
		/// Gets or sets the GuiaRecepcionMateriaPrimaId value.
		/// </summary>
		public int OrdenServicioControlCalidadId
		{ get; set; }

		

		public int EmpresaId
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

		public decimal TotalAnalisisSensorial
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

		public List<ActualizarNotaSalidaAlmacenAnalisisFisicoColorDetalleRequestDTO> AnalisisFisicoColorDetalleList { get; set; }

        public List<ActualizarNotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalleRequestDTO>  AnalisisFisicoDefectoPrimarioDetalleList{ get; set; }
		public List<ActualizarNotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetalleRequestDTO> AnalisisFisicoDefectoSecundarioDetalleList { get; set; }
		public List<ActualizarNotaSalidaAlmacenAnalisisFisicoOlorDetalleRequestDTO> AnalisisFisicoOlorDetalleList { get; set; }
		public List<ActualizarNotaSalidaAlmacenAnalisisSensorialAtributoDetalleRequestDTO> AnalisisSensorialAtributoDetalleList { get; set; }
		public List<ActualizarNotaSalidaAlmacenAnalisisSensorialDefectoDetalleRequestDTO> AnalisisSensorialDefectoDetalleList { get; set; }

		public List<ActualizarNotaSalidaAlmacenRegistroTostadoIndicadorDetalleRequestDTO> RegistroTostadoIndicadorDetalleList { get; set; }

		public ActualizarOrderServicioControlCalidadRequestDTO() {

			AnalisisFisicoColorDetalleList = new List<ActualizarNotaSalidaAlmacenAnalisisFisicoColorDetalleRequestDTO>();
			AnalisisFisicoDefectoPrimarioDetalleList = new List<ActualizarNotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalleRequestDTO>();
			AnalisisFisicoDefectoSecundarioDetalleList = new List<ActualizarNotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetalleRequestDTO>();
			AnalisisFisicoOlorDetalleList = new List<ActualizarNotaSalidaAlmacenAnalisisFisicoOlorDetalleRequestDTO>();
			AnalisisSensorialAtributoDetalleList = new List<ActualizarNotaSalidaAlmacenAnalisisSensorialAtributoDetalleRequestDTO>();
			AnalisisSensorialDefectoDetalleList = new List<ActualizarNotaSalidaAlmacenAnalisisSensorialDefectoDetalleRequestDTO>();
			RegistroTostadoIndicadorDetalleList = new List<ActualizarNotaSalidaAlmacenRegistroTostadoIndicadorDetalleRequestDTO>();

		}

	}
}
