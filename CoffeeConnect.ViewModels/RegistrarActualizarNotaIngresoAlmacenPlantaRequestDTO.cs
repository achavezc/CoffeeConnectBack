using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
   public class RegistrarActualizarNotaIngresoAlmacenPlantaRequestDTO
	{

		
		/// <summary>
		/// Gets or sets the NotaIngresoAlmacenPlantaId value.
		/// </summary>
		public int NotaIngresoAlmacenPlantaId
		{ get; set; }

		public int ControlCalidadPlantaId
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
		/// Gets or sets the TipoProduccionId value.
		/// </summary>
		public string TipoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the ProductoId value.
		/// </summary>
		public string EmpaqueId
		{ get; set; }


		/// <summary>
		/// Gets or sets the CantidadPesado value.
		/// </summary>
		public decimal Cantidad
		{ get; set; }

		public decimal PesoBruto
		{ get; set; }

		public decimal Tara
		{ get; set; }

		public decimal KilosNetos
		{ get; set; }
		
		public String Usuario { get; set; }
        

     
    }
}
