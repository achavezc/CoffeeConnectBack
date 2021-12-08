using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Models.Kardex
{
    public class KardexPergaminoIngresoConsultaResponse
    {
        public DateTime FechaRegistro { get; set; }
        public string Numero { get; set; }
        public string ObservacionPesado { get; set; }
        public string NombreRazonSocial { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Zona { get; set; }
        public string Producto { get; set; }
        public string SubProducto { get; set; }
        public decimal CantidadPesado { get; set; }
        public decimal KilosBrutosPesado { get; set; }
        public decimal TaraPesado { get; set; }
        public decimal DescuentoPorHumedad { get; set; }
        public decimal KilosNetosPagar { get; set; }
        public decimal PrecioPagado { get; set; }
        public decimal Importe { get; set; }
        public decimal HumedadPorcentajeAnalisisFisico { get; set; }
        public decimal ExportablePorcentajeAnalisisFisico { get; set; }
        public decimal CalculoKilosNetosPagarPorHumedad { get; set; }
        public decimal CalculoKilosNetosPagarPorRendimiento { get; set; }

    }
}

