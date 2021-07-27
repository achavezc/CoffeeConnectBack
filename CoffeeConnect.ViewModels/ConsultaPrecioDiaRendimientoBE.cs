using System;

namespace CoffeeConnect.Models
{
	public class ConsultaPrecioDiaRendimientoBE
	{
		#region Properties
		/// <summary>
		/// Gets or sets the ProductoPrecioDiaId value.
		/// </summary>
		
		/// <summary>
		/// Gets or sets the EmpresaId value.
		/// </summary>
		public int EmpresaId
		{ get; set; }

		public string MonedaId
		{ get; set; }
        public double TipoCambio { get; set; }
        public double PrecioPromedioContrato { get; set; }
        public double RendimientoInicio
		{ get; set; }

		public double RendimientoFin
		{ get; set; }


		public double Valor1
		{ get; set; }

		public double Valor2
		{ get; set; }

		public double Valor3
		{ get; set; }

		#endregion
	}
}
