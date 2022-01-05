using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Models.Kardex
{
    public class KardexPergaminoSalidaConsultaResponse
    {
        public string NumeroGuiaRemision { get; set; }
        public DateTime FechaGuiaRemision { get; set; }
        public decimal CalculoKilosNetosPagarPorHumedad { get; set; }
        public decimal CalculoKilosNetosPagarPorRendimiento { get; set; }
        public decimal Cantidad { get; set; }
        public decimal TotalKilosBrutosPesado { get; set; }
        public decimal Tara { get; set; }
        public decimal TotalKilosNetosPesado { get; set; }
        public decimal TotalKilosNetosDescontar { get; set; }
        
        public decimal HumedadPorcentajeAnalisisFisico { get; set; }
        public decimal RendimientoPorcentaje { get; set; }
    }
}
