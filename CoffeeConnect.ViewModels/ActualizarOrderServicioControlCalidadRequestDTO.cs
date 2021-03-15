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
