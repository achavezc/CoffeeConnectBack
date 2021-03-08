using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{   

    public class ConsultaLoteDetallePorLoteIdResponseDTO
    {
        public ConsultaLoteDetallePorLoteIdResponseDTO()
        {
            this.Result = new Result();
        }
        
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
		public Decimal? PromedioRendimientoPorcentaje { get; set; }
		public Decimal? PromedioHumedadPorcentaje { get; set; }
		public DateTime FechaRegistro { get; set; }
		public String UsuarioRegistro { get; set; }
		public DateTime? FechaUltimaActualizacion { get; set; }
		public String UsuarioUltimaActualizacion { get; set; }
		public bool Activo { get; set; }
		public Result Result { get; set; }
	}
}
