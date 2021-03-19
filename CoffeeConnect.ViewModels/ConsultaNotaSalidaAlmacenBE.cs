using System;

namespace CoffeeConnect.DTO
{
    public class ConsultaNotaSalidaAlmacenBE
    {
        public int NotaSalidaAlmacenId { get; set; }
        public String Numero { get; set; }
        public String AlmacenId { get; set; }
        public String Almacen { get; set; }
        public int EmpresaIdDestino { get; set; }
        public String Destinatario { get; set; }
        public int MotivoTrasladoId { get; set; }
        public String Motivo { get; set; }
        public int EmpresaTransporteId { get; set; }
        public String Transportista { get; set; }
        public decimal? CantidadLotes { get; set; }
        public decimal? PesoKilosBrutos { get; set; }

        public String EstadoId { get; set; }
        public String Estado { get; set; }
    }
}
