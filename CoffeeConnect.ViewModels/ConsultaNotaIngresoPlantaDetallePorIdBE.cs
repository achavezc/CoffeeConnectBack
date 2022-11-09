namespace CoffeeConnect.DTO
{
    public class ConsultaNotaIngresoPlantaDetallePorIdBE
    {

        public int NotaIngresoPlantaDetalleId { get; set; }

        /// <summary>
        /// Gets or sets the EmpresaId value.
        /// </summary>
        public int NotaIngresoPlantaId { get; set; }

        public string EmpaqueId { get; set; }

        public string Empaque { get; set; }

        public string TipoId { get; set; }

        public string Tipo { get; set; }

        public string SubProductoId { get; set; }

        public string SubProducto { get; set; }

        public decimal Cantidad { get; set; }

        public decimal KilosBrutos { get; set; }

        public decimal KilosNetos { get; set; }

        public decimal Tara { get; set; }


    }
}
