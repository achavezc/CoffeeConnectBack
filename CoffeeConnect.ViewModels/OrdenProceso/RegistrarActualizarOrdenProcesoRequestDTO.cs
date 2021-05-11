using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class RegistrarActualizarOrdenProcesoRequestDTO
    {
        public int EmpresaId { get; set; }
        public int EmpresaProcesadoraId { get; set; }
        public int ContratoId { get; set; }
        public string Numero { get; set; }
        public decimal CantidadSacosUtilizar { get; set; }
        public decimal RendimientoEsperadoPorcentaje { get; set; }
        public DateTime FechaFinProceso { get; set; }
        public decimal CantidadContenedores { get; set; }
        public string TipoProcesoId { get; set; }
        public string NombreArchivo { get; set; }
        public string DescripcionArchivo { get; set; }
        public string PathArchivo { get; set; }
        public string EstadoId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
    }
}
