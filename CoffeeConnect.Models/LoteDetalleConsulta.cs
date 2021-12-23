using System;

namespace CoffeeConnect.Models
{
    public class LoteDetalleConsulta
    {
        public int LoteDetalleId { get; set; }
        public int LoteId { get; set; }
        public String NumeroNotaIngresoAlmacen { get; set; }
        public DateTime FechaIngresoAlmacen { get; set; }
        public String AlmacenId { get; set; }
        public String Almacen { get; set; }
        public String TipoProvedorId { get; set; }
        public String TipoProvedor { get; set; }

        public String Certificadora { get; set; }

        
        public int ProveedorId { get; set; }
        public String CodigoSocio { get; set; }
        public String ProductoId { get; set; }
        public String Producto { get; set; }
        public String SubProductoId { get; set; }
        public String SubProducto { get; set; }
        public String UnidadMedidaIdPesado { get; set; }

        public String TipoDocumentoId { get; set; }

        public String TipoDocumento { get; set; }
        public String Socio { get; set; }
        public String UnidadMedida { get; set; }
        public Decimal CantidadPesado { get; set; }
        public Decimal KilosNetosPesado { get; set; }
        public Decimal RendimientoPorcentaje { get; set; }
        public Decimal HumedadPorcentaje { get; set; }
        public Decimal TotalAnalisisSensorial { get; set; }
        public decimal? KilosBrutosPesado { get; set; }

        public decimal? KilosNetosPagar { get; set; }

        
        public string TipoCertificacionId
        { get; set; }


        public string TipoCertificacion
        { get; set; }
    }
}
