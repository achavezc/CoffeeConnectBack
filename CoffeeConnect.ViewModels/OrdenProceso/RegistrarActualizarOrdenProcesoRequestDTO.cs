using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
    public class RegistrarActualizarOrdenProcesoRequestDTO
    {
        public int OrdenProcesoId { get; set; }
        public int EmpresaId { get; set; }
        public int EmpresaProcesadoraId { get; set; }
        public string TipoProcesoId { get; set; }
        public int ContratoId { get; set; }
        public string Numero { get; set; }
        public string Observacion { get; set; }
        public decimal RendimientoEsperadoPorcentaje { get; set; }
        public DateTime FechaFinProceso { get; set; }
        public decimal CantidadContenedores { get; set; }
        public string NombreArchivo { get; set; }
        public string DescripcionArchivo { get; set; }
        public string PathArchivo { get; set; }
        public string EstadoId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public List<OrdenProcesoDetalle> OrdenProcesoDetalle { get; set; }
    }
}
