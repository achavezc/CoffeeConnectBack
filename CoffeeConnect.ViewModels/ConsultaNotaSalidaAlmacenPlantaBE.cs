using System;

namespace CoffeeConnect.DTO
{
    public class ConsultaNotaSalidaAlmacenPlantaBE
    {
        public int NotaSalidaAlmacenPlantaId { get; set; }
        public String Numero { get; set; }
        public String AlmacenId { get; set; }
        public String Almacen { get; set; }
        public int EmpresaIdDestino { get; set; }
        public String Destinatario { get; set; }
        public int MotivoSalidaId { get; set; }
        public String Motivo { get; set; }
        public int EmpresaTransporteId { get; set; }
        public String Transportista { get; set; }
        public decimal? CantidadTotal { get; set; }
        public decimal? PesoKilosBrutos { get; set; }

        public decimal? PesoKilosNetos { get; set; }

        public String EstadoId { get; set; }
        public String Estado { get; set; }
    }
}
