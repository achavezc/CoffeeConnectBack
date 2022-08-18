using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
   public  class RegistrarActualizarEstadoControlCalidadPlantaRequestDTO
    {
		public int ControlCalidadPlantaId
		{
			get; set;
		}
		public int NotaIngresoPlantaId
		{ get; set; }
		public decimal CantidadProcesada
		{ get; set; }
		public string UsuarioUltimaActualizacion
		{ get; set; 
		
		}
		public decimal CantidadControlCalidad { get; set; }
		public decimal KilosNetosControlCalidad { get; set; }


	}
}

